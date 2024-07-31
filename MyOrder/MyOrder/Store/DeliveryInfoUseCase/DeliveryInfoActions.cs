using MyOrder.Shared.Dtos;

namespace MyOrder.Store.DeliveryInfoUseCase
{
    public class FetchDeliveryInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchDeliveryInfoSuccessAction(BasketDeliveryInfoDto basketDeliveryInfo)
    {
        public BasketDeliveryInfoDto BasketDeliveryInfo { get; } = basketDeliveryInfo;
    }

    public class FetchDeliveryInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
