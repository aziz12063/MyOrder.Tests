using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.DeliveryInfoUseCase;

public class DeliveryInfoEffects(IDeliveryInfoRepository deliveryInfoRepository, ILogger<DeliveryInfoEffects> logger)
{
    private readonly IDeliveryInfoRepository _deliveryInfoRepo = deliveryInfoRepository 
        ?? throw new ArgumentNullException(nameof(deliveryInfoRepository));
    [EffectMethod]
    public async Task HandleFetchDeliveryInfoAction(FetchDeliveryInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var basketDeliveryInfo = await deliveryInfoRepository.GetBasketDeliveryInfoAsync();
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
            var accountList = await deliveryInfoRepository.GetDeliverToAccountsAsync(action.Filter);
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
            var contactList = await deliveryInfoRepository.GetDeliverToContactsAsync(action.Filter);
            dispatcher.Dispatch(new FetchDeliveryContactsSuccessAction(contactList, isFiltered));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching delivery contacts data");
            dispatcher.Dispatch(new FetchDeliveryContactsFailureAction(ex.Message));
        }
    }
}