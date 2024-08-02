using Fluxor;

namespace MyOrder.Store.OrderInfoUseCase
{
    public static class OrderInfoReducers
    {
        [ReducerMethod]
        public static OrderInfoState ReduceFetchOrderInfoSuccessAction(OrderInfoState state, FetchOrderInfoSuccessAction action) =>
            new(action.BasketOrderInfo, action.ContactList, action.CustomerTags, action.SalesOrigins, action.WebOrigins, action.SalesPoolsDto);

        [ReducerMethod]
        public static OrderInfoState ReduceFetchOrderInfoFailureAction(OrderInfoState state, FetchOrderInfoFailureAction action) =>
             new ();
    }
}
