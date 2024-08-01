using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.TradeInfoUseCase;

[FeatureState]
public class TradeInfoState
{
    public BasketTradeInfoDto BasketTradeInfo { get; } = new();
    public bool IsLoading { get; } = true;

    public TradeInfoState() { }

    public TradeInfoState(BasketTradeInfoDto basketTradeInfo)
    {
        BasketTradeInfo = basketTradeInfo;
        IsLoading = false;
    }
}

