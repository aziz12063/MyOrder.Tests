using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.RessourcesUseCase;

public class RessourcesEffects(IBasketRepository basketRepository, ILogger<OrderInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchRessources(FetchRessourcesAction action, IDispatcher dispatcher)
    {
        try
        {
            var customerTagsTask = basketRepository.GetCustomerTagsAsync(action.BasketId);
            var salesOriginsTask = basketRepository.GetSalesOriginsAsync(action.BasketId);
            var webOriginsTask = basketRepository.GetWebOriginsAsync(action.BasketId);
            var salesPoolsTask = basketRepository.GetSalesPoolAsync(action.BasketId);
            var deliveryModesTask = basketRepository.GetDeliveryModesAsync(action.BasketId);
            var taxGroupsTask = basketRepository.GetTaxGroupsAsync(action.BasketId);
            var paymentModesTask = basketRepository.GetPaymentModesAsync(action.BasketId);
            var lineUpdateReasons = basketRepository.GetlineUpdateReasonsAsync(action.BasketId);
            var logisticFlows = basketRepository.GetlogisticFlowsAsync(action.BasketId);
            var couponsTask = basketRepository.GetCouponsAsync(action.BasketId);
            var warrantyCostOptionsTask = basketRepository.GetWarrantyCostOptionsAsync(action.BasketId);
            var shippingCostOptionsTask = basketRepository.GetShippingCostOptionsAsync(action.BasketId);

            await Task.WhenAll(customerTagsTask, salesOriginsTask, webOriginsTask, salesPoolsTask, deliveryModesTask,
                taxGroupsTask, paymentModesTask, lineUpdateReasons, logisticFlows, couponsTask, warrantyCostOptionsTask,
                shippingCostOptionsTask);

            dispatcher.Dispatch(new FetchRessourcesSuccessAction(customerTagsTask.Result, salesOriginsTask.Result,
                webOriginsTask.Result, salesPoolsTask.Result, deliveryModesTask.Result, taxGroupsTask.Result,
                paymentModesTask.Result, lineUpdateReasons.Result, logisticFlows.Result, couponsTask.Result,
                warrantyCostOptionsTask.Result, shippingCostOptionsTask.Result));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching ressources data");
            dispatcher.Dispatch(new FetchRessourcesFailureAction(ex.Message));
        }
    }
}
