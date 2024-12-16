using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class DeliveryInfoRepository(IDeliveryInfoApiClient deliveryInfoApiClient,
    IEventAggregator eventAggregator, IBasketService basketService, ILogger<DeliveryInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IDeliveryInfoRepository
{
    private readonly IDeliveryInfoApiClient _deliveryInfoApiClient = deliveryInfoApiClient
        ?? throw new ArgumentNullException(nameof(deliveryInfoApiClient));

    public async Task<BasketDeliveryInfoDto?> GetBasketDeliveryInfoAsync(CancellationToken cancellationToken)
    {
        logger.LogDebug("Fetching basket delivery info for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketDeliveryInfoAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetBasketDeliveryInfoAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<AccountDto?>?> GetDeliverToAccountsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching deliver to accounts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToAccountsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetDeliverToAccountsAsync(BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<DeliveryAccountDraft?> GetNewDeliveryAccountAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching new delivery account for {BasketId} with the filter {filter} from repository", BasketId, filter);
        var operationDescription = $"GetNewDeliveryAccountAsync for basketId {BasketId}, with filter {filter}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetNewDeliveryAccountAsync(BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> ResetNewDeliveryAccountAsync(CancellationToken? cancellationToken = null)
    {
        logger.LogDebug("Resetting new delivery account for {BasketId} from repository", BasketId);
        var operationDescription = $"ResetNewDeliveryAccountAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.ResetNewDeliveryAccountAsync(BasketId, token),
            operationDescription,
            cancellationToken ?? default);
    }

    public async Task<List<ContactDto?>?> GetDeliverToContactsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching deliver to contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToContactsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetDeliverToContactsAsync(BasketId, filter, token),
            operationDescription,
            cancellationToken);
    }
}