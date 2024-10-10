using MudBlazor;

namespace MyOrder.Services;

public interface IToastService
{
    event Action<string, string, ToastLevel> OnShow;

    void ShowSuccess(string message, Action? onClose = null);
    void ShowError(string message, Action? onClose = null);
    void ShowInfo(string message, Action? onClose = null);
    void ShowWarning(string message, Action? onClose = null);
    void ShowCustom(string message, string? title = null,
        ToastLevel level = ToastLevel.Info, Action? onClose = null, string? icon = null);

//void ShowToast(string message, string title = "", ToastLevel level = ToastLevel.Info);
}
