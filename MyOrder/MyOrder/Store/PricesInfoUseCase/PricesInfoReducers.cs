using Fluxor;
using MyOrder.Components.Childs.Header;

namespace MyOrder.Store.PricesInfoUseCase;

public static class PricesInfoReducers
{
    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoSuccessAction(PricesInfoState state, FetchPricesInfoSuccessAction action) =>
        new(action.PricesInfo, action.Coupons, action.WarrantyCostOptions,
            action.ShippingCostOptions, false);

    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoFailureAction(PricesInfoState state, FetchPricesInfoFailureAction action) =>
        new();
    [ReducerMethod]
    public static PricesInfoState ReduceFetchPricesInfoAction(PricesInfoState state, FetchPricesInfoAction action)
    {
        return new(null, null, null, null, true );
    }

    // to delete
    [ReducerMethod]
    public static PricesInfoState ReduceNoDataLoadedAction(PricesInfoState state, NoDataLoadedPriceInfoAction action) =>
        new(action.PricesInfo, action.Coupons, action.WarrantyCostOptions,
            action.ShippingCostOptions, false);


}

