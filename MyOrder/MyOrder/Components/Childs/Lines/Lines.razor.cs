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
using MyOrder.Utils;


namespace MyOrder.Components.Childs.Lines;

public sealed partial class Lines : FluxorComponentBase<LinesState, FetchLinesAction>, IDisposable
{
    private const string LineWarning = "lineWarning";
    private const string LineNotification = "lineNotification";
    private const string LineOffered = "lineOffered";
    private const string LineDiscounted = "lineDiscount";
    private const string LineInfo = "lineInfo";

    [Inject]
    private IModalService ModalService { get; set; } = null!;
    [Inject]
    private IToastService ToastService { get; set; } = null!;
    [Inject]
    private IClipboardService ClipboardService { get; set; } = null!;
    [Inject]
    private IEventAggregator EventAggregator { get; set; } = null!;

    private MudDataGrid<BasketLineDto> LinesDataGridInstance { get; set; } = null!;
    private BasketOrderLinesDto BasketOrderLinesDto => State.Value.BasketOrderLines;
    private List<BasketValueDto?>? UpdateReasons { get; set; }
    private List<BasketValueDto?>? LogisticFlows { get; set; }

    private BasketLineDto? CurrentLine { get; set; }
    private BasketLineDto? DetailedLine =>
        State.Value.BasketOrderLines?.Lines?.FirstOrDefault(line => line?.RecId == CurrentLine?.RecId);

    private bool IsItemIdEditable { get; set; }
    private bool IsNameEditable { get; set; }
    private bool IsDiscountTypeEditable { get; set; }
    private bool IsLineAmountEditable { get; set; }
    private IDisposable CtrlIShortcutHandlerSubscription { get; set; } = null!;

    protected override FetchLinesAction CreateFetchAction() => new();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UpdateReasons = ResourcesState?.Value.UpdateReasons
            ?? throw new ArgumentNullException("Unexpected null for UpdateReasons object.");
        LogisticFlows = ResourcesState?.Value.LogisticFlows
            ?? throw new ArgumentNullException("Unexpected null for LogisticFlows object.");

        CtrlIShortcutHandlerSubscription = EventAggregator.Subscribe<ShortcutTriggeredEvent>(CtrlIShortcutHandler);
        State.StateChanged += State_StateChanged;
    }

    private void State_StateChanged(object? sender, EventArgs e)
    {
        if (BasketOrderLinesDto is not null && BasketOrderLinesDto.Lines is not null && BasketOrderLinesDto.Lines.Count > 0)
        {
            IsItemIdEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.Lines[0]?.ItemId);
            IsNameEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.Lines[0]?.ItemName);
            IsDiscountTypeEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.Lines[0]?.DiscountType);
            IsLineAmountEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.Lines[0]?.LineAmount);
            StateHasChanged();
        }

        if (!BasketOrderLinesDto?.Lines?.Contains(CurrentLine) ?? false)
        {
            CurrentLine = BasketOrderLinesDto?.Lines?.FirstOrDefault();
            StateHasChanged();
        }
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
        await ModalService.OpenAddLineDialogAsync(index);

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

    private static string LineTagIconHelper(string? tag) =>
        tag switch
        {
            LineWarning => Icons.Material.Filled.Error,
            LineNotification => Icons.Material.TwoTone.Warning,
            LineOffered => Icons.Material.TwoTone.CardGiftcard,
            LineDiscounted => Icons.Material.Filled.LocalOffer,
            LineInfo => Icons.Material.Filled.Info,
            _ => Icons.Material.Filled.QuestionMark
        };

    private static string LineTagColorHelper(string? tag) =>
        tag switch
        {
            LineWarning => "#D44333",
            LineNotification => "#FFC107",
            LineOffered => "#4CAF50",
            LineDiscounted => "#FF9800",
            LineInfo => "#2196F3",
            _ => "#2196F3"
        };

    public void Dispose()
    {
        CtrlIShortcutHandlerSubscription.Dispose();
    }
}