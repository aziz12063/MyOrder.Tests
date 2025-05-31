using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Globalization;

namespace MyOrder.Components.Common.UI;

public enum DisplayFieldFormat
{
    None,
    Currency,
    Percentage,
    Weight,
    Volume,
    Date,
    Time,
    DateTime,
}

public partial class DisplayField<T>
{
    private const string OutlinedDisplayFieldClass = "outlined-display-field";
    private const string FixedMultiLineClass = "fixed-multiline-display-field";
    private const string MultilineFactorParameter = "--multiple-factor";

    [Parameter, EditorRequired]
    public Field<T>? Field { get; set; }
    [Parameter]
    public Adornment Adornment { get; set; } = Adornment.None;
    [Parameter]
    public string AdornmentIcon { get; set; } = Icons.Material.Filled.IntegrationInstructions;
    [Parameter]
    public Color AdornmentColor { get; set; }
    [Parameter]
    public bool IsMarkupString { get; set; } = false;
    [Parameter]
    public bool FixedMultilineHeight { get; set; } = false;
    [Parameter]
    public int Lines { get; set; } = 1;
    [Parameter]
    public DisplayFieldFormat Format { get; set; } = DisplayFieldFormat.None;
    [Parameter]
    public string AdornmentText { get; set; } = string.Empty;

    private string InternalCssClass { get; set; } = string.Empty;
    private string Style { get; set; } = string.Empty;
    private string? TooltipText => Field?.Description ??
        Field?.Name;

    private string? TextStyle => Field?.Color is not null ?
        $"color: {Field.Color}; font-weight: bolder;" : string.Empty;

    protected override void OnParametersSet()
    {
        InternalCssClass = Field?.DisplayStyle switch
        {
            FieldDisplayStyle.Emphasize => string.Concat(
                OutlinedDisplayFieldClass, " ", "onlyfordisplay-field-emphasize"),
            FieldDisplayStyle.Warn => string.Concat(
                OutlinedDisplayFieldClass, " ", "onlyfordisplay-field-warn"),
            _ => OutlinedDisplayFieldClass
        };

        if (FixedMultilineHeight)
        {
            Style = MultilineFactorParameter + ": " + Lines + ";";
            InternalCssClass = string.Concat(InternalCssClass, " ", FixedMultiLineClass);
        }

    }

}
