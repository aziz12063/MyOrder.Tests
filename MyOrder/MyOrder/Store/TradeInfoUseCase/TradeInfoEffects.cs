using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.TradeInfoUseCase;

public class TradeInfoEffects(IBasketRepository basketRepository, ILogger<TradeInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchTradeInfoAction(FetchTradeInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            // uncomment this after deleting the NoData
            //var tradeInfo = await basketRepository.GetBasketTradeInfoAsync(action.BasketId);
            //dispatcher.Dispatch(new FetchTradeInfoSuccessAction(tradeInfo));

            // delete this NoData
            dispatcher.Dispatch(new NoDataLoadedTradeInfoAction());
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while fetching trade info");
            dispatcher.Dispatch(new FetchTradeInfoFailureAction(e.Message));
        }
    }
}
