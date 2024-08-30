using Fluxor;
using Microsoft.AspNetCore.Components;
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
            basketLineDto = new();
        }

        protected override FetchLinesAction CreateFetchAction(LinesState state, string basketId)
        {
            return new FetchLinesAction(state, basketId);
        }

        private string UpdateReasonString
        {
            get => GetFieldValue(basketLineDto?.UpdateReason?.Value);
            set => SetBasketOrderValue(field: basketLineDto?.UpdateReason, value: value, procedureCallValue: value);

        }

        private string LogisticFlowString
        {
            get => GetFieldValue(basketLineDto?.LogisticFlow?.Value);
            set => SetBasketOrderValue(field: basketLineDto?.LogisticFlow, value: value, procedureCallValue: value);

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


