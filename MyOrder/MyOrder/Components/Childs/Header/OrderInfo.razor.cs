using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class OrderInfo : BaseFluxorComponent<OrderInfoState, FetchOrderInfoAction>
{
    [Inject] IDialogService DialogService { get; set; }

    private BasketOrderInfoDto? BasketOrderInfo { get; set; }
    private List<ContactDto?>? Contacts { get; set; }
    private List<SalesOriginDto?>? SalesOrigins { get; set; }
    private List<BasketValueDto?>? WebOrigins { get; set; }
    private List<BasketValueDto?>? SalesPools { get; set; }
    private string SelectedClient { get; set; } = string.Empty;
    private List<string>? AccountAddress { get; set; }

    protected override FetchOrderInfoAction CreateFetchAction(OrderInfoState state, string basketId) => new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketOrderInfo = State.Value.BasketOrderInfo ??
                          throw new ArgumentNullException(nameof(State.Value.BasketOrderInfo), "Unexpected null for BasketOrderInfo object.");
        Contacts = State.Value.ContactList;
        SalesOrigins = State.Value.SalesOrigins;
        WebOrigins = State.Value.WebOrigins;
        SalesPools = State.Value.SalesPools;
        SelectedClient = FieldUtility.SelectedAccount(BasketOrderInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketOrderInfo?.Account?.Value);
    }

    private ContactDto? ContactValue
    {
        get => BasketOrderInfo?.Contact?.Value;
        set => SetBasketOrderValue(field: BasketOrderInfo!.Contact, value: value, procedureCallValue: value?.ContactId);
    }
    private string SalesOriginIdValue
    {
        get => GetFieldValue(BasketOrderInfo?.SalesOriginId?.Value);
        set => SetBasketOrderValue(field: BasketOrderInfo!.SalesOriginId, value: value, procedureCallValue: value);

    }
    private string WebOriginIdValue
    {
        get => GetFieldValue(BasketOrderInfo?.WebOriginId?.Value);
        set => SetBasketOrderValue(field: BasketOrderInfo!.WebOriginId, value: value, procedureCallValue: value);
    }
    private string SalesPoolId
    {
        get => GetFieldValue(BasketOrderInfo?.SalesPoolId?.Value);
        set => SetBasketOrderValue(field: BasketOrderInfo!.SalesPoolId, value: value, procedureCallValue: value);
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
