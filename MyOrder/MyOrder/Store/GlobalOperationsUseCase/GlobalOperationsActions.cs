using MyOrder.Shared.Dtos.GeneralInformation;

namespace MyOrder.Store.GlobalOperationsUseCase;

public enum CompletionStatus
{
    Success,
    Failure,
    Unknown
}

// Blocking op
public record StartBlockingOpAction(Guid OperationId, string Name);
public record CompleteBlockingOpAction(Guid OperationId, CompletionStatus CompletionStatus, string CompletionMessage);

// Non-blocking op
public record StartNonBlockingOpAction(Guid OperationId, string Name);
public record CompleteNonBlockingOpAction(Guid OperationId, CompletionStatus CompletionStatus, string CompletionMessage);

// Miscellaneous actions
public record FaultAppAction(string ErrorMessage);
public record OpenExternalLinkAction(string Url, string Target);
public record UpdateBasketPublicationStateAction(BasketPublishingProgress? NewProgress);
