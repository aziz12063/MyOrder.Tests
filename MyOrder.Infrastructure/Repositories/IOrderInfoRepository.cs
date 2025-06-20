using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IOrderInfoRepository
{
    Task<BasketOrderInfoDto?> GetBasketOrderInfoAsync(CancellationToken cancellationToken = default);
    Task<List<ContactDto?>?> GetOrderByContactsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default);
    Task<List<BasketValueDto?>?> GetWebOriginsAsync(CancellationToken cancellationToken = default);
}