using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase
{
    public class FetchPricesInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchPricesInfoSuccessAction(BasketPricesInfoDto pricesInfo)
    {
        public BasketPricesInfoDto PricesInfo { get; } = pricesInfo;
    }

    public class FetchPricesInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
