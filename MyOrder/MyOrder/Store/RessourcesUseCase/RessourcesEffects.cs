using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.RessourcesUseCase;

public class RessourcesEffects(IBasketRessourcesRepository ressourcesRepository, ILogger<OrderInfoEffects> logger)
{
    private readonly IBasketRessourcesRepository _ressourcesRepository = ressourcesRepository
        ?? throw new ArgumentNullException(nameof(ressourcesRepository));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchRessources(FetchRessourcesAction action, IDispatcher dispatcher)
    {
        try
        {
            var customerTagsTask = _ressourcesRepository.GetCustomerTagsAsync();
            var salesOriginsTask = _ressourcesRepository.GetSalesOriginsAsync();
            var webOriginsTask = _ressourcesRepository.GetWebOriginsAsync();
            var salesPoolsTask = _ressourcesRepository.GetSalesPoolAsync();
            var deliveryModesTask = _ressourcesRepository.GetDeliveryModesAsync();
            var taxGroupsTask = _ressourcesRepository.GetTaxGroupsAsync();
            var paymentModesTask = _ressourcesRepository.GetPaymentModesAsync();
            var lineUpdateReasons = _ressourcesRepository.GetlineUpdateReasonsAsync();
            var logisticFlows = _ressourcesRepository.GetlogisticFlowsAsync();
            var couponsTask = _ressourcesRepository.GetCouponsAsync();
            var warrantyCostOptionsTask = _ressourcesRepository.GetWarrantyCostOptionsAsync();
            var shippingCostOptionsTask = _ressourcesRepository.GetShippingCostOptionsAsync();

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
