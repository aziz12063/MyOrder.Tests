using Newtonsoft.Json;

namespace MyOrder.Shared.Dtos
{
    public class BasketOrderInfoDto
    {
        public Field<AccountDto> Account { get; set; } = new() { Value = new AccountDto() };
        public Field<ContactDto> Contact { get; set; } = new() { Value = new ContactDto() };
        public Field<string> ActivityArea { get; set; } = new() { Value = string.Empty };
        public List<string> CustomerTags { get; set; } = [];
        public Field<string> SalesOriginId { get; set; } = new() { Value = string.Empty };
        public Field<string> WebOriginId { get; set; } = new() { Value = string.Empty };
        public Field<string> SalesPoolId { get; set; } = new() { Value = string.Empty };
        public Field<string> CustomerOrderRef { get; set; } = new() { Value = string.Empty };
        public Field<string> RelatedLink { get; set; } = new() { Value = string.Empty };
        public Field<string> Note { get; set; } = new() { Value = string.Empty };
    }

    public class AccountDto
    {
        public string? AccountId { get; set; }
        public string? Name { get; set; }
        public string? Recipient { get; set; }
        public string? Building { get; set; }
        public string? Street { get; set; }
        public string? Locality { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CellularPhone { get; set; }
        public bool Blocked { get; set; }
    }

    public class ContactDto
    {
        public string? ContactId { get; set; }
        public string? SocialTitle { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CellularPhone { get; set; }
    }
}
