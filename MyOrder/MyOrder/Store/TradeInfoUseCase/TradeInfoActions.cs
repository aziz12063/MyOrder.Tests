using MyOrder.Shared.Dtos;

namespace MyOrder.Store.TradeInfoUseCase
{
    public class FetchTradeInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchTradeInfoSuccessAction(BasketTradeInfoDto? basketTradeInfo)
    {
        public BasketTradeInfoDto? BasketTradeInfo { get; } = basketTradeInfo;
    }

    public class FetchTradeInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }

}
