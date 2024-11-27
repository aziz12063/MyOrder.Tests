using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.TradeInfoUseCase;

public class TradeInfoEffects(ITradeInfoRepository tradeInfoRespository, ILogger<TradeInfoEffects> logger)
{
    private readonly ITradeInfoRepository _tradeInfoRespository = tradeInfoRespository
        ?? throw new ArgumentNullException(nameof(tradeInfoRespository));
    private readonly ILogger<TradeInfoEffects> logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchTradeInfoAction(FetchTradeInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var tradeInfo = await _tradeInfoRespository.GetBasketTradeInfoAsync();
            dispatcher.Dispatch(new FetchTradeInfoSuccessAction(tradeInfo));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while fetching trade info");
            dispatcher.Dispatch(new FetchTradeInfoFailureAction(e.Message));
        }
    }
}
