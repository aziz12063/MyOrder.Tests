using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Components.Childs.Lines;

partial class LinePricesQuantities
{
    [Parameter, EditorRequired]
    public BasketLineDto? BasketLine { get; set; }
    public BasketPriceLinesDto? BasketPrices { get; set; }

    protected override void OnInitialized()
    {
        BasketPrices = BasketLine?.Prices;
    }
    protected string RowStyleFunc(BasketPriceLine? line) =>
        line?.IsCurrent == true
            ? "background-color:#8CED8C"
            : string.Empty;

}
