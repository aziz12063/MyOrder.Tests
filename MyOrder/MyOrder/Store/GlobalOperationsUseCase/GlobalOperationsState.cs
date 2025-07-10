using Fluxor;
using MyOrder.Shared.Dtos.GeneralInformation;

namespace MyOrder.Store.GlobalOperationsUseCase;

[FeatureState]
public record GlobalOperationsState(
    OperationInfo? BlockingOperation,
    IReadOnlyDictionary<Guid, OperationInfo> NonBlockingOperations,
    bool IsStateFaulted,
    string StateFaultMessage,
    bool IsAppReloading,
    int NonBlockingConcurrentLimit = 3,
    BasketPublishingProgress? CurrentPublishProgress = null)
{
    public bool IsGlobalBlocked => BlockingOperation != null;

    public GlobalOperationsState() : this(default, new Dictionary<Guid, OperationInfo>(), false, string.Empty, false) { }
}