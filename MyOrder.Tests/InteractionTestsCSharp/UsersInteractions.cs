using Microsoft.Playwright;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MyOrder.Tests.InteractionTestsCSharp;
public class UsersInteractions
{
    public static async Task Main()
    {
        // ======== CONFIG ========
        var baseUrl = Env("BASE_URL", "https://localhost:7017");
        // Number of virtual users
        int vus = Int("VUS", 100);

        // Test duration in seconds
        int durationS = Int("DURATION_SEC", 300);

        // Ramp-up duration in seconds
        int rampSec = Int("RAMP_SEC", 15);

        // Think time between actions in milliseconds
        int thinkMin = Int("THINK_MS_MIN", 50);
        int thinkMax = Int("THINK_MS_MAX", 400);

        int? appPid = NullableInt("APP_PID");
        string? appProcName = Environment.GetEnvironmentVariable("APP_PROC_NAME");

        var routes = Env("ROUTES", "/,/Raja-fr/EditBasket?BasketId=P0152946")
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        // ======== STATE ========
        var errors = new ConcurrentBag<string>();
        var http4xx5xx = new ConcurrentDictionary<int, int>();
        var requestFails = new ConcurrentDictionary<string, int>();
        var consoleErrors = new ConcurrentBag<string>();
        var pageErrors = new ConcurrentBag<string>();
        var actionLog = new ConcurrentQueue<string>();

        var resourceSamples = new List<ResourceSample>(capacity: durationS + 60);
        var resourceLock = new object();
        var startedAt = DateTime.UtcNow;

        // ======== PLAYWRIGHT SETUP ========
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(durationS + rampSec + 30));
        var pw = await Playwright.CreateAsync();
        var browser = await pw.Chromium.LaunchAsync(new()
        {
            Headless = true,
            Args = new[] { "--no-sandbox", "--disable-dev-shm-usage" }
        });

        // ======== RESOURCE SAMPLER ========
        Process? targetProcess = null;
        if (appPid.HasValue)
            targetProcess = Process.GetProcessById(appPid.Value);
        else if (!string.IsNullOrWhiteSpace(appProcName))
            targetProcess = Process.GetProcessesByName(appProcName).OrderByDescending(p => p.StartTime).FirstOrDefault();

