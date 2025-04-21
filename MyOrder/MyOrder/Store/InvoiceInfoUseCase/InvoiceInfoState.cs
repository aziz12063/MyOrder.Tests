using Fluxor;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public class InvoiceInfoState : StateBase
{
    public InvoicePanelDto? BasketInvoiceInfo { get; }

    public InvoiceInfoState() : base(true) { }

    public InvoiceInfoState(InvoicePanelDto? basketInvoiceInfo) : base(false)
    {
        BasketInvoiceInfo = basketInvoiceInfo;
    }

}