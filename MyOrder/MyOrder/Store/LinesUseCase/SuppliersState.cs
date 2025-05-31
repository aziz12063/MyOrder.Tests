using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase;

[FeatureState]
public class SuppliersState : StateBase
{
    public List<Supplier?>? Suppliers { get; set; } = null;
    public string? ErrorMessage { get; set; } = null;

    public SuppliersState() : base(true) { }

    public SuppliersState(List<Supplier?>? suppliers, bool isLoading = false) : base(isLoading)
    {
        Suppliers = suppliers;
    }

    public SuppliersState(string errorMessage, bool isLoading = false) : base(isLoading)
    {
        ErrorMessage = errorMessage;
    }
}
