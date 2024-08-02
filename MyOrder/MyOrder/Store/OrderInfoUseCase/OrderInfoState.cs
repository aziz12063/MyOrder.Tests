using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderInfoState
{
    public BasketOrderInfoDto BasketOrderInfo { get; } = new();
    public List<ContactDto> ContactList { get; set; } = [];
    public List<BasketValueDto> CustomerTags { get; } = [];
    public List<SalesOriginDto> SalesOrigins { get; } = [];
    public List<BasketValueDto> WebOrigins { get; } = [];
    public List<BasketValueDto> SalesPools { get; } = [];
    public bool IsLoading { get; } = true;

    public OrderInfoState() { }

    public OrderInfoState(BasketOrderInfoDto basketOrderInfo, List<ContactDto> contactList,
        List<BasketValueDto> customerTags, List<SalesOriginDto> salesOrigins, List<BasketValueDto> webOrigins, List<BasketValueDto> salesPools)
    {
        BasketOrderInfo = basketOrderInfo;
        ContactList = contactList;
        CustomerTags = customerTags;
        SalesOrigins = salesOrigins;
        WebOrigins = webOrigins;
        SalesPools = salesPools;
        IsLoading = false;
    }

}

