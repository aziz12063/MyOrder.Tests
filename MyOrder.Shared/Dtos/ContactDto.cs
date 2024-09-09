namespace MyOrder.Shared.Dtos;

public class ContactDto
{
    public string? ContactId { get; set; }
    public string? SocialTitle { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CellularPhone { get; set; }

    public override string ToString() => $"{LastName} {FirstName}";

    public override bool Equals(object? obj) => obj is ContactDto dto && dto.ContactId == ContactId;
    public override int GetHashCode() => ContactId?.GetHashCode() ?? 0;
    public static bool operator ==(ContactDto left, ContactDto right) => left.Equals(right);
    public static bool operator !=(ContactDto left, ContactDto right) => !(left == right);
}