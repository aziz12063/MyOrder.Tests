using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.PricesInfoUseCase;

public class PricesInfoEffects(IBasketRepository basketRepository, ILogger<PricesInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchPricesInfoAction(FetchPricesInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var pricesInfoTask = await basketRepository.GetBasketPricesInfoAsync(action.BasketId);

            dispatcher.Dispatch(new FetchPricesInfoSuccessAction(pricesInfoTask));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while fetching prices info");
            dispatcher.Dispatch(new FetchPricesInfoFailureAction(e.Message));
        }
    }
}
