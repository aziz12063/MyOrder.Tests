using Fluxor;

namespace MyOrder.Store.BasketItemsUseCase;

public static class BasketItemsReducers
{
    [ReducerMethod]
    public static BestSellersState ReduceFetchBestSellersSuccessAction(BestSellersState state, FetchBestSellersSuccessAction action)
    {
        return state with
        {
            BestSellers = action.BestSellers,
            ErrorMessage = string.Empty,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false
        };
    }

    [ReducerMethod]
    public static BestSellersState ReduceFetchBestSellersFailureAction(BestSellersState state, FetchBasketItemsFailureAction action)
    {       
        return state with
        {
            BestSellers = [],
            ErrorMessage = action.ErrorMessage,
            Initialized = true,
            IsLoading = false,
            IsFaulted = true
        };
    }

    [ReducerMethod]
    public static OrderedItemsState ReduceFetchOrderedItemsSuccessAction(OrderedItemsState state, FetchOrderedItemsSuccessAction action)
    {
        return state with
        {
            OrderedItems = action.OrderedItems,
            ErrorMessage = string.Empty,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false
        };
    }

    [ReducerMethod]
    public static OrderedItemsState ReduceFetchOrderedItemsFailureAction(OrderedItemsState state, FetchBasketItemsFailureAction action)
    {
        return state with
        {
            OrderedItems = [],
            ErrorMessage = action.ErrorMessage,
            Initialized = true,
            IsLoading = false,
            IsFaulted = true
        };
    }

    [ReducerMethod]
    public static SearchItemsState ReduceFetchBestSellersSuccessAction(SearchItemsState state, FetchSearchItemsSuccessAction action)
    {
        return state with 
        {
            SearchResults = action.SearchResults,
            ErrorMessage = string.Empty,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false
        };
    }

    [ReducerMethod]
    public static SearchItemsState ReduceFetchSearchItemsFailureAction(SearchItemsState state, FetchBasketItemsFailureAction action)
    {
        return state with
        {
            SearchResults = [],
            ErrorMessage = action.ErrorMessage,
            Initialized = true,
            IsLoading = false,
            IsFaulted = true
        };
    }
}
