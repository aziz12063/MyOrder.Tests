using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public class InvoiceInfoState : StateBase
{
    public BasketInvoiceInfoDto? BasketInvoiceInfo { get; }
    public List<AccountDto?>? InvoiceToAccounts { get; }

    public InvoiceInfoState() : base(true) { }

    public InvoiceInfoState(BasketInvoiceInfoDto? basketInvoiceInfo, List<AccountDto?>? invoiceToAccounts) : base(false)
    {
        BasketInvoiceInfo = basketInvoiceInfo;
        InvoiceToAccounts = invoiceToAccounts;
    }

}
