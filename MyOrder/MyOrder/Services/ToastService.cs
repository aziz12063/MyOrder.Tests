using MudBlazor;

namespace MyOrder.Services;

public class ToastService(ISnackbar snackbar, ILogger<ToastService> logger)
    : IToastService
{

    public event Action<string, string, ToastLevel> OnShow;

    public void ShowCustom(string message, string? title = null, ToastLevel level = ToastLevel.Info, Action? onClose = null, string? icon = null)
    {
        throw new NotImplementedException();
    }

    public void ShowError(string message, Action? onClose = null)
    {
        throw new NotImplementedException();
    }

    public void ShowInfo(string message, Action? onClose = null)
    {
        throw new NotImplementedException();
    }

    public void ShowSuccess(string message, Action? onClose = null)
    {
        throw new NotImplementedException();
    }

    public void ShowToast(string message, string title = "", ToastLevel level = ToastLevel.Info)
    {
        OnShow?.Invoke(message, title, level);
    }

    public void ShowWarning(string message, Action? onClose = null)
    {
        throw new NotImplementedException();
    }
}

public enum ToastLevel
{
    Success,
    Error,
    Info,
    Warning
}
