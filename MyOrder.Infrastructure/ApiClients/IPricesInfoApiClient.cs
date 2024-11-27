using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IPricesInfoApiClient
{
    [Get("/api/orderContext/{basketId}/pricesInfo")]
    Task<BasketPricesInfoDto?> GetBasketPricesInfoAsync(string basketId, CancellationToken cancellationToken = default);
}
