using MyOrder.Shared.Dtos.BasketItems;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IBasketItemsApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/bestSellerItems")]
    Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(
        string companyId, 
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/orderedItems")]
    Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(
        string companyId,
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/searchItems")]
    Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(
       string companyId, 
       string basketId,
       [Query] string? filter = null,
       CancellationToken cancellationToken = default);
}