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

    private void FormatField()
    {
        //This check makes us only get into the logic once 
        if (Adornment == Adornment.None
            && Format != DisplayFieldFormat.None
            && string.IsNullOrWhiteSpace(AdornmentText))
        {
            Console.WriteLine((Field?.Name ?? "No field name") + ": " + Style);
            Adornment = Adornment.End;
            switch (Format)
            {
                case DisplayFieldFormat.Currency:
                    var currencySymbol = GetCurrencySymbol();
                    AdornmentIcon = currencySymbol switch
                    {
                        "EUR" => Icons.Material.Filled.EuroSymbol,
                        "GBP" => Icons.Material.Filled.CurrencyPound,
                        _ => Icons.Material.Filled.AttachMoney // Defaults to $USD
                    };
                    Style = string.Concat(Style, " ", "text-align: right !important;");
                    break;
                case DisplayFieldFormat.Percentage:
                    AdornmentIcon = Icons.Material.Filled.Percent;
                    Style = string.Concat(Style, " ", "text-align: right !important;");
                    break;
                case DisplayFieldFormat.Weight:
                    Style = string.Concat(Style, " ", "text-align: right !important;");
                    AdornmentText = "Kg";
                    break;
                case DisplayFieldFormat.Volume:
                    Style = string.Concat(Style, " ", "text-align: right !important;");
                    AdornmentText = "m³";
                    break;
                case DisplayFieldFormat.Date:
                    AdornmentIcon = Icons.Material.Filled.CalendarToday;
                    break;
                case DisplayFieldFormat.Time:
                    AdornmentIcon = Icons.Material.Filled.Schedule;
                    break;
                case DisplayFieldFormat.DateTime:
                    AdornmentIcon = Icons.Material.Filled.Event;
                    break;
            }
        }
    }

    private static string GetCurrencySymbol()
    {
        var region = new RegionInfo(CultureInfo.CurrentCulture.Name);
        return region.ISOCurrencySymbol; // EUR, GBP, USD
    }

}
