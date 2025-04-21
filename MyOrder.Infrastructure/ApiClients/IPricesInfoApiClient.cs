using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IPricesInfoApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/pricesInfo")]
    Task<BasketPricesInfoDto?> GetBasketPricesInfoAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}
