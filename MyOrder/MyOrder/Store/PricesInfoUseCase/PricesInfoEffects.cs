using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.PricesInfoUseCase
{
    public class PricesInfoEffects(IBasketRepository basketRepository, ILogger<PricesInfoEffects> logger)
    {
        [EffectMethod]
        public async Task HandleFetchPricesInfoAction(FetchPricesInfoAction action, IDispatcher dispatcher)
        {
            try
            {
                var pricesInfoTask = basketRepository.GetBasketPricesInfoAsync(action.BasketId);
                var couponsTask = basketRepository.GetCouponsAsync(action.BasketId);
                var warrantyCostOptionsTask = basketRepository.GetWarrantyCostOptionsAsync(action.BasketId);
                var shippingCostOptionsTask = basketRepository.GetShippingCostOptionsAsync(action.BasketId);

                await Task.WhenAll(pricesInfoTask, couponsTask, warrantyCostOptionsTask, shippingCostOptionsTask);

                dispatcher.Dispatch(new FetchPricesInfoSuccessAction(pricesInfoTask.Result, couponsTask.Result,
                    warrantyCostOptionsTask.Result, shippingCostOptionsTask.Result));
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while fetching prices info");
                dispatcher.Dispatch(new FetchPricesInfoFailureAction(e.Message));
            }
        }
    }
}
