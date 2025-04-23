using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using Newtonsoft.Json;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public class BasketRessourcesJsonRepository(IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<BasketRessourcesJsonRepository> logger, IWebHostEnvironment environment)
    : BaseJsonRepository(eventAggregator, basketService, logger, environment), IBasketRessourcesRepository
{

    //==============================//
    //      Order ressources        //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetCustomerTagsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "customerTags.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching customer tags for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCustomerTagsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesOriginsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "salesOrigins.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching sales origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesOriginsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesPoolAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "salesPools.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching sales pool for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesPoolAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }


    //==============================//
    //      Invoice ressources      //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetTaxGroupsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "taxGroups.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching tax groups for {BasketId} from repository", BasketId);
        var operationDescription = $"GetTaxGroupsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetPaymentModesAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "paymentModes.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching payment modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetPaymentModesAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    //==============================//
    //      Prices ressources       //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetCouponsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "coupons.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching coupons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCouponsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "warrantyCostOptions.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching warranty cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWarrantyCostOptionsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "shippingCostOptions.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching shipping cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetShippingCostOptionsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    //==============================//
    //      Lines ressources        //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "lineUpdateReasons.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching line update reasons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlineUpdateReasonsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(CancellationToken cancellationToken = default)
    {
        var jsonFilePath = Path.Combine(baseDataPath, "logisticFlows.json");
        if (!File.Exists(jsonFilePath))
            return null;
        logger.LogDebug("Fetching logistic flows for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlogisticFlowsAsync for basketId {BasketId}";
        var json = await File.ReadAllTextAsync(jsonFilePath);
        return await ExecuteAsync(
             (token) => {
                 return Task.FromResult(JsonConvert.DeserializeObject<List<BasketValueDto?>>(json));
             },
            operationDescription,
            cancellationToken);
    }
}
