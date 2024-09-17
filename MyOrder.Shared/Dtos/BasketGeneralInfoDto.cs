namespace MyOrder.Shared.Dtos
{
    public class BasketGeneralInfoDto
    {
        public string? PageTitle { get; set; }
        public BasketCompany? Company { get; set; }
        public string? OrderType { get; set; }
        public string? BasketId { get; set; }
        public string? OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderDate { get; set; }
        public string? SalesResponsible { get; set; }
    }

    public class BasketCompany
    {
        public string? Name { get; set; }
        public string? CompanyId { get; set; }
        public string? GroupId { get; set; }
        public string? Locale { get; set; }
    }
}
