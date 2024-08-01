using Fluxor;

namespace MyOrder.Store.DeliveryInfoUseCase
{
    public static class DeliveryInfoReducers
    {
        [ReducerMethod]
        public static DeliveryInfoState ReduceFetchDeliveryInfoSuccessAction(DeliveryInfoState state, FetchDeliveryInfoSuccessAction action) =>
            new (action.BasketDeliveryInfo, action.DeliverToAccounts, action.DeliverToContacts, action.DeliveryModes);

        [ReducerMethod]
        public static DeliveryInfoState ReduceFetchDeliveryInfoFailureAction(DeliveryInfoState state, FetchDeliveryInfoFailureAction action) =>
             new ();
    }
}
