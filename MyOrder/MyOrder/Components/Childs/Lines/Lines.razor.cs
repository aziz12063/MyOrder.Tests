using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Common;
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

        protected void OnValueChange<T>(T value, Field<T?>? field)
        {
#warning "Logic for test purpose only. Do refactor."
             Logger.LogWarning($"the updated  value is {value} and the old value is {field.Value}");

                string? pcdCallValue;
                if (value is BasketValueDto basketValueDto)
                {
                    pcdCallValue = basketValueDto?.Value;
                }
                else
                {
                    pcdCallValue = value?.ToString();
                }
                SetBasketOrderValue(field: field, value: value, procedureCallValue: pcdCallValue);
        }
        protected void HandleIntervalElapsed(string debouncedText)
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
        
        void HandleRowDoubleClick(MouseEventArgs args, BasketLineDto item)
        {

            Console.WriteLine("the HandleRowDoubleClick is double clicked");

        }


        

        protected bool DelivaryDateReadOnly(BasketLineDto basketLineDto)
        {
            if (!FieldUtility.IsReadOnly(basketLineDto.DeliveryDate) && !FieldUtility.IsReadOnly(basketLineDto.IsCustomDeliveryDate) && basketLineDto.IsCustomDeliveryDate?.Value == true)
                return false;
            return true;
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


