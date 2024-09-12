using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.NotificationUseCase
{
    public class FetchNotificationAction(NotificationState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchNotificationSuccessAction(BasketNotificationDto basketNotificationDto)
    {
        public BasketNotificationDto NotificationDto { get; } = basketNotificationDto;
    }

    public class FetchNotificationFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
