using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.NotificationsUseCase;

namespace MyOrder.Components.Childs;

public partial class Notifications : FluxorComponentBase<NotificationsState, FetchNotificationsAction>
{
    [Inject]
    private ISnackbar Snackbar { get; set; }
    private List<BasketNotificationDto?>? BasketNotifications { get; set; }

    protected override FetchNotificationsAction CreateFetchAction(NotificationsState state, string basketId) => new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketNotifications = State?.Value.Notifications
                     ?? throw new ArgumentNullException(nameof(State.Value.Notifications), "Unexpected null for BasketNotifications object.");
    }

    protected override void OnStateChanged(object? sender, EventArgs e)
    {
        base.OnStateChanged(sender, e);

        if (BasketNotifications is not null && BasketNotifications is { Count: > 0 })
        {
            foreach (var notification in BasketNotifications)
            {
                if (notification is not null)
                    ShowNotification(notification);
            }
        }
    }

    private void ShowNotification(BasketNotificationDto notification)
    {
        Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

        static void config(SnackbarOptions options)
        {
            options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
            options.HideTransitionDuration = 200;
            options.ShowTransitionDuration = 200;
            options.VisibleStateDuration = int.MaxValue;
            options.SnackbarVariant = Variant.Text;
            options.ShowCloseIcon = true;
            options.CloseAfterNavigation = false;
            options.SnackbarTypeClass = "basket-notification-snackbar mt-11";
        }

        var severity = notification.Severity switch
        {
            "Error" => Severity.Error,
            "Warn" => Severity.Warning,
            "Info" => Severity.Info,
            "Success" => Severity.Success,
            _ => Severity.Info
        };

        if (notification.Message is not null)
        {
            var snackbar = Snackbar.Add(new MarkupString(notification.Message), severity, config, notification.NotificationId.ToString());
            if (snackbar is not null)
                snackbar.OnClose +=
                sb => Dispatcher.Dispatch(
                    new DeleteNotificationAction(
                        State.Value, notification.ProcedureCall, BasketId));
        }

    }

    private void RemoveNotification(Snackbar snackbar)
    {
        var notification = BasketNotifications?.Find(notification
            => notification?.Message?.Equals(snackbar.Message) ?? false);
        // if (notification is not null)
        //   Dispatcher.Dispatch(new UpdateFieldAction(BasketId, notification.ProcedureCall?.ToList()));
    }

    private void RemoveNotification(BasketNotificationDto notification)
    {
        //Dispatcher.Dispatch(new UpdateFieldAction(BasketId, notification.ProcedureCall.ToList()));
        Snackbar.RemoveByKey(notification.NotificationId.ToString());
    }
}
