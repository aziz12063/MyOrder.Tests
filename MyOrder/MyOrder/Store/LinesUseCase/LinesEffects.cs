using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Store.LinesUseCase
{
    public class LinesEffects(IBasketRepository basketRepository, ILogger<LinesEffects> logger)
    {
        [EffectMethod]
        public async Task HandleFetchLinesAction(FetchLinesAction action, IDispatcher dispatcher)
        {
            try
            {
                logger.LogInformation("Fetching lines for {BasketId}", action.BasketId);
                var lines = await basketRepository.GetBasketLinesAsync(action.BasketId);

                dispatcher.Dispatch(new FetchLinesSuccessAction(lines));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while fetching lines");
                dispatcher.Dispatch(new FetchLinesFailureAction(ex.Message));
            }
        }

    }
}
