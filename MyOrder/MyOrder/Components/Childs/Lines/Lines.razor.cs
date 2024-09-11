using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.LinesUseCase;
using MyOrder.Utils;
using static MudBlazor.CategoryTypes;


namespace MyOrder.Components.Childs.Lines
{
    public partial class Lines : BaseFluxorComponent<LinesState, FetchLinesAction>
    {
        [Inject] IDialogService DialogService { get; set; }
        private BasketOrderLinesDto? BasketOrderLinesDto { get; set; }
        private List<BasketValueDto?>? UpdateReasons { get; set; }
        private List<BasketValueDto?>? LogisticFlows { get; set; }
        private BasketLineDto? basketLineDto { get; set; }
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
        int? selectedLine;


        protected override void CacheNewFields()
        {
            BasketOrderLinesDto = State.Value.BasketOrderLines ?? throw new NullReferenceException("Unexpected null for BasketOrderLines object.");
            UpdateReasons = State.Value.UpdateReasons;
            LogisticFlows = State.Value.LogisticFlows;
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
        }

        protected override FetchLinesAction CreateFetchAction(LinesState state, string basketId)
        {
            return new FetchLinesAction(state, basketId);
        }

        MudDataGrid<BasketLineDto> dataGrid = new();



        private string NullableChek(BasketLineDto basketLineDto, Field<string> field, string value)
        {
            if (basketLineDto != null && field != null)
                return value;

            return string.Empty;
        }
         
       
       
        private void OnValueChange<T>(T value , BasketLineDto? row, Field<T?>? field, int? lineNbr)
        {
            if (lineNbr != null && lineNbr == row?.LineNum?.Value)
            {

                //basketLineDto = row;
                Console.WriteLine("Line nbr: " + row.LineNum.Value);
                Console.WriteLine("the new value: " + value);

                //if(value is int?  && field is Field<int?>)
                //{
                //    int x = Convert.ToInt32(value) ;
                //    if(CheckQuantityValue(x) != null)
                //    {
                //        return;
                //    }
                //}
                //    Logger.LogInformation($"in second else");
                    field!.Value = value;
                
                SetBasketOrderValue(field: field, value: value, procedureCallValue: value?.ToString());
                // Console.WriteLine("UpdateReasonString: " + UpdateReasonString);
            }
        }
        void HandleIntervalElapsed(string debouncedText)
        {
            //int value = Int32.Parse(debouncedText);
            //CheckQuantityValue(value);
        }

        private string? CheckQuantityValue(int? value)
        {
            if (value == null || value == 0)
                return "Quatity is required";
            if (value % 25 != 0)
            {
                return "Quantity don't match ";
            }
            return null;
        }

        // is called when a cell is modifyed
        private void CommittedItemChanges(BasketLineDto item)
        {
           
            Logger.LogInformation($"CommittedItemChanges is called for line nbr {item.LineNum?.Value}");
            
        }
        private string RowStyleFunc(BasketPriceLine x, int index, BasketLineDto item)
        {
           
            string style = "";
            int quantite = item?.SalesQuantity?.Value ?? 0;
            if (x.quantity == 25 && quantite < 100)
                style = "background-color:#8CED8C";

            else if (x.quantity == 100 && quantite >= 100 && quantite < 200)
                style = "background-color:#8CED8C";

            else if (x.quantity == 200 && quantite >= 200 && quantite < 400)
                style += "background-color:#8CED8C";

            else if (x.quantity == 400 && quantite >= 400 && quantite < 800)
                style += "background-color:#8CED8C";

            if (x.quantity > 500 && quantite >= 800 )
                style += "background-color:#8CED8C";

            return style;
        }

        void HandleRowDoubleClick(MouseEventArgs args, BasketLineDto item)
        {
            
            Console.WriteLine("the HandleRowDoubleClick is double clicked");
           
        }

       
        void HandlePopOverOnClick(int? linNbr)
        {
            selectedLine = linNbr;
        }
         bool OpenPopoverChecker(int? linNbr)
        {
            Logger.LogInformation($"parameter is: {linNbr}");
           

            if (selectedLine == linNbr)
                return true;

            return false;
        }

        private bool DelivaryDateReadOnly(BasketLineDto basketLineDto)
        {
            if (!FieldUtility.IsReadOnly(basketLineDto.DeliveryDate) && !FieldUtility.IsReadOnly(basketLineDto.IsCustomDeliveryDate) && basketLineDto.IsCustomDeliveryDate?.Value == true)
                return false;
            return true;
        }


        void RowClicked(DataGridRowClickEventArgs<BasketLineDto> args)
        {
            basketLineDto = args.Item;
            Logger.LogInformation("row clicked");
        }



        string BackgroundColor(BasketLineDto arg, int index) // it's called twice i don't know why
        {
            if (arg.LineNum?.Value == basketLineDto?.LineNum?.Value)
            {
                return "background-color:#5499c7";
            }
            return "";
        }

        // is called when chekbox a row
        void SelectedItemsChanged(HashSet<BasketLineDto> items)
        {
            // selectedBasketLineDto.Clear();
            selectedBasketLineDto = items.ToList();
        }


        //private async Task AddLine()
        //{
        //    await DialogService.OpenAsync<AddLines>("Add Line", new Dictionary<string, object>()
        //    {
        //        { "LineAddedCallback", EventCallback.Factory.Create<LineDto>(this, OnLineAdded) }
        //    });

        //}

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
}


