using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;

namespace MyOrder.Store.LinesUseCase;

public class LinesEffects(IBasketRepository basketRepository, IStateResolver stateResolver,
    ILogger<LinesEffects> logger)
{
    [EffectMethod]
    public async Task HandleFetchLinesAction(FetchLinesAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching lines for {BasketId}", action.BasketId);
            var lines = await basketRepository.GetBasketLinesAsync(action.BasketId);

            dispatcher.Dispatch(new FetchLinesSuccessAction(lines));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching lines");
            dispatcher.Dispatch(new FetchLinesFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleDuplicateLinesAction(DuplicateLinesActions action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Duplicating lines for {BasketId}", action.BasketId);
            var response = await basketRepository.DuplicateOrderLinesAsync(action.BasketId, action.LinesIds);

            dispatcher.Dispatch(new EffectOnLinesSuccessAction(action.BasketId, response));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while duplicating lines");
            dispatcher.Dispatch(new EffectOnLinesFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleDeleteLinesAction(DeleteLinesActions action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Deleting lines for {BasketId}", action.BasketId);
            var response = await basketRepository.DeleteOrderLinesAsync(action.BasketId, action.LinesIds);

            dispatcher.Dispatch(new EffectOnLinesSuccessAction(action.BasketId, response));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while deleting lines");
            dispatcher.Dispatch(new EffectOnLinesFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleEffectOnLineSuccessAction(EffectOnLinesSuccessAction receivedAction, IDispatcher dispatcher)
    {
        var refreshCalls = receivedAction?.ProcedureCallResponseDto?.RefreshCalls;
        var basketId = receivedAction?.BasketId;
        stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls, basketId);
    }

    [EffectMethod]
    public async Task HandleEffectOnLineFailureAction(EffectOnLinesFailureAction receivedAction, IDispatcher dispatcher)
    {
        logger.LogError("Error while performing action on lines: {ErrorMessage}", receivedAction.ErrorMessage);
    }
}
