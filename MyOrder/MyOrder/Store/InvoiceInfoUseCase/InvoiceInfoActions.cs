using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

public class FetchInvoiceInfoAction(InvoiceInfoState state) : FetchDataActionBase(state)
{ }

public class FetchInvoiceInfoSuccessAction(InvoicePanelDto? basketInvoiceInfo)
{
    public InvoicePanelDto? InvoiceInfo { get; } = basketInvoiceInfo;
}

public class FetchInvoiceInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchInvoiceAccountsAction(InvoiceAccountsState state, string? filter = null, bool? isSearch = null)
    : FetchDataActionBase(state), IFetchAccountsAction
{
    public string? Filter { get; } = filter;
    public bool? IsSearch { get; } = isSearch;
}

public class FetchInvoiceAccountsSuccessAction(List<AccountDto?>? accounts, bool isSearch)
{
    public List<AccountDto?>? Accounts { get; } = accounts;
    public bool IsSearch { get; } = isSearch;
}

public class FetchInvoiceAccountsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class FetchPaymentAuthorizationAction(PaymentAuthorizationState state) : FetchDataActionBase(state);
public record FetchPaymentAuthorizationSuccessAction(PaymentAuthorizationDto PaymentAuthorization);
public record FetchPaymentAuthorizationFailureAction(string ErrorMessage);