using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface ITradeInfoApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/tradeInfo")]
    Task<BasketTradeInfoDto?> GetBasketTradeInfoAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}
