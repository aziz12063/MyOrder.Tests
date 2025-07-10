using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common.UI;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Globalization;
using System.Numerics;

namespace MyOrder.Utils;

public static class FieldUtility
{
    /// <summary>
    /// Returns true if the field is null or if its status is set to hidden; otherwise, returns false.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <returns></returns>
    public static bool IsHidden<T>(Field<T>? field) => field == null || field?.Status == "hidden";
    // Refactor to use readOnly and onlyForDisplay
    public static bool IsReadOnly<T>(Field<T>? field) => field?.Status == "readOnly";
    // Refactor to use Variant.Filled to reflect the actual status
    public static bool IsOnlyForDisplay<T>(Field<T>? field) => field?.Status == "onlyForDisplay";
    public static bool IsReadWrite<T>(Field<T>? field) => field?.Status == "readWrite" || IsRequired(field);
    public static bool IsRequired<T>(Field<T>? field) => field?.Status == "required";
    public static Color GetFieldColor<T>(Field<T>? field) => field?.DisplayStyle switch
    {
        FieldDisplayStyle.Standard => Color.Primary,
        FieldDisplayStyle.Emphasize => Color.Warning,
        FieldDisplayStyle.Warn => Color.Error,
        FieldDisplayStyle.Success => Color.Success,
        _ => Color.Inherit
    };

    public static string NullOrWhiteSpaceHelperWithDash(string? value)
        => string.IsNullOrWhiteSpace(value) ? "—" : value;

    public static MarkupString MarkupStringHelper(string? value, bool replaceWithDashIfEmpty = true) =>
        string.IsNullOrWhiteSpace(value)
        ? replaceWithDashIfEmpty
            ? new MarkupString("—")
            : new MarkupString()
        : new MarkupString(value.Replace("\n", "<br />"));

    public static MarkupString MarkupStringHelper(ICollection<string?>? strs, bool replaceWithDashIfEmpty = true) =>
        strs is { Count: > 0 }
        ? MarkupStringHelper(string.Join("<br />", strs), replaceWithDashIfEmpty)
        : MarkupStringHelper((string?)null, replaceWithDashIfEmpty);

    public static string FormatValue(object? value, DisplayFieldFormat format)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            return "—";

        var culture = CultureInfo.CurrentCulture;

        return format switch
        {
            DisplayFieldFormat.None => value.ToString()!,

            DisplayFieldFormat.Currency
                when value is IFormattable fCur
                => fCur.ToString("C2", culture)!,

            DisplayFieldFormat.Currency
                when decimal.TryParse(value.ToString(), NumberStyles.Any, culture, out var dCur)
                => dCur.ToString("C2", culture),

            DisplayFieldFormat.Percentage
                when value is IFormattable fPct
                => $"{fPct.ToString("0", culture)} %",

            DisplayFieldFormat.Percentage
                when decimal.TryParse(value.ToString(), NumberStyles.Any, culture, out var dPct)
                => $"{dPct:0} %",

            DisplayFieldFormat.Weight
                when decimal.TryParse(value.ToString(), NumberStyles.Any, culture, out var w)
                => $"{w:0.###} kg",

            DisplayFieldFormat.Volume
                when decimal.TryParse(value.ToString(), NumberStyles.Any, culture, out var v)
                => $"{v:0.######}\u00A0m\u00B3",

            DisplayFieldFormat.Date
                when value is DateTime dtDate
                => dtDate.ToString("d", culture),

            DisplayFieldFormat.Date
                when DateTime.TryParse(value.ToString(), culture, DateTimeStyles.None, out var dtDate2)
                => dtDate2.ToString("d", culture),

            DisplayFieldFormat.Time
                when value is DateTime dtTime
                => dtTime.ToString("t", culture),

            DisplayFieldFormat.Time
                when TimeSpan.TryParse(value.ToString(), culture, out var ts)
                => ts.ToString(@"hh\:mm"),

            DisplayFieldFormat.DateTime
                when value is DateTime dtDateTime
                => dtDateTime.ToString("g", culture),

            DisplayFieldFormat.DateTime
                when DateTime.TryParse(value.ToString(), culture, DateTimeStyles.None, out var dt2)
                => dt2.ToString("g", culture),

            _ => value.ToString()!
        };
    }

    /// <summary>
    /// Returns the value of the field if it's not null; otherwise, returns the default numeric value (e.g., 0).
    /// </summary>
    /// <typeparam name="T">A numeric type implementing INumber&lt;T&gt;.</typeparam>
    /// <param name="field">The field containing the nullable numeric value.</param>
    /// <returns>The numeric value or the default if null.</returns>
    public static T NullNumberHelper<T>(Field<T?>? field) where T : struct, INumber<T> =>
        field?.Value ?? T.Zero;

    //public static List<string>? CreateAddressList(AccountDto? account)
    //{
    //    if (account == null) return null;

    //    var address = new List<string>();

    //    AddIfNotNullOrEmpty(account.Recipient);
    //    AddIfNotNullOrEmpty(account.Building);
    //    AddIfNotNullOrEmpty(account.Street);
    //    AddIfNotNullOrEmpty(account.Locality);
    //    AddIfNotNullOrEmpty($"{account.ZipCode} - {account.City}");
    //    AddIfNotNullOrEmpty(account.Country);

    //    return address.Count > 0 ? address : null;

    //    void AddIfNotNullOrEmpty(string? value)
    //    {
    //        if (!string.IsNullOrWhiteSpace(value))
    //        {
    //            address.Add(value);
    //        }
    //    }
    //}

    //public static string DisplayAddress(List<string?>? address) => address is var addressList && addressList != null
    //    ? string.Join("\n", addressList)
    //    : string.Empty;

    public static string DisplayListNoSpace(List<string?>? list) => list is var newList && newList != null
        ? string.Join("\n", newList)
        : string.Empty;
}