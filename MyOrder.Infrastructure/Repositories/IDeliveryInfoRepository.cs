using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;

namespace MyOrder.Infrastructure.Repositories;

public interface IDeliveryInfoRepository
{
    Task<BasketDeliveryInfoDto?> GetBasketDeliveryInfoAsync(CancellationToken cancellationToken = default);
    Task<List<AccountDto?>?> GetDeliverToAccountsAsync(string? filter = null, CancellationToken cancellationToken = default);
    Task<DeliveryAccountDraft?> GetNewDeliveryAccountAsync(string? filter = null, CancellationToken cancellationToken = default);
    Task<ProcedureCallResponseDto?> CommitNewDeliveryAccountAsync(CancellationToken? cancellationToken = default);
    Task<ProcedureCallResponseDto?> ResetNewDeliveryAccountAsync(CancellationToken? cancellationToken = default);
    Task<List<ContactDto?>?> GetDeliverToContactsAsync(string? filter = null, CancellationToken cancellationToken = default);
}