using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Utils;
using MyOrder.Store.LinesUseCase;
using MyOrder.Store.NewLineUseCase;
using MyOrder.Utils;


namespace MyOrder.Components.Childs.Lines;

public partial class Lines : FluxorComponentBase<LinesState, FetchLinesAction>
{
    [Inject]
    IModalService ModalService { get; set; }
    private BasketOrderLinesDto? BasketOrderLinesDto { get; set; }
    protected List<BasketValueDto?>? UpdateReasons { get; set; }
    protected List<BasketValueDto?>? LogisticFlows { get; set; }
    public MudDataGrid<BasketLineDto> LinesDataGridInstance { get; set; }
    
    private bool IsItemIdEditable { get; set; }
    private bool IsNameEditable { get; set; }
    private bool IsDiscountTypeEditable { get; set; }
    private bool IsLineAmountEditable { get; set; }

    private bool isLoading = true;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UpdateReasons = RessourcesState?.Value.UpdateReasons
            ?? throw new ArgumentNullException("Unexpected null for UpdateReasons object.");
        LogisticFlows = RessourcesState?.Value.LogisticFlows
            ?? throw new ArgumentNullException("Unexpected null for LogisticFlows object.");
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
        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    protected override FetchLinesAction CreateFetchAction(LinesState state, string basketId) =>
        new FetchLinesAction(state, basketId);

    private void OnDuplicateItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        Dispatcher.Dispatch(new DuplicateLinesAction(
         BasketId, selectedItemsNums));
    }

    private void OnDeleteItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        Dispatcher.Dispatch(new DeleteLinesAction(
         BasketId, selectedItemsNums));
    }

    private void OnCopyItemsClick()
    {
        var selectedItemsNums = GetSelectedItemsNums();
        if (selectedItemsNums is null || selectedItemsNums.Count < 1)
            return; // Show a message to the user

        Logger.LogError("Copy items not implemented : {stackTrace}", LogUtility.GetStackTrace());
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

    MudDataGrid<BasketLineDto> dataGrid = new();

    private async Task<IDialogReference> OpenAddLineDialogAsync()
    {
        return await ModalService.OpenAddLineDialogAsync(() =>
            Dispatcher.Dispatch(new ResetNewLineAction(BasketId)));
    }

    //private void OnLineAdded(LineDto newLine)
    //{
    //    newLine.Ligne = lines.Count + 1; // Set the line number or other default values
    //    lines.Add(newLine);
    //    grid.Reload();
    //    Console.WriteLine("nbr of line = " + lines.Count.ToString());

    //}

    //private void OnDeleteLineClick()
    //{
    //    // Handle Delete Line button click event
    //    Console.WriteLine("Delete Line button clicked");
    //}
}


