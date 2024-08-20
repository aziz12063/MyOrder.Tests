using MudBlazor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class OrderInfo : BaseFluxorComponent<OrderInfoState, FetchOrderInfoAction>
{
    private BasketOrderInfoDto? BasketOrderInfo => State.Value.BasketOrderInfo;
    private List<ContactDto?>? Contacts => State.Value.ContactList;
    private List<SalesOriginDto?>? SalesOrigins => State.Value.SalesOrigins;
    private List<BasketValueDto?>? WebOrigins => State.Value.WebOrigins;
    private List<BasketValueDto?>? SalesPools => State.Value.SalesPools;

    protected override FetchOrderInfoAction CreateFetchAction(OrderInfoState state, string basketId) => new(state, basketId);

    private string SelectedClient => BasketOrderInfo?.Account?.Value is var account && account is not null
        ? $"{account.AccountId} - {account.Name} - {account.ZipCode}"
        : string.Empty;
    private List<string>? AccountAddress => FieldUtility.CreateAddressList(BasketOrderInfo?.Account?.Value);
    private ContactDto? ContactValue
    {
        get => BasketOrderInfo?.Contact?.Value;
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(BasketOrderInfo.Contact, value, value?.ContactId);
        }
    }
    private string SalesOriginIdValue
    {
        get => GetFieldValue(BasketOrderInfo?.SalesOriginId?.Value);
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(field: BasketOrderInfo.SalesOriginId, value: value, procedureCallValue: value);
        }
    }
    private string WebOriginIdValue
    {
        get => GetFieldValue(BasketOrderInfo?.WebOriginId?.Value);
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(field: BasketOrderInfo.WebOriginId, value: value, procedureCallValue: value);
        }
    }
    private string SalesPoolId
    {
        get => GetFieldValue(BasketOrderInfo?.SalesPoolId?.Value);
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(field: BasketOrderInfo.SalesPoolId, value: value, procedureCallValue: value);
        }
    }
    private string CustomerOrderRefValue
    {
        get => GetFieldValue(BasketOrderInfo?.CustomerOrderRef?.Value);
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(field: BasketOrderInfo.CustomerOrderRef, value: value, procedureCallValue: value);
        }
    }
    private string WebSalesIdValue
    {
        get => GetFieldValue(BasketOrderInfo?.WebSalesId?.Value);
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(field: BasketOrderInfo.WebSalesId, value: value, procedureCallValue: value);
        }
    }
    private string RelatedLinkValue
    {
        get => GetFieldValue(BasketOrderInfo?.RelatedLink?.Value);
        set
        {
            if (BasketOrderInfo == null)
                throw new InvalidOperationException("BasketOrderInfo is null.");

            SetBasketOrderValue(field: BasketOrderInfo.RelatedLink, value: value, procedureCallValue: value);

        }
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
}
