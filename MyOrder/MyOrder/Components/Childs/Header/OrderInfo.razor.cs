using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Store.ProcedureCallUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class OrderInfo : FluxorComponentBase<OrderInfoState, FetchOrderInfoAction>
{
    [Inject]
    private IState<OrderContactsState> OrderContactsState { get; set; }
    [Inject]
    private IModalService ModalService { get; set; }
    private BasketOrderInfoDto? BasketOrderInfo { get; set; }
    private List<ContactDto?>? Contacts { get; set; }
    private List<BasketValueDto?>? SalesOrigins { get; set; }
    private List<BasketValueDto?>? WebOrigins { get; set; }
    private List<BasketValueDto?>? SalesPools { get; set; }
    private string SelectedClient { get; set; } = string.Empty;
    private List<string>? AccountAddress { get; set; }
    private bool isLoading = true;
    private bool disposed = false;


    protected override FetchOrderInfoAction CreateFetchAction(OrderInfoState state, string basketId) => new(state, basketId);

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new FetchOrderContactsAction(OrderContactsState.Value, BasketId));
        OrderContactsState.StateChanged += OrderContactsStateChanged;

        base.OnInitialized();

        var rscState = RessourcesState?.Value;

        SalesOrigins = rscState?.SalesOrigins
            ?? throw new ArgumentNullException(nameof(rscState.SalesOrigins), "Unexpected null for SalesOrigins object."); ;
        WebOrigins = rscState?.WebOrigins
            ?? throw new ArgumentNullException(nameof(rscState.WebOrigins), "Unexpected null for WebOrigins object."); ;
        SalesPools = rscState?.SalesPools
            ?? throw new ArgumentNullException(nameof(rscState.SalesPools), "Unexpected null for SalesPools object."); ;
    }

    protected override void CacheNewFields()
    {
        BasketOrderInfo = State?.Value.BasketOrderInfo
            ?? throw new ArgumentNullException(nameof(State.Value.BasketOrderInfo), "Unexpected null for BasketOrderInfo object.");
        SelectedClient = FieldUtility.SelectedAccount(BasketOrderInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketOrderInfo?.Account?.Value);
        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    private void OrderContactsStateChanged(object? sender, EventArgs e)
    {
        Logger.LogDebug("State has changed for Contacts in {Component}",
            GetType().Name);

        InvokeAsync(() =>
        {
            Contacts = OrderContactsState.Value.Contacts;
            StateHasChanged();
        });

        Logger.LogDebug("StateChanged handler completed for Contacts {Component}",
            GetType().Name);
    }

    private static Color CustomerTagColorHelper(string? value) =>
        value switch
        {
            "vip" => Color.Primary,
            "specialPrep" => Color.Info,
            "export" => Color.Success,
            "noGift" => Color.Error,
            "completeDelivery" => Color.Success,
            _ => Color.Warning
        };
#warning Tags are not complete
    private static string CustomerTagIconHelper(string? value) =>
        value switch
        {
            "vip" => Icons.Material.Filled.Star,
            "specialPrep" => Icons.Material.Filled.Warning,
            "export" => Icons.Material.Filled.ImportExport,
            "noGift" => Icons.Material.Filled.CardGiftcard,
            "completeDelivery" => Icons.Material.Filled.Done,
            _ => Icons.Material.Filled.Warning
        };

    private async Task OpenContactSearchDialogAsync()
    {
        if (BasketOrderInfo?.Contact is null)
        {
            Logger.LogWarning("Contact is null in {Component}",
                GetType().Name);
            return;
        }

        await ModalService.OpenSearchContactDialogAsync<OrderContactsState, FetchOrderContactsAction>(
             contact => Dispatcher.Dispatch(
                    new UpdateFieldAction(BasketOrderInfo.Contact, contact, typeof(FetchOrderInfoAction)))
             );
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                OrderContactsState.StateChanged -= OrderContactsStateChanged;
            }
            disposed = true;
        }
        base.Dispose(disposing);
    }
}
