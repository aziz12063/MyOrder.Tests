using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Components.Childs.Lines;

partial class LinePricesQuantities
{
    [Parameter, EditorRequired]
    public BasketLineDto? BasketLine { get; set; }

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
