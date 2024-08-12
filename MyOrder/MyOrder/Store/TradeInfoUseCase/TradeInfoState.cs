using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.TradeInfoUseCase;

[FeatureState]
public class TradeInfoState : StateBase
{
    public BasketTradeInfoDto? BasketTradeInfo { get; }

    public TradeInfoState() : base(true) { }

    public TradeInfoState(BasketTradeInfoDto? basketTradeInfo) : base(false)
    {
        BasketTradeInfo = basketTradeInfo;
    }
}

