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
            async (token) => await _ressourcesApiClient.GetCustomerTagsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesOriginsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching sales origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesOriginsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetSalesOriginsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetWebOriginsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching web origins for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWebOriginsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetWebOriginsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetSalesPoolAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching sales pool for {BasketId} from repository", BasketId);
        var operationDescription = $"GetSalesPoolAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetSalesPoolAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    //==============================//
    //      Delivery ressources     //
    //==============================//
    public async Task<List<BasketValueDto?>?> GetDeliveryModesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching delivery modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetDeliveryModesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetDeliveryModesAsync(BasketId, token),
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
            async (token) => await _ressourcesApiClient.GetTaxGroupsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetPaymentModesAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching payment modes for {BasketId} from repository", BasketId);
        var operationDescription = $"GetPaymentModesAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetPaymentModesAsync(BasketId, token),
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
            async (token) => await _ressourcesApiClient.GetCouponsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetWarrantyCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching warranty cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetWarrantyCostOptionsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetWarrantyCostOptionsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetShippingCostOptionsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching shipping cost options for {BasketId} from repository", BasketId);
        var operationDescription = $"GetShippingCostOptionsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetShippingCostOptionsAsync(BasketId, token),
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
            async (token) => await _ressourcesApiClient.GetlineUpdateReasonsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }

    public async Task<List<BasketValueDto?>?> GetlogisticFlowsAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Fetching logistic flows for {BasketId} from repository", BasketId);
        var operationDescription = $"GetlogisticFlowsAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) => await _ressourcesApiClient.GetlogisticFlowsAsync(BasketId, token),
            operationDescription,
            cancellationToken);
    }
}
