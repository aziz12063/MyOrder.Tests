using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Components.Common.UI;

public partial class DisplayField<T>
{
    [Parameter, EditorRequired]
    public Field<T>? Field { get; set; }
    private string CssClass { get; set; } = "outlined-display-field";
    private string? TooltipText => Field?.Description ?? Field?.Name;

    protected override void OnParametersSet()
    {
        CssClass = Field!.DisplayStyle switch
        {
            FieldDisplayStyle.Emphasize => string.Concat(
                CssClass, " ", "onlyfordisplay-field-emphasize"),
            FieldDisplayStyle.Warn => string.Concat(
                CssClass, " ", "onlyfordisplay-field-warn"),
            _ => CssClass
        };
    }
}
