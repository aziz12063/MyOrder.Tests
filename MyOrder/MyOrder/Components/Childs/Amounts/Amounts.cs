using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Components.Childs.Amounts
{
    public partial class Amounts
    {
        [CascadingParameter]
        public string TEST_BASKET_ID { get; set; }

        [Inject]
        private IBasketRepository BasketRepository { get; set; }

        public BasketAmountsDto BasketAmountsDto { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            BasketAmountsDto = await BasketRepository.GetBasketAmountsAsync(TEST_BASKET_ID);
        }
    }
}
