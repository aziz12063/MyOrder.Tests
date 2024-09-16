using MyOrder.Shared.Dtos.SharedComponents;
namespace MyOrder.Shared.Dtos
{
    public class BasketOrderInfoDto
    {
        public string? PanelLabel { get; set; }
        public string? ContactSection { get; set; }
        public string? InformationSectionLabel { get; set; }
        public Field<AccountDto?>? Account { get; set; }
        public Field<ContactDto?>? Contact { get; set; }
        public Field<string?>? ActivityArea { get; set; }
        public List<BasketValueDto?>? CustomerTags { get; set; }
        public Field<BasketValueDto?>? SalesOriginId { get; set; }
        public Field<BasketValueDto?>? WebOriginId { get; set; }
        public Field<BasketValueDto?>? SalesPoolId { get; set; }
        public Field<string?>? CustomerOrderRef { get; set; }
        public Field<string?>? WebSalesId { get; set; }
        public Field<string?>? RelatedLink { get; set; }
        public Field<string?>? Note { get; set; }
    }
}
