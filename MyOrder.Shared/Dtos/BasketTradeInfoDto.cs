using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public record BasketTradeInfoDto(
    string? PanelLabel,

    [property: DisplayOnlyField]
    Field<List<BasketTurnoverLineDto?>>? Turnover,
    string? InformationSectionLabel,

    [property: DisplayOnlyField]
    Field<string?>? ActivityArea,

    [property: DisplayOnlyField]
    List<BasketValueDto?>? CustomerTags,
    string? ContractSectionLabel,
    BasketContractInfoDto? Contract);

public record BasketTurnoverLineDto(
    string? Name,
    string? Ytd,
    string? YtdN1,
    string? N1,
    string? N2);

public record BasketContractInfoDto(
    [property: DisplayOnlyField]
    Field<string?>? ContractId,

    [property: DisplayOnlyField]
    Field<string?>? ContractType,

    [property: DisplayOnlyField]
    Field<string?>? ContractGroup,

    [property: DisplayOnlyField]
    Field<string?>? Status,

    [property: DisplayOnlyField]
    Field<string?>? ContractDates,

    [property: DisplayOnlyField]
    Field<string?>? CampaignId,

    [property: DisplayOnlyField]
    Field<string?>? MainContact,

    [property: DisplayOnlyField]
    Field<string?>? OfficeExecutive,

    [property: DisplayOnlyField]
    Field<List<string?>>? DiscountList);
