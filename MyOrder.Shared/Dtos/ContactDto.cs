namespace MyOrder.Shared.Dtos;

public record ContactDto(
    string? ContactId,
    string? SocialTitle,
    string? FirstName,
    string? LastName,
    string? Email,
    string? Phone,
    string? CellularPhone)
{
    public override string ToString() => $"{LastName} {FirstName}";
}