using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase
{
    public class FetchOrderInfoAction(OrderInfoState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }
    public class FetchOrderInfoSuccessAction(BasketOrderInfoDto basketOrderInfo, List<ContactDto?>? contactList)
    {
        public BasketOrderInfoDto? BasketOrderInfo { get; } = basketOrderInfo;
        public List<ContactDto?>? ContactList { get; } = contactList;
    }
    public class FetchOrderInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
