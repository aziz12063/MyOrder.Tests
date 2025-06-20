using Fluxor;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.Base;

namespace MyOrder.Store.BasketItemsUseCase;

[FeatureState]
public record SearchItemsState(List<BasketItemDto?> SearchResults) : StateBase
{
    public SearchItemsState() : this([]) { }
}