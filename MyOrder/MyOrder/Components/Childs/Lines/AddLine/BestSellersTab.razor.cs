using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.BasketItemsUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class BestSellersTab : FluxorComponentBase<BestSellersState, FetchBestSellersAction>
{
    private List<BestSellerItemDto?>? BestSellers { get; set; }
    private bool _showBlocked = true;

    protected override FetchBestSellersAction CreateFetchAction(BestSellersState state, string basketId) =>
        new(state, basketId);

    protected override void CacheNewFields()
    {
        BestSellers = State.Value.BestSellers;
    }

    private void FilterItemsCallback(string filterString) =>
        Dispatcher.Dispatch(new FetchBestSellersAction(State.Value, BasketId, filterString));

    private void ToggleBlockedCallback(bool applyFilter) =>
        _showBlocked = !applyFilter;

    private bool QuickFilter(BestSellerItemDto? item)
    {
        if (item == null)
            return false;

        // If _showBlocked is true, return true for all items
        // Otherwise, return true only if IsBlocked is false or null (treat null as not blocked)
        return _showBlocked || !(item.IsBlocked ?? false);
    }
}
