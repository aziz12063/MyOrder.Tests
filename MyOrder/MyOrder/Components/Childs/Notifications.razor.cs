using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.NotificationsUseCase;

namespace MyOrder.Components.Childs;

public partial class Notifications : FluxorComponentBase<NotificationsState, FetchNotificationsAction>
{
#warning Review the use of this component. It is not used in the current version of the app.
    private List<BasketNotificationDto?>? BasketNotifications => State.Value.Notifications;

    protected override FetchNotificationsAction CreateFetchAction() => new();
}
