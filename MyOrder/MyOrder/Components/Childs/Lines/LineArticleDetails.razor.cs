using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;

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
   
    private BasketValueDto? UpdateReasonValue
    {
        get => BasketLine?.UpdateReason?.Value;
        set => SetBasketOrderValue.InvokeAsync((BasketLine?.UpdateReason, value, value?.Value)); 
    }

    private int? LineNumValue
    {
        get => BasketLine?.LineNum?.Value;
        set => SetBasketOrderValue.InvokeAsync((BasketLine?.LineNum,  value,  value?.ToString()));
    }

    private string? ProductInfoValue
    {
        get => BasketLine?.ProductInfo?.Value;
        set => SetBasketOrderValue.InvokeAsync((BasketLine?.ProductInfo, value, value));
    }

    private void HandlePopOverOnClick()
    {
        _openPopOver = !_openPopOver;
    }


}
