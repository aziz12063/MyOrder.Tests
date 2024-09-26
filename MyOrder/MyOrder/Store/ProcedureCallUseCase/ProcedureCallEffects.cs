using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Utils;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.ProcedureCallUseCase;

public class ProcedureCallEffects(IBasketRepository basketRepository,
    ILogger<OrderInfoEffects> logger, IStateResolver stateResolver, BasketService basket)
{
    [EffectMethod]
    public async Task HandlePostProcedureCallAction(UpdateFieldAction action,
        IDispatcher dispatcher)
    {
        var field = action.Field;
        var value = action.Value;

        if (field == null)
        {
            logger.LogError("Trying to update a null field at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }

        string errorMessage = "An error occured!";
        try
        {
            ProcedureCallResponseDto response = await basketRepository.PostProcedureCallAsync(field, value, basket.BasketId);
            if (response.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    // In case of success, we refresh states indicated in the response
                    dispatcher.Dispatch(new PostProcedureCallSuccessAction(basket.BasketId, response));
                    return;
                }
                else
                    errorMessage = response.Message ?? "Field not updated.";
            }
            else
                errorMessage = response.Message ?? "An error occured!";
        }
        catch (InvalidOperationException e)
        {
            logger.LogError(e, "Error while updating procedure call for {Field}", field);
            //errorMessage = "Une erreur est survenue...";
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while posting procedure call");
            //errorMessage = "Une erreur est survenue...";
        }
        finally
        {
            dispatcher.Dispatch(new PostProcedureCallFailureAction(action.SelfFetchActionType, errorMessage));
        }
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallSuccessAction receivedAction,
        IDispatcher dispatcher)
    {
        var refreshCalls = receivedAction?.ProcedureCallResponse?.RefreshCalls;
        if (refreshCalls is null
            || refreshCalls.Count < 1)
        {
            logger.LogInformation("RefreshCall property is empty. No refresh calls to make.");
            return;
        }

        foreach (var call in refreshCalls)
        {
            if (string.IsNullOrWhiteSpace(call))
            {
                logger.LogError("Refresh call is null");
                continue;
            }
            logger.LogInformation("Dispatching refresh action for {Call}", call);
            stateResolver.DispatchRefreshAction(call, dispatcher, receivedAction.BasketId);
        }
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallFailureAction(PostProcedureCallFailureAction action,
        IDispatcher dispatcher)
    {
        logger.LogDebug("Error while posting procedure call: {ErrorMessage}", action.ErrorMessage);

        stateResolver.DispatchRefreshAction(
            StateResolver.EndpointFetchActionMap[action.SelfFetchActionType], 
            dispatcher, 
            basket.BasketId);
    }
}
