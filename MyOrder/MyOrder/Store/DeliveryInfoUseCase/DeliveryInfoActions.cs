using MyOrder.Shared.Dtos;

namespace MyOrder.Store.DeliveryInfoUseCase
{
    public class FetchDeliveryInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchDeliveryInfoSuccessAction(BasketDeliveryInfoDto basketDeliveryInfo, List<AccountDto> deliverToAccounts,
        List<ContactDto> deliverToContacts, List<BasketValueDto> deliveryModes)
    {
        public BasketDeliveryInfoDto BasketDeliveryInfo { get; } = basketDeliveryInfo;
        public List<AccountDto> DeliverToAccounts { get; set; } = deliverToAccounts;
        public List<ContactDto> DeliverToContacts { get; set; } = deliverToContacts;
        public List<BasketValueDto> DeliveryModes { get; set; } = deliveryModes;
    }

    public class FetchDeliveryInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
