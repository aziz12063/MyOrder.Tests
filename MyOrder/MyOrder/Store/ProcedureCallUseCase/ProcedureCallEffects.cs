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
        bool success = false;

        if (field == null)
        {
            logger.LogError("Trying to update a null field at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }

        string errorMessage = "Unhandled error occured." ;
        try
        {
            var response = await basketRepository.PostProcedureCallAsync(field, value, basket.BasketId);
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
                dispatcher.Dispatch(new PostProcedureCallFailureAction(action.SelfFetchActionType, errorMessage));
        }
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
