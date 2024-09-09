using Microsoft.Extensions.Options;
using MyOrder.Configuration;

namespace MyOrder.Services;

public class UrlService : IUrlService
{
    private readonly RouteConfig _routeConfig;
    private readonly ILogger<UrlService> _logger;

    public UrlService(IOptions<RouteConfig> routeConfig, ILogger<UrlService> logger)
    {
        _routeConfig = routeConfig?.Value ?? throw new ArgumentNullException(nameof(routeConfig), "RouteConfig is not provided.");
        _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger is not provided.");

        if (string.IsNullOrEmpty(_routeConfig.Basket))
        {
            _logger.LogWarning("Basket route is not configured. Using fallback route.");
            _routeConfig.Basket = "/?BasketId={basketId}";
        }

        if (string.IsNullOrEmpty(_routeConfig.Error))
        {
            _logger.LogWarning("Error route is not configured. Using fallback route.");
            _routeConfig.Error = "/error";
        }
    }

    public string GetBasketUrl(string basketId)
    {
        if (string.IsNullOrEmpty(basketId))
        {
            _logger.LogError("Invalid basketId provided.");
            throw new ArgumentException("BasketId cannot be null or empty.", nameof(basketId));
        }

        try
        {
            return _routeConfig.Basket!.Replace("{basketId}", basketId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating Basket URL.");
            throw new InvalidOperationException("Failed to generate Basket URL.", ex);
        }
    }

    public string GetErrorUrl()
    {
        try
        {
            return _routeConfig.Error!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating Error URL.");
            throw new InvalidOperationException("Failed to generate Error URL.", ex);
        }
    }
}
