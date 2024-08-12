using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderInfoState : StateBase
{
    public BasketOrderInfoDto? BasketOrderInfo { get; }
    public List<ContactDto?>? ContactList { get; set; }
    public List<BasketValueDto?>? CustomerTags { get; }
    public List<SalesOriginDto?>? SalesOrigins { get; }
    public List<BasketValueDto?>? WebOrigins { get; }
    public List<BasketValueDto?>? SalesPools { get; }

    public OrderInfoState() : base(true) { }

    public OrderInfoState(BasketOrderInfoDto? basketOrderInfo, List<ContactDto?>? contactList,
        List<BasketValueDto?>? customerTags, List<SalesOriginDto?>? salesOrigins, 
        List<BasketValueDto?>? webOrigins, List<BasketValueDto?>? salesPools) : base(false)
    {
        BasketOrderInfo = basketOrderInfo;
        ContactList = contactList;
        CustomerTags = customerTags;
        SalesOrigins = salesOrigins;
        WebOrigins = webOrigins;
        SalesPools = salesPools;
    }

}

