namespace MyOrder.Shared.Dtos;

public record AccountDto(
    string? AccountId,
    string? Name,
    string? Recipient,
    string? Building,
    string? Street,
    string? Locality,
    string? ZipCode,
    string? City,
    string? Country,
    string? Email,
    string? Phone,
    string? CellularPhone,
    bool? Blocked,
    DateTime? LastOrderDate,
    bool? IsLinked)
{
    public override string ToString() =>
        string.Join(" - ", new[]
            {
                AccountId,
                Name,
                ZipCode
            }
            .Where(s => !string.IsNullOrWhiteSpace(s)));

    public List<string> GetAddressAsAList()
    {
        var address = new List<string>();

        AddIfNotNullOrEmpty(Name);
        AddIfNotNullOrEmpty(Recipient);
        AddIfNotNullOrEmpty(Building);
        AddIfNotNullOrEmpty(Street);
        AddIfNotNullOrEmpty(Locality);
        AddIfNotNullOrEmpty($"{ZipCode} - {City}");
        AddIfNotNullOrEmpty(Country);

        return address.Count > 0 ? address : [];

        void AddIfNotNullOrEmpty(string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                address.Add(value);
            }
        }
    }

    public string GetAddressInlined()
    {
        var parts = new[] { Building, Street, Locality }
                        .Where(s => !string.IsNullOrWhiteSpace(s));
        return string.Join(", ", parts);
    }
}