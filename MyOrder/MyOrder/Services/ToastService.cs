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
    private static void ToastOptions(SnackbarOptions options)
    {
        options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
        options.VisibleStateDuration = 1500;
        options.HideTransitionDuration = 100;
        options.ShowTransitionDuration = 100;
    }

    public void ShowBasketNotification(BasketNotificationDto notification, Action<Snackbar>? onClose = null)
    {
        snackbarService.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

        static void configureOptions(SnackbarOptions options)
        {
            options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
            options.HideTransitionDuration = 100;
            options.ShowTransitionDuration = 100;
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

            var snackbar = snackbarService.Add(content, severity, configureOptions, notification.NotificationId.ToString());

            if (snackbar is not null && onClose is not null)
                snackbar.OnClose += onClose;
        }
    }



    public void ShowCustom(string message, string? title = null,
        ToastLevel level = ToastLevel.Info, Action? onClose = null,
        string? icon = null)
    {
        //var severity = level switch
        //{
        //    ToastLevel.Success => Severity.Success,
        //    ToastLevel.Error => Severity.Error,
        //    ToastLevel.Info => Severity.Info,
        //    ToastLevel.Warning => Severity.Warning,
        //    _ => Severity.Info
        //};

        //var snackbar = snackbarService.Add(message, severity, options =>
        //{
        //    options.Icon = icon;
        //    options.VisibleStateDuration = 10000;
        //    options.HideTransitionDuration = 500;
        //});

        //if (snackbar != null)
        //    snackbar.OnClose += (sb) => onClose?.Invoke();
        //else
        //    logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());

    }

    public void ShowError(string message, Action? onClose = null)
    {
        //snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomLeft;

        //var snackbar = snackbarService.Add(message, Severity.Error, ToastOptions);

        //if (snackbar != null)
        //    snackbar.OnClose += (sb) => onClose?.Invoke();
        //else
        //    logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }

    public void ShowInfo(string message, Action? onClose = null)
    {
        //snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomLeft;

        //var snackbar = snackbarService.Add(message, Severity.Info);

        //if (snackbar != null)
        //    snackbar.OnClose += (sb) => onClose?.Invoke();
        //else
        //    logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }

    public void ShowSuccess(string message, Action? onClose = null)
    {
        //snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomLeft;

        //var snackbar = snackbarService.Add(message, Severity.Success, ToastOptions);

        //if (snackbar != null)
        //    snackbar.OnClose += (sb) => onClose?.Invoke();
        //else
        //    logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }

    public void ShowWarning(string message, Action? onClose = null)
    {
        //snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomLeft;

        //var snackbar = snackbarService.Add(message, Severity.Warning);

        //if (snackbar != null)
        //    snackbar.OnClose += (sb) => onClose?.Invoke();
        //else
        //    logger.LogError("Snackbar is null {stackTrace}", LogUtility.GetStackTrace());
    }
}