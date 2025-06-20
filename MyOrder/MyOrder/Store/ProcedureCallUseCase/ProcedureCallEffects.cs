using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Utils;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Store.OrderInfoUseCase;
using System;

namespace MyOrder.Store.ProcedureCallUseCase;

public class ProcedureCallEffects(IBasketActionsRepository basketActionsRepository,
    ILogger<OrderInfoEffects> logger,
    IStateResolver stateResolver,
    IToastService toastService,
    IBasketService basketService)
{
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));
    private readonly IToastService _toastService = toastService
        ?? throw new ArgumentNullException(nameof(toastService));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    private readonly IBasketService _basketService = basketService
        ?? throw new ArgumentNullException(nameof(basketService));
    private readonly IStateResolver _stateResolver = stateResolver
        ?? throw new ArgumentNullException(nameof(stateResolver));

    [EffectMethod]
    public async Task HandleUpdateFieldAction(UpdateFieldAction action,
        IDispatcher dispatcher)
    {
        var field = action.Field;
        var value = action.Value;

        bool success = false;
        string errorMessage = string.Empty;

        if (field == null)
        {
            _logger.LogError("Trying to update a null field at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }
        try
        {
            var result = await PostProcedureCall(dispatcher,
               () => _basketActionsRepository.PostProcedureCallAsync(field, value));
            success = result.success;
            errorMessage = result.errorMessage;
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e, "Error while updating procedure call for {Field}", field);
            //errorMessage = "Une erreur est survenue...";
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while posting procedure call");
            //errorMessage = "Une erreur est survenue...";
        }
        finally
        {
            if (!success)
                dispatcher.Dispatch(new UpdateFieldProcedureCallFailureAction(action.SelfFetchActionType, errorMessage));
            //Handle failure by showing an app notification
        }
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallAction(PostProcedureCallAction action,
        IDispatcher dispatcher)
    {
        bool success = false;
        string errorMessage = string.Empty;

        var procedureCall = action.ProcedureCall;

        if (procedureCall is null || procedureCall.Count < 1)
        {
            _logger.LogError("ProcedureCall is null or empty at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }
        try
        {
            _logger.LogDebug("Posting procedure call.");

            var result = await PostProcedureCall(dispatcher,
               () => _basketActionsRepository.PostProcedureCallAsync(procedureCall));
            success = result.success;
            errorMessage = result.errorMessage;
        }
        finally
        {
            if (!success)
            {
                _logger.LogDebug("Error posting procedure call.");
                dispatcher.Dispatch(new PostProcedureCallFailureAction(errorMessage));
            }
        }
    }

    private static async Task<(bool success, string errorMessage)> PostProcedureCall(IDispatcher dispatcher,
         Func<Task<ProcedureCallResponseDto?>> postProcedureCallFunc)
    {
        bool success = false;
        string errorMessage = "Unhandled error occured.";
        try
        {
            ProcedureCallResponseDto? response = await postProcedureCallFunc();
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
        catch (Exception)
        {
            throw;
        }
        return (success, errorMessage);
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
