using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.NotificationsUseCase;

public class NotificationEffects(IBasketRepository basketRepository, ILogger<NotificationEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchNotificationAction(FetchNotificationsAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("fetching notification for {BasketId}", action.BasketId);
            var notifications = await basketRepository.GetNotificationsAsync(action.BasketId);
            dispatcher.Dispatch(new FetchNotificationsSuccessAction(notifications));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching notification");
            dispatcher.Dispatch(new FetchNotificationsFailureAction(ex.Message));
        }
    }
}
