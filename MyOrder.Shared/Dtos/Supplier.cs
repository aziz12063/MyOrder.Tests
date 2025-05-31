namespace MyOrder.Shared.Dtos;

public record Supplier(
    string SupplierId,
    string Name,
    string Recipient,
    string Building,
    string Street,
    string Locality,
    string ZipCode,
    string City,
    string County,
    string Country,
    string Email,
    string Phone,
    string CellularPhone,
    bool Blocked
)
{
    public override string ToString() => $"{SupplierId} - {Name} - {ZipCode}";
}