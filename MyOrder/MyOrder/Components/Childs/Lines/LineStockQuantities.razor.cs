using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Lines;

partial class LineStockQuantities
{
    [Parameter]
    public BasketLineDto? BasketLine { get; set; }

    [Parameter, EditorRequired]
    public List<BasketValueDto?>? UpdateReasons { get; set; }

    [Parameter, EditorRequired]
    public List<BasketValueDto?>? LogisticFlows { get; set; }

    private bool DelivaryDateReadOnly(BasketLineDto basketLineDto)
    {
        if (!FieldUtility.IsReadOnly(basketLineDto.DeliveryDate) && !FieldUtility.IsReadOnly(basketLineDto.IsCustomDeliveryDate) && basketLineDto.IsCustomDeliveryDate?.Value == true)
            return false;
        return true;
    }

}
