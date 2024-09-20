using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase
{
    public class FetchDeliveryInfoAction(DeliveryInfoState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchDeliveryInfoSuccessAction(BasketDeliveryInfoDto? basketDeliveryInfo, List<AccountDto?>? deliverToAccounts,
        List<ContactDto?>? deliverToContacts)
    {
        public BasketDeliveryInfoDto? BasketDeliveryInfo { get; } = basketDeliveryInfo;
        public List<AccountDto?>? DeliverToAccounts { get; set; } = deliverToAccounts;
        public List<ContactDto?>? DeliverToContacts { get; set; } = deliverToContacts;
    }

    public class FetchDeliveryInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
