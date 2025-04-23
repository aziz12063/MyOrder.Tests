using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class GeneralInfoJsonRepository(IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<GeneralInfoJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IGeneralInfoRepository
{

    public async Task<GeneralInfoDto?> GetBasketGeneralInfoAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "generalInfo.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket generalInfo for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketGeneralInfoAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<GeneralInfoDto>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketNotificationDto?>?> GetNotificationsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "notifications.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching notifications for {BasketId} from repository", BasketId);
        var operationDescription = $"GetNotificationsAsync for basketId {BasketId}";

        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketNotificationDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "blockingReasons.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching blocking reasons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBlockingReasonsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketBlockingReasonDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketNotificationDto?>?> GetValidationRulesAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "validationRules.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching validation rules for {BasketId} from repository", BasketId);
        var operationDescription = $"GetValidationRulesAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketNotificationDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<BasketPublishingProgress?> BasketPublicationStateAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "publicationState.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket publication state for {BasketId} from repository", BasketId);
        var operationDescription = $"BasketPublicationStateAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<BasketPublishingProgress>(json));
             },
            operationDescription,
            cancellationToken);
    }
}