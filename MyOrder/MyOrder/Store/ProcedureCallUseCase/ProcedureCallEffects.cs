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
    public async Task HandleUpdateFieldAction(UpdateFieldAction action,
        IDispatcher dispatcher)
    {
        var field = action.Field;
        var value = action.Value;

        bool success = false;
        string errorMessage = string.Empty;

        if (field == null)
        {
            logger.LogError("Trying to update a null field at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }
        try
        {
            var result = await PostProcedureCall(logger,
               basket, dispatcher,
               () => basketRepository.PostProcedureCallAsync(field, value, basket.BasketId));
            success = result.success;
            errorMessage = result.errorMessage;
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
            logger.LogError("ProcedureCall is null or empty at {StackTrace}",
                LogUtility.GetStackTrace());
        }
        try
        {
            logger.LogDebug("Posting procedure call for {BasketId}", action.BasketId);

            var result = await PostProcedureCall(logger,
               basket, dispatcher,
               () => basketRepository.PostProcedureCallAsync(procedureCall, basket.BasketId));
            success = result.success;
            errorMessage = result.errorMessage;
        }
        finally
        {
            if (!success)
            {
                logger.LogDebug("Fetching Validation Rules for {BasketId}", action.BasketId);
                dispatcher.Dispatch(new PostProcedureCallFailureAction(errorMessage));
            }
        }
    }

    private static async Task<(bool success, string errorMessage)> PostProcedureCall(ILogger<OrderInfoEffects> logger,
        BasketService basket, IDispatcher dispatcher,
         Func<Task<ProcedureCallResponseDto>> postProcedureCallFunc)
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
            else if (response.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    // In case of success, we refresh states indicated in the response
                    dispatcher.Dispatch(new PostProcedureCallSuccessAction(basket.BasketId, response));
                    success = true;
                }
                else
                    errorMessage = response.Message ?? "Field not updated.";
            }
            else
                errorMessage = response.Message ?? "An error occured!";
        }
        catch (Exception )
        {
            throw;
        }
        return (success, errorMessage);
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallSuccessAction receivedAction,
        IDispatcher dispatcher)
    {
        var refreshCalls = receivedAction?.ProcedureCallResponse?.RefreshCalls;
        var basketId = receivedAction?.BasketId;
        stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls, basketId);
    }



    [EffectMethod]
    public async Task HandlePostProcedureCallFailureAction(UpdateFieldProcedureCallFailureAction action,
        IDispatcher dispatcher)
    {
        logger.LogDebug("Error while posting procedure call: {ErrorMessage}", action.ErrorMessage);

        stateResolver.DispatchRefreshAction(
            StateResolver.EndpointFetchActionMap[action.SelfFetchActionType],
            dispatcher,
            basket.BasketId);
    }
}
