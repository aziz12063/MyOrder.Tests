using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.InvoiceInfoUseCase
{
    [FeatureState]
    public class InvoiceInfoState
    {
        public BasketInvoiceInfoDto BasketInvoiceInfo { get; } = new();
        public List<AccountDto> InvoiceToAccounts { get; } = [];
        public List<BasketValueDto> TaxGroups { get; } = [];
        public List<BasketValueDto> PaymentModes { get; } = [];
        public bool IsLoading { get; } = true;

        public InvoiceInfoState(){ }

        public InvoiceInfoState(BasketInvoiceInfoDto basketInvoiceInfo, List<AccountDto> invoiceToAccounts, 
            List<BasketValueDto> taxGroups, List<BasketValueDto> paymentModes)
        {
            BasketInvoiceInfo = basketInvoiceInfo;
            InvoiceToAccounts = invoiceToAccounts;
            TaxGroups = taxGroups;
            PaymentModes = paymentModes;
            IsLoading = false;
        }

    }
}
