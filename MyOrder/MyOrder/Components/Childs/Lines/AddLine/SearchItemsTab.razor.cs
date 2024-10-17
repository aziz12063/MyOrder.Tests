using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.BasketItemsUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class SearchItemsTab : FluxorComponentBase<SearchItemsState, FetchSearchItemsAction>, IHandleEvent
{
    private List<BasketItemDto?>? BasketItems { get; set; }
    private bool _showBlocked = true;

    protected override FetchSearchItemsAction CreateFetchAction(SearchItemsState state, string basketId) =>
   new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketItems = State.Value.BasketItems;
    }

    private void FilterItemsCallback(string filterString) =>
        Dispatcher.Dispatch(new FetchSearchItemsAction(State.Value, BasketId, filterString));

    private void ToggleBlockedCallback(bool applyFilter) =>
        _showBlocked = !applyFilter;

    private bool QuickFilter(BasketItemDto? item)
    {
        if (item == null)
            return false;

        // If _showBlocked is true, return true for all items
        // Otherwise, return true only if IsBlocked is false or null (treat null as not blocked)
        return _showBlocked || !(item.IsBlocked ?? false);
    }

    Task IHandleEvent.HandleEventAsync(
    EventCallbackWorkItem callback, object? arg) =>
    callback.InvokeAsync(arg);
}
