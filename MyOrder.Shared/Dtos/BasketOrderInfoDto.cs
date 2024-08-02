namespace MyOrder.Shared.Dtos
{
    public class BasketOrderInfoDto
    {
        public Field<AccountDto> Account { get; set; } = new() { Value = new AccountDto() };
        public Field<ContactDto> Contact { get; set; } = new() { Value = new ContactDto() };
        public Field<string> ActivityArea { get; set; } = new() { Value = string.Empty };
        public List<BasketValueDto> CustomerTags { get; set; } = [];
        public Field<string> SalesOriginId { get; set; } = new() { Value = string.Empty };
        public Field<string> WebOriginId { get; set; } = new() { Value = string.Empty };
        public Field<string> SalesPoolId { get; set; } = new() { Value = string.Empty };
        public Field<string> CustomerOrderRef { get; set; } = new() { Value = string.Empty };
        public Field<string> WebSalesId { get; set; } = new() { Value = string.Empty };
        public Field<string> RelatedLink { get; set; } = new() { Value = string.Empty };
        public Field<string> Note { get; set; } = new() { Value = string.Empty };
    }
}
