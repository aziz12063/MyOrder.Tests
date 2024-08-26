using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using System.Text;
using MyOrder.Components.Common;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class InvoiceDetails : BaseFluxorComponent<InvoiceInfoState, FetchInvoiceInfoAction>
{
    public BasketInvoiceInfoDto? BasketInvoiceInfo { get; set; }
    public List<AccountDto?>? InvoiceToAccounts { get; set; }
    public List<BasketValueDto?>? TaxGroups { get; set; }
    public List<BasketValueDto?>? PaymentModes { get; set; }
    private string SelectedClient { get; set; } = string.Empty;
    private List<string>? AccountAddress { get; set; }
    private string? DisplayAddress { get; set; }

    protected override FetchInvoiceInfoAction CreateFetchAction(InvoiceInfoState state, string basketId) =>
        new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketInvoiceInfo = State.Value.BasketInvoiceInfo ?? throw new NullReferenceException("Unexpected null for BasketInvoiceInfo object.");
        InvoiceToAccounts = State.Value.InvoiceToAccounts;
        TaxGroups = State.Value.TaxGroups;
        PaymentModes = State.Value.PaymentModes;

        SelectedClient = FieldUtility.SelectedAccount(BasketInvoiceInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketInvoiceInfo?.Account?.Value);
        DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);
    }

    private AccountDto? AccountValue
    {
        get => BasketInvoiceInfo?.Account?.Value;
        set => SetBasketOrderValue(field: BasketInvoiceInfo!.Account, value: value, procedureCallValue: value?.AccountId);
    }
    private string TaxGroupValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.TaxGroup?.Value);
        set => SetBasketOrderValue(field: BasketInvoiceInfo!.TaxGroup, value: value, procedureCallValue: value);
    }
    private string PaymentModeValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.PaymentMode?.Value);
        set => SetBasketOrderValue(field: BasketInvoiceInfo!.PaymentMode, value: value, procedureCallValue: value);
    }
    private string PublicEntityExecutingServiceValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.PublicEntityExecutingService?.Value);
        set => SetBasketOrderValue(field: BasketInvoiceInfo!.PublicEntityExecutingService, value: value, procedureCallValue: value);
    }
    private string PublicEntityLegalCommitmentValue
    {
        get => FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.PublicEntityExecutingService?.Value);
        set => SetBasketOrderValue(field: BasketInvoiceInfo!.PublicEntityLegalCommitment, value: value, procedureCallValue: value);
    }

    private bool IsPublicEntityValue =>
        FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.IsPublicEntity);

    private string NoteValue =>
        FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.Note?.Value);
}
