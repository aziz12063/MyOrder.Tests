namespace MyOrder.Shared.Dtos
{
    public class BasketGeneralInfoDto
    {
        public BasketCompany Company { get; set; }
        public string? OrderType { get; set; }
        public string? BasketId { get; set; }
        public string? OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderDate { get; set; }
        public string? SalesResponsible { get; set; }
    }

    public class BasketCompany
    {
        // N° de compte
        public string? GroupId { get; set; }

        // Raison sociale
        public string? Lang { get; set; }
    }
}
