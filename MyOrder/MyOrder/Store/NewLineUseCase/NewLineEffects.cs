using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Store.NewLineUseCase;

public class NewLineEffects(IBasketRepository basketRepository, IStateResolver stateResolver,
    ILogger<NewLineEffects> logger, IState<NewLineState> newLineState)
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

    [EffectMethod]
    public async Task HandleCommitNewLineAction(CommitNewLineAction action, IDispatcher dispatcher)
    {
        string errorMessage = "Fatal. Couldn't commit new line.";
        bool success = false;
        try
        {
            var response = await basketRepository.CommitAddNewLineAsync(action.BasketId);
            if (response.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    stateResolver.DispatchRefreshCalls(dispatcher, response.RefreshCalls, action.BasketId);
                    success = true;
                }
                else
                    errorMessage = (response.Message ?? "No line added.");
            }
            else
                errorMessage = (response.Message ?? "Failed updating field.")
                        + "\n"
                        + (response.ErrorCause ?? "Unknown error.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error committing new line");
            errorMessage = ex.Message;
        }
        finally
        {
            // In case of failure, we dispatch the same action as FetchNewLineFailureAction
            if (!success)
                dispatcher.Dispatch(new FetchNewLineFailureAction(errorMessage));
        }
    }
}
