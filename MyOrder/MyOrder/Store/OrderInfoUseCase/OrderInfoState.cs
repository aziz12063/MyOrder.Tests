using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
public class OrderInfoState : StateBase
{
    public BasketOrderInfoDto? BasketOrderInfo { get; }
    public List<ContactDto?>? ContactList { get; }

    public OrderInfoState() : base(true) { }

    public OrderInfoState(BasketOrderInfoDto? basketOrderInfo,
        List<ContactDto?>? contactList) : base(false)
    {
        BasketOrderInfo = basketOrderInfo;
        ContactList = contactList;
    }

}

