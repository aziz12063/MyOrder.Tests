using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase
{
    [FeatureState]
    public class InvoiceInfoState : StateBase
    {
        public BasketInvoiceInfoDto? BasketInvoiceInfo { get; }
        public List<AccountDto?>? InvoiceToAccounts { get; }
        public List<BasketValueDto?>? TaxGroups { get; }
        public List<BasketValueDto?>? PaymentModes { get; }

        public InvoiceInfoState() : base(true) { }

        public InvoiceInfoState(BasketInvoiceInfoDto? basketInvoiceInfo, List<AccountDto?>? invoiceToAccounts,
            List<BasketValueDto?>? taxGroups, List<BasketValueDto?>? paymentModes) : base(false)
        {
            BasketInvoiceInfo = basketInvoiceInfo;
            InvoiceToAccounts = invoiceToAccounts;
            TaxGroups = taxGroups;
            PaymentModes = paymentModes;
        }

    }
}
