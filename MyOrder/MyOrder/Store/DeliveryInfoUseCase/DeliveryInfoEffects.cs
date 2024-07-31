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
            var basketDeliveryInfo = await basketRepository.GetBasketDeliveryInfoAsync(action.BasketId);
            dispatcher.Dispatch(new FetchDeliveryInfoSuccessAction(basketDeliveryInfo));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching delivery info");
            dispatcher.Dispatch(new FetchDeliveryInfoFailureAction(ex.Message));
        }
    }
}