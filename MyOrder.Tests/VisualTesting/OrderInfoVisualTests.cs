using Bunit;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using Moq;
using MudBlazor.Services;
using MyOrder.Components;
using MyOrder.Components.Childs.Header;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.LinesUseCase;
using MyOrder.Store.OrderInfoUseCase;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Reflection.PortableExecutable;
using VerifyTests;
using VerifyTests.Playwright;
using VerifyXunit;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MyOrder.Tests.VisualTesting;

public class OrderInfoVisualTests : TestContext
{

    private IBrowser _browser;
    private readonly ITestOutputHelper _output;

    public OrderInfoVisualTests(ITestOutputHelper output)
    {
        _output = output;
    }
    //public async Task InitializeAsync()
    //{
    //    var playwright = await Playwright.CreateAsync();
    //    _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //    {
    //        Headless = true
    //    });
    //}

    public Task DisposeAsync()
    {
        return _browser.CloseAsync() ?? Task.CompletedTask;
    }




    [Fact]
    public async Task TakeScreenshotOfOrderInfo()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // To show the browser window during the test
        });

        var page = await browser.NewPageAsync(new BrowserNewPageOptions
        {
            ViewportSize = new ViewportSize { Width = 1600, Height = 1200 }
        });
        
        await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
     
        await Task.Delay(3000); // 3 seconds


        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        var testName = "OrderInfo";
       
        var baselineImagePath = Path.Combine(projectRoot, "VisualTesting", "BaselineImages", $"{testName}.png");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {

            Path = baselineImagePath,
            FullPage = true
        });
    }

    [Fact]
    public async Task ScreenShot_ShouldNotVisuallyRegress()
    {
        await TakeScreenshot("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946", "CurrentImages");

        // The output paths

        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        var actualScreenName = "OrderInfo";
        //var baseScreenName = "OrderInfoModified";
        var baseScreenName = "OrderInfo";
        var diffScreenName = "diff";

        var currentImagePath = Path.Combine(projectRoot, "VisualTesting", "CurrentImages", $"{actualScreenName}.png");
        var baselineImagePath = Path.Combine(projectRoot, "VisualTesting", "BaselineImages", $"{baseScreenName}.png");
        var diffImagePath = Path.Combine(projectRoot, "VisualTesting", "DiffImages", $"{diffScreenName}_diff.png");

        if (!File.Exists(baselineImagePath))
        {
            return;
        }

        var areEqual = CompareImagesPixelByPixel(baselineImagePath, currentImagePath, diffImagePath);
        _output.WriteLine($"Visual regression test result: {areEqual}");
        Assert.True(areEqual, $"Visual regression detected! See diff image at {diffImagePath}");
    }




    [Fact]
    public async Task OrerInfo_ShouldNotVisuallyRegress()
    {
        var mockedModalService = new Mock<IModalService>();
        var mockedBasketService = new Mock<IBasketService>();
        var mockedTradInfo = new Mock<ITradeInfoRepository>();
        var mockedBasketResourcesRepository = new Mock<IBasketResourcesRepository>();
        var mockedBasketActionsRepository = new Mock<IBasketActionsRepository>();
        var mockedStateResolver = new Mock<IStateResolver>();
        var mockedToastService = new Mock<IToastService>();
        var mockedIPricesInfoRepository = new Mock<IPricesInfoRepository>();
        var mockedIOrderInfoRepository = new Mock<IOrderInfoRepository>();
        var mockedIGeneralInfoRepository = new Mock<IGeneralInfoRepository>();

        var mockedINewOrderLineRepository = new Mock<INewOrderLineRepository>();
        var mockedIOrderLinesRepository = new Mock<IOrderLinesRepository>();
        var mockedIInvoiceInfoRepository = new Mock<IInvoiceInfoRepository>();
        var mockedIDeliveryInfoRepository = new Mock<IDeliveryInfoRepository>();
        var mockedIUrlService = new Mock<IUrlService>();
        var mockedIBasketItemsRepository = new Mock<IBasketItemsRepository>();
        

        var mockedOrderInfoState = new Mock<IState<OrderInfoState>>();
        mockedOrderInfoState.SetupGet(x => x.Value).Returns(new OrderInfoState());
        var mockedDispatcher = new Mock<IDispatcher>();


        using var ctx = new TestContext();
        ctx.Services.AddMudServices();

        ctx.Services.AddScoped<INewOrderLineRepository>(p => mockedINewOrderLineRepository.Object);
        ctx.Services.AddScoped<IOrderLinesRepository>(p => mockedIOrderLinesRepository.Object);
        ctx.Services.AddScoped<IInvoiceInfoRepository>(p => mockedIInvoiceInfoRepository.Object);
        ctx.Services.AddScoped<AppFaultedTicket>();
        ctx.Services.AddScoped<IDeliveryInfoRepository>(p => mockedIDeliveryInfoRepository.Object);
        ctx.Services.AddScoped<IUrlService>(p => mockedIUrlService.Object);
        ctx.Services.AddScoped<IBasketItemsRepository>(p => mockedIBasketItemsRepository.Object);
        


        ctx.Services.AddScoped<IState<OrderInfoState>>(provider => mockedOrderInfoState.Object);
        ctx.Services.AddScoped<IModalService>(p => mockedModalService.Object);
        ctx.Services.AddScoped<IBasketService>(p => mockedBasketService.Object);
        ctx.Services.AddScoped<ITradeInfoRepository>(p => mockedTradInfo.Object);
        ctx.Services.AddScoped<IBasketResourcesRepository>(p => mockedBasketResourcesRepository.Object);
        ctx.Services.AddScoped<IBasketActionsRepository>(p => mockedBasketActionsRepository.Object);
        ctx.Services.AddScoped<IStateResolver>(p => mockedStateResolver.Object);
        ctx.Services.AddScoped<IToastService>(p => mockedToastService.Object);
        ctx.Services.AddScoped<IPricesInfoRepository>(p => mockedIPricesInfoRepository.Object);
        ctx.Services.AddScoped<IOrderInfoRepository>(p => mockedIOrderInfoRepository.Object);
        ctx.Services.AddScoped<IGeneralInfoRepository>(p => mockedIGeneralInfoRepository.Object);


        ctx.Services.AddScoped<IDispatcher>(provider => mockedDispatcher.Object);
        ctx.Services.AddFluxor(opt => opt.ScanAssemblies(typeof(OrderInfo).Assembly));

        var rendered = ctx.RenderComponent<OrderInfo>();
        var html = rendered.Markup;

        // The output paths

        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        var testName = "OrderInfo";

        var currentImagePath = Path.Combine(projectRoot, "VisualTesting", "CurrentImages", $"{testName}.png");
        var baselineImagePath = Path.Combine(projectRoot, "VisualTesting", "BaselineImages", $"{testName}.png");
        var diffImagePath = Path.Combine(projectRoot, "VisualTesting", "DiffImages", $"{testName}_diff.png");

        var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

        // Use Playwright to take a screenshot of the rendered component
        var page = await _browser.NewPageAsync(new BrowserNewPageOptions
        {
            ViewportSize = new ViewportSize { Width = 1600, Height = 1200 }
        });

        await page.SetContentAsync(html);// look to chatgpt code
        var screenshot = await page.ScreenshotAsync(new PageScreenshotOptions
        {
            FullPage = true,
            Path = currentImagePath
        });

        if (!File.Exists(baselineImagePath))
        {
            //await File.WriteAllBytesAsync(baselineImagePath, screenshot);
            //Assert.True(true, "Baseline image created successfully.");
            //return;
            
            File.Copy(currentImagePath, baselineImagePath);
            return;
        }

        // Compare the current screenshot with the baseline image
        //var diffResult = await Verify(screenshot)
        //    .UseFileName(testName)
        //    .UseDirectory("VisualTesting/DiffImages")
        //    .UseExtension("png")
        //    .UseMethodName("OrderInfo_ShouldNotVisuallyRegress")
        //    .AddScrubber();

        var areEqual = CompareImagesPixelByPixel(baselineImagePath, currentImagePath, diffImagePath);
        _output.WriteLine($"Visual regression test result: {areEqual}");
        Assert.True(areEqual, $"Visual regression detected! See diff image at {diffImagePath}");

    }

    private bool CompareImagesPixelByPixel(string baselinePath, string currentPath, string diffPath)
    {
        // Load the images
        using var baseline = Image.Load<Rgba32>(baselinePath);
        using var current = Image.Load<Rgba32>(currentPath);

        // Check if dimensions match
        if (baseline.Width != current.Width || baseline.Height != current.Height)
        {
            _output.WriteLine("Image sizes differ.");
            return false; // Images are not the same size
        }

        // Compare pixel by pixel

        bool equal = true;
        using var diff = new Image<Rgba32>(baseline.Width, baseline.Height);

        for (int y = 0; y < baseline.Height; y++)
        {
            for (int x = 0; x < baseline.Width; x++)
            {
                var baselinePixel = baseline[x, y];
                var currentPixel = current[x, y];

                if (baselinePixel != currentPixel)
                {
                    equal = false;
                    // Save the diff image
                   _output.WriteLine($"Difference at ({x}, {y})");
                    diff[x, y] = new Rgba32(255, 0, 0); // Red pixel for difference
                    diff.Save(diffPath);
                }
                else
                {
                    diff[x, y] = baselinePixel;
                }
            }
        }
       
        if (!equal)
        {
            // Save the diff image if there are differences
            diff.Save(diffPath);
        }
        return equal;
    }


    
    private async Task TakeScreenshot(string localhost, string FolderName)
    {
        var mockedModalService = new Mock<IModalService>();
        var mockedBasketService = new Mock<IBasketService>();
        var mockedTradInfo = new Mock<ITradeInfoRepository>();
        var mockedBasketResourcesRepository = new Mock<IBasketResourcesRepository>();
        var mockedBasketActionsRepository = new Mock<IBasketActionsRepository>();
        var mockedStateResolver = new Mock<IStateResolver>();
        var mockedToastService = new Mock<IToastService>();
        var mockedIPricesInfoRepository = new Mock<IPricesInfoRepository>();
        var mockedIOrderInfoRepository = new Mock<IOrderInfoRepository>();
        var mockedIGeneralInfoRepository = new Mock<IGeneralInfoRepository>();

        var mockedINewOrderLineRepository = new Mock<INewOrderLineRepository>();
        var mockedIOrderLinesRepository = new Mock<IOrderLinesRepository>();
        var mockedIInvoiceInfoRepository = new Mock<IInvoiceInfoRepository>();
        var mockedIDeliveryInfoRepository = new Mock<IDeliveryInfoRepository>();
        var mockedIUrlService = new Mock<IUrlService>();
        var mockedIBasketItemsRepository = new Mock<IBasketItemsRepository>();


        var mockedOrderInfoState = new Mock<IState<OrderInfoState>>();
        mockedOrderInfoState.SetupGet(x => x.Value).Returns(new OrderInfoState());
        var mockedDispatcher = new Mock<IDispatcher>();

        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // To show the browser window during the test
        });

        var page = await browser.NewPageAsync(new BrowserNewPageOptions
        {
            ViewportSize = new ViewportSize { Width = 1600, Height = 1200 }
        });

        // Change the port if needed
        //await page.GotoAsync("https://localhost:7017/Raja-fr/EditBasket?BasketId=P0152946", new PageGotoOptions
        await page.GotoAsync(localhost, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });

        // Wait for the page to load completely
        await Task.Delay(3000); // 3 seconds


        //await page.WaitForSelectorAsync(".mud-main-content");

        var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
        var testName = "OrderInfo";

        var ImagePath = Path.Combine(projectRoot, "VisualTesting", FolderName, $"{testName}.png");

        await page.ScreenshotAsync(new PageScreenshotOptions
        {

            Path = ImagePath,
            FullPage = true
        });
    }









    //public OrderInfoVisualTests()
    //{
    //    Services.AddMudServices();
    //    Services.AddFluxor(opt => opt.ScanAssemblies(typeof(OrderInfo).Assembly));
    //}

    //[Fact]
    //public async Task OrderInfoComponent_ShouldMatchBaselineScreenshot()
    //{
    //    var cut = RenderComponent<OrderInfo>();
    //    var html = cut.Markup;

    //    using var playwright = await Playwright.CreateAsync();
    //    await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
    //    var page = await browser.NewPageAsync();
    //    await page.SetContentAsync(html);

    //    var screenshot = await page.ScreenshotAsync(new() { FullPage = true });

    //    await Verifier.Verify(screenshot).UseExtension("png");
    //}
}
