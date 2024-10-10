using Fluxor;

namespace MyOrder.Store.NotificationsUseCase;

public static class NotificationReducers
{
    [ReducerMethod]
    public static NotificationsState ReduceFetchNotificationSuccessAction(NotificationsState state, FetchNotificationsSuccessAction action) =>
        new(action.Notifications);

    [ReducerMethod]
    public static NotificationsState ReduceFetchNotificationFailureAction(NotificationsState state, FetchNotificationsFailureAction action) =>
        new();

    [ReducerMethod]
    public static NotificationsState ReduceDeleteNotificationSuccessAction(NotificationsState state, DeleteNotificationSuccessAction action) =>
        new();

    [ReducerMethod]
    public static NotificationsState ReduceDeleteNotificationFailureAction(NotificationsState state, DeleteNotificationFailureAction action) =>
        new();
}