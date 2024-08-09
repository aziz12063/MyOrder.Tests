using Fluxor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using System.Text;

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
            get => NullOrWhiteSpaceHelper(BasketInvoiceInfo.IsPublicEntity);
           
        }

        private static bool NullOrWhiteSpaceHelper(bool? value) => value ?? false;

        private string SelectedCompte
        {
            get
            {
                var account = BasketInvoiceInfo?.Account?.Value;
                return account == null ? string.Empty :
                    $"{account.AccountId} - {account.Name} - {account.ZipCode}";
            }
            set 
            {
               
            }
        }

        private string GetInvoiceAccount(AccountDto accountDto)
        {
            string account = accountDto == null ? string.Empty : $"{accountDto.AccountId} - {accountDto.Name} - {accountDto.ZipCode}";
            return account;
        }

        private string AccountAddress
        {
            get
            {
                var account = BasketInvoiceInfo?.Account?.Value;
                return account == null ? string.Empty :
                    $"{account.Building} - {account.Street} \n" +
                    $"{account.ZipCode} -  {account.City}\n" +
                    $"{account.Country}";
            }
            set { }
        }
    }
}
