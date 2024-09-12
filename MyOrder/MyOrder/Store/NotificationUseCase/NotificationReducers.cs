using Fluxor;

namespace MyOrder.Store.NotificationUseCase
{
    public static class NotificationReducers
    {
        [ReducerMethod]
        public static NotificationState ReduceFetchNotificationSuccessAction(NotificationState state, FetchNotificationSuccessAction action) =>
            new(action.NotificationDto);

        [ReducerMethod]
        public static NotificationState ReduceFetchNotificationFailureAction(NotificationState state, FetchNotificationFailureAction action) =>
            new NotificationState();
    }
}
