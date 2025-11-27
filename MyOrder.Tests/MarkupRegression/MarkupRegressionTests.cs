using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Tests.MarkupRegression
{
    public class MarkupRegressionTests : IClassFixture<PlaywrightFixture>
    {
        private readonly PlaywrightFixture _fixture;
        private readonly string imagePath;
        private readonly string projectRoot;
        public MarkupRegressionTests(PlaywrightFixture fixture)
        {
            _fixture = fixture;
            projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            imagePath = Path.Combine(projectRoot, "MarkupRegression", "Snapshots");

            Directory.CreateDirectory(imagePath);
        }


        [Fact]
        public async Task HtmlSnapshot_EditBasket_Test()
        {           
            var context = await _fixture._browser.NewContextAsync(new BrowserNewContextOptions
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

            await Verify(html, "html", settings);

        }

        [Theory]
        [InlineData("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946", "EditBasket")]
        [InlineData("https://localhost:7017/Raja-fr/AnotherPage", "AnotherPage")]
        public async Task Verify_PageDomContract(string url, string snapshotName)
        {
            var context = await _fixture._browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1600, Height = 1200 }
            });

            var page = await context.NewPageAsync();

            await page.GotoAsync(url);
            await page.WaitForSelectorAsync("body");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForTimeoutAsync(1000);

            var htmlPage = await page.ContentAsync();

            var settings = new VerifySettings();
            settings.UseDirectory(imagePath);
            settings.UseFileName(snapshotName);

            await Verify(htmlPage, "html", settings);
        }

        //[Fact]
        //public async Task HtmlSnapshot_EditBasket_Test()
        //{
        //    var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        //    var imagePath = Path.Combine(projectRoot, "MarkupRegression", "Snapshots");

        //    Directory.CreateDirectory(imagePath);

        //    using var playwright = await Playwright.CreateAsync();
        //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //    {
        //        Headless = true
        //    });
        //    var context = await browser.NewContextAsync(new BrowserNewContextOptions
        //    {
        //        ViewportSize = new ViewportSize
        //        {
        //            Width = 1600,
        //            Height = 1200
        //        }
        //    });

        //    var page = await context.NewPageAsync();

        //    await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946");

        //    // Wait for the page to fully load and initialize
        //    await page.WaitForSelectorAsync("body");
        //    //await page.WaitForSelectorAsync("script[src*='blazor.server.js']");
        //    await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        //    await page.WaitForTimeoutAsync(1000);

        //    // Get the full HTML content
        //    var html = await page.ContentAsync();
        //    //
        //    var settings = new VerifySettings();
        //    settings.UseDirectory(imagePath);
        //    settings.UseFileName($"EditBasket");

        //    await Verify(html, "html", settings);

        //}

    }
}
