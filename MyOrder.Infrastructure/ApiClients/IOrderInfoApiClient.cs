using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IOrderInfoApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/orderInfo")]
    Task<BasketOrderInfoDto?> GetBasketOrderInfoAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/orderByContacts")]
    Task<List<ContactDto?>?> GetOrderByContactsAsync(
        string companyId, string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/webOrigins")]
    Task<List<BasketValueDto?>?> GetWebOriginsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}