using Microsoft.AspNetCore.Components;
using MyOrder.Components.Childs.Shared;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Header
{
    public partial class OrderInfo : LoadableComponent
    {
        [Inject]
        public IBasketRepository BasketRepository { get; set; }
        private BasketOrderInfoDto BsktOrderInfo { get; set; } = new BasketOrderInfoDto();
        private List<SalesOriginDto> SalesOrigins { get; set; } = [];
        private List<SalesPoolsDto> SalesPools { get; set; } = [];
        private string SelectedClient => BsktOrderInfo.Account.AccountNum + " - " + BsktOrderInfo.Account.Name + " - " + BsktOrderInfo.Account.ZipCode;
        private string SelectedContact => BsktOrderInfo.Contact.FirstName + " - " + BsktOrderInfo.Contact.LastName;

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
            BsktOrderInfo = await BasketRepository.GetBasketOrderInfoAsync(GlobalParms.TestBasketId);
        }

        private async Task LoadSalesOrigins()
        {

            SalesOrigins = await BasketRepository.GetSalesOriginsAsync(GlobalParms.TestBasketId);
        }
        private async Task LoadSalesPools()
        {

            SalesPools = await BasketRepository.GetSalesPoolAsync(GlobalParms.TestBasketId);
        }
    }
}
