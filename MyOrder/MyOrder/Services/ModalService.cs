namespace MyOrder.Services
{
    public class ModalService : IModalService
    {
        public event Action<string, string, Action> OnShow;
        public event Action OnClose;

        public void ShowModal(string title, string message,
             Action onConfirm, ModalSeverity modalSeverity = ModalSeverity.info)
        {
            OnShow?.Invoke(title, message, onConfirm);
        }

        public void CloseModal()
        {
            OnClose?.Invoke();
        }
    }

    public enum ModalSeverity
    {
        info,
        success,
        warning,
        error
    }
}
