using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Lines;

partial class LineStockQuantities
{
    [Parameter]
    public BasketLineDto? BasketLine { get; set; }

    [Parameter]
    public EventCallback<(dynamic?, dynamic?, string?)> SetBasketOrderValue { get; set; }

    private BasketValueDto? LogisticFlowValue
    {
        get => BasketLine?.LogisticFlow?.Value;
        set => SetBasketOrderValue(field: BasketLine?.LogisticFlow, value: value, procedureCallValue: value?.Value);
    }

    private bool? IsCustomDeliveryDateValue
    {
        get => BasketLine?.IsCustomDeliveryDate?.Value;
        set => SetBasketOrderValue(field: BasketLine?.IsCustomDeliveryDate, value: value, procedureCallValue: value?.ToString());
    }

    private string? InventLocationIdValue
    {
        get => BasketLine?.InventLocationId?.Value;
        set => SetBasketOrderValue(field: BasketLine?.InventLocationId, value: value, procedureCallValue: value);
    }
    private string? DeliveryDateValue
    {
        get => BasketLine?.DeliveryDate?.Value;
        set => SetBasketOrderValue(field: BasketLine?.DeliveryDate, value: value, procedureCallValue: value);
    }


}
