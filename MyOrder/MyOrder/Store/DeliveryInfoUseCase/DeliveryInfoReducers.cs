using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.DeliveryInfoUseCase;

public static class DeliveryInfoReducers
{
    [ReducerMethod(typeof(FetchDeliveryInfoAction))]
    public static DeliveryInfoState ReduceFetchDeliveryInfoAction(DeliveryInfoState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static DeliveryInfoState ReduceFetchDeliveryInfoSuccessAction(DeliveryInfoState state, FetchDeliveryInfoSuccessAction action)
    {
        return state with
        {
            BasketDeliveryInfo = action.BasketDeliveryInfo,
            DeliveryModes = action.DeliveryModes,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static DeliveryInfoState ReduceFetchDeliveryInfoFailureAction(DeliveryInfoState state, FetchDeliveryInfoFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod(typeof(FetchDeliveryAccountsAction))]
    public static DeliveryAccountsState ReduceFetchDeliveryAccountsAction(DeliveryAccountsState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static DeliveryAccountsState ReduceFetchDeliveryAccountsSuccessAction(DeliveryAccountsState state, FetchDeliveryAccountsSuccessAction action)
    {
#warning Remove this warning when the old logic is no longer needed
        // Old logic :
        //        if (isSearch)
        //        {
        //            // Temporary fix to keep the old state of accounts
        //            Accounts = oldState.Accounts;
        //            SearchedAccounts = accountList;
        //        }
        //        else
        //            Accounts = accountList;
        return state with
        {
            Accounts = action.IsSearch ? state.Accounts : action.DeliveryAccounts,
            SearchedAccounts = action.IsSearch ? action.DeliveryAccounts : [],
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }
    
    [ReducerMethod]
    public static DeliveryAccountsState ReduceFetchDeliveryAccountsFailureAction(DeliveryAccountsState state, FetchDeliveryAccountsFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod(typeof(FetchNewDeliveryAccountAction))]
    public static NewDeliveryAccountState ReduceFetchNewDeliveryAccountAction(NewDeliveryAccountState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NewDeliveryAccountState ReduceFetchNewDeliveryAccountSuccessAction(NewDeliveryAccountState state, FetchNewDeliveryAccountSuccessAction action)
    {
        return state with
        {
            DeliveryAccountDraft = action.DeliveryAccountDraft,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NewDeliveryAccountState ReduceFetchNewDeliveryAccountFailureAction(NewDeliveryAccountState state, FetchNewDeliveryAccountFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod(typeof(FetchDeliveryContactsAction))]
    public static DeliveryContactsState ReduceFetchDeliveryContactsAction(DeliveryContactsState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static DeliveryContactsState ReduceFetchDeliveryContactsSuccessAction(DeliveryContactsState state, FetchDeliveryContactsSuccessAction action)
    {
#warning Remove this warning when the old logic is no longer needed
        // Olg logic :
        //public DeliveryContactsState(List<ContactDto?>? contactList, bool isFiltered) : base(false)
        //{
        //    if (isFiltered)
        //        FilteredContacts = contactList;
        //    else
        //        Contacts = contactList;
        //}
        return state with
        {
            Contacts = action.IsFiltered ? state.Contacts : action.DeliveryContacts,
            FilteredContacts = action.IsFiltered ? action.DeliveryContacts : state.FilteredContacts,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static DeliveryContactsState ReduceFetchDeliveryContactsFailureAction(DeliveryContactsState state, FetchDeliveryContactsFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod(typeof(FetchNewDeliveryContactAction))]
    public static NewDeliveryContactState ReduceFetchNewDeliveryContactAction(NewDeliveryContactState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NewDeliveryContactState ReduceFetchNewDeliveryContactSuccessAction(NewDeliveryContactState state, FetchNewDeliveryContactSuccessAction action)
    {
        return state with
        {
            DeliveryContactDraft = action.DeliveryContactDraft,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NewDeliveryContactState ReduceFetchNewDeliveryContactFailureAction(NewDeliveryContactState state, FetchNewDeliveryContactFailureAction action)
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
