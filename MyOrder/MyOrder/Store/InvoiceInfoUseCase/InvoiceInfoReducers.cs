using Fluxor;

namespace MyOrder.Store.InvoiceInfoUseCase;
public static class InvoiceInfoReducers
{
    [ReducerMethod]
    public static InvoiceInfoState ReduceFetchInvoiceInfoSuccessAction(InvoiceInfoState state, FetchInvoiceInfoSuccessAction action) =>
        new(action.InvoiceInfo);

    [ReducerMethod]
    public static InvoiceInfoState ReduceFetchInvoiceInfoFailureAction(InvoiceInfoState state, FetchInvoiceInfoFailureAction action) =>
        new();

    [ReducerMethod]
    public static InvoiceAccountsState ReduceFetchInvoiceInfoAccountsSuccessAction(InvoiceAccountsState state, FetchInvoiceAccountsSuccessAction action) =>
         new(action.Accounts, action.IsSearch, state);

    [ReducerMethod]
    public static InvoiceAccountsState ReduceFetchInvoiceInfoAccountsFailureAction(InvoiceAccountsState state, FetchInvoiceAccountsFailureAction action) =>
        new();

    [ReducerMethod(typeof(FetchPaymentAuthorizationAction))]
    public static PaymentAuthorizationState ReduceFetchPaymentAuthorizationAction(PaymentAuthorizationState state) =>
        new();

    [ReducerMethod]
    public static PaymentAuthorizationState ReduceFetchPaymentAuthorizationSuccessAction(PaymentAuthorizationState state, FetchPaymentAuthorizationSuccessAction action) =>
        new(action.PaymentAuthorization, string.Empty);

    [ReducerMethod]
    public static PaymentAuthorizationState ReduceFetchPaymentAuthorizationFailureAction(PaymentAuthorizationState state, FetchPaymentAuthorizationFailureAction action) =>
        new(state.PaymentAuthorization, action.ErrorMessage);
}

