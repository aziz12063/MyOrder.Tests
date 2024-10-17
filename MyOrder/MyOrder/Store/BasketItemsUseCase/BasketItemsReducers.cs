using Fluxor;

namespace MyOrder.Store.BasketItemsUseCase;

public static class BasketItemsReducers
{
    [ReducerMethod]
    public static BestSellersState ReduceFetchBestSellersSuccessAction(BestSellersState state, FetchBestSellersSuccessAction action) =>
       new(action.BestSellers);

    [ReducerMethod]
    public static BestSellersState ReduceFetchBestSellersFailureAction(BestSellersState state, FetchBasketItemsFailureAction action) =>
         new();

    [ReducerMethod]
    public static OrderedItemsState ReduceFetchOrderedItemsSuccessAction(OrderedItemsState state, FetchOrderedItemsSuccessAction action) =>
      new(action.OrderedItems);

    [ReducerMethod]
    public static OrderedItemsState ReduceFetchOrderedItemsFailureAction(OrderedItemsState state, FetchBasketItemsFailureAction action) =>
         new();

    [ReducerMethod]
    public static SearchItemsState ReduceFetchBestSellersSuccessAction(SearchItemsState state, FetchSearchItemsSuccessAction action) =>
      new(action.SearchItems);

    [ReducerMethod]
    public static SearchItemsState ReduceFetchSearchItemsFailureAction(SearchItemsState state, FetchBasketItemsFailureAction action) =>
         new();
}
