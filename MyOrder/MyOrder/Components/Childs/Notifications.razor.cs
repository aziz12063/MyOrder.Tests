using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Store.NotificationsUseCase;

namespace MyOrder.Components.Childs;

public partial class Notifications : FluxorComponentBase<NotificationsState, FetchNotificationsAction>
{
    private List<BasketNotificationDto?>? BasketNotifications { get; set; }

    protected override FetchNotificationsAction CreateFetchAction(NotificationsState state) => new(state);

    protected override void CacheNewFields()
    {
        BasketNotifications = State?.Value.Notifications
                     ?? throw new ArgumentNullException(nameof(State.Value.Notifications), "Unexpected null for BasketNotifications object.");
    }
}
