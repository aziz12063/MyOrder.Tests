using System.Collections.Immutable;

namespace MyOrder.Shared.Dtos;

public record BasketNotificationDto(
    int NotificationId,
    string? Severity,
    string? Message,
    DateTime CreatedDate,
    ImmutableList<string?>? ProcedureCall);