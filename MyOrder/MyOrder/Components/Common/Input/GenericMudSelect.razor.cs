using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Common.Input;

public enum DropdownItemsDisplay
{
    Value,
    Description,
    Combined
}

public partial class GenericMudSelect<T> : GenericInputBase<T>
{
    private const string OutlinedCssClass = "outlined-generic-select";

    private bool _isOpen;

    [Parameter, EditorRequired]
    public List<T>? Items { get; set; }
    [Parameter]
    public Variant Variant { get; set; } = Variant.Outlined;
    [Parameter]
    public string? Class { get; set; }
    [Parameter]
    public DropdownItemsDisplay DropdownItemsDisplay { get; set; } = DropdownItemsDisplay.Description;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (Variant == Variant.Outlined)
        {
            if (string.IsNullOrEmpty(Class))
                Class = OutlinedCssClass;
            else
                Class += OutlinedCssClass;
        }
    }

    //protected override void OnParametersSet()
    //{
    //    base.OnParametersSet();
    //    if (typeof(T) == typeof(BasketValueDto))
    //    {
    //        var basketValue = Field.Value as BasketValueDto;

    //        if (basketValue != null)
    //        {
    //            // Find the item in Items where item.Value matches value.Value
    //            innerValueProperty = (T?)(object?)Items?
    //                .OfType<BasketValueDto>()
    //                .FirstOrDefault(item => item.Value == basketValue.Value);
    //        }
    //    }
    //    else
    //        innerValueProperty = ValueProperty;
    //}

    private void OnValueChanged(T newValue)
    {
        if (_isOpen)
            return;

        ValueChangedHandler(newValue);
    }

    /// <summary>
    /// Determines the display value of a basket item based on the specified display mode.
    /// </summary>
    /// <param name="basketItem">
    /// An instance of <see cref="BasketValueDto"/> containing the item's <see cref="BasketValueDto.Description"/>
    /// and <see cref="BasketValueDto.Value"/>.
    /// </param>
    /// <param name="dropdownItemsDisplay">
    /// Specifies the mode of display, determining whether to show the description, value, or a combination of both.
    /// </param>
    /// <returns>
    /// A formatted string representing the basket item's display value based on the selected <paramref name="dropdownItemsDisplay"/>.
    /// Returns "N/A" if neither description nor value is available.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The method handles three display modes as defined by the <see cref="DropdownItemsDisplay"/> enum:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DropdownItemsDisplay.Description"/>: 
    /// Displays the <see cref="BasketValueDto.Description"/> if available; otherwise, falls back to <see cref="BasketValueDto.Value"/>. 
    /// If neither is available, returns "N/A".
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DropdownItemsDisplay.Value"/>: 
    /// Displays the <see cref="BasketValueDto.Value"/> if available; otherwise, falls back to <see cref="BasketValueDto.Description"/>. 
    /// If neither is available, returns "N/A".
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DropdownItemsDisplay.Combined"/>: 
    /// Displays both <see cref="BasketValueDto.Description"/> and <see cref="BasketValueDto.Value"/> separated by a dash (" - ") if both are available.
    /// If only one is available, displays the available value.
    /// If neither is available, returns "N/A".
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// var basketItem = new BasketValueDto
    /// {
    ///     Description = "Premium Package",
    ///     Value = "€49.99"
    /// };
    /// 
    /// string displayValue = DisplayedValue(basketItem, DropdownItemsDisplay.Combined);
    /// // displayValue: "Premium Package - €49.99"
    /// 
    /// displayValue = DisplayedValue(basketItem, DropdownItemsDisplay.Description);
    /// // displayValue: "Premium Package"
    /// 
    /// var basketItemWithoutDescription = new BasketValueDto
    /// {
    ///     Description = null,
    ///     Value = "€19.99"
    /// };
    /// 
    /// displayValue = DisplayedValue(basketItemWithoutDescription, DropdownItemsDisplay.Description);
    /// // displayValue: "€19.99" (fallback to Value)
    /// 
    /// var emptyBasketItem = new BasketValueDto
    /// {
    ///     Description = null,
    ///     Value = null
    /// };
    /// 
    /// displayValue = DisplayedValue(emptyBasketItem, DropdownItemsDisplay.Combined);
    /// // displayValue: "N/A"
    /// </code>
    /// </example>
    public static string DisplayedValue(BasketValueDto basketItem, DropdownItemsDisplay dropdownItemsDisplay)
    {
        return dropdownItemsDisplay switch
        {
            DropdownItemsDisplay.Description => basketItem.Description?.Trim() switch
            {
                not null and { Length: > 0 } => basketItem.Description.Trim(),
                _ when !string.IsNullOrWhiteSpace(basketItem.Value) => basketItem.Value.Trim(),
                _ => "N/A",
            },

            DropdownItemsDisplay.Value => basketItem.Value?.Trim() switch
            {
                not null and { Length: > 0 } => basketItem.Value.Trim(),
                _ when !string.IsNullOrWhiteSpace(basketItem.Description) => basketItem.Description.Trim(),
                _ => "N/A",
            },

            DropdownItemsDisplay.Combined => (basketItem.Description?.Trim(), basketItem.Value?.Trim()) switch
            {
                (not null and { Length: > 0 }, not null and { Length: > 0 }) => $"{basketItem.Value.Trim()} - {basketItem.Description.Trim()}",
                (not null and { Length: > 0 }, _) => basketItem.Description.Trim(),
                (_, not null and { Length: > 0 }) => basketItem.Value.Trim(),
                _ => "N/A",
            },

            _ => "N/A",
        };
    }

    public void DropDownClosedHandler() => _isOpen = false;

    public void DropDownOpenedHandler() => _isOpen = true;
}
