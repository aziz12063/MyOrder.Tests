using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.TradeInfoUseCase;

public record FetchTradeInfoAction() : FetchDataActionBase;

public record FetchTradeInfoSuccessAction(BasketTradeInfoDto BasketTradeInfo);

public record FetchTradeInfoFailureAction(string ErrorMessage);