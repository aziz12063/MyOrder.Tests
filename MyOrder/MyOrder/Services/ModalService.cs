using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Childs.Header.Delivery;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Components.Childs.Menu;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store;
using static MudBlazor.CategoryTypes;

namespace MyOrder.Services;

public class ModalService(IDialogService dialogService) : IModalService
{
    //public event Action<string, string, Action> OnShow;

    //public void ShowModal(string title, string message,
    //     Action onConfirm, ModalSeverity modalSeverity = ModalSeverity.info)
    //{
    //    OnShow?.Invoke(title, message, onConfirm);
    //}
    
    

    public async Task<IDialogReference> OpenAddLineDialogAsync(AddLineDialogTab index, Action? onCloseCallback = null )
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false
        };

        var parameters = new DialogParameters<AddLineDialog>
        {
            { dialog => dialog.CurrentTab, index }
        };

        var dialogReference = await dialogService.ShowAsync<AddLineDialog>(
            "AddLineDialog", parameters, options);

        var dialogResult = await dialogReference.Result;

        if (dialogResult?.Canceled == true)
            onCloseCallback?.Invoke();

        return dialogReference;
    }

    public async Task<IDialogReference> OpenNewBasketDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small };

        return await dialogService.ShowAsync<NewBasketDialog>("NewBasketDialog", options);
    }

    public async Task<IDialogReference> OpenBasketDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, CloseButton = true };

        return await dialogService.ShowAsync<OpenBasketDialog>("OpenBasketDialog", options);
    }

    public async Task<IDialogReference> OpenBasketOrderNoteDialogAsync(Field<string> noteField)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, CloseButton = true, BackdropClick = false };
        var parameters = new DialogParameters<BasketNotesDialog>
        {
            { dialog => dialog.NoteField, noteField }
        };
        return await dialogService.ShowAsync<BasketNotesDialog>("BasketNotesDialog", parameters, options);
    }

    public async Task<IDialogReference> OpenSearchContactDialogAsync<TState, TAction>(
        Action<ContactDto> contactClicked)
        where TState : class, IContactsState
        where TAction : class, IFetchContactsAction
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, CloseButton = true };
        var parameters = new DialogParameters<SearchContactDialog<TState, TAction>>
        {
            { dialog => dialog.ContactClicked,
                EventCallback.Factory.Create(this, contactClicked)
            }
        };

        return await dialogService.ShowAsync<SearchContactDialog<TState, TAction>>(
            "Search contact", parameters, options);
    }

    public async Task<IDialogReference> OpenSearchAccountDialogAsync<TState, TAction>(
        Action<AccountDto> accountClicked,
        Action addNewAccountClicked)
        where TState : class, IAccountsState
        where TAction : class, IFetchAccountsAction
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            FullWidth = true,
            MaxWidth = MaxWidth.Small,
            CloseButton = true
        };
        var parameters = new DialogParameters<SearchAccountDialog<TState, TAction>>
        {
            { dialog => dialog.AccountClicked,
                EventCallback.Factory.Create(this, accountClicked)
            },
            {
                dialog => dialog.AddNewAccountClicked,
                EventCallback.Factory.Create(this, addNewAccountClicked)
            }
        };

        return await dialogService.ShowAsync<SearchAccountDialog<TState, TAction>>(
            "Search compte", parameters, options);
    }

    public async Task<IDialogReference> OpenEditDeliveryAccountDialogAsync(Action? onCloseCallback = null, string? accountId = null)
    {

        var parameters = new DialogParameters<NewDeliveryAccountDialog>
        {
            { dialog => dialog.AccountId, accountId},
        };

        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false
        };

        var dialogReference = await dialogService.ShowAsync<NewDeliveryAccountDialog>(
            "EditDeliveryAccountDialog", parameters, options);

        var dialogResult = await dialogReference.Result;

        if (dialogResult?.Canceled == true)
            onCloseCallback?.Invoke();

        return dialogReference;
    }

    public async Task<bool> ShowConfirmationDialog(string message, string? title = null,
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

    public async Task<IDialogReference> OpenPaymentAuthorizationDialog()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, BackdropClick = false, CloseButton = true };

        return await dialogService.ShowAsync<PaymentAuthorizationDialog>("PaymentAuthorization", options);
    }

    
}

public enum ModalSeverity
{
    info,
    success,
    warning,
    error
}
