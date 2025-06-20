namespace MyOrder.Shared.Dtos;

public record ContactDto(
    string? ContactId,
    string? SocialTitle,
    string? FirstName,
    string? LastName,
    string? Email,
    string? Phone,
    string? CellularPhone,
    string? Description)
{
    public override string ToString() => Description ?? "NO_DESCRIPTION_PROVIDED";
    public string FullName => $"{SocialTitle} {FirstName} {LastName}".Trim();
}