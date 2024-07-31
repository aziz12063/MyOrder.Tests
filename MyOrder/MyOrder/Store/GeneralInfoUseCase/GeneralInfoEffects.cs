using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.GeneralInfoUseCase
{
    public class GeneralInfoEffects(IBasketRepository basketRepository, ILogger<GeneralInfoEffects> logger)
    {
        [EffectMethod]
        public async Task HandleFetchGeneralInfo(FetchGeneralInfoAction action, IDispatcher dispatcher)
        {
            try
            {
                logger.LogInformation("Fetching general info for {BasketId}", action.BasketId);
                var basketGeneralInfo = await basketRepository.GetBasketGeneralInfoAsync(action.BasketId);
                dispatcher.Dispatch(new FetchGeneralInfoSuccessAction(basketGeneralInfo));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching general info data");
                dispatcher.Dispatch(new FetchGeneralInfoFailureAction(ex.Message));
            }
        }
    }
}
