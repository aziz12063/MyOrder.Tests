using MudBlazor;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store;

namespace MyOrder.Services;

public interface IModalService
{
    //event Action<string, string, Action> OnShow;

    Task<IDialogReference> OpenAddLineDialogAsync(AddLineDialogTab index, Action? onCloseCallback = null);
    Task<IDialogReference> OpenEditDeliveryAccountDialogAsync(Action? onCloseCallback = null, string? accountId = null);

    Task<IDialogReference> OpenNewBasketDialogAsync();
    Task<IDialogReference> OpenBasketDialogAsync();
    Task<IDialogReference> OpenBasketOrderNoteDialogAsync(Field<string> noteField);

    Task<IDialogReference> OpenSearchContactDialogAsync<TState, TAction>(
        Action<ContactDto> contactClicked)
        where TState : class, IContactsState
        where TAction : class, IFetchContactsAction;
    Task<IDialogReference> OpenSearchAccountDialogAsync<TState, TAction>(
        Action<AccountDto> accountClicked,
        Action addNewAccountClicked)
        where TState : class, IAccountsState
        where TAction : class, IFetchAccountsAction;
    Task<bool> ShowConfirmationDialog(string message, string? title = null,
        Action? onConfirm = null, ModalSeverity modalSeverity = ModalSeverity.info);

    Task<IDialogReference> OpenPaymentAuthorizationDialog();
    //public void ShowModal(string title, string message,
    // Action onConfirm, ModalSeverity modalSeverity = ModalSeverity.info);

}
