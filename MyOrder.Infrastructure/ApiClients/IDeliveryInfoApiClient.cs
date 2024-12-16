using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IDeliveryInfoApiClient
{
    [Get("/api/orderContext/{basketId}/deliveryInfo")]
    Task<BasketDeliveryInfoDto?> GetBasketDeliveryInfoAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/deliverToAccounts")]
    Task<List<AccountDto?>?> GetDeliverToAccountsAsync(
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/newDeliverToAccount")]
    Task<DeliveryAccountDraft?> GetNewDeliveryAccountAsync(
         string basketId,
        [Query] string? accountId = null,
        CancellationToken cancellationToken = default);

    [Put("/api/orderContext/{basketId}/newDeliverToAccount/add")]
    Task<ProcedureCallResponseDto?> CommitNewDeliveryAccountAsync(string basketId, CancellationToken cancellationToken = default);

    [Put("/api/orderContext/{basketId}/newDeliverToAccount/reset")]
    Task<ProcedureCallResponseDto> ResetNewDeliveryAccountAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/deliverToContacts")]
    Task<List<ContactDto?>?> GetDeliverToContactsAsync(
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);
}
