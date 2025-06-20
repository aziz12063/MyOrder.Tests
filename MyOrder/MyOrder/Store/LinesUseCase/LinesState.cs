using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.LinesUseCase;

[FeatureState]
[GenerateFieldReducers]
public record LinesState(
    BasketOrderLinesDto BasketOrderLines) : StateBase
{
    public LinesState() : this((BasketOrderLinesDto)null!) { }
}