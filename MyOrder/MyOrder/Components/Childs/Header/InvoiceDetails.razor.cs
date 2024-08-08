using Fluxor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;

namespace MyOrder.Components.Childs.Header
{
    public partial class InvoiceDetails : BaseFluxorComponent<InvoiceInfoState, FetchInvoiceInfoAction>
    {
        public BasketInvoiceInfoDto? BasketInvoiceInfo => State.Value.BasketInvoiceInfo;
        public List<AccountDto?>? InvoiceToAccounts => State.Value.InvoiceToAccounts;
        public List<BasketValueDto?>? TaxGroups => State.Value.TaxGroups;
        public List<BasketValueDto?>? PaymentModes => State.Value.PaymentModes;

        protected override FetchInvoiceInfoAction CreateFetchAction(string basketId)
        {
            return new FetchInvoiceInfoAction(basketId);
        }

        private bool IsPublicEntityValue
        {
            get => NullOrWhiteSpaceHelper(BasketInvoiceInfo.IsPublicEntity); // check this
           
        }

        private static bool NullOrWhiteSpaceHelper(bool? value) => value ?? false;


    }
}
