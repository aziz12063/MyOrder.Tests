using Fluxor;

namespace MyOrder.Store.DeliveryInfoUseCase;

public static class DeliveryInfoReducers
{
    [ReducerMethod]
    public static DeliveryInfoState ReduceFetchDeliveryInfoSuccessAction(DeliveryInfoState state, FetchDeliveryInfoSuccessAction action) =>
        new (action.BasketDeliveryInfo);

    [ReducerMethod]
    public static DeliveryInfoState ReduceFetchDeliveryInfoFailureAction(DeliveryInfoState state, FetchDeliveryInfoFailureAction action) =>
         new ();

    [ReducerMethod]
    public static DeliveryAccountsState ReduceFetchDeliveryAccountsSuccessAction(DeliveryAccountsState state, FetchDeliveryAccountsSuccessAction action) =>
        new(action.DeliveryAccounts, action.IsFiltered);

    [ReducerMethod]
    public static DeliveryAccountsState ReduceFetchDeliveryAccountsFailureAction(DeliveryAccountsState state, FetchDeliveryAccountsFailureAction action) =>
        new();

    [ReducerMethod]
    public static DeliveryContactsState ReduceFetchDeliveryContactsSuccessAction(DeliveryContactsState state, FetchDeliveryContactsSuccessAction action)
    {
        return new(action.DeliveryContacts, action.IsFiltered);
    }

    [ReducerMethod]
    public static DeliveryContactsState ReduceFetchDeliveryContactsFailureAction(DeliveryContactsState state, FetchDeliveryContactsFailureAction action) =>
        new();
}
