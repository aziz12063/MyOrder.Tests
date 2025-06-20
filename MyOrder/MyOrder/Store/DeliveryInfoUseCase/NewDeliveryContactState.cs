using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record NewDeliveryContactState(
    DeliveryContactDraft DeliveryContactDraft) : StateBase
{
    public NewDeliveryContactState() : this((DeliveryContactDraft)null!) { }
}
