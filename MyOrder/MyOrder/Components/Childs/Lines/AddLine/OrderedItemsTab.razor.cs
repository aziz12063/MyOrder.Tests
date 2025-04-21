using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Utils;
using MyOrder.Store.BasketItemsUseCase;


namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class OrderedItemsTab : FluxorComponentBase<OrderedItemsState, FetchOrderedItemsAction>, IHandleEvent
{
    [Inject]
    public IClipboardService ClipboardService { get; set; }
    private List<OrderedItemDto?>? OrderedItems { get; set; }
    private bool _showBlocked = true;

    [Parameter, EditorRequired]
    public EventCallback<string> ItemClicked { get; set; }

    protected override FetchOrderedItemsAction CreateFetchAction(OrderedItemsState state) =>
   new(state);

    protected override void CacheNewFields()
    {
        OrderedItems = State.Value.OrderedItems;
    }

    private void FilterItemsCallback(string filterString) =>
        Dispatcher.Dispatch(new FetchOrderedItemsAction(State.Value, filterString));

    private void ToggleBlockedCallback(bool applyFilter) =>
        _showBlocked = !applyFilter;

    private bool QuickFilter(OrderedItemDto? item)
    {
        if (item == null)
            return false;

        // If _showBlocked is true, return true for all items
        // Otherwise, return true only if IsBlocked is false or null (treat null as not blocked)
        return _showBlocked || !(item.IsBlocked ?? false);
    }

    private void OnItemClick(OrderedItemDto? item)
    {
        if (item == null)
            return;

        ItemClicked.InvokeAsync(item.ItemId);
    }

    private async Task CopyDataToClipboard()
    {
        var headers = new[] {
                "Date", "Réf. Client", "Code", "Description", "Vendu par",
                "Quantité", "Prix U", "Remise", "Montant HT", "Statut" };

        //Check wether to include blocked items or not
        var dataToCopy = _showBlocked ? OrderedItems
            : OrderedItems?.Where(x => x?.IsBlocked != false).ToList();

        if (dataToCopy is null || dataToCopy.Count == 0)
        {
            await ClipboardService.CopyTextToClipboardAsync(string.Empty);
            return;
        }

        string formattedData = DataFormatter.GenerateTabSeparatedData(
            data: dataToCopy,
            headers: headers,
            selector: static (item) =>
            [
                item?.OrderDate.ToString() ?? string.Empty,
                item?.CustomerOrderId ?? string.Empty,
                item?.ItemId ?? string.Empty,
                item?.Description ?? string.Empty,
                item?.MultipleQuantity.ToString() ?? string.Empty,
                item?.Quantity.ToString() ??string.Empty,
                item?.Price.ToString() ??string.Empty,
                item?.Discount ??string.Empty,
                item?.Price.ToString() ??string.Empty,
                item?.Status ?? string.Empty
            ]);

        await ClipboardService.CopyTextToClipboardAsync(formattedData);
    }

    Task IHandleEvent.HandleEventAsync(
    EventCallbackWorkItem callback, object? arg) =>
    callback.InvokeAsync(arg);
}
