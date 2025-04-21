using MyOrder.Components.Childs.Header;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.PricesInfoUseCase;

public class FetchPricesInfoAction(PricesInfoState state) : FetchDataActionBase(state)
{ }

public class FetchPricesInfoSuccessAction(BasketPricesInfoDto? pricesInfo)
{
    public BasketPricesInfoDto? PricesInfo { get; } = pricesInfo;
}

public class FetchPricesInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
