using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.NotificationsUseCase;

public class NotificationEffects(IGeneralInfoRepository generalInfoRepository, IBasketActionsRepository basketActionsRepository,
    ILogger<NotificationEffects> logger, IToastService toastService)
{
    private readonly IGeneralInfoRepository _generalInfoRepository = generalInfoRepository
        ?? throw new ArgumentNullException(nameof(generalInfoRepository));
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));

    [EffectMethod]
    public async Task HandleFetchNotificationAction(FetchNotificationsAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogDebug("Effect: Handling fetch notifications action");
            var notifications = await _generalInfoRepository.GetNotificationsAsync();

            ShowBasketNotifications(toastService, dispatcher, notifications);

            dispatcher.Dispatch(new FetchNotificationsSuccessAction(notifications));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching notification");
            dispatcher.Dispatch(new FetchNotificationsFailureAction(ex.Message));
        }
    }

    private static void ShowBasketNotifications(IToastService toastService, IDispatcher dispatcher, List<BasketNotificationDto?>? notifications)
    {
        if (notifications is not null && notifications is { Count: > 0 })
        {
            foreach (var notification in notifications)
            {
                if (notification is not null)
                    toastService.ShowBasketNotification(notification,
                        sb => dispatcher.Dispatch(new DeleteNotificationAction(
                            notification.ProcedureCall)));
            }
        }
    }

    [EffectMethod]
    public async Task HandleDeleteNotificationAction(DeleteNotificationAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("deleting notification.");
            await _basketActionsRepository.PostProcedureCallAsync(action.ProcedureCall);
#warning TODO: Implement the delete notification response handling logic
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while deleting notification");
            dispatcher.Dispatch(new DeleteNotificationFailureAction(ex.Message));
        }
        finally
        {
            dispatcher.Dispatch(new FetchNotificationsAction());
        }
    }
}
