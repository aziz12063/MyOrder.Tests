using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.OrderInfoUseCase;
using System.Text;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class OrderInfo : BaseFluxorComponent<OrderInfoState, FetchOrderInfoAction>
{
    private BasketOrderInfoDto BasketOrderInfo => State.Value.BasketOrderInfo;
    private List<ContactDto> Contacts => State.Value.ContactList;
    private List<SalesOriginDto> SalesOrigins => State.Value.SalesOrigins;
    private List<BasketValueDto> WebOrigins => State.Value.WebOrigins;
    private List<BasketValueDto> SalesPools => State.Value.SalesPools;

    protected override FetchOrderInfoAction CreateFetchAction(OrderInfoState state, string basketId)
    {
        return new FetchOrderInfoAction(state, basketId);
    }

    private string SelectedClient
    {
        get
        {
            var account = BasketOrderInfo?.Account?.Value;
            return account == null ? string.Empty :
                $"{account.AccountId} - {account.Name} - {account.ZipCode}";
        }
    }

    private List<string>? AccountAddress
    {
        get
        {
            var account = BasketOrderInfo?.Account?.Value;
            if (account == null)
            {
                return null;
            }

            var addressBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(account.Recipient))
            {
                addressBuilder.AppendLine(account.Recipient);
            }

            if (!string.IsNullOrWhiteSpace(account.Building))
            {
                addressBuilder.AppendLine(account.Building);
            }

            if (!string.IsNullOrWhiteSpace(account.Street))
            {
                addressBuilder.AppendLine(account.Street);
            }

            if (!string.IsNullOrWhiteSpace(account.ZipCode) && !string.IsNullOrWhiteSpace(account.City))
            {
                addressBuilder.AppendLine($"{account.ZipCode} - {account.City}");
            }

            if (!string.IsNullOrWhiteSpace(account.Country))
            {
                addressBuilder.AppendLine(account.Country);
            }

            return addressBuilder.ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }

    private ContactDto? ContactValue
    {
        get => BasketOrderInfo.Contact.Value;
        set
        {
            BasketOrderInfo.Contact.Value = value;
            UpdateProcedureCall(value?.ContactId, BasketOrderInfo.Contact.ProcedureCall);
        }
    }
    private string SalesOriginIdValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketOrderInfo.SalesOriginId.Value);
        set
        {
            BasketOrderInfo.SalesOriginId.Value = value;
            UpdateProcedureCall(value, BasketOrderInfo.SalesOriginId.ProcedureCall);
        }
    }
    private string WebOriginIdValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketOrderInfo.WebOriginId.Value);
        set
        {
            BasketOrderInfo.WebOriginId.Value = value;
            UpdateProcedureCall(value, BasketOrderInfo.WebOriginId.ProcedureCall);
        }
    }
    private string SalesPoolId
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketOrderInfo.SalesPoolId.Value);
        set
        {
            BasketOrderInfo.SalesPoolId.Value = value;
            UpdateProcedureCall(value, BasketOrderInfo.SalesPoolId.ProcedureCall);
        }
    }
    private string CustomerOrderRefValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketOrderInfo.CustomerOrderRef.Value);
        set
        {
            BasketOrderInfo.CustomerOrderRef.Value = value;
            UpdateProcedureCall(value, BasketOrderInfo.CustomerOrderRef.ProcedureCall);
        }
    }
    private string WebSalesIdValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketOrderInfo.WebSalesId.Value);
        set
        {
            BasketOrderInfo.WebSalesId.Value = value;
            UpdateProcedureCall(value, BasketOrderInfo.WebSalesId.ProcedureCall);
        }
    }
    private string RelatedLinkValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketOrderInfo.RelatedLink.Value);
        set
        {
            BasketOrderInfo.RelatedLink.Value = value;
            UpdateProcedureCall(value, BasketOrderInfo.RelatedLink.ProcedureCall);
        }
    }
    private static Color CustomerTagColorHelper(string value) => value switch
    {
        "vip" => Color.Primary,
        "noGift" => Color.Error,
        _ => Color.Warning
    };
    private static string CustomerTagIconHelper(string value) =>
        value switch
        {
            "vip" => Icons.Material.Filled.Star,
            "noGift" => Icons.Material.Filled.CardGiftcard,
            _ => Icons.Material.Filled.Warning
        };

}
