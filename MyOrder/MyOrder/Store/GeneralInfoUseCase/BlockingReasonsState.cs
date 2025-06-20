using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.GeneralInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record BlockingReasonsState(
    BasketBlockingReasonsDto BlockingReasons) : StateBase
{
    public BlockingReasonsState() : this((BasketBlockingReasonsDto) null!) { }
}