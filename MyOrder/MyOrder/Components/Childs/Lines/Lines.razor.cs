using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Utils;
using MyOrder.Store.LinesUseCase;
using MyOrder.Store.NewLineUseCase;
using MyOrder.Utils;
using System.Drawing;


namespace MyOrder.Components.Childs.Lines;

public partial class Lines : FluxorComponentBase<LinesState, FetchLinesAction>
{
    [Inject]
    private IModalService ModalService { get; set; }
    [Inject]
    private IToastService ToastService { get; set; }
    [Inject]
    private IClipboardService ClipboardService { get; set; }
    [Inject]
    IJSRuntime JSRuntime { get; set; }

    private MudDataGrid<BasketLineDto> LinesDataGridInstance { get; set; }
    private BasketOrderLinesDto? BasketOrderLinesDto { get; set; }
    private List<BasketValueDto?>? UpdateReasons { get; set; }
    private List<BasketValueDto?>? LogisticFlows { get; set; }

    private BasketLineDto? CurrentLine { get; set; }
    private BasketLineDto? LineRightClicked { get; set; }

    private BasketLineDto? DetailedLine =>
        State.Value.BasketOrderLines?.lines?.FirstOrDefault(line => line?.RecId == CurrentLine?.RecId);

    private DotNetObjectReference<Lines>? _dotNetHelper;

    private bool IsItemIdEditable { get; set; }
    private bool IsNameEditable { get; set; }
    private bool IsDiscountTypeEditable { get; set; }
    private bool IsLineAmountEditable { get; set; }

    private bool _isLoading = true;

    protected override FetchLinesAction CreateFetchAction(LinesState state) =>
    new(state);

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UpdateReasons = RessourcesState?.Value.UpdateReasons
            ?? throw new ArgumentNullException("Unexpected null for UpdateReasons object.");
        LogisticFlows = RessourcesState?.Value.LogisticFlows
            ?? throw new ArgumentNullException("Unexpected null for LogisticFlows object.");

        _dotNetHelper = DotNetObjectReference.Create(this);
        JSRuntime.InvokeVoidAsync("registerCtrlIHandler", _dotNetHelper);
        Logger.LogDebug("Lines initialized");
    }


    protected override void CacheNewFields()
    {
        BasketOrderLinesDto = State?.Value.BasketOrderLines
            ?? throw new ArgumentNullException("Unexpected null for BasketOrderLines object.");
        if (BasketOrderLinesDto is not null && BasketOrderLinesDto.lines is not null && BasketOrderLinesDto.lines.Count > 0)
        {
            IsItemIdEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.ItemId);
            IsNameEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.Name);
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
        List<BasketLineDto?> items = [];
        
        await OnCopyItemsClick(LinesDataGridInstance.SelectedItems.ToList());
    }

    private async Task OnCopyItemsClick(BasketLineDto? LineRightClicked)
    {
        List<BasketLineDto?> items = [];
        items.Add(LineRightClicked);

        await OnCopyItemsClick(items);
    }

    private async Task OnCopyItemsClick(List<BasketLineDto> items)
    {
        var headers = new[] { "Code article", "Quantité", "Prix unitaire" };

        string formattedData = DataFormatter.GenerateTabSeparatedData(
            data: items,
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

    private async Task OnDuplicateItemsClick(BasketLineDto? LineRightClicked)
    {
        var selectedItemsNums = GetRightClickedItemNums(LineRightClicked);
        if (selectedItemsNums is null)
            return; // Show a message to the user
        await OnDuplicateItemsClick(selectedItemsNums, "Voulez-vous dupliquer cette ligne?");
    }

    private async Task OnDuplicateItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        await OnDuplicateItemsClick(selectedItemsNums, "Voulez-vous dupliquer les lignes sélectionnées?");
    }

    private async Task OnDuplicateItemsClick(List<int> items, string message)
    {
        await ModalService.ShowConfirmationDialog(message,
           onConfirm: () =>
           {
               Dispatcher.Dispatch(new DuplicateLinesAction(items));
               LinesDataGridInstance.SelectedItems.Clear();
           });
    }

    private async Task OnDeleteItemsClick(BasketLineDto? LineRightClicked)
    {
        var selectedItemsNums = GetRightClickedItemNums(LineRightClicked);
        if (selectedItemsNums is null)
            return; // Show a message to the user

        await OnDeleteItemsClick(selectedItemsNums, "Voulez-vous supprimer cette ligne??");
    }
    private async Task OnDeleteItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        await OnDeleteItemsClick(selectedItemsNums, "Voulez-vous supprimer les lignes sélectionnées?");
    }

    private async Task OnDeleteItemsClick(List<int> items, string message)
    {
        await ModalService.ShowConfirmationDialog(message,
            onConfirm: () =>
            {
                Dispatcher.Dispatch(new DeleteLinesAction(items));
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

    private List<int>? GetRightClickedItemNums(BasketLineDto? LineRightClicked)
    {
        List<int> selectedItemsNums = [];
        if (LineRightClicked != null)
        {
            if (LineRightClicked.LineNum?.Value != null)
            {
                selectedItemsNums.Add((int)LineRightClicked?.LineNum?.Value!);
            }
        }
        return selectedItemsNums;
    }

    private bool IsAnyItemSelected() =>
        LinesDataGridInstance.SelectedItems.Count > 0;


    //open add line dialog
    private async Task<IDialogReference> OpenAddLineDialogAsync()
    {
        return await ModalService.OpenAddLineDialogAsync(() =>
                   Dispatcher.Dispatch(new ResetNewLineAction()));
    }

    [JSInvokable("CtrlIPressed")]
    public async void CtrlIPressed()
    {
        Logger.LogDebug("CtrlIPressed called");
        await OpenAddLineDialogAsync();
    }

    private void RowClicked(DataGridRowClickEventArgs<BasketLineDto> ClickedRow)
    {
        CurrentLine = ClickedRow.Item;
    }

    private MudMenu _contextMenu = null!;

    private async Task RowRightClicked(DataGridRowClickEventArgs<BasketLineDto> ClickedRow)
    {
        LineRightClicked = ClickedRow.Item;
        await _contextMenu.OpenMenuAsync(ClickedRow.MouseEventArgs);
    }

    private string RowStyleFunc(BasketLineDto? line, int index) =>
        line == CurrentLine
            ? "background-color : #cce4ff; color: #084298"
            : string.Empty;
}