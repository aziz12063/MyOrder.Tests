using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IDeliveryInfoRepository
{
    Task<BasketDeliveryInfoDto?> GetBasketDeliveryInfoAsync(CancellationToken cancellationToken = default);
    Task<List<AccountDto?>?> GetDeliverToAccountsAsync(string? filter = null, CancellationToken cancellationToken = default);
    Task<List<ContactDto?>?> GetDeliverToContactsAsync(string? filter = null, CancellationToken cancellationToken = default);
}
