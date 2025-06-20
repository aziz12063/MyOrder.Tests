using Fluxor;

namespace MyOrder.Store.LinesUseCase;

public static class LinesReducers
{
    [ReducerMethod]
    public static LinesState ReduceFetchLinesSuccessAction(LinesState state, FetchLinesSuccessAction action)
    {
        return state with
        {
            BasketOrderLines = action.BasketOrderLinesDto,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static LinesState ReduceFetchLinesFailureAction(LinesState state, FetchLinesFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod]
    public static SuppliersState ReduceFetchSuppliersSuccessAction(SuppliersState state, FetchSuppliersSuccessAction action)
    {
        return state with
        {
            Suppliers = action.Suppliers,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static SuppliersState ReduceFetchSuppliersFailureAction(SuppliersState state, FetchSuppliersFailureAction action)
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
