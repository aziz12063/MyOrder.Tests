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
         new(action.Accounts, action.IsFiltered);

    [ReducerMethod]
    public static InvoiceAccountsState ReduceFetchInvoiceInfoAccountsFailureAction(InvoiceAccountsState state, FetchInvoiceAccountsFailureAction action) =>
        new();
}

