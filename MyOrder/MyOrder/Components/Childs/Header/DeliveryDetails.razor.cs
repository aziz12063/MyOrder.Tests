using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.OrderInfoUseCase;
using System.Text;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class DeliveryDetails : BaseFluxorComponent<DeliveryInfoState, FetchDeliveryInfoAction>
{
    private BasketDeliveryInfoDto? BasketDeliveryInfo => State.Value.BasketDeliveryInfo;
    private List<AccountDto>? Accounts => State.Value.DeliverToAccounts;
    private List<ContactDto>? Contacts => State.Value.DeliverToContacts;
    private List<BasketValueDto>? WebOrigins => State.Value.DeliveryModes;

    //override

    protected override FetchDeliveryInfoAction CreateFetchAction(DeliveryInfoState state, string basketId) => new(state, basketId);

    private string SelectedAccount => FieldUtility.SelectedAccount(BasketDeliveryInfo?.Account?.Value);
    private List<string>? AccountAddress => FieldUtility.CreateAddressList(BasketDeliveryInfo?.Account?.Value);
    private string DisplayAddress => FieldUtility.DisplayAddress(AccountAddress);
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
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketDeliveryInfo.Note.Value);
        set
        {
            BasketDeliveryInfo.Note.Value = value;
            UpdateProcedureCall(value, BasketDeliveryInfo.Note.ProcedureCall);
        }
    }
}

