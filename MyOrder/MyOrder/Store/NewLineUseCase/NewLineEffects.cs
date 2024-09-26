using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.NewLineUseCase;

public class NewLineEffects(IBasketRepository basketRepository, ILogger<NewLineEffects> logger, IState<NewLineState> newLineState)
{
    [EffectMethod]
    public async Task HandleFetchNewLineAction(FetchNewLineAction action, IDispatcher dispatcher)
    {
        try
        {
            var basketLine = await basketRepository.GetNewLineAsync(action.BasketId);
            dispatcher.Dispatch(new FetchNewLineSuccessAction(basketLine));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching new line");
            dispatcher.Dispatch(new FetchNewLineFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleResetNewLineAction(ResetNewLineAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await basketRepository.ResetNewLineStateAsync(action.BasketId);

            // To refetch the latest new line state
            dispatcher.Dispatch(new FetchNewLineAction(newLineState.Value, action.BasketId));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error resetting new line");

            // In case of failure, we dispatch the same action as FetchNewLineFailureAction
            dispatcher.Dispatch(new FetchNewLineFailureAction(ex.Message));
        }
    }
}
