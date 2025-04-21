using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class BasketItemsRepository(IBasketItemsApiClient basketItemsApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<BasketItemsRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IBasketItemsRepository
{
    private readonly IBasketItemsApiClient _basketItemsApiClient = basketItemsApiClient
        ?? throw new ArgumentNullException(nameof(basketItemsApiClient));
    public async Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket best sellers for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketBestSellersAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketItemsApiClient.GetBasketBestSellersAsync(CompanyId, BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket ordered items for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketOrderedItemsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketItemsApiClient.GetBasketOrderedItemsAsync(CompanyId, BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket search items for basketId {BasketId}", BasketId);
        var operationDescription = $"GetBasketSearchItemsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _basketItemsApiClient.GetBasketSearchItemsAsync(CompanyId, BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }
}