using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.OrderInfoUseCase;
using System.Text;

namespace MyOrder.Components.Childs.Header;
public partial class DeliveryDetails : BaseFluxorComponent<DeliveryInfoState, FetchDeliveryInfoAction>
{
    private BasketDeliveryInfoDto BasketDeliveryInfo => State.Value.BasketDeliveryInfo;
    private List<AccountDto> Accounts => State.Value.DeliverToAccounts;
    private List<ContactDto> Contacts => State.Value.DeliverToContacts;
    private List<BasketValueDto> WebOrigins => State.Value.DeliveryModes;

    protected override FetchDeliveryInfoAction CreateFetchAction(string basketId)
    {
        return new FetchDeliveryInfoAction(basketId);
    }

    private string SelectedAccount
    {
        get
        {
            var account = BasketDeliveryInfo?.Account?.Value;
            return account == null ? string.Empty :
                $"{account.AccountId} - {account.Name} - {account.ZipCode}";
        }
    }
    private List<string>? AccountAddress
    {
        get
        {
            var account = BasketDeliveryInfo?.Account?.Value;
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
    private string DisplayAddress => string.Join("\n", AccountAddress);
    private ContactDto? ContactValue
    {
        get => BasketDeliveryInfo.Contact.Value;
        set
        {
            BasketDeliveryInfo.Contact.Value = value;
            UpdateProcedureCall(value?.ContactId, BasketDeliveryInfo.Contact.ProcedureCall);
        }
    }
    private string NoteValue
    {
        get => NullOrWhiteSpaceHelper(BasketDeliveryInfo.Note.Value);
        set
        {
            BasketDeliveryInfo.Note.Value = value;
            UpdateProcedureCall(value, BasketDeliveryInfo.Note.ProcedureCall);
        }
    }
}

