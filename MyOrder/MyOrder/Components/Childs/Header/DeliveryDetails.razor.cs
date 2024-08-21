using MyOrder.Components.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.OrderInfoUseCase;
using System.Text;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class DeliveryDetails : BaseFluxorComponent<DeliveryInfoState, FetchDeliveryInfoAction>
{
    private BasketDeliveryInfoDto? BasketDeliveryInfo { get; set; }
    private List<AccountDto>? Accounts { get; set; }
    private List<ContactDto>? Contacts { get; set; }
    private List<BasketValueDto>? WebOrigins { get; set; }
    private string SelectedAccount { get; set; }
    private List<string>? AccountAddress { get; set; }
    private string DisplayAddress { get; set; }

    protected override void CacheNewFields()
    {
        BasketDeliveryInfo = State.Value.BasketDeliveryInfo ?? throw new NullReferenceException("Unexpected null for BasketOrderInfo object.");
        Accounts = State.Value.DeliverToAccounts;
        Contacts = State.Value.DeliverToContacts; ;
        WebOrigins = State.Value.DeliveryModes;

        SelectedAccount = FieldUtility.SelectedAccount(BasketDeliveryInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketDeliveryInfo?.Account?.Value);
        DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);
    }

    protected override FetchDeliveryInfoAction CreateFetchAction(DeliveryInfoState state, string basketId) => new(state, basketId);


    private ContactDto? ContactValue
    {
        get => BasketDeliveryInfo?.Contact?.Value;
        set
        {
            BasketDeliveryInfo.Contact.Value = value;
            UpdateProcedureCall(value?.ContactId, BasketDeliveryInfo.Contact.ProcedureCall);
        }
    }
    private string NoteValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketDeliveryInfo?.Note?.Value);
        set
        {
            BasketDeliveryInfo.Note.Value = value;
            UpdateProcedureCall(value, BasketDeliveryInfo.Note.ProcedureCall);
        }
    }
}

