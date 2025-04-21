using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Lines;

partial class LineStockQuantities
{
    [Parameter, EditorRequired]
    public BasketLineDto? BasketLine { get; set; }

    [Parameter, EditorRequired]
    public List<BasketValueDto?>? LogisticFlows { get; set; }
}
