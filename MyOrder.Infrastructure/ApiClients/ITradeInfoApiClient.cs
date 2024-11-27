using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface ITradeInfoApiClient
{
    [Get("/api/orderContext/{basketId}/tradeInfo")]
    Task<BasketTradeInfoDto?> GetBasketTradeInfoAsync(string basketId, CancellationToken cancellationToken = default);
}
