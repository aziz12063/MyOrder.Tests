using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Childs.GeneralInfo;
using MyOrder.Components.Childs.Header.Delivery;
using MyOrder.Components.Childs.Header.Invoice;
using MyOrder.Components.Childs.Lines;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store;
using MyOrder.Store.Base;
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

    public async Task<IDialogReference> OpenAddLineDialogAsync(AddLineDialogTab index)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false,
            FullWidth = true
        };

        var parameters = new DialogParameters<AddLineDialog>
        {
            { dialog => dialog.CurrentTab, index }
        };

        return await dialogService.ShowAsync<AddLineDialog>(
            "AddLineDialog", parameters, options);
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

    public async Task<IDialogReference> OpenBlockingReasonsDialogAsync()
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            FullWidth = true,
            MaxWidth = MaxWidth.Small,
            CloseButton = true,
            BackdropClick = true
        };
        return await dialogService.ShowAsync<BlockingReasonsDialog>("BlockingReasonsDialog", options);
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
        Action<ContactDto> contactClicked,
        Action onCloseCallback)
        where TState : StateBase, IContactsState
        where TAction : class, IFetchContactsAction
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, CloseButton = true };
        var parameters = new DialogParameters<SearchContactDialog<TState, TAction>>
        {
            { dialog => dialog.ContactClicked,
                EventCallback.Factory.Create(this, contactClicked)
            }
        };

        var dialog = await dialogService.ShowAsync<SearchContactDialog<TState, TAction>>(
            "Search contact", parameters, options);

        var dialogResult = await dialog.Result;

        onCloseCallback?.Invoke();

        return dialog;
    }

    public async Task<IDialogReference> OpenSearchAccountDialogAsync<TState, TAction>(
        Action<AccountDto> accountClicked,
        Action addNewAccountClicked,
        Action onCloseCallback)
        where TState : StateBase, IAccountsState
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

        var dialog = await dialogService.ShowAsync<SearchAccountDialog<TState, TAction>>(
            "Search compte", parameters, options);

        var dialogResult = await dialog.Result;

        onCloseCallback?.Invoke();

        return dialog;
    }

    public async Task<IDialogReference> OpenEditDeliveryAccountDialogAsync(string? accountId = null, bool isNew = false)
    {

        var parameters = new DialogParameters<NewDeliveryAccountDialog>
        {
            { dialog => dialog.AccountId, accountId},
            { dialog => dialog.IsNewAccount, isNew }
        };

        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false,
            MaxWidth = MaxWidth.Small,
            FullWidth = true
        };

        return await dialogService.ShowAsync<NewDeliveryAccountDialog>(
            "EditDeliveryAccountDialog", parameters, options);
    }

    public async Task<IDialogReference> OpenEditDeliveryInstructionsDialogAsync(string? accountId = null)
    {
        var parameters = new DialogParameters<NewDeliveryAccountDialog>
        {
            { dialog => dialog.AccountId, accountId},
        };

        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true
        };

        return await dialogService.ShowAsync<DeliveryInstructionsDialog>(
            "EditDeliveryAccountDialog", parameters, options);
    }

    public async Task<IDialogReference> OpenEditDeliveryContactDialogAsync(string? contactId = null, bool isNew = false)
    {
        var parameters = new DialogParameters<NewDeliveryContactDialog>
        {
            { dialog => dialog.ContactId, contactId},
            { dialog => dialog.IsNewContact, isNew }
        };
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            CloseButton = true,
            BackdropClick = false,
            MaxWidth = MaxWidth.Small,
            FullWidth = true
        };
        return await dialogService.ShowAsync<NewDeliveryContactDialog>(
            "EditDeliveryContactDialog", parameters, options);
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

    public async Task<IDialogReference> OpenSearchSupplierDialog()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, CloseButton = true };
        return await dialogService.ShowAsync<SearchSupplierDialog>("SearchSupplierDialog", options);
    }
}

public enum ModalSeverity
{
    info,
    success,
    warning,
    error
}
