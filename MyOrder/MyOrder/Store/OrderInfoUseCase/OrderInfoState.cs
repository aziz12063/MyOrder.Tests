using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderInfoState : StateBase
{
    public BasketOrderInfoDto? BasketOrderInfo { get; }

    public List<BasketValueDto?>? WebOrigins { get; }

    public OrderInfoState() : base(true) { }

    public OrderInfoState(BasketOrderInfoDto? basketOrderInfo, List<BasketValueDto?>? webOrigins) : base(false)
    {
        BasketOrderInfo = basketOrderInfo;
        WebOrigins = webOrigins;
    }

}

