using System.Collections.Immutable;

namespace MyOrder.Shared.Dtos.Lines;

#warning TODO: Refactor to use BasketLineDto only
public record BasketOrderLinesDto(ImmutableList<BasketLineDto?>? Lines);