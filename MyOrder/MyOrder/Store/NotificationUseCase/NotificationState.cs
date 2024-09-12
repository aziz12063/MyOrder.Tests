using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.NotificationUseCase
{
    [FeatureState]
    public class NotificationState : StateBase
    {
        public BasketNotificationDto? NotificationDto { get; set; }

        public NotificationState() : base(true) { }

        public NotificationState(BasketNotificationDto? notificationDto) : base(false)
        {
            NotificationDto = notificationDto;
        }

    }
}
