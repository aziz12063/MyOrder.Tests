using Fluxor;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

[FeatureState]
public class BestSellersState : StateBase
{
    public List<BestSellerItemDto?>? BestSellers { get; }

    public BestSellersState() : base(true) {  }

    public BestSellersState(List<BestSellerItemDto?>? bestSellers) : base(false)
    {
        BestSellers = bestSellers;
    }
}
