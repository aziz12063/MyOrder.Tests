using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.AmountsUseCase
{
    public class Effects
    {

        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<Effects> _logger;

        public Effects(IBasketRepository basketRepository, ILogger<Effects> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        [EffectMethod]
        public async Task HandleFetchAmountsData(FetchAmountsDataRequestAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Fetching basket amounts for {BasketId}", action.BasketId);
                var basketAmountsDto = await _basketRepository.GetBasketAmountsAsync(action.BasketId);
                dispatcher.Dispatch(new FetchAmountsDataAction(basketAmountsDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching basket amounts for {BasketId}", action.BasketId);
                dispatcher.Dispatch(new FetchAmountsDataErrorAction(ex.Message));
            }
        }
    }
}

