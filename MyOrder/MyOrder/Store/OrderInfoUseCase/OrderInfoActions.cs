using MyOrder.Shared.Dtos;

namespace MyOrder.Store.OrderInfoUseCase
{
    public class FetchOrderInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }
    public class FetchOrderInfoSuccessAction(BasketOrderInfoDto basketOrderInfo, List<SalesOriginDto> salesOrigin, List<SalesPoolsDto> salesPools)
    {
        public BasketOrderInfoDto BasketOrderInfo { get; } = basketOrderInfo;
        public List<SalesOriginDto> SalesOrigins { get; set; } = salesOrigin;
        public List<SalesPoolsDto> SalesPoolsDto { get; set; } = salesPools;
    }
    public class FetchOrderInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
