using Fluxor;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class NewDeliveryContactState : StateBase
{
    public DeliveryContactDraft? DeliveryContactDraft { get; set; }

    public NewDeliveryContactState() : base(true) { }

    public NewDeliveryContactState(DeliveryContactDraft? deliveryContactDraft) : base(false)
    {
        DeliveryContactDraft = deliveryContactDraft;
    }
}
