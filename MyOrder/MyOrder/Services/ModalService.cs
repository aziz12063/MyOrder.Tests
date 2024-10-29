using MudBlazor;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Components.Childs.Menu;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos.GeneralInformation;

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

    public async Task<bool> ShowConfirmationDialog( string message, string? title = null,
        Action? onConfirm = null, ModalSeverity modalSeverity = ModalSeverity.info)
    {
        var parameters = new DialogParameters<ConfirmationDialog>
        {
            { dialog => dialog.Message, message},
            { dialog => dialog.SeverityColor, GetSeverityColor(modalSeverity)}

        };

        if (title != null)
        {
            parameters.Add(dialog => dialog.Title, title);
        }

        var dialogReference = await dialogService.ShowAsync<ConfirmationDialog>(
            "confirmationDialog", parameters);

        var result = await dialogReference.Result;

        if ((bool?)result?.Data == true)
        {
            onConfirm?.Invoke();
            return true;
        }
        else
            return false;
    }

    private static Color GetSeverityColor(ModalSeverity modalSeverity)
    {
        return modalSeverity switch
        {
            ModalSeverity.info => Color.Info,
            ModalSeverity.success => Color.Success,
            ModalSeverity.warning => Color.Warning,
            ModalSeverity.error => Color.Error,
            _ => Color.Info
        };
    }
}

public enum ModalSeverity
{
    info,
    success,
    warning,
    error
}
