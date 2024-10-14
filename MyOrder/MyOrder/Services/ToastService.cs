using MudBlazor;
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