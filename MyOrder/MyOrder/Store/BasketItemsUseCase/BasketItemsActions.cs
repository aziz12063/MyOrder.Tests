using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

public class FetchBestSellersAction(BestSellersState state, string? filter = null) : FetchDataActionBase(state)
{
    public string? Filter { get; set; } = filter;
}

public class FetchBestSellersSuccessAction(List<BestSellerItemDto?>? bestSellers)
{
    public List<BestSellerItemDto?>? BestSellers { get; } = bestSellers;
}

public class FetchBasketItemsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchOrderedItemsAction(OrderedItemsState state, string? filter = null) : FetchDataActionBase(state)
{
    public string? Filter { get; set; } = filter;
}

public class FetchOrderedItemsSuccessAction(List<OrderedItemDto?>? orderedItems)
{
    public List<OrderedItemDto?>? OrderedItems { get; } = orderedItems;
}

public class FetchSearchItemsAction(SearchItemsState state, string? filter = null) : FetchDataActionBase(state)
{
    public string? Filter { get; set; } = filter;
}

public class FetchSearchItemsSuccessAction(List<BasketItemDto?>? searchItems)
{
    public List<BasketItemDto?>? SearchItems { get; } = searchItems;
}

