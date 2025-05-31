using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Utils;
using MyOrder.Store.BasketItemsUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class BestSellersTab : FluxorComponentBase<BestSellersState, FetchBestSellersAction>,
    IHandleEvent
{
    [Inject]
    public IClipboardService ClipboardService { get; set; }
    private List<BestSellerItemDto?>? BestSellers { get; set; }
    private bool _showBlocked = true;

    [Parameter, EditorRequired]
    public EventCallback<string> ItemClicked { get; set; }

    protected override FetchBestSellersAction CreateFetchAction(BestSellersState state) =>
        new(state);

    protected override void CacheNewFields()
    {
        BestSellers = State.Value.BestSellers;
    }

    private void FilterItemsCallback(string filterString) =>
        Dispatcher.Dispatch(new FetchBestSellersAction(State.Value, filterString));

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

    private void OnItemClick(BestSellerItemDto? item)
    {
        if (item == null)
            return;

        ItemClicked.InvokeAsync(item.ItemId);
    }

    //Necessary to preserve the internal state of childs (FilterItems)
    Task IHandleEvent.HandleEventAsync(
        EventCallbackWorkItem callback, object? arg) =>
        callback.InvokeAsync(arg);

    private async Task CopyDataToClipboard()
    {
        var headers = new[] {
            "Code", "Description", "Famille Catalogue", "Vendu par",
            "Chiffre d'affaire", "Quantité", "Statut" };

        //Check wether to include blocked items or not
        var dataToCopy = _showBlocked ? BestSellers
            : BestSellers?.Where(x => x?.IsBlocked != false).ToList();

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
                item?.ItemId ?? string.Empty,
                item?.Description ?? string.Empty,
                item?.Category1 ?? string.Empty,
                item?.MultipleQuantity.ToString() ?? string.Empty,
                item?.Amount.ToString() ?? string.Empty,
                item?.Quantity.ToString() ??string.Empty,
                item?.Status ?? string.Empty
            ]);

        await ClipboardService.CopyTextToClipboardAsync(formattedData);
    }
}