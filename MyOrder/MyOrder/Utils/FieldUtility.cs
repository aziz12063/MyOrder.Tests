using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Utils;

public static class FieldUtility
{
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