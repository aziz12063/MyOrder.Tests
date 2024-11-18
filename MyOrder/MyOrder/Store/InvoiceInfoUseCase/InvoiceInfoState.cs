using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public class InvoiceInfoState : StateBase
{
    public BasketInvoiceInfoDto? BasketInvoiceInfo { get; }

    public InvoiceInfoState() : base(true) { }

    public InvoiceInfoState(BasketInvoiceInfoDto? basketInvoiceInfo) : base(false)
    {
        BasketInvoiceInfo = basketInvoiceInfo;
    }

}