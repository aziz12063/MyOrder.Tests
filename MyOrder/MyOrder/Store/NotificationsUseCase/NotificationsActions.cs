using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;
using System.Collections.Immutable;

namespace MyOrder.Store.NotificationsUseCase;

public class FetchNotificationsAction(NotificationsState state)
    : FetchDataActionBase(state)
{
    public NotificationsState State => state;
}

public class FetchNotificationsSuccessAction(List<BasketNotificationDto?>? notifications)
{
    public List<BasketNotificationDto?>? Notifications { get; } = notifications;
}

public class FetchNotificationsFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public class DeleteNotificationAction(ImmutableList<string> procedureCall,
    NotificationsState? state = null) : FetchDataActionBase(state)
{
    public ImmutableList<string> ProcedureCall { get; } = procedureCall;

#warning Code smell: This property should be removed
    public NotificationsState? State => state;
}

public class DeleteNotificationSuccessAction()
{ }

public class DeleteNotificationFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}