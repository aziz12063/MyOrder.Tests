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

    public DeliveryInfoState() : base(true) { }

    public DeliveryInfoState(BasketDeliveryInfoDto? basketDeliveryInfo, List<AccountDto?>? deliverToAccounts,
        List<ContactDto?>? deliverToContacts) : base(false)
    {
        BasketDeliveryInfo = basketDeliveryInfo;
        DeliverToAccounts = deliverToAccounts;
        DeliverToContacts = deliverToContacts;
    }
}

