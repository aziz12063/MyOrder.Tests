using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.NotificationsUseCase
{
    public class FetchNotificationsAction(NotificationsState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchNotificationsSuccessAction(List<BasketNotificationDto?>? notifications)
    {
        public List<BasketNotificationDto?>? Notifications { get; } = notifications;
    }

    public class FetchNotificationsFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}