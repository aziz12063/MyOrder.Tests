using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase;

[FeatureState]
public record SuppliersState(
    List<Supplier?> Suppliers) : StateBase
{
    public SuppliersState() : this([]) { }
}