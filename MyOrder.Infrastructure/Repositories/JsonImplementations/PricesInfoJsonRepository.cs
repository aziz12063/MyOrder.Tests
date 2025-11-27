using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class PricesInfoJsonRepository(IEventAggregator eventAggregator,
    IBasketService basketService, ILogger<PricesInfoJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IPricesInfoRepository
{

    public async Task<BasketPricesInfoDto?> GetBasketPricesInfoAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "pricesInfo.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket prices info for basket : {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketPricesInfoAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<BasketPricesInfoDto>(json));
             },
            operationDescription,
            cancellationToken);
    }
}