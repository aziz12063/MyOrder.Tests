using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.OrderInfoUseCase;

public class OrderInfoEffects(IBasketRepository basketRepository, ILogger<OrderInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchOrderInfo(FetchOrderInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching order info for {BasketId}", action.BasketId);
            var basketOrderInfoTask = basketRepository.GetBasketOrderInfoAsync(action.BasketId);
            var contactListTask = basketRepository.GetOrderByContactsAsync(action.BasketId);
            var customerTagsTask = basketRepository.GetCustomerTagsAsync(action.BasketId);
            var salesOriginsTask = basketRepository.GetSalesOriginsAsync(action.BasketId);
            var webOriginsTask = basketRepository.GetWebOriginsAsync(action.BasketId);
            var salesPoolsTask = basketRepository.GetSalesPoolAsync(action.BasketId);

            await Task.WhenAll(basketOrderInfoTask, contactListTask, customerTagsTask, salesOriginsTask, salesPoolsTask);

            dispatcher.Dispatch(new FetchOrderInfoSuccessAction(basketOrderInfoTask.Result, contactListTask.Result,
                customerTagsTask.Result, salesOriginsTask.Result, webOriginsTask.Result, salesPoolsTask.Result));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching order info data");
            dispatcher.Dispatch(new FetchOrderInfoFailureAction(ex.Message));
        }
    }
}

