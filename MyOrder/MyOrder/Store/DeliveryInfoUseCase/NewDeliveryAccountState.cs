using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record NewDeliveryAccountState(DeliveryAccountDraft DeliveryAccountDraft) : StateBase
{
    public NewDeliveryAccountState() : this((DeliveryAccountDraft) null!) { }
}