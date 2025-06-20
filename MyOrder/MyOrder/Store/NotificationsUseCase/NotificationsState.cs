using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.NotificationsUseCase;

[FeatureState]
public record NotificationsState(
    List<BasketNotificationDto?> Notifications) : StateBase
{
    public NotificationsState() : this([]) { }
}