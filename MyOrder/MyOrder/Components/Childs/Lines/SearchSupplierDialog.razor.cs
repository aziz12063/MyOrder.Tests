using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.LinesUseCase;

namespace MyOrder.Components.Childs.Lines;

public partial class SearchSupplierDialog : FluxorComponentBase<SuppliersState, FetchSuppliersAction>
{
    public List<Supplier?>? Suppliers => State.Value.Suppliers;
    private string SearchText { get; set; } = string.Empty;

    protected override FetchSuppliersAction CreateFetchAction() =>
        new(Search: true, Filter: null);

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(new FetchSuppliersAction(Search: true, Filter: SearchText));
    }
}