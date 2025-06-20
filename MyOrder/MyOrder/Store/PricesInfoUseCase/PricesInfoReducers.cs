using Fluxor;
using MyOrder.Components.Childs.Header;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase;

public static class PricesInfoReducers
{
    [ReducerMethod(typeof(FetchPricesInfoAction))]
    public static PricesInfoState ReduceFetchPricesInfoAction(PricesInfoState state)
    {
        return state with
        {
            IsLoading = true
        };
    }

    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoSuccessAction(PricesInfoState state, FetchPricesInfoSuccessAction action)
    {
        return state with
        {
            PricesInfo = action.PricesInfo,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoFailureAction(PricesInfoState state, FetchPricesInfoFailureAction action)
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

