using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public sealed partial class OrderInfo : FluxorComponentBase<OrderInfoState, FetchOrderInfoAction>, IDisposable
{
    [Inject]
    private IState<OrderContactsState> OrderContactsState { get; set; } = null!;
    [Inject]
    private IModalService ModalService { get; set; } = null!;

    private BasketOrderInfoDto BasketOrderInfo => State.Value.BasketOrderInfo;
    private List<ContactDto?>? Contacts { get; set; }
    private List<BasketValueDto?>? SalesOrigins { get; set; }
    private List<BasketValueDto?>? WebOrigins => State.Value.WebOrigins;
    private List<BasketValueDto?>? SalesPools { get; set; }
    private string SelectedClient => BasketOrderInfo.Account?.Value?.ToString() ?? string.Empty;

    private string AccountLandLine => BasketOrderInfo?.Account?.Value?.Phone ?? string.Empty;
    private string AccountCellularPhone => BasketOrderInfo?.Account?.Value?.CellularPhone ?? string.Empty;
    string ContactLandLine => BasketOrderInfo?.Contact?.Value?.Phone ?? string.Empty;
    string ContactCellularPhone => BasketOrderInfo?.Contact?.Value?.CellularPhone ?? string.Empty;

    protected override FetchOrderInfoAction CreateFetchAction() => new();

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new FetchOrderContactsAction());
        OrderContactsState.StateChanged += OrderContactsStateChanged;

        base.OnInitialized();

        var rscState = ResourcesState?.Value;

        SalesOrigins = rscState?.SalesOrigins
            ?? throw new ArgumentNullException(nameof(rscState.SalesOrigins), "Unexpected null for SalesOrigins object.");
        SalesPools = rscState?.SalesPools
            ?? throw new ArgumentNullException(nameof(rscState.SalesPools), "Unexpected null for SalesPools object.");
    }

    private void OrderContactsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogTrace("State has changed for Contacts in {Component}",
            GetType().Name);
        Contacts = OrderContactsState.Value.Contacts;
        StateHasChanged();
    }

    private async Task OpenContactSearchDialogAsync()
    {
        if (BasketOrderInfo?.Contact is null)
        {
            Logger.LogWarning("Contact is null in {Component}",
                GetType().Name);
            return;
        }

        await ModalService.OpenSearchContactDialogAsync<OrderContactsState, FetchOrderContactsAction>(
             contact =>
                Dispatcher.Dispatch(new UpdateFieldAction(BasketOrderInfo.Contact, contact, typeof(FetchOrderInfoAction))),
             () => Dispatcher.Dispatch(new FetchOrderContactsAction(null, null)));
    }

    public void Dispose()
    {
        OrderContactsState.StateChanged -= OrderContactsStateChanged;

    }
}
