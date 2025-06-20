using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public record ContactSectionActions(
    [property: DisplayOnlyField]
    Field<string?>? SalesforceLink,
    [property: DisplayOnlyField]
    Field<string?>? ClickToCall);