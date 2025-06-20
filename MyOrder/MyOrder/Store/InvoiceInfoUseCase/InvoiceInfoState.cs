using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record InvoiceInfoState(
    InvoicePanelDto BasketInvoiceInfo) : StateBase
{
    public InvoiceInfoState() : this((InvoicePanelDto)null!) { }
}