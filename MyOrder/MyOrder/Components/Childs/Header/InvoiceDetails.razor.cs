using Fluxor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using System.Text;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header
{
    public partial class InvoiceDetails : BaseFluxorComponent<InvoiceInfoState, FetchInvoiceInfoAction>
    {
        public BasketInvoiceInfoDto? BasketInvoiceInfo { get; set; }
        public List<AccountDto?>? InvoiceToAccounts { get; set; }
        public List<BasketValueDto?>? TaxGroups { get; set; }
        public List<BasketValueDto?>? PaymentModes { get; set; }
        private string SelectedClient { get; set; } = string.Empty;
        private List<string>? AccountAddress { get; set; }
        private string DisplayAddress { get; set; }

        protected override FetchInvoiceInfoAction CreateFetchAction(InvoiceInfoState state, string basketId)
        {
            return new FetchInvoiceInfoAction(state, basketId);
        }

        protected override void CacheNewFields()
        {
            BasketInvoiceInfo = State.Value.BasketInvoiceInfo ?? throw new NullReferenceException("Unexpected null for BasketInvoiceInfo object.");
            InvoiceToAccounts = State.Value.InvoiceToAccounts;
            TaxGroups = State.Value.TaxGroups;
            PaymentModes = State.Value.PaymentModes;

            SelectedClient = FieldUtility.SelectedAccount(BasketInvoiceInfo?.Account?.Value);
            AccountAddress = FieldUtility.CreateAddressList(BasketInvoiceInfo?.Account?.Value);
            DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);
        }

        private bool IsPublicEntityValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.IsPublicEntity);

        }

        private AccountDto SelectedAccount
        {
            get => BasketInvoiceInfo?.Account?.Value;

            set
            {
                if (BasketInvoiceInfo == null)
                    throw new InvalidOperationException("BasketInvoiceInfo is null");

                //BasketInvoiceInfo.Account.Value = value;
                //AccountAddress = FieldUtility.CreateAddressList(BasketInvoiceInfo?.Account?.Value);
                //DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);

                SetBasketOrderValue(field: BasketInvoiceInfo.Account, value: value, procedureCallValue: value.AccountId);
            }
        }





    }
}
