using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryInfoState : StateBase
{
    public BasketDeliveryInfoDto? BasketDeliveryInfo { get; }
    public List<AccountDto?>? DeliverToAccounts { get; }
    public List<ContactDto?>? DeliverToContacts { get; }
    public List<BasketValueDto?>? DeliveryModes { get; }

    public DeliveryInfoState() : base(true) { }

    public DeliveryInfoState(BasketDeliveryInfoDto? basketDeliveryInfo, List<AccountDto?>? deliverToAccounts,
        List<ContactDto?>? deliverToContacts, List<BasketValueDto?>? deliveryModes) : base(false)
    {
        BasketDeliveryInfo = basketDeliveryInfo;
        DeliverToAccounts = deliverToAccounts;
        DeliverToContacts = deliverToContacts;
        DeliveryModes = deliveryModes;
    }
}

