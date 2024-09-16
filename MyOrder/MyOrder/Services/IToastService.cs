namespace MyOrder.Services;

public interface IToastService
{
    event Action<string, string, ToastLevel> OnShow;
    void ShowToast(string message, string title = "", ToastLevel level = ToastLevel.Info);
}
