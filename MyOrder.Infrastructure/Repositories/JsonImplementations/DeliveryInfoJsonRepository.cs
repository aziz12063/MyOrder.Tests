using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class DeliveryInfoJsonRepository(IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<DeliveryInfoJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IDeliveryInfoRepository
{

    public async Task<BasketDeliveryInfoDto?> GetBasketDeliveryInfoAsync(CancellationToken cancellationToken)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "deliveryInfo.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching basket delivery info for {BasketId} from repository", BasketId);
        var operationDescription = $"GetBasketDeliveryInfoAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) =>
             {
                 return Task.FromResult(JsonConvert.DeserializeObject<BasketDeliveryInfoDto>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<AccountDto?>?> GetDeliverToAccountsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "deliverToAccounts.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching deliver to accounts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToAccountsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) =>
             {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<AccountDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<DeliveryAccountDraft?> GetNewDeliveryAccountAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "newDeliverToAccount.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching new delivery account for {BasketId} with the filter {filter} from repository", BasketId, filter);
        var operationDescription = $"GetNewDeliveryAccountAsync for basketId {BasketId}, with filter {filter}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) =>
             {
                 return Task.FromResult(JsonConvert.DeserializeObject<DeliveryAccountDraft>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<DeliveryContactDraft?> GetNewDeliveryContactAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "newDeliverToContact.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching deliver to contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToContactsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) =>
             {
                 return Task.FromResult(JsonConvert.DeserializeObject<DeliveryContactDraft>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> CommitNewDeliveryAccountAsync(CancellationToken? cancellationToken = null)
    {
        logger.LogDebug("Committing new delivery account for {BasketId} from repository", BasketId);
        var operationDescription = $"CommitNewDeliveryAccountAsync for basketId {BasketId}";

        var result = new ProcedureCallResponseDto(
            UpdateDone: true,
    RefreshCalls: null,
    Target: null,
    Success: true,
    Message: "New delivery account committed successfully",
    ErrorCause: null
        );

        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult<ProcedureCallResponseDto?>(result);
            },
            operationDescription,
            cancellationToken ?? default);
    }

    public async Task<ProcedureCallResponseDto?> ResetNewDeliveryAccountAsync(CancellationToken? cancellationToken = null)
    {
        logger.LogDebug("Resetting new delivery account for {BasketId} from repository", BasketId);
        var operationDescription = $"ResetNewDeliveryAccountAsync for basketId {BasketId}";

        var result = new ProcedureCallResponseDto(
             UpdateDone: true,
     RefreshCalls: null,
     Target: null,
     Success: true,
     Message: "New delivery account committed successfully",
     ErrorCause: null
         );
        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult<ProcedureCallResponseDto?>(result);
            },
            operationDescription,
            cancellationToken ?? default);
    }

    public async Task<List<ContactDto?>?> GetDeliverToContactsAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "deliverToContacts.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching deliver to contacts for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliverToContactsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
            (token) =>
            {
                return Task.FromResult(JsonConvert.DeserializeObject<List<ContactDto?>>(json));
            },
           operationDescription,
           cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetDeliveryModesAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "deliveryModes.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching delivery modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliveryModesAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) =>
             {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public Task<List<ContactDto?>?> GetDeliverToContactsAsync(string? filter = null, bool? search = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ProcedureCallResponseDto?> ResetNewDeliveryContactAsync(CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }
}