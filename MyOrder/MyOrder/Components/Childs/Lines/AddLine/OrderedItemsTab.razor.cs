using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.BasketItemsUseCase;


namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class OrderedItemsTab : FluxorComponentBase<OrderedItemsState, FetchOrderedItemsAction>, IHandleEvent
{
    private List<OrderedItemDto?>? OrderedItems {  get; set; }
    private bool _showBlocked = true;

    protected override FetchOrderedItemsAction CreateFetchAction(OrderedItemsState state, string basketId) =>
   new(state, basketId);

    protected override void CacheNewFields()
    {
        OrderedItems = State.Value.OrderedItems;
    }

    private void FilterItemsCallback(string filterString) =>
        Dispatcher.Dispatch(new FetchOrderedItemsAction(State.Value, BasketId, filterString));

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
