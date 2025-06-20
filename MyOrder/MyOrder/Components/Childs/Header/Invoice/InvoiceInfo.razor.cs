using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;

namespace MyOrder.Components.Childs.Header.Invoice;

public sealed partial class InvoiceInfo : FluxorComponentBase<InvoiceInfoState, FetchInvoiceInfoAction>, IDisposable
{
    [Inject]
    private IState<InvoiceAccountsState> InvoiceAccountsState { get; set; } = null!;
    [Inject]
    private IModalService ModalService { get; set; } = null!;

    private InvoicePanelDto BasketInvoiceInfo => State.Value.BasketInvoiceInfo;
    private List<AccountDto?>? InvoiceToAccounts { get; set; }
    private List<BasketValueDto?>? TaxGroups { get; set; }
    private List<BasketValueDto?>? PaymentModes { get; set; }
    private Field<string?>? PaymentAuthorizationAction => BasketInvoiceInfo.PaymentAuthorizationAction;

    private string AccountLandLine => BasketInvoiceInfo?.Account?.Value?.Phone ?? string.Empty;
    private string AccountCellularPhone => BasketInvoiceInfo?.Account?.Value?.CellularPhone ?? string.Empty;

    protected override FetchInvoiceInfoAction CreateFetchAction() =>
        new();

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(
            new FetchInvoiceAccountsAction());
        InvoiceAccountsState.StateChanged += InvoiceAccountsStateChanged;

        base.OnInitialized();

        TaxGroups = ResourcesState?.Value.TaxGroups
            ?? throw new NullReferenceException("Unexpected null for TaxGroups object.");

        PaymentModes = ResourcesState?.Value.PaymentModes
            ?? throw new NullReferenceException("Unexpected null for PaymentModes object.");
    }

    private void InvoiceAccountsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for Accounts in {Component}",
            GetType().Name);

        InvokeAsync(() =>
        {
            InvoiceToAccounts = InvoiceAccountsState.Value.Accounts;
            StateHasChanged();
        });

        Logger.LogDebug("StateChanged handler completed for Accounts {Component}", GetType().Name);
    }

    private async Task OpenAccountSearchDialogAsync()
    {
        if (BasketInvoiceInfo?.Account is null)
        {
            Logger.LogWarning("Account is null in {Component}",
                GetType().Name);
            return;
        }

        await ModalService.OpenSearchAccountDialogAsync<InvoiceAccountsState, FetchInvoiceAccountsAction>(
            account => Dispatcher.Dispatch(
                new UpdateFieldAction(BasketInvoiceInfo.Account, account, typeof(FetchInvoiceAccountsAction))),
                () => throw new NotImplementedException(),
                () => Dispatcher.Dispatch(new FetchInvoiceAccountsAction(null, null))
            );
    }

    public void Dispose() => InvoiceAccountsState.StateChanged -= InvoiceAccountsStateChanged;
}
