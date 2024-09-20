using Fluxor;

namespace MyOrder.Store.LinesUseCase
{
    
    public static class LinesReducers
    {
        [ReducerMethod]
        public static LinesState ReduceFetchLinesSuccessAction(LinesState state, FetchLinesSuccessAction action) =>
            new(action.BasketOrderLinesDto);

        [ReducerMethod]
        public static LinesState ReduceFetchLinesFailureAction(LinesState state, FetchLinesFailureAction action) =>
            new LinesState();

    }
}
