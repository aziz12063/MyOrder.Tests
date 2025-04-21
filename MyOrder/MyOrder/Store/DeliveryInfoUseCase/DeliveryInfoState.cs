using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryInfoState : StateBase
{
    public BasketDeliveryInfoDto? BasketDeliveryInfo { get; }
    public List<BasketValueDto?>? DeliveryModes { get; }


    public DeliveryInfoState() : base(true) { }

    public DeliveryInfoState(BasketDeliveryInfoDto? basketDeliveryInfo, List<BasketValueDto?>? deliveryModes) : base(false)
    {
        BasketDeliveryInfo = basketDeliveryInfo;
        DeliveryModes = deliveryModes;
    }
}

