using Fluxor;

namespace MyOrder.Store.DeliveryInfoUseCase
{
    public static class DeliveryInfoReducers
    {
        [ReducerMethod]
        public static DeliveryInfoState ReduceFetchDeliveryInfoSuccessAction(DeliveryInfoState state, FetchDeliveryInfoSuccessAction action)
        {
            return new DeliveryInfoState(action.BasketDeliveryInfo);
        }

        [ReducerMethod]
        public static DeliveryInfoState ReduceFetchDeliveryInfoFailureAction(DeliveryInfoState state, FetchDeliveryInfoFailureAction action)
        {
            return new DeliveryInfoState();
        }
    }
}
