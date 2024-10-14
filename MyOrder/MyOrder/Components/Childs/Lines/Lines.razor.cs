using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
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
    private List<BasketLineDto>? selectedBasketLineDto { get; set; }
    private bool IsLineNbrEditable { get; set; }
    private bool IsItemIdEditable { get; set; }
    private bool IsNameEditable { get; set; }
    private bool IsInventLocationIdEditable { get; set; }
    private bool IsSalesQuantityEditable { get; set; }
    private bool IsSalesPriceEditable { get; set; } // not yet
    private bool IsDiscountTypeEditable { get; set; }
    private bool IsLineAmountEditable { get; set; }
    private bool IsDiscountRateEditable { get; set; }
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
        selectedBasketLineDto = new List<BasketLineDto>();
        if (BasketOrderLinesDto is not null && BasketOrderLinesDto.lines is not null && BasketOrderLinesDto.lines.Count > 0)
        {
            IsLineNbrEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.LineNum);
            IsItemIdEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.ItemId);
            IsNameEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.Name);
            IsInventLocationIdEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.InventLocationId);
            IsSalesQuantityEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.SalesQuantity);
            IsDiscountTypeEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.DiscountType);
            IsLineAmountEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.LineAmount);
            IsDiscountRateEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.DiscountRate);
            IsSalesPriceEditable = FieldUtility.IsReadWrite(BasketOrderLinesDto.lines[0]?.SalesPrice);
        }
        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    protected override FetchLinesAction CreateFetchAction(LinesState state, string basketId)
    {
        return new FetchLinesAction(state, basketId);
    }

    MudDataGrid<BasketLineDto> dataGrid = new();

    // is called when chekbox a row
    void SelectedItemsChanged(HashSet<BasketLineDto> items)
    {
        // selectedBasketLineDto.Clear();
        selectedBasketLineDto = items.ToList();
    }

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


