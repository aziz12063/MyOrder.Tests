namespace MyOrder.Store.GlobalOperationsUseCase;

public record OperationInfo(
    Guid OperationId,
    string Name,
    DateTime StartTime,
    int? Progress,
    bool IsBlocking
);