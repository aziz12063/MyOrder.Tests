namespace MyOrder.Shared.Dtos.GeneralInformation;

public class GeneralInfoDto
{
    public string? PageTitle { get; set; }
    public BasketCompany? Company { get; set; }
    public string? OrderType { get; set; }
    public string? BasketId { get; set; }
    public string? OrderId { get; set; }
    public string? OrderStatus { get; set; }
    public string? OrderDate { get; set; }
    public string? SalesResponsible { get; set; }
    public BasketActions? Actions { get; set; }
}
