using Fluxor;

namespace MyOrder.Store.NewLineUseCase;

public class NewLineReducers
{
    [ReducerMethod(typeof(FetchNewLineAction))]
    public static NewLineState ReduceFetchNewDeliveryAccountAction(NewLineState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod(typeof(ResetNewLineAction))]
    public static NewLineState ReduceResetNewDeliveryAccountAction9(NewLineState state)
    {
        return state with
        {
            BasketLine = null!,
            Initialized = false,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NewLineState ReduceFetchNewLineSuccessAction(NewLineState state, FetchNewLineSuccessAction action)
    {
        return state with
        {
            BasketLine = action.NewLine,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NewLineState ReduceFetchNewLineFailureAction(NewLineState state, FetchNewLineFailureAction action)
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
