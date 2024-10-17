using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

public class FetchBestSellersAction(BestSellersState state, string basketId, string? filter = null) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
    public string? Filter { get; set; } = filter;
}

public class FetchBestSellersSuccessAction(List<BestSellerItemDto?>? bestSellers)
{
    public List<BestSellerItemDto?>? BestSellers { get; } = bestSellers;
}

public class FetchBestSellersFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
