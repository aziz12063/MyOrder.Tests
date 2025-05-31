using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.LinesUseCase;

namespace MyOrder.Components.Childs.Lines;

public partial class SearchSupplierDialog : FluxorComponentBase<SuppliersState, FetchSuppliersAction>
{
    public List<Supplier?>? Suppliers { get; set; }
    private bool _isLoading = true;
    private string SearchText { get; set; } = string.Empty;

    protected override FetchSuppliersAction CreateFetchAction(SuppliersState state) =>
        new(state, Search: true, Filter: null);

    protected override void CacheNewFields()
    {
        Suppliers = State?.Value.Suppliers ?? throw new ArgumentNullException("Suppliers is null in SuppliersState");
        _isLoading = State.Value.IsLoading;
    }

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(new FetchSuppliersAction(State.Value, Search: true, Filter: SearchText));
    }
}