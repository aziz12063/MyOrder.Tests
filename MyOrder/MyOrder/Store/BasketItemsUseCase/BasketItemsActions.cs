using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

public sealed record FetchBestSellersAction(string? Filter = null) : FetchDataActionBase;

public record FetchBestSellersSuccessAction(List<BestSellerItemDto?> BestSellers);

public record FetchBasketItemsFailureAction(string ErrorMessage);

public record FetchOrderedItemsAction(string? Filter = null) : FetchDataActionBase;

public record FetchOrderedItemsSuccessAction(List<OrderedItemDto?> OrderedItems);

public record FetchSearchItemsAction(string? Filter = null) : FetchDataActionBase;

public record FetchSearchItemsSuccessAction(List<BasketItemDto?> SearchResults);

