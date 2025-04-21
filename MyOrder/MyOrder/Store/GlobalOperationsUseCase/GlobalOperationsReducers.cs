using Fluxor;

namespace MyOrder.Store.GlobalOperationsUseCase;

public static class GlobalOperationsReducers
{
    [ReducerMethod]
    public static GlobalOperationsState OnStartBlockingOp(GlobalOperationsState state, StartBlockingOpAction action)
    {
        // 1) If there's already a blocking op, ignore
        if (state.BlockingOperation is not null)
            return state;

        // 2) If we require no non-blocking ops are in flight, check that first
        if (state.NonBlockingOperations.Count > 0)
        {
            return state;
        }

        // 3) Accept the new blocking op
        var newOp = new OperationInfo(
            OperationId: action.OperationId,
            Name: action.Name,
            StartTime: DateTime.UtcNow,
            Progress: null,
            IsBlocking: true);
        return state with
        {
            BlockingOperation = newOp
        };
    }

    [ReducerMethod]
    public static GlobalOperationsState OnCompleteBlockingOp(GlobalOperationsState state, CompleteBlockingOpAction action)
    {
        if (state.BlockingOperation?.OperationId == action.OperationId)
        {
            return state with
            {
                BlockingOperation = null
            };
        }
        return state;
    }

    [ReducerMethod]
    public static GlobalOperationsState OnBlockingOpConflict(GlobalOperationsState state, BlockingOpConflictAction action)
    {
        //if (state.BlockingOperation?.OperationId == action.OperationId)
        //{
        //    return state with
        //    {
        //        BlockingOperation = null
        //    };
        //}
        return state;
    }

    [ReducerMethod]
    public static GlobalOperationsState ReduceUpdateBasketPublicationStateAction(GlobalOperationsState state, UpdateBasketPublicationStateAction action)
    {
        return state with { CurrentPublishProgress = action.NewProgress };
    }

    [ReducerMethod]
    public static GlobalOperationsState OnStartNonBlockingOp(GlobalOperationsState state, StartNonBlockingOpAction action)
    {
        // If there's a blocking op, do we allow starting a new non-blocking op?
        // Probably not, so we can ignore or refuse:
        if (state.BlockingOperation is not null)
        {
            // ignore or dispatch an error 
            return state;
        }

        // Also if we want a concurrency limit for non-blocking ops:
        if (state.NonBlockingOperations.Count >= state.NonBlockingConcurrentLimit)
        {
            // ignore or queue or show a notification
            return state;
        }

        var newOp = new OperationInfo
        (
            OperationId: action.OperationId,
            Name: action.Name,
            StartTime: DateTime.UtcNow,
            Progress: null,
            IsBlocking: false
        );

        var updatedDict = new Dictionary<Guid, OperationInfo>(state.NonBlockingOperations)
        {
            [action.OperationId] = newOp
        };

        return state with
        {
            NonBlockingOperations = updatedDict
        };
    }

    [ReducerMethod]
    public static GlobalOperationsState OnCompleteNonBlockingOp(GlobalOperationsState state, CompleteNonBlockingOpAction action)
    {
        if (!state.NonBlockingOperations.ContainsKey(action.OperationId))
            return state;

        var updatedDict = new Dictionary<Guid, OperationInfo>(state.NonBlockingOperations);
        updatedDict.Remove(action.OperationId);

        return state with
        {
            NonBlockingOperations = updatedDict
        };
    }

    [ReducerMethod]
    public static GlobalOperationsState OnFailNonBlockingOp(GlobalOperationsState state, FailNonBlockingOpAction action)
    {
        if (!state.NonBlockingOperations.ContainsKey(action.OperationId))
            return state;

        var updatedDict = new Dictionary<Guid, OperationInfo>(state.NonBlockingOperations);
        updatedDict.Remove(action.OperationId);

        return state with
        {
            NonBlockingOperations = updatedDict
        };
    }

    /// <summary>
    /// Fault the app globally. We catch only the first fault and ignore the rest.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    [ReducerMethod]
    public static GlobalOperationsState OnFaultApp(GlobalOperationsState state, FaultAppAction action)
    {
        if(state.IsAppGloballyFaulted)
            return state; // already faulted

        return state with
        {
            IsAppGloballyFaulted = true,
            FaultMessage = action.ErrorMessage
        };
    }

    [ReducerMethod]
    public static ExternalNavigationState ReduceOpenExternalLinkAction(
        ExternalNavigationState state,
        OpenExternalLinkAction action)
    {
        return state with
        {
            Url = action.Url,
            Target = action.Target
        };
    }
}
