using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.BasketItemsUseCase;

public class BasketItemsEffects(IBasketItemsRepository basketItemsRepository, ILogger<BasketItemsEffects> logger)
{
    private readonly IBasketItemsRepository _basketItemsRepository = basketItemsRepository
        ?? throw new ArgumentNullException(nameof(basketItemsRepository));
    private readonly ILogger<BasketItemsEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchBesetSellersAction(FetchBestSellersAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Fetching best sellers for {BasketId}", action.BasketId);
            var basketItems = await _basketItemsRepository.GetBasketBestSellersAsync(action.Filter);
            dispatcher.Dispatch(new FetchBestSellersSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching best sellers data");
            dispatcher.Dispatch(new FetchBasketItemsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchOrderedItemsAction(FetchOrderedItemsAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Fetching ordered items for {BasketId}", action.BasketId);
            var basketItems = await _basketItemsRepository.GetBasketOrderedItemsAsync(action.Filter);
            dispatcher.Dispatch(new FetchOrderedItemsSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching ordered items data");
            dispatcher.Dispatch(new FetchBasketItemsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchSearchItemsAction(FetchSearchItemsAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Fetching basket items for {BasketId}", action.BasketId);
            var basketItems = await _basketItemsRepository.GetBasketSearchItemsAsync(action.Filter);
            dispatcher.Dispatch(new FetchSearchItemsSuccessAction(basketItems));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching ordered items data");
            dispatcher.Dispatch(new FetchBasketItemsFailureAction(ex.Message));
        }
    }
}