using Fluxor;

namespace MyOrder.Store.NewLineUseCase;

public class NewLineReducers
{
    [ReducerMethod]
    public static NewLineState ReduceFetchNewLineSuccessAction(NewLineState state, FetchNewLineSuccessAction action)
    {
        return state with 
        { 
            BasketLine = action.NewLine,
            Initialized = true,
            IsLoading = false ,
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
