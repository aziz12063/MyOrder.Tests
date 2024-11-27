using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.OrderInfoUseCase;

public class OrderInfoEffects(IOrderInfoRepository orderInfoRepository, ILogger<OrderInfoEffects> logger)
{
    private readonly IOrderInfoRepository _orderInfoRepository = orderInfoRepository 
        ?? throw new ArgumentNullException(nameof(orderInfoRepository));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchOrderInfo(FetchOrderInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Fetching order info for {BasketId}", action.BasketId);
            var basketOrderInfoTask = _orderInfoRepository.GetBasketOrderInfoAsync();
            var contactListTask = _orderInfoRepository.GetOrderByContactsAsync();
           
            await Task.WhenAll(basketOrderInfoTask, contactListTask);

            dispatcher.Dispatch(new FetchOrderInfoSuccessAction(basketOrderInfoTask.Result, contactListTask.Result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching order info data");
            dispatcher.Dispatch(new FetchOrderInfoFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleFetchOrderContacts(FetchOrderContactsAction action, IDispatcher dispatcher)
    {
        try
        {
            var isFiltered = !string.IsNullOrEmpty(action.Filter);
            _logger.LogInformation("Fetching order contacts for {BasketId}", action.BasketId);
            var contactList = await _orderInfoRepository.GetOrderByContactsAsync(action.Filter);
            dispatcher.Dispatch(new FetchOrderContactsSuccessAction(contactList, isFiltered));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching order contacts data");
            dispatcher.Dispatch(new FetchOrderContactsFailureAction(ex.Message));
        }
    }
}