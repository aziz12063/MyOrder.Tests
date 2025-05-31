using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Utils;
using MyOrder.Store.LinesUseCase;
using MyOrder.Store.NewLineUseCase;
using MyOrder.Utils;


namespace MyOrder.Components.Childs.Lines;

public partial class Lines : FluxorComponentBase<LinesState, FetchLinesAction>
{
    [Inject]
    private IModalService ModalService { get; set; } = null!;
    [Inject]
    private IToastService ToastService { get; set; } = null!;
    [Inject]
    private IClipboardService ClipboardService { get; set; } = null!;
    [Inject]
    private IEventAggregator EventAggregator { get; set; } = null!;

    private MudDataGrid<BasketLineDto> LinesDataGridInstance { get; set; }
    private BasketOrderLinesDto? BasketOrderLinesDto { get; set; }
    private List<BasketValueDto?>? UpdateReasons { get; set; }
    private List<BasketValueDto?>? LogisticFlows { get; set; }

    private BasketLineDto? CurrentLine { get; set; }
    private BasketLineDto? DetailedLine =>
        State.Value.BasketOrderLines?.lines?.FirstOrDefault(line => line?.RecId == CurrentLine?.RecId);

    private bool IsItemIdEditable { get; set; }
    private bool IsNameEditable { get; set; }
    private bool IsDiscountTypeEditable { get; set; }
    private bool IsLineAmountEditable { get; set; }

    private bool _isLoading = true;
    private bool _disposed = false;
    private IDisposable CtrlIShortcutHandlerSubscription { get; set; } = null!;

    protected override FetchLinesAction CreateFetchAction(LinesState state) =>
    new(state);

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UpdateReasons = RessourcesState?.Value.UpdateReasons
            ?? throw new ArgumentNullException("Unexpected null for UpdateReasons object.");
        LogisticFlows = RessourcesState?.Value.LogisticFlows
            ?? throw new ArgumentNullException("Unexpected null for LogisticFlows object.");

        CtrlIShortcutHandlerSubscription = EventAggregator.Subscribe<ShortcutTriggeredEvent>(CtrlIShortcutHandler);
    }

    protected override void CacheNewFields()
    {
        BasketOrderLinesDto = State?.Value.BasketOrderLines
            ?? throw new ArgumentNullException("Unexpected null for BasketOrderLines object.");
        if (BasketOrderLinesDto is not null && BasketOrderLinesDto.lines is not null && BasketOrderLinesDto.lines.Count > 0)
        {
            IsItemIdEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.ItemId);
            IsNameEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.ItemName);
            IsDiscountTypeEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.DiscountType);
            IsLineAmountEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.LineAmount);
        }
        _isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;

        if (!BasketOrderLinesDto?.lines?.Contains(CurrentLine) ?? false)
            CurrentLine = BasketOrderLinesDto?.lines?.FirstOrDefault();
    }

    private async Task OnCopyItemsClick()
    {
        if (!IsAnyItemSelected())
        {
            Logger.LogWarning("No selected item to copy. At : {StackTrace}", LogUtility.GetStackTrace());
            ToastService.ShowError($"Erreur lors de la copie dans le presse-papiers.");
            return;
        }

        var headers = new[] { "Code article", "Quantité", "Prix unitaire" };

        string formattedData = DataFormatter.GenerateTabSeparatedData(
            data: LinesDataGridInstance.SelectedItems,
            headers: headers,
            selector: static (item) =>
            [
                item?.ItemId?.Value ?? string.Empty,
                item?.SalesQuantity?.Value?.ToString() ?? string.Empty,
                item?.SalesPrice?.Value?.ToString() ?? string.Empty,
            ]);

        try
        {
            await ClipboardService.CopyTextToClipboardAsync(formattedData);
            ToastService.ShowInfo("Les lignes sélectionnées ont été copiées dans le presse-papiers.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Couldn't copy items into clipboard.");
            ToastService.ShowError($"Erreur lors de la copie dans le presse-papiers.");
        }
    }

    private async Task OnDuplicateItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        await ModalService.ShowConfirmationDialog("Voulez-vous dupliquer les lignes sélectionnées?",
            onConfirm: () =>
            {
                Dispatcher.Dispatch(new DuplicateLinesAction(selectedItemsNums));
                LinesDataGridInstance.SelectedItems.Clear();
            });
    }

    private async Task OnDeleteItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        await ModalService.ShowConfirmationDialog("Voulez-vous supprimer les lignes sélectionnées?",
            onConfirm: () =>
            {
                Dispatcher.Dispatch(new DeleteLinesAction(selectedItemsNums));
                LinesDataGridInstance.SelectedItems.Clear();
            });

    }

    private List<int>? GetSelectedItemsNums()
    {
        var selectedItems = LinesDataGridInstance.SelectedItems;
        if (selectedItems is null || selectedItems.Count < 1)
            Logger.LogInformation("No item selected.");

        return selectedItems?
            .Where(x => x.LineNum?.Value != null)?
            .Select(x => x.LineNum?.Value)?
            .Cast<int>()?
            .ToList();
    }

    private bool IsAnyItemSelected() =>
        LinesDataGridInstance.SelectedItems.Count > 0;

    private async Task<IDialogReference> OpenAddLineDialogAsync(AddLineDialogTab index) =>
         await ModalService.OpenAddLineDialogAsync(index, () =>
                           Dispatcher.Dispatch(new ResetNewLineAction()));

    private async void CtrlIShortcutHandler(ShortcutTriggeredEvent @event)
    {
        ArgumentNullException.ThrowIfNull(@event);

        if (@event.Shortcut == Shortcut.CtrlI)
            await OpenAddLineDialogAsync(AddLineDialogTab.AddLine);
    }

    private void RowClicked(DataGridRowClickEventArgs<BasketLineDto> ClickedRow)
    {
        CurrentLine = ClickedRow.Item;
    }

    private string RowStyleFunc(BasketLineDto? line, int index) =>
        line == CurrentLine
            ? "selected-row"
            : string.Empty;

    private static string ItemIdStyleFunc(BasketLineDto? line) =>
        string.IsNullOrEmpty(line?.ItemId?.Color)
            ? string.Empty
            : $"color: {line.ItemId.Color} !important; font-weight: bolder !important;";

    private static string InventoryStyleFunc(BasketLineDto? line) =>
        string.IsNullOrEmpty(line?.InventLocationId?.Color)
            ? string.Empty
            : $"color: {line.InventLocationId.Color} !important; font-weight: bolder !important;";

    protected override void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                CtrlIShortcutHandlerSubscription.Dispose();
            }
            _disposed = true;
        }
        base.Dispose(disposing);
    }
}