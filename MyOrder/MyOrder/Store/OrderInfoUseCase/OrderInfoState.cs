using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderInfoState
{
    public BasketOrderInfoDto BasketOrderInfo { get; } = new();
    public List<BasketValueDto> CustomerTags { get; } = [];
    public List<SalesOriginDto> SalesOrigins { get; } = [];
    public List<BasketValueDto> SalesPools { get; } = [];
    public bool IsLoading { get; } = true;

    public OrderInfoState() { }

    public OrderInfoState(BasketOrderInfoDto basketOrderInfo, List<BasketValueDto> customerTags,
        List<SalesOriginDto> salesOrigins, List<BasketValueDto> salesPools)
    {
        BasketOrderInfo = basketOrderInfo;
        CustomerTags = customerTags;
        SalesOrigins = salesOrigins;
        SalesPools = salesPools;
        IsLoading = false;
    }

}

