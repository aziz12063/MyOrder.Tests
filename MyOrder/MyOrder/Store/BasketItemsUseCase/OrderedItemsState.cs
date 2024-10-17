using Fluxor;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

[FeatureState]
public class OrderedItemsState : StateBase
{
    public List<OrderedItemDto?>? OrderedItems { get; }

    public OrderedItemsState() : base(true) { }

    public OrderedItemsState(List<OrderedItemDto?>? orderedItems) : base(false)
    {
        OrderedItems = orderedItems;
    }
}
