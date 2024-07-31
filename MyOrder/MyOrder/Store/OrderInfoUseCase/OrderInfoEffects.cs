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
            var basketOrderInfo = await basketRepository.GetBasketOrderInfoAsync(action.BasketId);
            var salesOrigins = await basketRepository.GetSalesOriginsAsync(action.BasketId);
            var salesPools = await basketRepository.GetSalesPoolAsync(action.BasketId);

            dispatcher.Dispatch(new FetchOrderInfoSuccessAction(basketOrderInfo, salesOrigins, salesPools));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching order info data");
            dispatcher.Dispatch(new FetchOrderInfoFailureAction(ex.Message));
        }
    }
}

