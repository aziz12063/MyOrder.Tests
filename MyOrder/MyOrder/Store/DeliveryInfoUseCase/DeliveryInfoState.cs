using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryInfoState : StateBase
{
    public BasketDeliveryInfoDto? BasketDeliveryInfo { get; }

    public DeliveryInfoState() : base(true) { }

    public DeliveryInfoState(BasketDeliveryInfoDto? basketDeliveryInfo) : base(false)
    {
        BasketDeliveryInfo = basketDeliveryInfo;
    }
}

