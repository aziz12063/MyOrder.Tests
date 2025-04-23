using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Infrastructure.Repositories.Implementations;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class TradeInfoJsonRepository(ITradeInfoApiClient tradeInfoApiClient, IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<TradeInfoJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), ITradeInfoRepository
{
    

    public async Task<BasketTradeInfoDto?> GetBasketTradeInfoAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "tradeInfo.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket trade info for basket : {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketTradeInfoAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<BasketTradeInfoDto>(json));
             },
            operationDescription,
            cancellationToken);
    }
}