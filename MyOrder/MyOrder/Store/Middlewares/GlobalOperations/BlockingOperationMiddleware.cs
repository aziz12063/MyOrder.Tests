using Fluxor;
using MyOrder.Store.GlobalOperationsUseCase;

namespace MyOrder.Store.Middlewares.GlobalOperations;

public class BlockingOperationMiddleware(
    IState<GlobalOperationsState> globalState,
    ILogger<BlockingOperationMiddleware> logger) : Middleware
{
    private readonly IState<GlobalOperationsState> _globalState = globalState
        ?? throw new ArgumentNullException(nameof(globalState));
    private readonly ILogger<BlockingOperationMiddleware> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    private IStore _store = null!;
    private IDispatcher _dispatcher = null!;

    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        _store = store;
        _dispatcher = dispatcher;
        return base.InitializeAsync(dispatcher, store);
    }

    public override bool MayDispatchAction(object action)
    {
        //if (action is StartBlockingOpAction startAction)
        //{
        //    var state = _globalState.Value;

        //    if (state.BlockingOperation != null)
        //    {
        //        var conflict = new BlockingOpConflictAction(
        //            ExistingOperationId: state.BlockingOperation.OperationId,
        //            ExistingOperationName: state.BlockingOperation.Name,
        //            AttemptedOperationId: startAction.OperationId,
        //            AttemptedOperationName: startAction.Name,
        //            Timestamp: DateTime.UtcNow
        //        );

        //        _logger.LogWarning("Blocking operation conflict: attempted to start '{NewOperationName}' " +
        //            "while '{OldOperationName}' is still running.", startAction.Name, state.BlockingOperation.Name);

        //        _dispatcher.Dispatch(conflict);
        //        return false;
        //    }
        //}

        return true;
    }
}