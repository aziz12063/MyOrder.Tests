using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class BasketItemsJsonRepository(IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<BasketItemsJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IBasketItemsRepository
{
    public async Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "bestSellerItems.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket best sellers for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketBestSellersAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BestSellerItemDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "orderedItems.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket ordered items for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketOrderedItemsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<OrderedItemDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "searchItems.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket search items for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketSearchItemsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketItemDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }
}