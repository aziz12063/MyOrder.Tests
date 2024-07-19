using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;


namespace MyOrder.Components.Childs
{
    public partial class GeneralInfo : LoadableComponent
    {
        [Inject]
        public IBasketRepository BasketRepository { get; set; }
        private BasketGeneralInfoDto BsktInfo { get; set; } = new BasketGeneralInfoDto();

        protected override async Task LoadDataAsync()
        {
            BsktInfo = await BasketRepository.GetBasketGeneralInfoAsync(GlobalParms.TEST_BASKET_ID);
        }
    }
}
