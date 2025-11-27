using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class OrderInfoJsonRepository(IOrderInfoApiClient orderInfoApiClient,
    IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<OrderInfoJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IOrderInfoRepository
{
   

    public async Task<BasketOrderInfoDto?> GetBasketOrderInfoAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "orderInfo.json");
        if (!File.Exists(jsonFilePath))
                return null;
            logger.LogDebug("Fetching orderinfo for {BasketId} from repository", BasketId);
        var operationDescription = $"GetOrderInfoAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                return Task.FromResult(JsonConvert.DeserializeObject<BasketOrderInfoDto>(json));
            },
            operationDescription,
            cancellationToken);

        //return JsonConvert.DeserializeObject<BasketOrderInfoDto>(json);
    }

    public async Task<List<ContactDto?>?> GetOrderByContactsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "orderByContacts.json");
        if (!File.Exists(jsonFilePath))
            return null;

        logger.LogDebug("Fetching order by contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetOrderByContactsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
            async (token) => {
                return JsonConvert.DeserializeObject<List<ContactDto?>>(json);
            },
            operationDescription,
            cancellationToken);
    }

    public Task<List<ContactDto?>?> GetOrderByContactsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BasketValueDto?>?> GetWebOriginsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "webOrigins.json");
        if (!File.Exists(jsonFilePath))
            return null;

        logger.LogDebug("Fetching web origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWebOriginsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
            async (token) => {
                return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
            },
            operationDescription,
            cancellationToken);
    }
}
