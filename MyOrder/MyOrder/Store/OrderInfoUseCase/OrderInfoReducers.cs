using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.OrderInfoUseCase;

public static class OrderInfoReducers
{
    [ReducerMethod]
    public static OrderInfoState ReduceFetchOrderInfoSuccessAction(OrderInfoState state, FetchOrderInfoSuccessAction action)
            {
        return state with
        {
            BasketOrderInfo = action.BasketOrderInfo,
            WebOrigins = action.WebOrigins,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static OrderInfoState ReduceFetchOrderInfoFailureAction(OrderInfoState state, FetchOrderInfoFailureAction action)
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
    public static OrderContactsState ReduceFetchOrderContactsSuccessAction(OrderContactsState state, FetchOrderContactsSuccessAction action)
    {
#warning Remove this warning when the old logic is removed
        //Old logic :
        //public OrderContactsState(List<ContactDto?>? contactList, bool isFiltered) : base(false)
        //{
        //    if (isFiltered)
        //        FilteredContacts = contactList;
        //    else
        //        Contacts = contactList;
        //}
        //        return new(action.OrderContacts, action.IsFiltered);

        return state with
        {
            Contacts = action.IsFiltered ? state.Contacts : action.OrderContacts,
            FilteredContacts = action.IsFiltered ? action.OrderContacts : [],
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static OrderContactsState ReduceFetchOrderContactsFailureAction(OrderContactsState state, FetchOrderContactsFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage,
        };
    }
}
