using Fluxor;
using MyOrder.Shared.Dtos.GeneralInformation;

namespace MyOrder.Store.GlobalOperationsUseCase;

[FeatureState]
public record GlobalOperationsState(
    OperationInfo? BlockingOperation,
    IReadOnlyDictionary<Guid, OperationInfo> NonBlockingOperations,
    bool IsAppGloballyFaulted,
    string GlobalFaultMessage,
    bool IsStateFaulted,
    string StateFaultMessage,
    int NonBlockingConcurrentLimit = 3,
    BasketPublishingProgress? CurrentPublishProgress = null)
{
    public bool IsGlobalBlocked => BlockingOperation != null;

    public GlobalOperationsState() : this(default, new Dictionary<Guid, OperationInfo>(), false, string.Empty, false, string.Empty) { }
}