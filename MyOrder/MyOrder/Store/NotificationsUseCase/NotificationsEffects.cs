using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.NotificationsUseCase;

public class NotificationEffects(IBasketRepository basketRepository, ILogger<NotificationEffects> logger,
    IToastService toastService)
{
    [EffectMethod]
    public async Task HandleFetchNotificationAction(FetchNotificationsAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogDebug("Fetching Notifications for {BasketId}", action.BasketId);
            var notifications = await basketRepository.GetNotificationsAsync(action.BasketId);
            
            ShowBasketNotifications(toastService, action.BasketId, dispatcher, notifications, action.State);

            dispatcher.Dispatch(new FetchNotificationsSuccessAction(notifications));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching notification");
            dispatcher.Dispatch(new FetchNotificationsFailureAction(ex.Message));
        }
    }

    private static void ShowBasketNotifications(IToastService toastService, string basketId, IDispatcher dispatcher, List<BasketNotificationDto?>? notifications, NotificationsState? state = null)
    {
        if (notifications is not null && notifications is { Count: > 0 })
        {
            foreach (var notification in notifications)
            {
                if (notification is not null)
                    toastService.ShowBasketNotification(notification,
                        sb => dispatcher.Dispatch(new DeleteNotificationAction(
                            notification.ProcedureCall, basketId, state)));
            }
        }
    }

    [EffectMethod]
    public async Task HandleDeleteNotificationAction(DeleteNotificationAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("deleting notification for {BasketId}", action.BasketId);
            await basketRepository.PostProcedureCallAsync(action.ProcedureCall, action.BasketId);
#warning TODO: Implement the delete notification response handling logic
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while deleting notification");
            dispatcher.Dispatch(new DeleteNotificationFailureAction(ex.Message));
        }
        finally
        {
            dispatcher.Dispatch(new FetchNotificationsAction(action.State, action.BasketId));
        }
    }

}
