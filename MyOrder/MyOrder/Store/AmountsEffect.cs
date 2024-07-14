using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.AmountsUseCase;
using Fluxor;

namespace MyOrder.Store
{
    public class AmountsEffect
    {
        private readonly IBasketRepository _basketRepository;

        public AmountsEffect(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
            
        }
        public  async Task HandleFetchAmountsDataRequest(AmountsState state, FetchAmountsDataRequestAction action, IDispatcher dispatcher)
        {

            try
            {
              
                var basketAmountsDto = await _basketRepository.GetBasketAmountsAsync(action.BasketId);
                dispatcher.Dispatch(new FetchAmountsDataAction(basketAmountsDto));
            }
            catch (Exception ex)
            {
              
                dispatcher.Dispatch(new FetchAmountsDataErrorAction(ex.Message));
            }
        }
    }
}
