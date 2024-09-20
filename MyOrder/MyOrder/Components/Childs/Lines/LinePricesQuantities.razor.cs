using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Lines;

partial class LinePricesQuantities
{
    [Parameter]
    public BasketLineDto? BasketLine { get; set; }
  
    [Parameter]
    public EventCallback<(dynamic?, dynamic?, string?)> SetBasketOrderValue { get; set; }

    private BasketValueDto? DiscountTypeValue
    {
        get => BasketLine?.DiscountType?.Value;
        set => SetBasketOrderValue.InvokeAsync((BasketLine?.DiscountType, value, value?.Value));
    }

    private decimal? DiscountRateValue
    {
        get => BasketLine?.DiscountRate?.Value;
        set => SetBasketOrderValue.InvokeAsync((BasketLine?.DiscountRate, value, value?.ToString()));
    }

    private decimal? DiscountPriceValue
    {
        get => BasketLine?.DiscountPrice?.Value;
        set => SetBasketOrderValue.InvokeAsync((BasketLine?.DiscountPrice, value, value?.ToString()));
    }

    private string? DiscountDescriptionValue
    {
        get => BasketLine?.DiscountDescription?.Value;
        set => SetBasketOrderValue.InvokeAsync(( BasketLine?.DiscountDescription, value, value));
    }

    protected string RowStyleFunc(BasketPriceLine x, int index, BasketLineDto item)
    {

        string style = "";
        int quantite = item?.SalesQuantity?.Value ?? 0;
        if (x.Quantity == 25 && quantite < 100)
            style = "background-color:#8CED8C";

        else if (x.Quantity == 100 && quantite >= 100 && quantite < 200)
            style = "background-color:#8CED8C";

        else if (x.Quantity == 200 && quantite >= 200 && quantite < 400)
            style += "background-color:#8CED8C";

        else if (x.Quantity == 400 && quantite >= 400 && quantite < 800)
            style += "background-color:#8CED8C";

        if (x.Quantity > 500 && quantite >= 800)
            style += "background-color:#8CED8C";

        return style;
    }

}
