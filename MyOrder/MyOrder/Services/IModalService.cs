using MudBlazor;
using MyOrder.Shared.Dtos.GeneralInformation;

namespace MyOrder.Services;

public interface IModalService
{
    public event Action<string, string, Action> OnShow;
    public event Action OnClose;

    public Task<IDialogReference> OpenAddLineDialogAsync(Action? onCloseCallback = null);
    public Task<IDialogReference> OpenNewBasketDialogAsync();
    public Task<IDialogReference> OpenBasketDialogAsync();
    public Task<IDialogReference> LastOpenedBaskets(List<BasketHistory?>? basketHistories);

    public void ShowModal(string title, string message,
     Action onConfirm, ModalSeverity modalSeverity = ModalSeverity.info);

    void CloseModal();
}
