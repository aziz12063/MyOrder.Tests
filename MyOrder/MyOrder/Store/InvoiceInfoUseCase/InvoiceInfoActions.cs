using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase
{
    public class FetchInvoiceInfoAction(InvoiceInfoState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }
    
    public class FetchInvoiceInfoSuccessAction(BasketInvoiceInfoDto? basketInvoiceInfo, List<AccountDto?>? invoiceToAccounts,
        List<BasketValueDto?>? taxGroups, List<BasketValueDto?>? paymentModes)
    {
        public BasketInvoiceInfoDto? InvoiceInfo { get; } = basketInvoiceInfo;
        public List<AccountDto?>? InvoiceToAccounts { get; } = invoiceToAccounts;
        public List<BasketValueDto?>? TaxGroups { get; } = taxGroups;
        public List<BasketValueDto?>? PaymentModes { get; } = paymentModes;
    }

    public class FetchInvoiceInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
