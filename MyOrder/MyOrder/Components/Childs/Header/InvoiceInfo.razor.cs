using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class InvoiceInfo : FluxorComponentBase<InvoiceInfoState, FetchInvoiceInfoAction>
{
    [Inject]
    private IState<InvoiceAccountsState> InvoiceAccountsState { get; set; } = null!;
    [Inject]
    private IModalService ModalService { get; set; } = null!;

    private InvoicePanelDto? BasketInvoiceInfo { get; set; }
    private List<AccountDto?>? InvoiceToAccounts { get; set; }
    private List<BasketValueDto?>? TaxGroups { get; set; }
    private List<BasketValueDto?>? PaymentModes { get; set; }
    private Field<string?>? PaymentAuthorizationAction { get; set; }
    private bool _isLoading = true;
    private bool _disposed = false;

    protected override FetchInvoiceInfoAction CreateFetchAction(InvoiceInfoState state) =>
        new(state);

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(
            new FetchInvoiceAccountsAction(InvoiceAccountsState.Value));
        InvoiceAccountsState.StateChanged += InvoiceAccountsStateChanged;

        base.OnInitialized();

        TaxGroups = RessourcesState?.Value.TaxGroups
            ?? throw new NullReferenceException("Unexpected null for TaxGroups object.");

        PaymentModes = RessourcesState?.Value.PaymentModes
            ?? throw new NullReferenceException("Unexpected null for PaymentModes object.");
    }

    protected override void CacheNewFields()
    {
        BasketInvoiceInfo = State.Value.BasketInvoiceInfo
            ?? throw new NullReferenceException("Unexpected null for BasketInvoiceInfo object.");
        PaymentAuthorizationAction = BasketInvoiceInfo.PaymentAuthorizationAction;
        _isLoading = State.Value.IsLoading;
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
                () => throw new NotImplementedException()
            );
    }

    protected override void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                InvoiceAccountsState.StateChanged -= InvoiceAccountsStateChanged;
            }
            _disposed = true;
        }
        base.Dispose(disposing);
    }
}
