using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Header.OrderInfo
{
    public partial class OrderInfo : LoadableComponent
    {
        [Inject]
        public IBasketRepository BasketRepository { get; set; }
        private BasketOrderInfoDto BsktOrderInfo { get; set; } = new BasketOrderInfoDto();
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
            BsktOrderInfo = await BasketRepository.GetBasketOrderInfoAsync(GlobalParms.TEST_BASKET_ID);
        }
    }
}
