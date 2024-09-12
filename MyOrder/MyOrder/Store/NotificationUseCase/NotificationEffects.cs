using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.LinesUseCase;

namespace MyOrder.Store.NotificationUseCase
{
    public class NotificationEffects(IBasketRepository basketRepository, ILogger<NotificationEffects> logger)
    {
        [EffectMethod]
        public async Task HandleFetchNotificationAction(FetchNotificationAction action, IDispatcher dispatcher)
        {
            try
            {
                logger.LogInformation("fetching notification for {BasketId}", action.BasketId);
                var notification = await basketRepository.GetNotificationsAsync(action.BasketId);
                dispatcher.Dispatch(new FetchNotificationSuccessAction(notification));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while fetching notification");
                dispatcher.Dispatch(new FetchNotificationFailureAction(ex.Message));
            }
        }
    }
}
