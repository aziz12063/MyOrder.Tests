using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Services;
using System.Globalization;

namespace MyOrder.Components.Common.Input;

public partial class GenericTextField<T> : GenericInputBase<T>
{
    [Inject]
    private ICurrencyService Currency { get; set; }
    [Parameter]
    public int Lines { get; set; } = 1;
    [Parameter]
    public string? Format { get; set; }
    [Parameter]
    public Variant Variant { get; set; } = Variant.Outlined;
    [Parameter]
    public string Class { get; set; } = string.Empty;
    [Parameter]
    public bool ShrinkLabel { get; set; } = true;
    [Parameter]
    public Typo Typo { get; set; } = Typo.subtitle2;
    [Parameter]
    public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

    private MudTextField<T?>? TextField { get; set; }
    public CultureInfo? Culture { get; set; }
    private string cssClass = string.Empty;
    

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Culture = Currency.GetCurrency();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        // if (ReadOnly)
        // {
        //     //cssClass = ".readonly-field";

        // }
        // else if (readWrite)
        // {
        //     //cssClass = "readwrite-field";
        // }

        Format = FormatPercentValue(Format);
        cssClass = Class;
        if (Required)
            cssClass += " required-field";
        if (Variant == Variant.Outlined)
            cssClass += " outlined-generic-textfield";
    }

    private async Task KeyDownHandler(KeyboardEventArgs e) =>
        await OnKeyDown.InvokeAsync(e);

    public async ValueTask FocusAsync() =>
        await TextField!.FocusAsync();
}
