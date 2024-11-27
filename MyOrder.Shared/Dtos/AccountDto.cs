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
    bool? Blocked)
{
    public override string ToString() => $"{AccountId} - {Name} - {ZipCode}";
}