        var samplerTask = targetProcess != null
            ? Task.Run(async () =>
            {
                var lastCpu = targetProcess.TotalProcessorTime;
                var lastWall = Stopwatch.GetTimestamp();
                double ticksPerSec = Stopwatch.Frequency;

                while (!cts.IsCancellationRequested)
                {
                    await Task.Delay(1000, cts.Token).ConfigureAwait(false);
                    try
                    {
                        targetProcess.Refresh();
                        var nowCpu = targetProcess.TotalProcessorTime;
                        var nowWall = Stopwatch.GetTimestamp();

                        var cpuDelta = (nowCpu - lastCpu).TotalMilliseconds;
                        var wallDeltaMs = (nowWall - lastWall) * 1000.0 / ticksPerSec;
                        lastCpu = nowCpu;
                        lastWall = nowWall;

                        var cpuPct = Math.Max(0, Math.Min(100 * cpuDelta / (wallDeltaMs * Environment.ProcessorCount), 100));
                        var wsMb = targetProcess.WorkingSet64 / (1024.0 * 1024.0);

                        lock (resourceLock)
                        {
                            resourceSamples.Add(new ResourceSample
                            {
                                Ts = DateTime.UtcNow,
                                CpuPct = cpuPct,
                                WorkingSetMb = wsMb
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Sampler: " + ex.Message);
                    }
                }
            }, cts.Token)
            : Task.CompletedTask;

        // ======== USER SIMULATION ========
        var tasks = Enumerable.Range(0, vus).Select(async vu =>
        {
            try
            {
                await Task.Delay((int)(vu * (rampSec * 1000.0 / Math.Max(1, vus))), cts.Token).ConfigureAwait(false);
                await using var ctx = await browser.NewContextAsync(new() { BaseURL = baseUrl, IgnoreHTTPSErrors = true });
                var page = await ctx.NewPageAsync();

                // Capture errors and telemetry
                page.Console += (_, msg) =>
                {
                    if (msg.Type == "error" || msg.Type == "warning")
                    {
                        var line = JsonSerializer.Serialize(new { t = Now(), vu, kind = "console", level = msg.Type, text = msg.Text });
                        consoleErrors.Add($"{msg.Type}: {msg.Text}");
                        actionLog.Enqueue(line);
                    }
                };
                page.PageError += (_, err) =>
                {
                    var line = JsonSerializer.Serialize(new { t = Now(), vu, kind = "pageerror", text = err });
                    pageErrors.Add(err);
                    actionLog.Enqueue(line);
                };
                page.RequestFailed += (_, req) =>
                {
                    var key = SafeUrl(req.Url);
                    requestFails.AddOrUpdate(key, 1, (_, c) => c + 1);
                    var line = JsonSerializer.Serialize(new { t = Now(), vu, kind = "requestFailed", url = key, method = req.Method, failure = req.Failure });
                    actionLog.Enqueue(line);
                };
                page.Response += async (_, resp) =>
                {
                    try
                    {
                        var status = resp.Status;
                        if (status >= 400)
                        {
                            http4xx5xx.AddOrUpdate(status, 1, (_, c) => c + 1);
                            var key = SafeUrl(resp.Url);
                            var line = JsonSerializer.Serialize(new { t = Now(), vu, kind = "http", status, url = key });
                            actionLog.Enqueue(line);
                        }
                    }
                    catch { }
                };

                await page.GotoAsync("/", new() { WaitUntil = WaitUntilState.DOMContentLoaded }).ConfigureAwait(false);

                var rnd = new Random(Guid.NewGuid().GetHashCode());
                var until = DateTime.UtcNow.AddSeconds(durationS);

                while (DateTime.UtcNow < until && !cts.Token.IsCancellationRequested)
                {
                    var action = await RandomAction(page, rnd, routes, cts.Token).ConfigureAwait(false);
                    actionLog.Enqueue(JsonSerializer.Serialize(new { t = Now(), vu, kind = "action", action }));
                    await Task.Delay(rnd.Next(thinkMin, thinkMax), cts.Token).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                errors.Add($"{ex.GetType().Name}: {ex.Message}");
            }
        });

        await Task.WhenAll(tasks);
        cts.Cancel();
        await samplerTask;

        await browser.CloseAsync();
        pw.Dispose();

        // ======== REPORT GENERATION ========
        var endedAt = DateTime.UtcNow;
        var dur = (endedAt - startedAt).TotalSeconds;

        var summary = new RunSummary
        {
            BaseUrl = baseUrl,
            Users = vus,
            DurationSec = durationS,
            StartedUtc = startedAt,
            EndedUtc = endedAt,
            Errors = errors.GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count()),
            ConsoleErrors = consoleErrors.GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count()),
            PageErrors = pageErrors.GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count()),
            Http4xx5xx = http4xx5xx.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key.ToString(), kv => kv.Value),
            RequestFailuresTop = requestFails.OrderByDescending(kv => kv.Value).Take(20)
                .ToDictionary(kv => kv.Key, kv => kv.Value),
            ResourceStats = ComputeStats(resourceSamples)
        };

        var reportJson = JsonSerializer.Serialize(summary, new JsonSerializerOptions { WriteIndented = true });
        System.IO.Directory.CreateDirectory("artifacts");
        await System.IO.File.WriteAllTextAsync("artifacts/monkey-report.json", reportJson);
        await System.IO.File.WriteAllLinesAsync("artifacts/monkey-actions.ndjson", actionLog);

