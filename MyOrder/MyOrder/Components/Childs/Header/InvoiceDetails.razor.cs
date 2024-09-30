using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.InvoiceInfoUseCase;
using MyOrder.Store.PricesInfoUseCase;
using System.Text;
using MyOrder.Components.Common;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header;

public partial class InvoiceDetails : FluxorComponentBase<InvoiceInfoState, FetchInvoiceInfoAction>
{
    public BasketInvoiceInfoDto? BasketInvoiceInfo { get; set; }
    public List<AccountDto?>? InvoiceToAccounts { get; set; }
    public List<BasketValueDto?>? TaxGroups { get; set; }
    public List<BasketValueDto?>? PaymentModes { get; set; }
    private string SelectedClient { get; set; } = string.Empty;
    private List<string>? AccountAddress { get; set; }
    private string? DisplayAddress { get; set; }
    private bool isLoading = true;

    protected override FetchInvoiceInfoAction CreateFetchAction(InvoiceInfoState state, string basketId) =>
        new(state, basketId);

    protected override void OnInitialized()
    {
        base.OnInitialized();

        TaxGroups = RessourcesState?.Value.TaxGroups
            ?? throw new NullReferenceException("Unexpected null for TaxGroups object.");

        PaymentModes = RessourcesState?.Value.PaymentModes
            ?? throw new NullReferenceException("Unexpected null for PaymentModes object.");
    }

    protected override void CacheNewFields()
    {
        BasketInvoiceInfo = State.Value.BasketInvoiceInfo ?? throw new NullReferenceException("Unexpected null for BasketInvoiceInfo object.");
        InvoiceToAccounts = State.Value.InvoiceToAccounts;
        InvoiceToAccounts = State.Value.InvoiceToAccounts;

        SelectedClient = FieldUtility.SelectedAccount(BasketInvoiceInfo?.Account?.Value);
        AccountAddress = FieldUtility.CreateAddressList(BasketInvoiceInfo?.Account?.Value);
        DisplayAddress = FieldUtility.DisplayAddress(AccountAddress);
        isLoading = State.Value.IsLoading;
    }

    private bool IsPublicEntityValue =>
        FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.IsPublicEntity);

    private string NoteValue =>
        FieldUtility.NullOrWhiteSpaceHelper(BasketInvoiceInfo?.Note?.Value);
}
