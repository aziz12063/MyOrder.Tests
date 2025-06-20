using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.InvoiceInfoUseCase;
public static class InvoiceInfoReducers
{
    [ReducerMethod]
    public static InvoiceInfoState ReduceFetchInvoiceInfoSuccessAction(InvoiceInfoState state, FetchInvoiceInfoSuccessAction action)
    {
        return state with
        {
            BasketInvoiceInfo = action.InvoiceInfo,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static InvoiceInfoState ReduceFetchInvoiceInfoFailureAction(InvoiceInfoState state, FetchInvoiceInfoFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod]
    public static InvoiceAccountsState ReduceFetchInvoiceInfoAccountsSuccessAction(InvoiceAccountsState state, FetchInvoiceAccountsSuccessAction action)
    {
        // Old logic : 
        //    public InvoiceAccountsState(List<AccountDto?>? accountList, bool isSearch, InvoiceAccountsState oldState) : base(false)
        //    {
        //        if (isSearch)
        //        {
        //            Accounts = oldState.Accounts;
        //            SearchedAccounts = accountList;
        //        }
        //        else
        //            Accounts = accountList;
        //    }
        return state with
        {
            Accounts = action.IsSearch ? state.Accounts : action.Accounts,
            SearchedAccounts = action.IsSearch ? action.Accounts : [], // If not searching, we clear the searched accounts
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }


    [ReducerMethod]
    public static InvoiceAccountsState ReduceFetchInvoiceInfoAccountsFailureAction(InvoiceAccountsState state, FetchInvoiceAccountsFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod]
    public static PaymentAuthorizationState ReduceFetchPaymentAuthorizationSuccessAction(PaymentAuthorizationState state, FetchPaymentAuthorizationSuccessAction action)
    {
        return state with
        {
            PaymentAuthorization = action.PaymentAuthorization,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static PaymentAuthorizationState ReduceFetchPaymentAuthorizationFailureAction(PaymentAuthorizationState state, FetchPaymentAuthorizationFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }
}

