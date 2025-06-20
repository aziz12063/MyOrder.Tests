using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.ResourcesUseCase;

public class ResourcesEffects(IBasketResourcesRepository resourcesRepository, ILogger<OrderInfoEffects> logger)
{
    private readonly IBasketResourcesRepository _resourcesRepository = resourcesRepository
        ?? throw new ArgumentNullException(nameof(resourcesRepository));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchResources(FetchResourcesAction action, IDispatcher dispatcher)
    {
        try
        {
            var contactSalutationsTask = _resourcesRepository.GetContactSalutationsAsync();
            var customerTagsTask = _resourcesRepository.GetCustomerTagsAsync();
            var salesOriginsTask = _resourcesRepository.GetSalesOriginsAsync();
            var salesPoolsTask = _resourcesRepository.GetSalesPoolAsync();
            var deliveryCountriesTask = _resourcesRepository.GetDeliveryCountriesAsync();
            var carrierTypesTask = _resourcesRepository.GetCarrierTypesAsync();
            var taxGroupsTask = _resourcesRepository.GetTaxGroupsAsync();
            var paymentModesTask = _resourcesRepository.GetPaymentModesAsync();
            var lineUpdateReasons = _resourcesRepository.GetlineUpdateReasonsAsync();
            var logisticFlows = _resourcesRepository.GetlogisticFlowsAsync();
            var couponsTask = _resourcesRepository.GetCouponsAsync();
            var warrantyCostOptionsTask = _resourcesRepository.GetWarrantyCostOptionsAsync();
            var shippingCostOptionsTask = _resourcesRepository.GetShippingCostOptionsAsync();

            await Task.WhenAll(
                contactSalutationsTask,
                customerTagsTask,
                salesOriginsTask,
                salesPoolsTask,
                deliveryCountriesTask,
                carrierTypesTask,
                taxGroupsTask,
                paymentModesTask,
                lineUpdateReasons,
                logisticFlows,
                couponsTask,
                warrantyCostOptionsTask,
                shippingCostOptionsTask);

            dispatcher.Dispatch(
                new FetchResourcesSuccessAction(
                    contactSalutationsTask.Result,
                    customerTagsTask.Result,
                    salesOriginsTask.Result,
                    salesPoolsTask.Result,
                    deliveryCountriesTask.Result,
                    carrierTypesTask.Result,
                    taxGroupsTask.Result,
                    paymentModesTask.Result,
                    lineUpdateReasons.Result,
                    logisticFlows.Result,
                    couponsTask.Result,
                    warrantyCostOptionsTask.Result,
                    shippingCostOptionsTask.Result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching resources data");
            dispatcher.Dispatch(new FetchResourcesFailureAction(ex.Message));
        }
    }
}
