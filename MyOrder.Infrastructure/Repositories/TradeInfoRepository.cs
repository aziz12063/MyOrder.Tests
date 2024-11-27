using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories;

public class TradeInfoRepository(ITradeInfoApiClient tradeInfoApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<TradeInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), ITradeInfoRepository
{
    private readonly ITradeInfoApiClient _tradeInfoApiClient = tradeInfoApiClient
        ?? throw new ArgumentNullException(nameof(tradeInfoApiClient));

    public async Task<BasketTradeInfoDto?> GetBasketTradeInfoAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket trade info for basket : {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketTradeInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _tradeInfoApiClient.GetBasketTradeInfoAsync(BasketId, cancellationToken),
            operationDescription,
            cancellationToken);
    }
}