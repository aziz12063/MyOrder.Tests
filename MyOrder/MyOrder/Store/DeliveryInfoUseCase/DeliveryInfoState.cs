using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryInfoState
{
    public BasketDeliveryInfoDto BasketDeliveryInfo { get; } = new();
    public List<AccountDto> DeliverToAccounts { get; } = [];
    public List<ContactDto> DeliverToContacts { get; } = [];
    public List<BasketValueDto> DeliveryModes { get; } = [];
    public bool IsLoading { get; } = true;

    public DeliveryInfoState() { }

    public DeliveryInfoState(BasketDeliveryInfoDto basketDeliveryInfo, List<AccountDto> deliverToAccounts,
        List<ContactDto> deliverToContacts, List<BasketValueDto> deliveryModes)
    {
        BasketDeliveryInfo = basketDeliveryInfo;
        DeliverToAccounts = deliverToAccounts;
        DeliverToContacts = deliverToContacts;
        DeliveryModes = deliveryModes;
        IsLoading = false;
    }
}

