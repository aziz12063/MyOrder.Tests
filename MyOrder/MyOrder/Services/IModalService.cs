namespace MyOrder.Services;

public interface IModalService
{
    public event Action<string, string, Action> OnShow;
    public event Action OnClose;

    public void ShowModal(string title, string message,
     Action onConfirm, ModalSeverity modalSeverity = ModalSeverity.info);

    void CloseModal();
}
