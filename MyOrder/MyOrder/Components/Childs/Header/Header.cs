using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Header
{
    public partial class Header
    {
        private const string TEST_BASKET_ID = "P0130625";
        private bool isLoading = false;

        [Inject]
        private IBasketRepository BasketRepository { get; set; }

        public BasketHeaderDto? BasketHeaderDto { get; set; } = new();


        protected override async void OnInitialized()
        {
            isLoading = true;

            try
            {
                BasketHeaderDto = await BasketRepository.GetBasketHeaderAsync(TEST_BASKET_ID);
            }
            finally
            {
                isLoading = false;
            }

        }


    }
}
