using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.TradeInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record TradeInfoState(
    BasketTradeInfoDto BasketTradeInfo) : StateBase
{
    public TradeInfoState() : this((BasketTradeInfoDto)null!) { }
}