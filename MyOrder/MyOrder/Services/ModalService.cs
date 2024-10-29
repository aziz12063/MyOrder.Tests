using MudBlazor;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Components.Childs.Menu;

namespace MyOrder.Services;

public class ModalService(IDialogService dialogService) : IModalService
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

    public async Task<IDialogReference> OpenAddLineDialogAsync(Action? onCloseCallback = null)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false
        };

        var dialogReference = await dialogService.ShowAsync<AddLineDialog>(
            "AddLineDialog", options);

        var dialogResult = await dialogReference.Result;

        if (dialogResult?.Canceled == true)
            onCloseCallback?.Invoke();

        return dialogReference;
    }

    public async Task<IDialogReference> OpenNewBasketDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small };

        return await dialogService.ShowAsync<NewBasketDialog>("Simple Dialog", options);
    }

    public async Task<IDialogReference> OpenBasketDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, CloseButton = true };

        return await dialogService.ShowAsync<OpenBasketDialog>("Simple Dialog", options);
    }
}

public enum ModalSeverity
{
    info,
    success,
    warning,
    error
}
