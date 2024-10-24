using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
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
    public static bool IsReadWrite<T>(Field<T>? field) => field?.Status == "readWrite";
    public static bool IsRequired<T>(Field<T>? field) => field?.Status == "required";
    public static string NullOrWhiteSpaceHelper(string? value) => string.IsNullOrWhiteSpace(value) ? string.Empty : value;
    public static string NullOrWhiteSpaceHelperWithDash(string? value)
        => string.IsNullOrWhiteSpace(value) ? "-" : value;
    public static MarkupString MarkupStringHelper(string? value)
       => string.IsNullOrWhiteSpace(value) ? new MarkupString(string.Empty)
        : new MarkupString(value);

    /// <summary>
    /// Returns the value of the field if it's not null; otherwise, returns the default numeric value (e.g., 0).
    /// </summary>
    /// <typeparam name="T">A numeric type implementing INumber&lt;T&gt;.</typeparam>
    /// <param name="field">The field containing the nullable numeric value.</param>
    /// <returns>The numeric value or the default if null.</returns>
    public static T NullNumberHelper<T>(Field<T?>? field) where T : struct, INumber<T> =>
        field?.Value ?? T.Zero;
    //field is null || field.Value is null ? T.Zero
    //: field.Value;

    public static decimal? NullOrWhiteSpaceHelper(decimal? value) => value == null || value == 0 ? 0 : value;// i will make the return non-nullable
    public static int? NullOrWhiteSpaceHelper(int? value) => value == null || value == 0 ? 0 : value;// i will make the return non-nullable
    public static bool NullOrWhiteSpaceHelper(bool? value) => value ?? false;// i will make the return non-nullable

    public static string SelectedAccount(AccountDto? account) => account?.ToString() ?? string.Empty;
    public static List<string>? CreateAddressList(AccountDto? account)
    {
        if (account == null) return null;

        var address = new List<string>();

        AddIfNotNullOrEmpty(account.Recipient);
        AddIfNotNullOrEmpty(account.Building);
        AddIfNotNullOrEmpty(account.Street);
        AddIfNotNullOrEmpty($"{account.ZipCode} - {account.City}");
        AddIfNotNullOrEmpty(account.Country);

        return address.Count > 0 ? address : null;

        void AddIfNotNullOrEmpty(string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                address.Add(value);
            }
        }
    }

    public static string DisplayAddress(List<string?>? address) => address is var addressList && addressList != null
        ? string.Join("\n", addressList)
        : string.Empty;

    public static string DisplayListNoSpace(List<string?>? list) => list is var newList && newList != null
        ? string.Join("\n", newList)
        : string.Empty;



}