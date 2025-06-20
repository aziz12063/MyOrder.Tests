using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.NewLineUseCase;

[FeatureState]
[GenerateFieldReducers]
public record NewLineState(BasketLineDto BasketLine) : StateBase
{
    public NewLineState() : this((BasketLineDto)null!) { }
}