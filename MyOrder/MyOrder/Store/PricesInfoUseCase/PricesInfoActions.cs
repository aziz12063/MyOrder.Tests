using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.PricesInfoUseCase;

public record FetchPricesInfoAction() : FetchDataActionBase;

public record FetchPricesInfoSuccessAction(BasketPricesInfoDto PricesInfo);

public record FetchPricesInfoFailureAction(string ErrorMessage);