using Microsoft.Playwright;


namespace MyOrder.Tests.VisualTesting;

public class PlaywrightVisualTests
{
    [Fact]
    public async Task Verify_MainLayout_With_EditBaskete()
    {
        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        var imagePath = Path.Combine(projectRoot, "VisualTesting", "Snapshots");

        Directory.CreateDirectory(imagePath);

        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });
        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1600,
                Height = 1200
            }
        });

        var page = await context.NewPageAsync();

        await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946");

        // Wait for the page to fully load and initialize
        await page.WaitForSelectorAsync("body");
        //await page.WaitForSelectorAsync("script[src*='blazor.server.js']");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await page.WaitForTimeoutAsync(1000);

        // Get the full HTML content
        var html = await page.ContentAsync();
        //
        var settings = new VerifySettings();
        settings.UseDirectory(imagePath);
        settings.UseFileName($"EditBasket");

        await Verify(html,"html", settings);

    }


}
