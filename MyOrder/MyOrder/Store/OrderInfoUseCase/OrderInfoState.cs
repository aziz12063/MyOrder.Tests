using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderInfoState
{
    public BasketOrderInfoDto BasketOrderInfo { get; } = new();
    public List<SalesOriginDto> SalesOrigins { get; } = [];
    public List<SalesPoolsDto> SalesPools { get; } = [];
    public bool IsLoading { get; } = true;

    public OrderInfoState() { }

    public OrderInfoState(BasketOrderInfoDto basketOrderInfo, List<SalesOriginDto> salesOrigins, List<SalesPoolsDto> salesPools)
    {
        BasketOrderInfo = basketOrderInfo;
        SalesOrigins = salesOrigins;
        SalesPools = salesPools;
        IsLoading = false;
    }

}

