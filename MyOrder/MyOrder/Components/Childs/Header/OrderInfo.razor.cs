using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Header
{
    public partial class OrderInfo : LoadableComponent
    {
        [Inject]
        public IBasketRepository BasketRepository { get; set; }
        private BasketOrderInfoDto BsktOrderInfo { get; set; } = new BasketOrderInfoDto();
        private List<SalesOriginDto> SalesOrigins { get; set; } = new();
        private List<SalesPoolsDto> SalesPools { get; set; } = new();
        private string SelectedClient
        {
            get
            {
                return BsktOrderInfo.Account.AccountNum + " - " + BsktOrderInfo.Account.Name + " - " + BsktOrderInfo.Account.ZipCode;
            }
        }
        private string SelectedContact
        {
            get
            {
                return BsktOrderInfo.Contact.FirstName + " - " + BsktOrderInfo.Contact.LastName;
            }
            set
            {

            }
        }

        protected override async Task LoadDataAsync()
        {
            var tasks = new List<Task>
            {
                LoadBasket(),
                LoadSalesOrigins(),
                LoadSalesPools()
            };

            await Task.WhenAll(tasks);
        }

        private async Task LoadBasket()
        {
            BsktOrderInfo = await BasketRepository.GetBasketOrderInfoAsync(GlobalParms.TEST_BASKET_ID);
        }

        private async Task LoadSalesOrigins()
        {

            SalesOrigins = await BasketRepository.GetSalesOriginsAsync(GlobalParms.TEST_BASKET_ID);
        }
        private async Task LoadSalesPools()
        {

            SalesPools = await BasketRepository.GetSalesPoolAsync(GlobalParms.TEST_BASKET_ID);
        }
    }
}
