using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.OrderInfoUseCase;

public class OrderInfoEffects(IBasketRepository basketRepository, ILogger<OrderInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchOrderInfo(FetchOrderInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching order info for {BasketId}", action.BasketId);
            var basketOrderInfoTask = basketRepository.GetBasketOrderInfoAsync(action.BasketId);
            var contactListTask = basketRepository.GetOrderByContactsAsync(action.BasketId);
           
            await Task.WhenAll(basketOrderInfoTask, contactListTask);

            dispatcher.Dispatch(new FetchOrderInfoSuccessAction(basketOrderInfoTask.Result, contactListTask.Result));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching order info data");
            dispatcher.Dispatch(new FetchOrderInfoFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchOrderContacts(FetchOrderContactsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            logger.LogInformation("Fetching order contacts for {BasketId}", action.BasketId);
            var contactList = await basketRepository.GetOrderByContactsAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchOrderContactsSuccessAction(contactList, isFiltered));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching order contacts data");
            dispatcher.Dispatch(new FetchOrderContactsFailureAction(ex.Message));
        }
    }
}

