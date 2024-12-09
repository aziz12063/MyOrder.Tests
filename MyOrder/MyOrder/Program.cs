using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using MudBlazor.Services;
using MyOrder;
using MyOrder.Components;
using MyOrder.Configuration;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Infrastructure.HttpHandlers;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Infrastructure.Resilience;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Services;
using Refit;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Logging
builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

//MudBlazor and UI elements
builder.Services.AddMudServices(/*config =>
{
    config.PopoverOptions = new()
    {
        Mode = MudBlazor.PopoverMode.Legacy,
        PoolInitialFill = 10,
        PoolSize = 20
    };
}*/
);
ThemeConfiguration.ApplyCustomMudGlobals();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped<IEventAggregator, EventAggregator>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IStateResolver, StateResolver>();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IModalService, ModalService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<INotificationService, NotificationService>(); // App notifications (not basketnotifications)
builder.Services.AddScoped<IClipboardService, ClipboardService>();
builder.Services.Configure<RouteConfig>(
    builder.Configuration.GetSection(RouteConfig.Routes));


// Repositories, Api Client, and Resilience Policies
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<InfrastructureFailureHandler>();
if (builder.Environment.IsDevelopment())
    builder.Services.AddTransient<UserNameHandlerDev>();
else
    builder.Services.AddTransient<UserNameHandler>();

RegisterRepositoriesWithRefitClient<IBasketRessourcesApiClient, IBasketRessourcesRepository, BasketRessourcesRepository>(builder);
RegisterRepositoriesWithRefitClient<IGeneralInfoApiClient, IGeneralInfoRepository, GeneralInfoRepository>(builder);
RegisterRepositoriesWithRefitClient<IBasketActionsApiClient, IBasketActionsRepository, BasketActionsRepository>(builder);
RegisterRepositoriesWithRefitClient<IOrderInfoApiClient, IOrderInfoRepository, OrderInfoRepository>(builder);
RegisterRepositoriesWithRefitClient<IDeliveryInfoApiClient, IDeliveryInfoRepository, DeliveryInfoRepository>(builder);
RegisterRepositoriesWithRefitClient<IInvoiceInfoApiClient, IInvoiceInfoRepository, InvoiceInfoRepository>(builder);
RegisterRepositoriesWithRefitClient<ITradeInfoApiClient, ITradeInfoRepository, TradeInfoRepository>(builder);
RegisterRepositoriesWithRefitClient<IPricesInfoApiClient, IPricesInfoRepository, PricesInfoRepository>(builder);
RegisterRepositoriesWithRefitClient<IOrderLinesApiClient, IOrderLinesRepository, OrderLinesRepository>(builder);
RegisterRepositoriesWithRefitClient<INewOrderLineApiClient, INewOrderLineRepository, NewOrderLineRepository>(builder);
RegisterRepositoriesWithRefitClient<IBasketItemsApiClient, IBasketItemsRepository, BasketItemsRepository>(builder);

//Fluxor
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
    if (builder.Environment.IsDevelopment())
        options.UseReduxDevTools();
});

//builder.Services.AddSingleton<IBasketRepository, JsonBasketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    //To disable caching while in development
    app.Use(async (context, next) =>
    {
        context.Response.Headers.CacheControl = "no-cache, no-store";
        context.Response.Headers.Pragma = "no-cache";
        context.Response.Headers.Expires = "-1";
        await next();
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyOrder.Client._Imports).Assembly);

app.MapGet("/DeployTest", () => "Running!");

app.Run();

static IHttpClientBuilder RegisterRepositoriesWithRefitClient<TApiClient, TRepositoryInterface, TConcreteRepository>(WebApplicationBuilder builder)
    where TApiClient : class
    where TRepositoryInterface : class
    where TConcreteRepository : class, TRepositoryInterface
{

    builder.Services.AddScoped<TRepositoryInterface, TConcreteRepository>();

    var httpBuilder = builder.Services.AddRefitClient<TApiClient>(new RefitSettings
    {
        ContentSerializer = new NewtonsoftJsonContentSerializer()
    })
     .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://aliasiisq:8080")) // Refactor to use https only
     //.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44324")) // For local testing
     .AddHttpMessageHandler<InfrastructureFailureHandler>()
     .AddPolicyHandler(ResiliencePolicies.GetRetryPolicy())
     .AddPolicyHandler(ResiliencePolicies.GetCircuitBreakerPolicy())
     .AddPolicyHandler(ResiliencePolicies.GetTimeoutPolicy());

    if (builder.Environment.IsDevelopment())
        httpBuilder.AddHttpMessageHandler<UserNameHandlerDev>();
    else
        httpBuilder.AddHttpMessageHandler<UserNameHandler>();

    return httpBuilder;
}