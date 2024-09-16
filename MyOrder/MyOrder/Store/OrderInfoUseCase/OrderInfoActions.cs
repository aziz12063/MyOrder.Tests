using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase
{
    public class FetchOrderInfoAction(OrderInfoState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }
    public class FetchOrderInfoSuccessAction(BasketOrderInfoDto basketOrderInfo, List<ContactDto?>? contactList, List<BasketValueDto?> customerTags,
        List<BasketValueDto?>? salesOrigin, List<BasketValueDto?>? webOrigins, List<BasketValueDto?>? salesPools)
    {
        public BasketOrderInfoDto? BasketOrderInfo { get; } = basketOrderInfo;
        public List<ContactDto?>? ContactList { get; } = contactList;
        public List<BasketValueDto?>? CustomerTags { get; set; } = customerTags;
        public List<BasketValueDto?>? SalesOrigins { get; set; } = salesOrigin;
        public List<BasketValueDto?>? WebOrigins { get; set; } = webOrigins;
        public List<BasketValueDto?>? SalesPoolsDto { get; set; } = salesPools;
    }
    public class FetchOrderInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
