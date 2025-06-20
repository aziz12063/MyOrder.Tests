using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record DeliveryInfoState(
    BasketDeliveryInfoDto BasketDeliveryInfo,
    List<BasketValueDto?> DeliveryModes) : StateBase
{
    public DeliveryInfoState() : this(default!, []) { }
}