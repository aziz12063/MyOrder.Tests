using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;
using System.Collections.Immutable;

namespace MyOrder.Store.NotificationsUseCase;

public record FetchNotificationsAction() : FetchDataActionBase;

public record FetchNotificationsSuccessAction(List<BasketNotificationDto?> Notifications);

public record FetchNotificationsFailureAction(string ErrorMessage);

public record DeleteNotificationAction(ImmutableList<string> ProcedureCall) : FetchDataActionBase;

public record DeleteNotificationSuccessAction();

public record DeleteNotificationFailureAction(string ErrorMessage);