using Fluxor;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

[FeatureState]
public record OrderedItemsState(List<OrderedItemDto?> OrderedItems) : StateBase
{
    public OrderedItemsState() : this([]) { }
}
