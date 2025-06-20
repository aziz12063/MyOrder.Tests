using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public record BasketOrderInfoDto(
    AccountActions? AccountActions,
    string? PanelLabel,
    string? AccountSectionLabel,
    string? ContactSectionLabel,
    string? InformationSectionLabel,
    Field<AccountDto?>? Account,
    Field<ContactDto?>? Contact,
    ContactSectionActions? ContactActions,
    Field<BasketValueDto?>? SalesOriginId,
    Field<BasketValueDto?>? WebOriginId,
    Field<BasketValueDto?>? SalesPoolId,
    Field<string?>? CustomerOrderRef,
    Field<string?>? WebSalesId,
    Field<string?>? RelatedLink,
    
    [property: DisplayOnlyField]
    Field<string?>? Note);