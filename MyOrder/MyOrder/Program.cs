using Fluxor;
using MyOrder.Components;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Infrastructure.Resilience;
using MyOrder.Shared.Dtos;
using Radzen;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Api Client, and Resilience Policies
builder.Services.AddRefitClient<IBasketApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://aliasiisq:8080"))
    .AddPolicyHandler(ResiliencePolicies.GetRetryPolicy())
    .AddPolicyHandler(ResiliencePolicies.GetCircuitBreakerPolicy());

// Enabling Fluxor
builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly));

// Repositories
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//Radzen and UI elements
builder.Services.AddRadzenComponents();
builder.Services.AddCascadingValue(_ => new BasketHeaderDto());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
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
