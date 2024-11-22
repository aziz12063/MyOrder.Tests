using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MudBlazor;
using MyOrder.Components.Common.UI;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Utils;

namespace MyOrder.Services;

public enum ToastLevel
{
    Success,
    Error,
    Info,
    Warning
}

public class ToastService(ISnackbar snackbarService, ILogger<ToastService> logger)
    : IToastService
{
    public void ShowBasketNotification(BasketNotificationDto notification, Action<Snackbar>? onClose = null)
    {
        snackbarService.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

        static void config(SnackbarOptions options)
        {
            options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
            options.HideTransitionDuration = 200;
            options.ShowTransitionDuration = 200;
            options.VisibleStateDuration = int.MaxValue;
            options.SnackbarVariant = Variant.Text;
            options.ShowCloseIcon = true;
            options.CloseAfterNavigation = false;
            options.SnackbarTypeClass = "basket-notification-snackbar";
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
            void content(RenderTreeBuilder builder)
            {
                builder.OpenComponent<BasketNotificationContent>(0);
                builder.AddAttribute(1, BasketNotificationContent.ContentParameterName, new MarkupString(notification.Message));
                builder.CloseComponent();
            }

            var snackbar = snackbarService.Add(content, severity, config, notification.NotificationId.ToString());

            if (snackbar is not null && onClose is not null)
                snackbar.OnClose += onClose;
        }
    }

    public void ShowCustom(string message, string? title = null,
        ToastLevel level = ToastLevel.Info, Action? onClose = null,
        string? icon = null)
    {
        var severity = level switch
        {
            ToastLevel.Success => Severity.Success,
            ToastLevel.Error => Severity.Error,
            ToastLevel.Info => Severity.Info,
            ToastLevel.Warning => Severity.Warning,
            _ => Severity.Info
        };

        var snackbar = snackbarService.Add(message, severity, options =>
        {
            options.Icon = icon;
            options.VisibleStateDuration = 10000;
            options.HideTransitionDuration = 500;
        });

        if (snackbar != null)
            snackbar.OnClose += (sb) => onClose?.Invoke();
        else
            logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());

    }

    public void ShowError(string message, Action? onClose = null)
    {
        var snackbar = snackbarService.Add(message, Severity.Error);

        if (snackbar != null)
            snackbar.OnClose += (sb) => onClose?.Invoke();
        else
            logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }

    public void ShowInfo(string message, Action? onClose = null)
    {
        var snackbar = snackbarService.Add(message, Severity.Info);

        if (snackbar != null)
            snackbar.OnClose += (sb) => onClose?.Invoke();
        else
            logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }

    public void ShowSuccess(string message, Action? onClose = null)
    {
        var snackbar = snackbarService.Add(message, Severity.Success);

        if (snackbar != null)
            snackbar.OnClose += (sb) => onClose?.Invoke();
        else
            logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }

    public void ShowWarning(string message, Action? onClose = null)
    {
        var snackbar = snackbarService.Add(message, Severity.Warning);

        if (snackbar != null)
            snackbar.OnClose += (sb) => onClose?.Invoke();
        else
            logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }
}