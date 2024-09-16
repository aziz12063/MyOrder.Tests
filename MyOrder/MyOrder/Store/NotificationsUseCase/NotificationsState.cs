using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.NotificationsUseCase;

[FeatureState]
public class NotificationsState : StateBase
{
    public List<BasketNotificationDto?>? Notifications { get; }

    public NotificationsState() : base(true) { }

    public NotificationsState(List<BasketNotificationDto?>? notifications) : base(false)
    {
        Notifications = notifications;
    }

}