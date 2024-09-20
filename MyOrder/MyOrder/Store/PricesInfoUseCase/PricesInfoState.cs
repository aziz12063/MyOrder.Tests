using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.PricesInfoUseCase;

[FeatureState]
public class PricesInfoState : StateBase
{
    public BasketPricesInfoDto? PricesInfo { get; }

    public PricesInfoState() : base(true) { }

    public PricesInfoState(BasketPricesInfoDto? pricesInfo) : base(false)
    {
        PricesInfo = pricesInfo;
    }
}
