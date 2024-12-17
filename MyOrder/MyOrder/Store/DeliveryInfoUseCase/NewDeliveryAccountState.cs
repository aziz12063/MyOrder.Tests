using Fluxor;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class NewDeliveryAccountState : StateBase
{
    public DeliveryAccountDraft? DeliveryAccountDraft { get; set; }

    public NewDeliveryAccountState() : base(true) { }

    public NewDeliveryAccountState(DeliveryAccountDraft? deliveryAccountDraft) : base(false)
    {
        DeliveryAccountDraft = deliveryAccountDraft;
    }
}
