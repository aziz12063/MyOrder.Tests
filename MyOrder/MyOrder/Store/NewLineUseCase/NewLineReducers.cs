using Fluxor;

namespace MyOrder.Store.NewLineUseCase;

public class NewLineReducers
{
    [ReducerMethod]
    public static NewLineState ReduceFetchNewLineSuccessAction(NewLineState state, FetchNewLineSuccessAction action) =>
        new(action.NewLine);

    [ReducerMethod]
    public static NewLineState ReduceFetchNewLineFailureAction(NewLineState state, FetchNewLineFailureAction action) =>
        state;
}
