using Fluxor;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

[FeatureState]
public class SearchItemsState : StateBase
{
    public List<BasketItemDto?>? BasketItems { get; }

    public SearchItemsState() : base(true) { }

    public SearchItemsState(List<BasketItemDto?>? basketItems) : base(false)
    {
        BasketItems = basketItems;
    }
}
