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
            async (token) => await _deliveryInfoApiClient.GetBasketDeliveryInfoAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<AccountDto?>?> GetDeliverToAccountsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching deliver to accounts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToAccountsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetDeliverToAccountsAsync(CompanyId, BasketId, filter, search, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<DeliveryAccountDraft?> GetNewDeliveryAccountAsync(string? accountId = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching new delivery account for {BasketId} with accountId {AccountId} from repository", BasketId, accountId);
        var operationDescription = $"GetNewDeliveryAccountAsync for basketId {BasketId}, with accountId {accountId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetNewDeliveryAccountAsync(CompanyId, BasketId, accountId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> CommitNewDeliveryAccountAsync(CancellationToken? cancellationToken = null)
    {
        logger.LogDebug("Committing new delivery account for {BasketId} from repository", BasketId);
        var operationDescription = $"CommitNewDeliveryAccountAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.CommitNewDeliveryAccountAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken ?? default);
    }

    public async Task<ProcedureCallResponseDto?> ResetNewDeliveryAccountAsync(CancellationToken? cancellationToken = null)
    {
        logger.LogDebug("Resetting new delivery account for {BasketId} from repository", BasketId);
        var operationDescription = $"ResetNewDeliveryAccountAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.ResetNewDeliveryAccountAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken ?? default);
    }

    public async Task<List<ContactDto?>?> GetDeliverToContactsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching deliver to contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToContactsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetDeliverToContactsAsync(CompanyId, BasketId, filter, search, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<DeliveryContactDraft?> GetNewDeliveryContactAsync(string? contactId = null, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching new delivery contact for {BasketId} with contactId {contactId} from repository", BasketId, contactId);
        var operationDescription = $"GetNewDeliveryContactAsync for basketId {BasketId}, with contactId {contactId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetNewDeliveryContactAsync(CompanyId, BasketId, contactId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> ResetNewDeliveryContactAsync(CancellationToken? cancellationToken = default)
    {
        logger.LogDebug("Resetting new delivery contact for {BasketId} from repository", BasketId);
        var operationDescription = $"ResetNewDeliveryContactAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.ResetNewDeliveryContactAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken ?? default);
    }

    public async Task<List<BasketValueDto?>?> GetDeliveryModesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching delivery modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliveryModesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _deliveryInfoApiClient.GetDeliveryModesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
}