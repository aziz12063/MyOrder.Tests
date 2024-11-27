using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IOrderInfoRepository
{
    Task<BasketOrderInfoDto?> GetBasketOrderInfoAsync(CancellationToken cancellationToken = default);
    Task<List<ContactDto?>?> GetOrderByContactsAsync(string? filter = null, CancellationToken cancellationToken = default);
}