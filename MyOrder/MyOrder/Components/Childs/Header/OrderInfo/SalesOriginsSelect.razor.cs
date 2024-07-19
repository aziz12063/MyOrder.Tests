using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Header.OrderInfo.OrderInfo
{
    public partial class SalesOriginsSelect : LoadableComponent
    {
        [Inject]
        public IBasketRepository BasketRepository { get; set; }
        private SalesOriginsDto SalesOrigins { get; set; } = new();
        override protected async Task LoadDataAsync()
        {
            SalesOrigins = await BasketRepository.GetSalesOriginsAsync(GlobalParms.TEST_BASKET_ID);
        }
    }
}
