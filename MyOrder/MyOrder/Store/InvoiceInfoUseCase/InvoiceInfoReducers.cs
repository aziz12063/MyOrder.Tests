using Fluxor;

namespace MyOrder.Store.InvoiceInfoUseCase;
public static class InvoiceInfoReducers
{
    [ReducerMethod]
    public static InvoiceInfoState ReduceFetchInvoiceInfoSuccessAction(InvoiceInfoState state, FetchInvoiceInfoSuccessAction action) =>
        new(action.InvoiceInfo, action.InvoiceToAccounts, action.TaxGroups, action.PaymentModes);

    [ReducerMethod]
    public static InvoiceInfoState ReduceFetchInvoiceInfoFailureAction(InvoiceInfoState state, FetchInvoiceInfoFailureAction action) =>
        new();
}

