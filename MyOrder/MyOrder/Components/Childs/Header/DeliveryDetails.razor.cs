using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class DeliveryDetails : FluxorComponentBase<DeliveryInfoState, FetchDeliveryInfoAction>
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
    private List<string>? AccountAddress { get; set; }
    private string DisplayAddress { get; set; } = string.Empty;
    private bool isLoading = true;
    private bool disposed = false;


    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new FetchDeliveryAccountsAction(DeliveryAccountsState.Value, BasketId));
        DeliveryAccountsState.StateChanged += DeliveryAccountsStateChanged;
        Dispatcher.Dispatch(new FetchDeliveryContactsAction(DeliveryContactsState.Value, BasketId));
        DeliveryContactsState.StateChanged += DeliveryContactsStateChanged;

        base.OnInitialized();
        DeliveryModes = RessourcesState?.Value.DeliveryModes
            ?? throw new ArgumentNullException(nameof(RessourcesState.Value.DeliveryModes), "Unexpected null for DeliveryModes object.");
    }
    protected override FetchDeliveryInfoAction CreateFetchAction(DeliveryInfoState state, string basketId) => new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketDeliveryInfo = State?.Value.BasketDeliveryInfo
                             ?? throw new ArgumentNullException(nameof(State.Value.BasketDeliveryInfo), "Unexpected null for BasketOrderInfo object.");

        AccountAddress = FieldUtility.CreateAddressList(BasketDeliveryInfo?.Account?.Value);
        DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);
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
        await ModalService.OpenSearchAccountDialogAsync<DeliveryAccountsState, FetchDeliveryAccountsAction>(
            account => Dispatcher.Dispatch(
                new UpdateFieldAction(BasketDeliveryInfo.Account, account, typeof(FetchDeliveryInfoAction)))
            );
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

