using Fluxor;

namespace MyOrder.Store.LinesUseCase;

public static class LinesReducers
{
    [ReducerMethod]
    public static LinesState ReduceFetchLinesSuccessAction(LinesState state, FetchLinesSuccessAction action) =>
        new(action.BasketOrderLinesDto);

    [ReducerMethod]
    public static LinesState ReduceFetchLinesFailureAction(LinesState state, FetchLinesFailureAction action) =>
        new();

    [ReducerMethod]
    public static SuppliersState ReduceFetchSuppliersSuccessAction(SuppliersState state, FetchSuppliersSuccessAction action) =>
        new(action.Suppliers);
    [ReducerMethod]
    public static SuppliersState ReduceFetchSuppliersFailureAction(SuppliersState state, FetchSuppliersFailureAction action) =>
        new(action.ErrorMessage);

}
