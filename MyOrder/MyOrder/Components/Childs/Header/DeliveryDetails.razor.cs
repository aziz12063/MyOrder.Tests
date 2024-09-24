using MyOrder.Shared.Dtos;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.OrderInfoUseCase;
using System.Text;
using MyOrder.Components.Common;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;
public partial class DeliveryDetails : BaseFluxorComponent<DeliveryInfoState, FetchDeliveryInfoAction>
{
    private BasketDeliveryInfoDto? BasketDeliveryInfo { get; set; }
    private List<AccountDto?>? Accounts { get; set; }
    private List<ContactDto?>? Contacts { get; set; }
    private List<BasketValueDto?>? DeliveryModes { get; set; }
    private string SelectedAccount { get; set; } = string.Empty;
    private List<string>? AccountAddress { get; set; }
    private string DisplayAddress { get; set; } = string.Empty;
    private bool isLoading = true;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DeliveryModes = RessourcesState?.Value.DeliveryModes
            ?? throw new ArgumentNullException(nameof(RessourcesState.Value.DeliveryModes), "Unexpected null for DeliveryModes object.");
    }

    protected override void CacheNewFields()
    {
        BasketDeliveryInfo = State?.Value.BasketDeliveryInfo
                             ?? throw new ArgumentNullException(nameof(State.Value.BasketDeliveryInfo), "Unexpected null for BasketOrderInfo object.");
        Accounts = State.Value.DeliverToAccounts;
        Contacts = State.Value.DeliverToContacts;

        SelectedAccount = FieldUtility.SelectedAccount(BasketDeliveryInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketDeliveryInfo?.Account?.Value);
        DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);
        isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }

    protected override FetchDeliveryInfoAction CreateFetchAction(DeliveryInfoState state, string basketId) => new(state, basketId);

    private bool? CompleteDelivery
    {
        get => BasketDeliveryInfo?.CompleteDelivery?.Value;
        set => SetBasketOrderValue(field: BasketDeliveryInfo!.CompleteDelivery, value: value, procedureCallValue: value.ToString());
    }
    private DateTime? ImperativeDateValue
    {
        get => BasketDeliveryInfo?.ImperativeDate?.Value;
        set => SetBasketOrderValue(field: BasketDeliveryInfo!.ImperativeDate, value: value, procedureCallValue: value.ToString()); // This is triggered 2 times when set to null. Do troubleshoot.
    }
    public bool? SaveNoteForFutureOrders
    {
        get => BasketDeliveryInfo?.NoteMustBeSaved?.Value;
        set => SetBasketOrderValue(field: BasketDeliveryInfo!.NoteMustBeSaved, value: value, procedureCallValue: value.ToString());
    }
    private string NoteValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketDeliveryInfo?.Note?.Value);
        set => SetBasketOrderValue(field: BasketDeliveryInfo!.Note, value: value, procedureCallValue: value);
    }
}

