using MyOrder.Shared.Dtos.GeneralInformation;

namespace MyOrder.Store.GlobalOperationsUseCase;

// For starting a blocking op
public record StartBlockingOpAction(Guid OperationId, string Name);

// For completing/failing a blocking op
public record CompleteBlockingOpAction(Guid OperationId);
public record FailBlockingOpAction(
    Guid OperationId,
    string ErrorMessage,
    DateTime Timestamp
);
public record BlockingOpConflictAction(
    Guid ExistingOperationId,
    string ExistingOperationName,
    Guid AttemptedOperationId,
    string AttemptedOperationName,
    DateTime Timestamp
);
public record UpdateBasketPublicationStateAction(BasketPublishingProgress? NewProgress);

// For starting a non-blocking op
public record StartNonBlockingOpAction(Guid OperationId, string Name);

// For completing/failing a non-blocking op
public record CompleteNonBlockingOpAction(Guid OperationId);
public record FailNonBlockingOpAction(Guid OperationId, string ErrorMessage);

public record FaultAppAction(string ErrorMessage);

public record OpenExternalLinkAction(string Url, string Target);