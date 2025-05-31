using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class BasketRessourcesRepository(IBasketRessourcesApiClient ressourcesApiClient,
    IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<BasketRessourcesRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IBasketRessourcesRepository
{
    private readonly IBasketRessourcesApiClient _ressourcesApiClient = ressourcesApiClient
        ?? throw new ArgumentNullException(nameof(ressourcesApiClient));

    //==============================//
    //      Order ressources        //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetCustomerTagsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching customer tags for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCustomerTagsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetCustomerTagsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesOriginsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching sales origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesOriginsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetSalesOriginsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesPoolAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching sales pool for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesPoolAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetSalesPoolAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    //==============================//
    //      Delivery ressources     //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetDeliveryCountriesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching delivery countries for {basketId} from repository", BasketId);
        var operationDescription = $"GetDeliveryCountriesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetDeliveryCountriesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetCarrierTypesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching carrier types for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCarrierTypesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetCarrierTypesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }


    //==============================//
    //      Invoice ressources      //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetTaxGroupsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching tax groups for {BasketId} from repository", BasketId);
        var operationDescription = $"GetTaxGroupsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetTaxGroupsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetPaymentModesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching payment modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetPaymentModesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetPaymentModesAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    //==============================//
    //      Prices ressources       //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetCouponsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching coupons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetCouponsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetCouponsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching warranty cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWarrantyCostOptionsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetWarrantyCostOptionsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching shipping cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetShippingCostOptionsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetShippingCostOptionsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    //==============================//
    //      Lines ressources        //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetlineUpdateReasonsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching line update reasons for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlineUpdateReasonsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetlineUpdateReasonsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching logistic flows for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlogisticFlowsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetlogisticFlowsAsync(CompanyId, BasketId, token),
            operationDescription,
            cancellationToken);
    }
}
