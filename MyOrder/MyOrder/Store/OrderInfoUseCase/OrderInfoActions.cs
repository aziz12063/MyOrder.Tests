using MyOrder.Shared.Dtos;

namespace MyOrder.Store.OrderInfoUseCase
{
    public class FetchOrderInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }
    public class FetchOrderInfoSuccessAction(BasketOrderInfoDto basketOrderInfo, List<ContactDto> contactList, List<BasketValueDto> customerTags,
        List<SalesOriginDto> salesOrigin, List<BasketValueDto> salesPools)
    {
        public BasketOrderInfoDto BasketOrderInfo { get; } = basketOrderInfo;
        public List<ContactDto> ContactList { get; } = contactList;
        public List<BasketValueDto> CustomerTags { get; set; } = customerTags;
        public List<SalesOriginDto> SalesOrigins { get; set; } = salesOrigin;
        public List<BasketValueDto> SalesPoolsDto { get; set; } = salesPools;
    }
    public class FetchOrderInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
