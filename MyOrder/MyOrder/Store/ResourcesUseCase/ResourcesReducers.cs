using Fluxor;

namespace MyOrder.Store.ResourcesUseCase;

public class ResourcesReducers
{
    [ReducerMethod(typeof(FetchResourcesAction))]
    public static ResourcesState ReduceFetchResourcesAction(ResourcesState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static ResourcesState ReduceFetchResourcesSuccessAction(ResourcesState state, FetchResourcesSuccessAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty,
            ContactSalutations = action.ContactSalutations,
            CustomerTags = action.CustomerTags,
            SalesOrigins = action.SalesOrigins,
            SalesPools = action.SalesPools,
            Countries = action.DeliveryCountries,
            CarrierTypes = action.CarrierTypes,
            TaxGroups = action.TaxGroups,
            PaymentModes = action.PaymentModes,
            UpdateReasons = action.UpdateReasons,
            LogisticFlows = action.LogisticFlows,
            Coupons = action.Coupons,
            WarrantyCostOptions = action.WarrantyCostOptions,
            ShippingCostOptions = action.ShippingCostOptions

        };
    }

    [ReducerMethod]
    public static ResourcesState ReduceFetchResourcesFailureAction(ResourcesState state, FetchResourcesFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }
}
