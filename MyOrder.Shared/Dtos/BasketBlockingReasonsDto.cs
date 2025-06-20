using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;
using System.Collections.Immutable;

namespace MyOrder.Shared.Dtos;

public record BasketBlockingReasonsDto(ImmutableList<BasketBlockingReasonDto?>? BlockingReasons);

public record BasketBlockingReasonDto(

    [property: DisplayOnlyField]
    Field<string?>? ReasonId,

    [property: DisplayOnlyField]
    Field<string?>? Description,

    Field<bool?>? IsActive,

    [property: DisplayOnlyField]
    Field<string?>? Comment);