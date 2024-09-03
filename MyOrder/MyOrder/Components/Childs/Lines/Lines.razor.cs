using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.LinesUseCase;


namespace MyOrder.Components.Childs.Lines
{
    public partial class Lines : BaseFluxorComponent<LinesState, FetchLinesAction>
    {
       
        private BasketOrderLinesDto? BasketOrderLinesDto {  get; set; }
        private List<BasketValueDto?>? UpdateReasons { get; set; }
        private List<BasketValueDto?>? LogisticFlows { get; set; }
        private BasketLineDto? basketLineDto { get; set; }
        private List<BasketLineDto>? selectedBasketLineDto { get; set; }

        protected override void CacheNewFields()
        {
            BasketOrderLinesDto = State.Value.BasketOrderLines ?? throw new NullReferenceException("Unexpected null for BasketOrderLines object.");
            UpdateReasons = State.Value.UpdateReasons;
            LogisticFlows = State.Value.LogisticFlows;
            selectedBasketLineDto = new List<BasketLineDto>();
        }
 
        protected override FetchLinesAction CreateFetchAction(LinesState state, string basketId)
        {
            return new FetchLinesAction(state, basketId);
        }

        MudDataGrid<BasketLineDto> dataGrid = new();



        string test = "";
        private void OnValueChange<T>(T value, BasketLineDto row, MyOrder.Shared.Dtos.SharedComponents.Field<T?> field, int? lineNbr)
        {
            if (lineNbr != null && lineNbr == row.LineNum.Value)
            {

                //basketLineDto = row;
                Console.WriteLine("Line nbr: " + row.LineNum.Value);
                Console.WriteLine("the new value: " + value);

                field.Value = value;
                SetBasketOrderValue(field: field, value: value, procedureCallValue: value?.ToString());
                // Console.WriteLine("UpdateReasonString: " + UpdateReasonString);
                Console.WriteLine("UpdateReason: " + row.UpdateReason.Value);

            }

        }

      

        void HandleRowDoubleClick(MouseEventArgs args, BasketLineDto item)
        {
            Console.WriteLine("the HandleRowDoubleClick is double clicked");
        }

        void RowClicked(DataGridRowClickEventArgs<BasketLineDto> args)
        {
            basketLineDto = args.Item;
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


