using Fluxor;

namespace MyOrder.Store.PricesInfoUseCase;

public static class PricesInfoReducers
{
    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoSuccessAction(PricesInfoState state, FetchPricesInfoSuccessAction action)
    {
        return new PricesInfoState(action.PricesInfo);
    }

    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoFailureAction(PricesInfoState state, FetchPricesInfoFailureAction action)
    {
        return new PricesInfoState();
    }
}

