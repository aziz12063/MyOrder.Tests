using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Utils;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.ProcedureCallUseCase;

public class ProcedureCallEffects(
    IBasketActionsRepository basketActionsRepository,
    ILogger<OrderInfoEffects> logger,
    IState<GlobalOperationsState> globalOperationsState,
    IStateResolver stateResolver,
    IToastService toastService,
    IBasketService basketService)
{
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    private readonly IState<GlobalOperationsState> _globalOperationsState = globalOperationsState
        ?? throw new ArgumentNullException(nameof(globalOperationsState));
    private readonly IStateResolver _stateResolver = stateResolver
        ?? throw new ArgumentNullException(nameof(stateResolver));
    private readonly IToastService _toastService = toastService
        ?? throw new ArgumentNullException(nameof(toastService));
    private readonly IBasketService _basketService = basketService
        ?? throw new ArgumentNullException(nameof(basketService));

    [EffectMethod]
    public async Task HandleUpdateFieldAction(UpdateFieldAction action,
        IDispatcher dispatcher)
    {
        var field = action.Field;
        if (field is null)
        {
            _logger.LogError("Trying to update a null field at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }

        await ExecuteProcedureCallAsync(
            dispatcher,
            () => _basketActionsRepository.PostProcedureCallAsync(field, action.Value),
            $"Updating field {action.SelfFetchActionType}",
            field.IsBlockingProcedure ?? false);
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallAction(PostProcedureCallAction action,
        IDispatcher dispatcher)
    {
        var procedureCall = action.ProcedureCall;

        if (procedureCall is null || procedureCall.Count < 1)
        {
            _logger.LogError("ProcedureCall is null or empty at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }

        await ExecuteProcedureCallAsync(
            dispatcher,
            () => _basketActionsRepository.PostProcedureCallAsync(procedureCall),
            $"Posting procedure call {string.Join("\n", procedureCall)}",
            action.IsBlocking);
    }

    private async Task ExecuteProcedureCallAsync(
        IDispatcher dispatcher,
         Func<Task<ProcedureCallResponseDto?>> postProcedureCallFunc,
         string operationName,
         bool isBlocking)
    {
        // check if app is blocked
        if (_globalOperationsState.Value.IsGlobalBlocked)
        {
            // also log the on going operation from the state in addition to the new one
            _logger.LogError("Global operations are blocked, cannot execute post procedure call: {OperationName}\n" +
                "--- at: {StackTrace}",
                operationName,
                LogUtility.GetStackTrace());

#warning remove this throw when feature is ready
            throw new InvalidOperationException("Global operations are blocked, cannot post procedure call.");
            //return;
        }

        var operationId = Guid.NewGuid();

        if (isBlocking)
        {
            dispatcher.Dispatch(new StartBlockingOpAction(operationId, operationName));
        }
        else
        {
            dispatcher.Dispatch(new StartNonBlockingOpAction(operationId, operationName));
        }

        var (success, errorMessage) = (false, "Unhandled error occurred.");

        try
        {
            var response = await postProcedureCallFunc();

            if (response == null)
            {
                errorMessage = "Null response returned.";
            }
            else
            {
                HandlePostProcedureCallNavigation(dispatcher, response);

                var updateDone = response.UpdateDone.GetValueOrDefault(false);
                success = response.Success.GetValueOrDefault(false) && updateDone;

                errorMessage = response.Message ??
                    (!updateDone ?
                        "No update done upon procedure call completion\nDispatching refresh calls..."
                        : success ?
                            "Procedure call completed successfully\nDispatching refresh calls..."
                            : "Server returned \"OK\" upon procedure call completion with success : false.\n" +
                            "Dispatching refresh calls...");

                dispatcher.Dispatch(new PostProcedureCallCompletedSuccessfullyAction(response));
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error posting procedure call. {Message}", errorMessage);

        }
        finally
        {
            if (isBlocking)
            {
                dispatcher.Dispatch(new CompleteBlockingOpAction(
                    operationId,
                    success ? CompletionStatus.Success : CompletionStatus.Failure,
                    string.Empty));
            }
            else
            {
                dispatcher.Dispatch(new CompleteNonBlockingOpAction(
                    operationId,
                    success ? CompletionStatus.Success : CompletionStatus.Failure,
                    string.Empty));
            }
        }
    }

    private static void HandlePostProcedureCallNavigation(IDispatcher dispatcher, ProcedureCallResponseDto? response)
    {
        var target = response?.Target;

        if (target == null)
            return;

        var url = target.TargetUrl;

        if (string.IsNullOrEmpty(url))
            return;

        dispatcher.Dispatch(new OpenExternalLinkAction(url, target.TargetType ?? "_blank"));
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallCompletedSuccessfullyAction receivedAction,
        IDispatcher dispatcher)
    {
        var refreshCalls = receivedAction?.ProcedureCallResponse?.RefreshCalls;
        _toastService.ShowSuccess(receivedAction.ProcedureCallResponse?.Message ?? "Success");
        try
        {
            if (refreshCalls == null)
            {
                _logger.LogWarning("Refresh calls are null");
                return;
            }
            _stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while dispatching refresh calls");
        }
        //stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls);
    }


    [EffectMethod]
    public async Task HandlePostProcedureCallFailureAction(UpdateFieldProcedureCallFailureAction action,
        IDispatcher dispatcher)
    {
        _logger.LogDebug("Error while posting procedure call: {ErrorMessage}", action.ErrorMessage);

        _toastService.ShowError(action.ErrorMessage);

        _stateResolver.DispatchRefreshAction(dispatcher,
            StateResolver.EndpointFetchActionMap[action.SelfFetchActionType]);
    }
}
