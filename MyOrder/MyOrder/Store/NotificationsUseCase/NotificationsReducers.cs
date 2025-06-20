using Fluxor;

namespace MyOrder.Store.NotificationsUseCase;

public static class NotificationReducers
{
    [ReducerMethod]
    public static NotificationsState ReduceFetchNotificationSuccessAction(NotificationsState state, FetchNotificationsSuccessAction action)
    {
        return state with
        {
            Notifications = action.Notifications,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static NotificationsState ReduceFetchNotificationFailureAction(NotificationsState state, FetchNotificationsFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

#warning TODO: Implement the delete notification response handling logic and review code below
    //[ReducerMethod]
    //public static NotificationsState ReduceDeleteNotificationAction(NotificationsState state, DeleteNotificationAction action)
    //{
    //    return state with
    //    {
    //        Notifications = [.. state.Notifications.Where(n => n?.ProcedureCall != action.ProcedureCall)],
    //        Initialized = true,
    //        IsLoading = true,
    //        IsFaulted = false,
    //        ErrorMessage = string.Empty
    //    };
    //}

    //[ReducerMethod]
    //public static NotificationsState ReduceDeleteNotificationSuccessAction(NotificationsState state, DeleteNotificationSuccessAction action) =>
    //    new();

    [ReducerMethod]
    public static NotificationsState ReduceDeleteNotificationFailureAction(NotificationsState state, DeleteNotificationFailureAction action)
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