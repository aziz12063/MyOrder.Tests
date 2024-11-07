using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class DeliveryInfoEffects(IBasketRepository basketRepository, ILogger<DeliveryInfoEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchDeliveryInfoAction(FetchDeliveryInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var basketDeliveryInfo = await basketRepository.GetBasketDeliveryInfoAsync(action.BasketId);
            dispatcher.Dispatch(new FetchDeliveryInfoSuccessAction(basketDeliveryInfo));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching delivery info");
            dispatcher.Dispatch(new FetchDeliveryInfoFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchDeliveryAccountsAction(FetchDeliveryAccountsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            logger.LogInformation("Fetching delivery accounts for {BasketId}", action.BasketId);
            var accountList = await basketRepository.GetDeliverToAccountsAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchDeliveryAccountsSuccessAction(accountList, isFiltered));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching delivery accounts data");
            dispatcher.Dispatch(new FetchDeliveryAccountsFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchDeliveryContactsAction(FetchDeliveryContactsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            logger.LogInformation("Fetching delivery contacts for {BasketId}", action.BasketId);
            var contactList = await basketRepository.GetDeliverToContactsAsync(action.BasketId, action.Filter);
            dispatcher.Dispatch(new FetchDeliveryContactsSuccessAction(contactList, isFiltered));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching delivery contacts data");
            dispatcher.Dispatch(new FetchDeliveryContactsFailureAction(ex.Message));
        }
    }
}