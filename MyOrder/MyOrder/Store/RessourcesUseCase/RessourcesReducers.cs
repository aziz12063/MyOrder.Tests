using Fluxor;

namespace MyOrder.Store.RessourcesUseCase;

public class RessourcesReducers
{
    [ReducerMethod]
    public static RessourcesState ReduceFetchRessourcesSuccessAction(RessourcesState state, FetchRessourcesSuccessAction action) =>
        new(action.CustomerTags, action.SalesOrigins, action.SalesPools,
            action.TaxGroups, action.PaymentModes, action.UpdateReasons, action.LogisticFlows, action.Coupons,
            action.WarrantyCostOptions, action.ShippingCostOptions);

    [ReducerMethod]
    public static RessourcesState ReduceFetchRessourcesFailureAction(RessourcesState state, FetchRessourcesFailureAction action) =>
        new();
}
