using Bunit;
using ImageMagick;
using Microsoft.Playwright;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Xunit.Abstractions;

namespace MyOrder.Tests.VisualTesting;


public class DialogueVisualTests : TestContext
{

    private readonly ITestOutputHelper _output;
    [Fact]
    public async Task Dialog_Should_Render_Correctly()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946");

        // Open AddLine dialogue dialog
        await page.ClickAsync("#AddlineDialogue"); // target it by Id
        var element = await page.WaitForSelectorAsync(".mud-dialog"); // wait until dialog is rendered

        var dialogScreenshot = await element.ScreenshotAsync( new ElementHandleScreenshotOptions
        {
            Type = ScreenshotType.Png
        });



        //// Compare against baseline
        //await Verifier.Verify(dialogScreenshot).UseFileName("Dialog");


        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        var imagePath = Path.Combine(projectRoot, "VisualTesting", "Snapshots");

        var todayFolder = Path.Combine(imagePath, DateTime.Now.ToString("yyyy-MM-dd"));

        // Ensure directories exist
        Directory.CreateDirectory(imagePath);
        Directory.CreateDirectory(todayFolder);

        // Timestamp for filenames (HH-mm-ss)
        var timestamp = DateTime.Now.ToString("HH-mm-ss");


        //var settings = new VerifySettings();
        //settings.UseDirectory(imagePath);
        //settings.UseFileName("Dialog");
        Directory.CreateDirectory(imagePath);

        var currentFile = Path.Combine(imagePath, todayFolder, $"Dialog.current.{timestamp}.png");
        var baselineFile = Path.Combine(imagePath, "Dialog.baseline.png");
        var diffFile = Path.Combine(imagePath, todayFolder, $"Dialog.diff.{timestamp}.png");

        // Save current screenshot
        await File.WriteAllBytesAsync(currentFile, dialogScreenshot);

        if (File.Exists(baselineFile))
        {
            var baselineBytes = await File.ReadAllBytesAsync(baselineFile);

            if (baselineBytes.SequenceEqual(dialogScreenshot))
            {
                File.Delete(currentFile); // Clean up
                return;
            }
            else
            {
                // Screenshots don't match - create diff
                await CreateVisualDiff(baselineFile, currentFile, diffFile);

                // Test fails with helpful message
                Assert.True(false, $"Visual regression detected!\nBaseline: {baselineFile}\nCurrent: {currentFile}\nDiff: {diffFile}");
            }
        }
        else
        {
            // First run - create baseline
            File.Move(currentFile, baselineFile);
            
        }
    }

    private async Task CreateVisualDiff(string baselinePath, string currentPath, string diffPath)
    {
        using var imageA = new MagickImage(baselinePath);
        using var imageB = new MagickImage(currentPath);

        // The correct overload is: Compare(IMagickImage image, ErrorMetric metric, out double distortion)
        double distortion;
        using var diff = imageA.Compare(imageB, ErrorMetric.RootMeanSquared, out distortion);
        diff.Write(diffPath);


    }


    private async Task CompareImagesPixelByPixel(string baselinePath, string currentPath, string diffPath)
    {
        // Load the images
        using var baseline = Image.Load<Rgba32>(baselinePath);
        using var current = Image.Load<Rgba32>(currentPath);

        // Check if dimensions match
        if (baseline.Width != current.Width || baseline.Height != current.Height)
        {
            _output.WriteLine("Image sizes differ.");
            return; // Images are not the same size
        }


        // Compare pixel by pixel

        using var diff = new Image<Rgba32>(baseline.Width, baseline.Height);

        for (int y = 0; y < baseline.Height; y++)
        {
            for (int x = 0; x < baseline.Width; x++)
            {
                var baselinePixel = baseline[x, y];
                var currentPixel = current[x, y];

                if (baselinePixel != currentPixel)
                {              
                    // Save the diff image
                   // _output.WriteLine($"Difference at ({x}, {y})");
                    diff[x, y] = new Rgba32(255, 0, 0); // Red pixel for difference
                    diff.Save(diffPath);
                }
                else
                {
                    diff[x, y] = baselinePixel;
                }
            }
        }

       await diff.SaveAsPngAsync(diffPath);

    }

    /////////////////////////////////////////////////////////////////////////////////
    ///


    [Fact]
    public async Task AllDialogs_Should_Render_Correctly()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946");

        // Find all buttons that open dialogs
        var dialogButtons = await page.QuerySelectorAllAsync("[data-dialog]");

        Assert.NotEmpty(dialogButtons); // sanity check

        foreach (var button in dialogButtons)
        {
            var dialogName = await button.GetAttributeAsync("data-dialog");
            Console.WriteLine($"Testing dialog: {dialogName}");

            await button.ClickAsync();

            // Wait for the dialog to appear
            var dialog = await page.WaitForSelectorAsync(".mud-dialog", new PageWaitForSelectorOptions
            {
                Timeout = 5000
            });

            // Screenshot of the dialog
            var screenshot = await dialog.ScreenshotAsync(new ElementHandleScreenshotOptions
            {
                Type = ScreenshotType.Png
            });

            // Paths
            var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            var imagePath = Path.Combine(projectRoot, "VisualTesting");
            Directory.CreateDirectory(imagePath);

            var baseName = SanitizeFileName(dialogName ?? "Dialog");
            var baseline = Path.Combine(imagePath, $"{baseName}.baseline.png");
            var current = Path.Combine(imagePath, $"{baseName}.current.png");
            var diff = Path.Combine(imagePath, $"{baseName}.diff.png");

            await File.WriteAllBytesAsync(current, screenshot);

            if (File.Exists(baseline))
            {
                var baselineBytes = await File.ReadAllBytesAsync(baseline);
                if (!baselineBytes.SequenceEqual(screenshot))
                {
                    await CreateVisualDiff2(baseline, current, diff);
                    Assert.True(false, $"Visual regression detected for {dialogName}.\nDiff: {diff}");
                }
                else
                {
                    File.Delete(current);
                }
            }
            else
            {
                File.Move(current, baseline);
                Console.WriteLine($"Baseline created for {dialogName}");
            }

            // Close the dialog before testing the next one
            await page.Keyboard.PressAsync("Escape");
            await page.WaitForSelectorAsync(".mud-dialog", new() { State = WaitForSelectorState.Detached });
        }
    }

    private static string SanitizeFileName(string name)
    {
        foreach (var c in Path.GetInvalidFileNameChars())
            name = name.Replace(c, '_');
        return name;
    }

    private async Task CreateVisualDiff2(string baselinePath, string currentPath, string diffPath)
    {
        using var imageA = new ImageMagick.MagickImage(baselinePath);
        using var imageB = new ImageMagick.MagickImage(currentPath);

        double distortion;
        using var diff = imageA.Compare(imageB, ImageMagick.ErrorMetric.RootMeanSquared, out distortion);
        diff.Write(diffPath);
    }


}