        Console.WriteLine("==== MONKEY REPORT ====");
        Console.WriteLine($"Target: {baseUrl}   Users: {vus}   Duration: {durationS}s   Ran: {dur:F1}s");
        if (summary.ResourceStats != null)
        {
            Console.WriteLine($"CPU%  min/avg/max: {summary.ResourceStats.CpuMin:F1} / {summary.ResourceStats.CpuAvg:F1} / {summary.ResourceStats.CpuMax:F1}");
            Console.WriteLine($"WSMB  min/avg/max: {summary.ResourceStats.WsMin:F1} / {summary.ResourceStats.WsAvg:F1} / {summary.ResourceStats.WsMax:F1}");
        }
        Console.WriteLine($"PageErrors: {summary.PageErrors.Values.Sum()}  ConsoleErrors: {summary.ConsoleErrors.Values.Sum()}  RequestFailed: {requestFails.Values.Sum()}");
        Console.WriteLine("HTTP 4xx/5xx:");
        foreach (var kv in summary.Http4xx5xx) Console.WriteLine($"  {kv.Key}: {kv.Value}");
        Console.WriteLine("Top failed URLs:");
        foreach (var kv in summary.RequestFailuresTop) Console.WriteLine($"  {kv.Key}  x{kv.Value}");
        Console.WriteLine("Artifacts written:");
        Console.WriteLine("  artifacts/monkey-report.json");
        Console.WriteLine("  artifacts/monkey-actions.ndjson");
    }

    // ======== HELPERS ========
    static string Env(string k, string d) => Environment.GetEnvironmentVariable(k) ?? d;
    static int Int(string k, int d) => int.TryParse(Environment.GetEnvironmentVariable(k), out var v) ? v : d;
    static int? NullableInt(string k) => int.TryParse(Environment.GetEnvironmentVariable(k), out var v) ? v : null;
    static string Now() => DateTime.UtcNow.ToString("O");
    static string SafeUrl(string url)
    {
        try
        {
            var u = new Uri(url);
            return u.GetLeftPart(UriPartial.Path);
        }
        catch { return url; }
    }

    static ResourceStats? ComputeStats(List<ResourceSample> samples)
    {
        if (samples.Count == 0) return null;
        var cpu = samples.Select(s => s.CpuPct).ToArray();
        var ws = samples.Select(s => s.WorkingSetMb).ToArray();
        return new ResourceStats
        {
            CpuMin = cpu.Min(),
            CpuMax = cpu.Max(),
            CpuAvg = cpu.Average(),
            WsMin = ws.Min(),
            WsMax = ws.Max(),
            WsAvg = ws.Average(),
            Samples = samples.Count
        };
    }

    // Random user interaction method
    static async Task<object> RandomAction(IPage page, Random rnd, string[] routes, CancellationToken ct)
    {
        if (rnd.NextDouble() < 0.10)
        {
            var target = routes[rnd.Next(routes.Length)];
            await page.GotoAsync(target, new() { WaitUntil = WaitUntilState.DOMContentLoaded });
            return new { kind = "nav", target };
        }

        var visible = page.Locator(":visible").Filter(new() { HasNot = page.Locator("[disabled], [aria-disabled='true']") });
        var p = rnd.NextDouble();

        if (p < 0.5)
        {
            var clickables = visible.Locator("button, [role='button'], a, input[type='button'], input[type='submit']");
            var n = await clickables.CountAsync();
            if (n > 0)
            {
                var idx = rnd.Next(n);
                await clickables.Nth(idx).ClickAsync();
                return new { kind = "click", idx, count = n };
            }
        }
        else if (p < 0.85)
        {
            var inputs = visible.Locator("input:not([type='hidden']), textarea, [contenteditable=''], [role='textbox']");
            var n = await inputs.CountAsync();
            if (n > 0)
            {
                var idx = rnd.Next(n);
                var el = inputs.Nth(idx);
                await el.ClickAsync();
                var text = RandomWord(rnd);
                await el.FillAsync(text);
                if (rnd.NextDouble() < 0.3) await el.PressAsync("Enter");
                return new { kind = "type", idx, text };
            }
        }
        else
        {
            var delta = rnd.Next(-1500, 1500);
            await page.Mouse.WheelAsync(0, delta);
            return new { kind = "scroll", delta };
        }

        return new { kind = "idle" };
    }

    static string RandomWord(Random r)
    {
        string[] words = { "test", "ibuprofen", "search", "hello", "xyz", "123", "€" };
        return words[r.Next(words.Length)];
    }

    // Data records
    record ResourceSample
    {
        public DateTime Ts { get; init; }
        public double CpuPct { get; init; }
        public double WorkingSetMb { get; init; }
    }
    record ResourceStats
    {
        public double CpuMin { get; init; }
        public double CpuMax { get; init; }
        public double CpuAvg { get; init; }
        public double WsMin { get; init; }
        public double WsMax { get; init; }
        public double WsAvg { get; init; }
        public int Samples { get; init; }
    }
    record RunSummary
    {
        public string BaseUrl { get; init; } = "";
        public int Users { get; init; }
        public int DurationSec { get; init; }
        public DateTime StartedUtc { get; init; }
        public DateTime EndedUtc { get; init; }
        public Dictionary<string, int> Errors { get; init; } = new();
        public Dictionary<string, int> ConsoleErrors { get; init; } = new();
        public Dictionary<string, int> PageErrors { get; init; } = new();
        public Dictionary<string, int> Http4xx5xx { get; init; } = new();
        public Dictionary<string, int> RequestFailuresTop { get; init; } = new();
        public ResourceStats? ResourceStats { get; init; }
    }
}

