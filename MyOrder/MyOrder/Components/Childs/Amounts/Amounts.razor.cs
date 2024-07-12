using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;
using Fluxor;
using MyOrder.Store.AmountsUseCase;
using MyOrder.Store;

namespace MyOrder.Components.Childs.Amounts
{
    public partial class Amounts
    {
        [CascadingParameter]
        public string TEST_BASKET_ID { get; set; }

        [Inject]
        private IBasketRepository BasketRepository { get; set; }
        [Inject]
        private IState<AmountsState> AmountsState { get; set; }
        [Inject]
        public IDispatcher Dispatcher { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            FetchBasketAmounts(TEST_BASKET_ID);
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    BasketAmountsDto = await BasketRepository.GetBasketAmountsAsync(TEST_BASKET_ID);
        //}


        public void FetchBasketAmounts(string basketId)
        {
            Dispatcher.Dispatch(new FetchAmountsDataRequestAction(basketId));
        }


    }
}
