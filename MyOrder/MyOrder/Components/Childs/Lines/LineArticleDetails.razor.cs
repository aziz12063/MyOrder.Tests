using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Components.Childs.Lines;

public partial class LineArticleDetails
{
    private bool _openPopOver = false;
    
    [Parameter, EditorRequired]
    public BasketLineDto? BasketLine { get; set; }

    [Parameter, EditorRequired]
    public List<BasketValueDto?>? UpdateReasons { get; set; }

    [Parameter]
    public EventCallback<(dynamic?, dynamic?, string?)> SetBasketOrderValue { get; set; }

    private void HandlePopOverOnClick()
    {
        _openPopOver = !_openPopOver;
    }
}
