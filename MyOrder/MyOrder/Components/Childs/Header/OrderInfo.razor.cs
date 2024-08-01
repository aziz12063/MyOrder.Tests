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

namespace MyOrder.Components.Childs.Header;

public partial class OrderInfo : BaseFluxorComponent<OrderInfoState, FetchOrderInfoAction>
{
    private BasketOrderInfoDto BasketOrderInfo => State.Value.BasketOrderInfo;
    private List<ContactDto> Contacts => State.Value.ContactList;
    private List<SalesOriginDto> SalesOrigins => State.Value.SalesOrigins;
    private List<BasketValueDto> SalesPools => State.Value.SalesPools;

    protected override FetchOrderInfoAction CreateFetchAction(string basketId)
    {
        return new FetchOrderInfoAction(basketId);
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

    private string SelectedContact
    {
        get
        {
            var contact = BasketOrderInfo?.Contact?.Value;
            return contact == null ? string.Empty :
                $"{contact.FirstName} - {contact.LastName}";
        }
    }

    private List<string>? UpdateContactProcedureCall(List<string>? procedureCall, string value)
    {
        if (procedureCall == null || procedureCall.Count == 0)
        {
            return null;
        }
        procedureCall[^1] = value;
        return procedureCall;
    }
    //private string SelectedContact
    //{
    //    get => OrderInfoState.Value.BasketOrderInfo.Contact.Value?.FirstName + " - " + OrderInfoState.Value.BasketOrderInfo.Contact.Value?.LastName;
    //    set => throw new NotImplementedException();
    //}
}
