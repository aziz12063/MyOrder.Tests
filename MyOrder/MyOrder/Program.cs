using Fluxor;
using MyOrder;
using MyOrder.Components;
using MyOrder.Components.Layout;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Infrastructure.Resilience;
using MyOrder.Shared.Dtos;
using MyOrder.Store.AdminUseCase;
using Radzen;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped<Radzen.DialogService>();

// Api Client, and Resilience Policies
builder.Services.AddRefitClient<IBasketApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://aliasiisq:8080"))
    .AddPolicyHandler(ResiliencePolicies.GetRetryPolicy())
    .AddPolicyHandler(ResiliencePolicies.GetCircuitBreakerPolicy());

// Enabling Fluxor
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
    
});

// Register the generic state for each component type you want to use
//builder.Services.AddScoped<IFeature, GenericFeature<Adminlayout>>();
//builder.Services.AddScoped<IState<AdminState>, State<AdminState>>();
builder.Services.AddScoped<AdminEffects>();
//builder.Services.AddScoped<IFeature, AdminFeature>();
builder.Services.AddSingleton<ComponentLoaderService>();



// Add more component types as needed

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
