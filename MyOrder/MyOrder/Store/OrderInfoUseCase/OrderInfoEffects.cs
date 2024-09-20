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
           
            await Task.WhenAll(basketOrderInfoTask, contactListTask);

            dispatcher.Dispatch(new FetchOrderInfoSuccessAction(basketOrderInfoTask.Result, contactListTask.Result));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching order info data");
            dispatcher.Dispatch(new FetchOrderInfoFailureAction(ex.Message));
        }
    }
}

