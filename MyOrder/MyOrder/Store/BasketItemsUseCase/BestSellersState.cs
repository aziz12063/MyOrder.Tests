using Fluxor;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

[FeatureState]
public record BestSellersState(List<BestSellerItemDto?> BestSellers) : StateBase
{
    public BestSellersState() : this([]) { }
}
