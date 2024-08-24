using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.ProcedureCallUseCase;

public class ProcedureCallEffects(IBasketRepository basketRepository, ILogger<OrderInfoEffects> logger, IStateResolver stateResolver)
{
    [EffectMethod]
    public async Task HandlePostProcedureCallAction(PostProcedureCallAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await basketRepository.PostProcedureCallAsync(action.BasketId, action.ProcedureCall);
            dispatcher.Dispatch(new PostProcedureCallSuccessAction(action.BasketId, response));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while posting procedure call");
            dispatcher.Dispatch(new PostProcedureCallFailureAction(e.Message));
        }
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallSuccessAction receivedAction,
        IDispatcher dispatcher)
    {
        if (receivedAction?.ProcedureCallResponse?.RefreshCalls is null || receivedAction.ProcedureCallResponse.RefreshCalls.Count < 1)
        {
            logger.LogInformation("RefreshCall property is empty. No refresh calls to make.");
            return;
        }

        foreach (var call in receivedAction.ProcedureCallResponse.RefreshCalls)
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
}
