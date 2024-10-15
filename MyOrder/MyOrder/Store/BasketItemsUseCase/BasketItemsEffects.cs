using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.BasketItemsUseCase;

public class BasketItemsEffects(IBasketRepository basketRepository, ILogger<BasketItemsEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchBasketItems(FetchBestSellersAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching basket items for {BasketId}", action.BasketId);
            var basketItems = await basketRepository.GetBasketBestSellersAsync(action.BasketId);
            dispatcher.Dispatch(new FetchBestSellersSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching ordered items data");
            dispatcher.Dispatch(new FetchBestSellersFailureAction(ex.Message));
        }
    }
}
