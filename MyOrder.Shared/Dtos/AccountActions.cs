using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public record AccountActions(
    [property: DisplayOnlyField]
    Field<string?>? AddressLookup,

    [property: DisplayOnlyField]
    Field<string?>? SalesforceLink,

    [property: DisplayOnlyField]
    Field<string?>? ClickToCall,

    [property: DisplayOnlyField]
    Field<string?>? OrderInfo);