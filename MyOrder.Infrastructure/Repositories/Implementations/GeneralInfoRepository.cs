using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class GeneralInfoRepository(IGeneralInfoApiClient generalInfoApiClient,
    IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<GeneralInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IGeneralInfoRepository
{
    private readonly IGeneralInfoApiClient _generalInfoApiClient = generalInfoApiClient
        ?? throw new ArgumentNullException(nameof(generalInfoApiClient));

    public async Task<GeneralInfoDto?> GetBasketGeneralInfoAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket generalInfo for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketGeneralInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _generalInfoApiClient.GetBasketGeneralInfoAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketNotificationDto?>?> GetNotificationsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching notifications for {BasketId} from repository", BasketId);
        var operationDescription = $"GetNotificationsAsync for basketId {BasketId}";

        return await ExecuteAsync(
            async (token) => await _generalInfoApiClient.GetNotificationsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching blocking reasons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBlockingReasonsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _generalInfoApiClient.GetBlockingReasonsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketNotificationDto?>?> GetValidationRulesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching validation rules for {BasketId} from repository", BasketId);
        var operationDescription = $"GetValidationRulesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _generalInfoApiClient.GetValidationRulesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<BasketPublishingProgress?> BasketPublicationStateAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching basket publication state for {BasketId} from repository", BasketId);
        var operationDescription = $"BasketPublicationStateAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _generalInfoApiClient.BasketPublicationStateAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
}