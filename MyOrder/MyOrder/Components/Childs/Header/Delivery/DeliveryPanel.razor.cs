using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public sealed partial class DeliveryPanel : FluxorComponentBase<DeliveryInfoState, FetchDeliveryInfoAction>, IDisposable
{
    [Inject]
    private IState<DeliveryAccountsState> DeliveryAccountsState { get; set; } = null!;
    [Inject]
    private IState<DeliveryContactsState> DeliveryContactsState { get; set; } = null!;
    [Inject]
    private IModalService ModalService { get; set; } = null!;

    private BasketDeliveryInfoDto BasketDeliveryInfo => State.Value.BasketDeliveryInfo;
    private List<AccountDto?>? Accounts { get; set; }
    private List<ContactDto?>? Contacts { get; set; }
    private List<BasketValueDto?>? DeliveryModes => State.Value.DeliveryModes;
    private bool disposed = false;

    private string AccountLandLine => BasketDeliveryInfo?.Account?.Value?.Phone ?? string.Empty;
    private string AccountCellularPhone => BasketDeliveryInfo?.Account?.Value?.CellularPhone ?? string.Empty;
    private string ContactLandLine => BasketDeliveryInfo?.Contact?.Value?.Phone ?? string.Empty;
    private string ContactCellularPhone => BasketDeliveryInfo?.Contact?.Value?.CellularPhone ?? string.Empty;

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new FetchDeliveryAccountsAction());
        DeliveryAccountsState.StateChanged += DeliveryAccountsStateChanged;
        Dispatcher.Dispatch(new FetchDeliveryContactsAction());
        DeliveryContactsState.StateChanged += DeliveryContactsStateChanged;

        base.OnInitialized();
    }
    protected override FetchDeliveryInfoAction CreateFetchAction() => new();

    private void DeliveryAccountsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for Accounts in {Component}",
            GetType().Name);
        Accounts = DeliveryAccountsState.Value.Accounts;
        StateHasChanged();
    }

    private void DeliveryContactsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for Contacts in {Component}",
            GetType().Name);
        Contacts = DeliveryContactsState.Value.Contacts;
        StateHasChanged();
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
                    new UpdateFieldAction(BasketDeliveryInfo.Contact, contact, typeof(FetchDeliveryInfoAction))),
             () => Dispatcher.Dispatch(new FetchDeliveryContactsAction(null, null))
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
                        () => Dispatcher.Dispatch(new ResetNewDeliveryAccountAction())),
                () => Dispatcher.Dispatch(new FetchDeliveryAccountsAction(null, null))
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

    public void Dispose()
    {
        DeliveryAccountsState.StateChanged -= DeliveryAccountsStateChanged;
        DeliveryContactsState.StateChanged -= DeliveryContactsStateChanged;
    }
}