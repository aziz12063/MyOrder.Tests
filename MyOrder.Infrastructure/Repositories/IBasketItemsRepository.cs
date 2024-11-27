using MyOrder.Shared.Dtos.BasketItems;

namespace MyOrder.Infrastructure.Repositories;

public interface IBasketItemsRepository
{
    Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(string? filter = null, CancellationToken cancellationToken = default);
    Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(string? filter = null, CancellationToken cancellationToken = default);
    Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(string? filter = null, CancellationToken cancellationToken = default);
}