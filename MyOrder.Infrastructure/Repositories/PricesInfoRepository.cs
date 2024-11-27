using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories;

public class PricesInfoRepository(IPricesInfoApiClient pricesInfoApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<PricesInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IPricesInfoRepository
{
    private readonly IPricesInfoApiClient _pricesInfoApiClient = pricesInfoApiClient
        ?? throw new ArgumentNullException(nameof(pricesInfoApiClient));

    public async Task<BasketPricesInfoDto?> GetBasketPricesInfoAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket prices info for basket : {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketPricesInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _pricesInfoApiClient.GetBasketPricesInfoAsync(BasketId, cancellationToken),
            operationDescription,
            cancellationToken);
    }
}