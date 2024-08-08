using Fluxor;

namespace MyOrder.Store.TradeInfoUseCase;

public static class TradeInfoReducers
{

    [ReducerMethod]
    public static TradeInfoState ReduceFetchTradeInfoSuccessAction(TradeInfoState state, FetchTradeInfoSuccessAction action) =>
        new (action.BasketTradeInfo);

    [ReducerMethod]
    public static TradeInfoState ReduceFetchTradeInfoFailureAction(TradeInfoState state, FetchTradeInfoFailureAction action) =>
        new ();


    // to delete
    [ReducerMethod]
    public static TradeInfoState ReduceNoDataLoadedPriceInfoAction(TradeInfoState state, NoDataLoadedTradeInfoAction action)
    {
        return new(action.BasketTradeInfo);
    }
}
