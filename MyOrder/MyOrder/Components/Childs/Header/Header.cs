using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;
using Radzen;

namespace MyOrder.Components.Childs.Header
{
    public partial class Header
    {
        private const string TEST_BASKET_ID = "P0130625";
        private bool isLoading = false;

        private readonly IBasketRepository basketRepository;

        public BasketHeaderDto BasketHeaderDto { get; set; }

        public Header(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        protected override async void OnInitialized()
        {
            isLoading = true;

            try
            {
                BasketHeaderDto = await basketRepository.GetBasketHeaderAsync(TEST_BASKET_ID);
            }
            finally
            {
                isLoading = false;
            }

        }


    }
}
