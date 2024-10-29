using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Components.Common.UI;

public partial class DisplayField<T>
{
    [Parameter, EditorRequired]
    public Field<T>? Field { get; set; }
    [Parameter]
    public bool IsMarkupString { get; set; } = false;
    [Parameter]
    public bool FixedMultilineHeight { get; set; } = false;
    private string CssClass { get; set; } = string.Empty;
    public string OutlinedDisplayFieldClass { get; set; } = "outlined-display-field";
    private string FixedMultiLineClass { get; set; } = "fixed-multiline-display-field";
    private string? TooltipText => Field?.Description ??
        Field?.Name;

    protected override void OnParametersSet()
    {
        CssClass = Field?.DisplayStyle switch
        {
            FieldDisplayStyle.Emphasize => string.Concat(
                OutlinedDisplayFieldClass, " ", "onlyfordisplay-field-emphasize"),
            FieldDisplayStyle.Warn => string.Concat(
                OutlinedDisplayFieldClass, " ", "onlyfordisplay-field-warn"),
            _ => OutlinedDisplayFieldClass
        };

        if (FixedMultilineHeight)
        {
            CssClass = string.Concat(CssClass, " ", FixedMultiLineClass);
        }
    }

}
