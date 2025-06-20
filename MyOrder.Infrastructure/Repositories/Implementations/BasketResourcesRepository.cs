using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class BasketResourcesRepository(IBasketResourcesApiClient resourcesApiClient,
    IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<BasketResourcesRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IBasketResourcesRepository
{
    private readonly IBasketResourcesApiClient _resourcesApiClient = resourcesApiClient
        ?? throw new ArgumentNullException(nameof(resourcesApiClient));

      //==============================//
     //       Common resources       //
    //==============================//
    public Task<List<BasketValueDto?>?> GetContactSalutationsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching contact salutations for {BasketId} from repository", BasketId);
        var operationDescription = $"GetContactSalutationsAsync for basketId {BasketId}";
        return ExecuteAsync(
            async (token) => await _resourcesApiClient.GetContactSalutationsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

      //==============================//
     //      Order resources         //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetCustomerTagsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching customer tags for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCustomerTagsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetCustomerTagsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesOriginsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching sales origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesOriginsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetSalesOriginsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesPoolAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching sales pool for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesPoolAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetSalesPoolAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

      //==============================//
     //      Delivery resources      //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetDeliveryCountriesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching delivery countries for {basketId} from repository", BasketId);
        var operationDescription = $"GetDeliveryCountriesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetDeliveryCountriesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetCarrierTypesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching carrier types for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCarrierTypesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetCarrierTypesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }


      //==============================//
     //      Invoice resources       //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetTaxGroupsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching tax groups for {BasketId} from repository", BasketId);
        var operationDescription = $"GetTaxGroupsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetTaxGroupsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetPaymentModesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching payment modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetPaymentModesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetPaymentModesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

      //==============================//
     //      Prices resources        //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetCouponsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching coupons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCouponsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetCouponsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching warranty cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWarrantyCostOptionsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetWarrantyCostOptionsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching shipping cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetShippingCostOptionsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetShippingCostOptionsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

      //==============================//
     //      Lines resources         //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching line update reasons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlineUpdateReasonsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetlineUpdateReasonsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching logistic flows for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlogisticFlowsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _resourcesApiClient.GetlogisticFlowsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
}
