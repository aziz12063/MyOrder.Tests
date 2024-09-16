namespace MyOrder.Services
{
    public class ToastService
    {

        public event Action<string, string, ToastLevel> OnShow;

        public void ShowToast(string message, string title = "", ToastLevel level = ToastLevel.Info)
        {
            OnShow?.Invoke(message, title, level);
        }
    }

    public enum ToastLevel
    {
        Success,
        Error,
        Info,
        Warning
    }
}
