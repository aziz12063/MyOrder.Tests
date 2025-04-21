using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.TradeInfoUseCase;

public class FetchTradeInfoAction(TradeInfoState state) : FetchDataActionBase(state)
{ }

public class FetchTradeInfoSuccessAction(BasketTradeInfoDto? basketTradeInfo)
{
    public BasketTradeInfoDto? BasketTradeInfo { get; } = basketTradeInfo;
}

public class FetchTradeInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
