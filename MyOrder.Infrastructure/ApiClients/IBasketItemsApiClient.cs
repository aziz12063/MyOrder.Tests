using MyOrder.Shared.Dtos.BasketItems;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketItemsApiClient
{
    [Get("/api/orderContext/{basketId}/bestSellerItems")]
    Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/orderedItems")]
    Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/searchItems")]
    Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(
       string basketId,
       [Query] string? filter = null,
       CancellationToken cancellationToken = default);
}