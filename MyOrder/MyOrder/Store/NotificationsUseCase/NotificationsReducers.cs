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
}