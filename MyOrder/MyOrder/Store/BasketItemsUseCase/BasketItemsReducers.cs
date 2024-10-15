using Fluxor;

namespace MyOrder.Store.BasketItemsUseCase;

public static class BasketItemsReducers
{
    [ReducerMethod]
    public static BestSellersState ReduceFetchBestSellersSuccessAction(BestSellersState state, FetchBestSellersSuccessAction action) =>
       new(action.BestSellers);

    [ReducerMethod]
    public static BestSellersState ReduceFetchBestSellersFailureAction(BestSellersState state, FetchBestSellersFailureAction action) =>
         new();
}
