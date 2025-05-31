using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class DeliveryPanel : FluxorComponentBase<DeliveryInfoState, FetchDeliveryInfoAction>
{
    [Inject]
    private IState<DeliveryAccountsState> DeliveryAccountsState { get; set; }
    [Inject]
    private IState<DeliveryContactsState> DeliveryContactsState { get; set; }
    [Inject]
    private IModalService ModalService { get; set; }

    private BasketDeliveryInfoDto? BasketDeliveryInfo { get; set; }
    private List<AccountDto?>? Accounts { get; set; }
    private List<ContactDto?>? Contacts { get; set; }
    private List<BasketValueDto?>? DeliveryModes { get; set; }
    private bool isLoading = true;
    private bool disposed = false;


    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new FetchDeliveryAccountsAction(DeliveryAccountsState.Value));
        DeliveryAccountsState.StateChanged += DeliveryAccountsStateChanged;
        Dispatcher.Dispatch(new FetchDeliveryContactsAction(DeliveryContactsState.Value));
        DeliveryContactsState.StateChanged += DeliveryContactsStateChanged;

        base.OnInitialized();
    }
    protected override FetchDeliveryInfoAction CreateFetchAction(DeliveryInfoState state) => new(state);

    protected override void CacheNewFields()
    {
        DeliveryModes = State?.Value.DeliveryModes
           ?? throw new ArgumentNullException(nameof(State.Value.DeliveryModes), "Unexpected null for DeliveryModes object.");

        BasketDeliveryInfo = State?.Value.BasketDeliveryInfo
                             ?? throw new ArgumentNullException(nameof(State.Value.BasketDeliveryInfo), "Unexpected null for BasketOrderInfo object.");
        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    private void DeliveryAccountsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for Accounts in {Component}",
            GetType().Name);

        InvokeAsync(() =>
        {
            Accounts = DeliveryAccountsState.Value.Accounts;
            StateHasChanged();
        });

        Logger.LogDebug("StateChanged handler completed for Accounts {Component}",
            GetType().Name);
    }

    private void DeliveryContactsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for Contacts in {Component}",
            GetType().Name);

        InvokeAsync(() =>
        {
            Contacts = DeliveryContactsState.Value.Contacts;
            StateHasChanged();
        });

        Logger.LogDebug("StateChanged handler completed for Contacts {Component}",
            GetType().Name);
    }

    private async Task OpenContactSearchDialogAsync()
    {
        if (BasketDeliveryInfo?.Contact is null)
        {
            Logger.LogWarning("Contact is null in {Component}",
                GetType().Name);
            return;
        }
        await ModalService.OpenSearchContactDialogAsync<DeliveryContactsState, FetchDeliveryContactsAction>(
             contact => Dispatcher.Dispatch(
                    new UpdateFieldAction(BasketDeliveryInfo.Contact, contact, typeof(FetchDeliveryInfoAction)))
             );
    }

    private async Task OpenAccountSearchDialogAsync()
    {
        if (BasketDeliveryInfo?.Account is null)
        {
            Logger.LogWarning("Account is null in {Component}",
                GetType().Name);
            return;
        }
#warning This is a temporary solution to avoid the error of the new account not being reset
        Dispatcher.Dispatch(new ResetNewDeliveryAccountAction());

        await ModalService.OpenSearchAccountDialogAsync<DeliveryAccountsState, FetchDeliveryAccountsAction>(
            account => Dispatcher.Dispatch(
                new UpdateFieldAction(BasketDeliveryInfo.Account, account, typeof(FetchDeliveryInfoAction))),
                async () => await ModalService.OpenEditDeliveryAccountDialogAsync(
                        () => Dispatcher.Dispatch(new ResetNewDeliveryAccountAction()))
            );
    }

    private async Task<IDialogReference> OpenEditDeliveryAccountDialogAsync()
    {
#warning This is a temporary solution to avoid the error of the new account not being reset. Force hard reset from the server whenever we want to edit an account (when account ID is set as a parameter)
        Dispatcher.Dispatch(new ResetNewDeliveryAccountAction());

        return await ModalService.OpenEditDeliveryAccountDialogAsync(
            () => Dispatcher.Dispatch(new ResetNewDeliveryAccountAction()), BasketDeliveryInfo?.Account?.Value?.AccountId);
    }

    private async Task<IDialogReference> OpenDeliveryInstructionsAsync()
    {
#warning This is a temporary solution to avoid the error of the new account not being reset. Force hard reset from the server whenever we want to edit an account (when account ID is set as a parameter)
        Dispatcher.Dispatch(new ResetNewDeliveryAccountAction());

        return await ModalService.OpenEditDeliveryInstructionsDialogAsync(
            () => Dispatcher.Dispatch(new ResetNewDeliveryAccountAction()), BasketDeliveryInfo?.Account?.Value?.AccountId);
    }

    private async Task<IDialogReference> OpenAddDeliveryContactAsync()
    {
        return await ModalService.OpenEditDeliveryContactDialogAsync(
            () => Dispatcher.Dispatch(new ResetNewDeliveryContactAction()));
    }

    private async Task<IDialogReference> OpenEditDeliveryContactAsync()
    {
        return await ModalService.OpenEditDeliveryContactDialogAsync(
            () => Dispatcher.Dispatch(new ResetNewDeliveryContactAction()), BasketDeliveryInfo?.Contact?.Value?.ContactId);
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                DeliveryAccountsState.StateChanged -= DeliveryAccountsStateChanged;
                DeliveryContactsState.StateChanged -= DeliveryContactsStateChanged;
            }
            disposed = true;
        }
        base.Dispose(disposing);
    }
}