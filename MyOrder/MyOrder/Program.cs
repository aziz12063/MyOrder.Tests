using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using MudBlazor.Services;
using MyOrder.Components;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Infrastructure.HttpHandlers;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Infrastructure.Resilience;
using MyOrder.Services;
using Refit;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Configure Logging
builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.WithExceptionDetails());

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<IStateResolver, StateResolver>();

// Api Client, and Resilience Policies
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<UserNameHandler>();
builder.Services.AddRefitClient<IBasketApiClient>()
    .AddHttpMessageHandler<UserNameHandler>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://aliasiisq:8080")) // Refactor to use https only
    .AddPolicyHandler(ResiliencePolicies.GetRetryPolicy())
    .AddPolicyHandler(ResiliencePolicies.GetCircuitBreakerPolicy());

//Fluxor
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
    if(builder.Environment.IsDevelopment())
        options.UseReduxDevTools();
});


// Repositories
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
//builder.Services.AddSingleton<IBasketRepository, InMemoryBasketRepository>();

//MudBlazor and UI elements
builder.Services.AddMudServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    //To disable caching while in development
    app.Use(async (context, next) =>
    {
        context.Response.Headers["Cache-Control"] = "no-cache, no-store";
        context.Response.Headers["Pragma"] = "no-cache";
        context.Response.Headers["Expires"] = "-1";
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

app.Run();
