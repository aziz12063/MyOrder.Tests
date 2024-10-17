using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.BasketItemsUseCase;

public class BasketItemsEffects(IBasketRepository basketRepository, ILogger<BasketItemsEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchBesetSellersAction(FetchBestSellersAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching best sellers for {BasketId}", action.BasketId);
            var basketItems = await basketRepository.GetBasketBestSellersAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchBestSellersSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching best sellers data");
            dispatcher.Dispatch(new FetchBasketItemsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchOrderedItemsAction(FetchOrderedItemsAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching ordered items for {BasketId}", action.BasketId);
            var basketItems = await basketRepository.GetBasketOrderedItemsAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchOrderedItemsSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching ordered items data");
            dispatcher.Dispatch(new FetchBasketItemsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchSearchItemsAction(FetchSearchItemsAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching basket items for {BasketId}", action.BasketId);
            var basketItems = await basketRepository.GetBasketSearchItemsAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchSearchItemsSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching ordered items data");
            dispatcher.Dispatch(new FetchBasketItemsFailureAction(ex.Message));
        }
    }
}
