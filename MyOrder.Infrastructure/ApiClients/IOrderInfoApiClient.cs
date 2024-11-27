using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IOrderInfoApiClient
{
    [Get("/api/orderContext/{basketId}/orderInfo")]
    Task<BasketOrderInfoDto?> GetBasketOrderInfoAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/orderByContacts")]
    Task<List<ContactDto?>?> GetOrderByContactsAsync(
        string basketId,
        [Query] string? filter = null,
        CancellationToken cancellationToken = default);
}