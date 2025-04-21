using Fluxor;

namespace MyOrder.Store.OrderInfoUseCase;

public static class OrderInfoReducers
{
    [ReducerMethod]
    public static OrderInfoState ReduceFetchOrderInfoSuccessAction(OrderInfoState state, FetchOrderInfoSuccessAction action) =>
        new(action.BasketOrderInfo, action.WebOrigins);

    [ReducerMethod]
    public static OrderInfoState ReduceFetchOrderInfoFailureAction(OrderInfoState state, FetchOrderInfoFailureAction action) =>
         new();

    [ReducerMethod]
    public static OrderContactsState ReduceFetchOrderContactsSuccessAction(OrderContactsState state, FetchOrderContactsSuccessAction action)
    {
        return new(action.OrderContacts, action.IsFiltered);
    }

    [ReducerMethod]
    public static OrderContactsState ReduceFetchOrderContactsFailureAction(OrderContactsState state, FetchOrderContactsFailureAction action) =>
        new();
}
