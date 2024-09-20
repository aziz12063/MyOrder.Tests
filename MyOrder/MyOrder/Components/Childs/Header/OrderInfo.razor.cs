using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Store.RessourcesUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class OrderInfo : BaseFluxorComponent<OrderInfoState, FetchOrderInfoAction>
{
    [Inject]
    private IDialogService DialogService { get; set; }
    private BasketOrderInfoDto? BasketOrderInfo { get; set; }
    private List<ContactDto?>? Contacts { get; set; }
    private List<BasketValueDto?>? SalesOrigins { get; set; }
    private List<BasketValueDto?>? WebOrigins { get; set; }
    private List<BasketValueDto?>? SalesPools { get; set; }
    private string SelectedClient { get; set; } = string.Empty;
    private List<string>? AccountAddress { get; set; }
    private bool isLoading = true;

    protected override FetchOrderInfoAction CreateFetchAction(OrderInfoState state, string basketId) => new(state, basketId);

    protected override void OnInitialized()
    {
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
        Contacts = State.Value.ContactList;
        SelectedClient = FieldUtility.SelectedAccount(BasketOrderInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketOrderInfo?.Account?.Value);
        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    private ContactDto? ContactValue
    {
        get => BasketOrderInfo?.Contact?.Value;
        set => SetBasketOrderValue(field: BasketOrderInfo!.Contact, value: value, procedureCallValue: value?.ContactId);
    }
    private BasketValueDto? SalesOriginIdValue
    {
        get => BasketOrderInfo?.SalesOriginId?.Value;
        set => SetBasketOrderValue(field: BasketOrderInfo!.SalesOriginId, value: value, procedureCallValue: value?.Value);

    }
    private BasketValueDto? WebOriginIdValue
    {
        get => BasketOrderInfo?.WebOriginId?.Value;
        set => SetBasketOrderValue(field: BasketOrderInfo!.WebOriginId, value: value, procedureCallValue: value?.Value);
    }
    private BasketValueDto? SalesPoolId
    {
        get => BasketOrderInfo?.SalesPoolId?.Value;
        set => SetBasketOrderValue(field: BasketOrderInfo!.SalesPoolId, value: value, procedureCallValue: value?.Value);
    }
    private string CustomerOrderRefValue
    {
        get => GetFieldValue(BasketOrderInfo?.CustomerOrderRef?.Value);
        set => SetBasketOrderValue(field: BasketOrderInfo!.CustomerOrderRef, value: value, procedureCallValue: value);
    }
    private string WebSalesIdValue
    {
        get => GetFieldValue(BasketOrderInfo?.WebSalesId?.Value);
        set => SetBasketOrderValue(field: BasketOrderInfo!.WebSalesId, value: value, procedureCallValue: value);
    }
    private string RelatedLinkValue
    {
        get => GetFieldValue(BasketOrderInfo?.RelatedLink?.Value);
        set => SetBasketOrderValue(field: BasketOrderInfo!.RelatedLink, value: value, procedureCallValue: value);
    }

    private static Color CustomerTagColorHelper(string? value) =>
        value switch
        {
            "vip" => Color.Primary,
            "noGift" => Color.Error,
            _ => Color.Warning
        };

    private static string CustomerTagIconHelper(string? value) =>
        value switch
        {
            "vip" => Icons.Material.Filled.Star,
            "noGift" => Icons.Material.Filled.CardGiftcard,
            _ => Icons.Material.Filled.Warning
        };

    private Task OpenContactSearchDialogAsync()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, CloseButton = true };
        var parameters = new DialogParameters<SearchContactDialog>
        {
            { x => x.Contacts, Contacts }
        };
        return DialogService.ShowAsync<SearchContactDialog>("Simple Dialog", parameters, options);
    }
}
