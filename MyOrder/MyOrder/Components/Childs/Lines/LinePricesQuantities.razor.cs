using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Components.Childs.Lines;

partial class LinePricesQuantities
{
    [Parameter, EditorRequired]
    public BasketLineDto? BasketLine { get; set; }
    public BasketPriceLinesDto? BasketPrices { get; set; }

    protected override void OnParametersSet()
    {
        BasketPrices = BasketLine?.Prices;
    }

    private static string RowStyleFunc(BasketPriceLine? line) =>
        line?.IsCurrent == true
            ? "background-color : #cce4ff; color: #084298"
            : string.Empty;

}
