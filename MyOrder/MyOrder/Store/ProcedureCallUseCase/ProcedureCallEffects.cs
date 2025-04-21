using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Utils;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Store.OrderInfoUseCase;

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

                if (response.Success == true)
                {
                    if (response.UpdateDone == true)
                    {
                        // In case of success, we refresh states indicated in the response
                        dispatcher.Dispatch(new PostProcedureCallSuccessAction(response));
                        success = true;
                    }
                    else
                        errorMessage = response.Message ?? "Field not updated.";
                }
                else
                    errorMessage = response.Message ?? "An error occured!";
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
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallSuccessAction receivedAction,
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
