using MudBlazor;
using MyOrder.Components.Childs.Lines.AddLine;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store;
using MyOrder.Store.Base;

namespace MyOrder.Services;

public interface IModalService
{
    //event Action<string, string, Action> OnShow;

    Task<IDialogReference> OpenAddLineDialogAsync(AddLineDialogTab index);
    Task<IDialogReference> OpenEditDeliveryAccountDialogAsync(string? accountId = null, bool isNew = false);
    Task<IDialogReference> OpenEditDeliveryInstructionsDialogAsync(string? accountId = null);
    Task<IDialogReference> OpenEditDeliveryContactDialogAsync(string? contactId = null, bool isNew = false);

    Task<IDialogReference> OpenNewBasketDialogAsync();
    Task<IDialogReference> OpenBasketDialogAsync();
    Task<IDialogReference> OpenBlockingReasonsDialogAsync();
    Task<IDialogReference> OpenBasketOrderNoteDialogAsync(Field<string> noteField);

    Task<IDialogReference> OpenSearchContactDialogAsync<TState, TAction>(
        Action<ContactDto> contactClicked,
        Action onCloseCallback)
        where TState : StateBase, IContactsState
        where TAction : class, IFetchContactsAction;
    Task<IDialogReference> OpenSearchAccountDialogAsync<TState, TAction>(
        Action<AccountDto> accountClicked,
        Action addNewAccountClicked,
        Action onCloseCallback)
        where TState : StateBase, IAccountsState
        where TAction : class, IFetchAccountsAction;
    Task<bool> ShowConfirmationDialog(string message, string? title = null,
        Action? onConfirm = null, ModalSeverity modalSeverity = ModalSeverity.info);

    Task<IDialogReference> OpenPaymentAuthorizationDialog();
    Task<IDialogReference> OpenSearchSupplierDialog();
    //public void ShowModal(string title, string message,
    // Action onConfirm, ModalSeverity modalSeverity = ModalSeverity.info);

}
