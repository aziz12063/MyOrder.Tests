using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IDeliveryInfoApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/deliveryInfo")]
    Task<BasketDeliveryInfoDto?> GetBasketDeliveryInfoAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/deliverToAccounts")]
    Task<List<AccountDto?>?> GetDeliverToAccountsAsync(
        string companyId, 
        string basketId,
        [Query] string? filter = null,
        [Query] bool? search = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/newDeliverToAccount")]
    Task<DeliveryAccountDraft?> GetNewDeliveryAccountAsync(
         string companyId,
         string basketId,
        [Query] string? accountId = null,
        CancellationToken cancellationToken = default);

    [Put("/api/myorder/{companyId}/{basketId}/newDeliverToAccount/add")]
    Task<ProcedureCallResponseDto?> CommitNewDeliveryAccountAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/deliverToContacts")]
    Task<List<ContactDto?>?> GetDeliverToContactsAsync(
        string companyId, 
        string basketId,
        [Query] string? filter = null,
        [Query] bool? search = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/newDeliverToContact")]
    Task<DeliveryContactDraft?> GetNewDeliveryContactAsync(
        string companyId, 
        string basketId,
        [Query] string? contactId = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/deliveryModes")]
    Task<List<BasketValueDto?>?> GetDeliveryModesAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}