using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class DeliveryInfoEffects(IBasketRepository basketRepository, ILogger<DeliveryInfoEffects> logger)
{

    [EffectMethod]
    public async Task HandleFetchDeliveryInfoAction(FetchDeliveryInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var basketId = action.BasketId;

            // Run all the async operations in parallel
            var basketDeliveryInfoTask = basketRepository.GetBasketDeliveryInfoAsync(basketId);
            var deliverToAccountsTask = basketRepository.GetDeliverToAccountsAsync(basketId);
            var deliverToContactsTask = basketRepository.GetDeliverToContactsAsync(basketId);

            await Task.WhenAll(basketDeliveryInfoTask, deliverToAccountsTask, 
                deliverToContactsTask);

            dispatcher.Dispatch(new FetchDeliveryInfoSuccessAction(basketDeliveryInfoTask.Result, deliverToAccountsTask.Result,
                deliverToContactsTask.Result));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching delivery info");
            dispatcher.Dispatch(new FetchDeliveryInfoFailureAction(ex.Message));
        }
    }
}