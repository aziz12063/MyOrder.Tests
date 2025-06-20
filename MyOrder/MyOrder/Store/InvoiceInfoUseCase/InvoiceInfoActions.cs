using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

public record FetchInvoiceInfoAction() : FetchDataActionBase;

public record FetchInvoiceInfoSuccessAction(InvoicePanelDto InvoiceInfo);

public record FetchInvoiceInfoFailureAction(string ErrorMessage);

public record FetchInvoiceAccountsAction(string? Filter = null, bool? IsSearch = null)
    : FetchDataActionBase, IFetchAccountsAction;

public record FetchInvoiceAccountsSuccessAction(List<AccountDto?> Accounts, bool IsSearch);

public record FetchInvoiceAccountsFailureAction(string ErrorMessage);

public record FetchPaymentAuthorizationAction() : FetchDataActionBase;

public record FetchPaymentAuthorizationSuccessAction(PaymentAuthorizationDto PaymentAuthorization);

public record FetchPaymentAuthorizationFailureAction(string ErrorMessage);