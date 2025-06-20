using Fluxor;

namespace MyOrder.Store.TradeInfoUseCase;

public static class TradeInfoReducers
{
    [ReducerMethod(typeof(FetchTradeInfoAction))]
    public static TradeInfoState ReduceFetchTradeInfo(TradeInfoState state)
    {
        return state with
        {
            IsLoading = true
        };
    }

    [ReducerMethod]
    public static TradeInfoState ReduceFetchTradeInfoSuccessAction(TradeInfoState state, FetchTradeInfoSuccessAction action)
    {
        return state with
        {
            BasketTradeInfo = action.BasketTradeInfo,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static TradeInfoState ReduceFetchTradeInfoFailureAction(TradeInfoState state, FetchTradeInfoFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

}
