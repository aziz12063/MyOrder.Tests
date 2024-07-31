using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryInfoState
{
    public BasketDeliveryInfoDto BasketDeliveryInfo { get; private set; } = new ();
    public bool IsLoading { get; } = true;

    public DeliveryInfoState() { }

    public DeliveryInfoState(BasketDeliveryInfoDto basketDeliveryInfo)
    {
        BasketDeliveryInfo = basketDeliveryInfo;
        IsLoading = false;
    }
}

