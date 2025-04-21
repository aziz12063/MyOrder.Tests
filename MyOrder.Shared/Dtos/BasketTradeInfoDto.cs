using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public class BasketTradeInfoDto
{
    public string? PanelLabel { get; set; }
    public Field<List<BasketTurnoverLineDto?>>? Turnover { get; set; }
    public string? InformationSectionLabel { get; set; }
    public Field<string?>? ActivityArea { get; set; }
    public List<BasketValueDto?>? CustomerTags { get; set; }
    public string? ContractSectionLabel { get; set; }
    public BasketContractInfoDto? Contract { get; set; }
}
public class BasketTurnoverLineDto
{
    public string? Name { get; set; }
    public string? Ytd { get; set; }
    public string? YtdN1 { get; set; }
    public string? N1 { get; set; }
    public string? N2 { get; set; }

}

public class BasketContractInfoDto
{
    public Field<string?>? ContractId { get; set; }
    public Field<string?>? ContractType { get; set; }
    public Field<string?>? ContractGroup { get; set; }
    public Field<string?>? Status { get; set; }
    public Field<string?>? ContractDates { get; set; }
    public Field<string?>? CampaignId { get; set; }
    public Field<string?>? MainContact { get; set; }
    public Field<string?>? OfficeExecutive { get; set; }
    public Field<List<string?>>? DiscountList { get; set; }
}
