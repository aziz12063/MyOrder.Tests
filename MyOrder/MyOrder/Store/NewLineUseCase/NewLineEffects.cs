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

    [EffectMethod]
    public async Task HandlePostFreeTextAction(PostFreeTextAction action, IDispatcher dispatcher)
    {
        var texts = action.FreeTexts;
        var basketId = action.BasketId;
        bool success = false;
        if (texts == null || texts.Count == 0)
        {
            logger.LogError("free text is null or empty");
            return;
        }

        string errorMessage = "";
        try
        {
            var response = await basketRepository.CommitAddFreeTextLineAsync(basketId, texts);


            if (response == null)
            {
                errorMessage = "Null response returned";
            }
            else if (response.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    logger.LogInformation($"dispatching PostFreeTextSuccessAction");
                    dispatcher.Dispatch(new PostFreeTextSuccessAction(basketId, response));
                    success = true;
                }
                else
                    errorMessage = response.Message ?? "free text not added";
            }
            else
                errorMessage = response.Message ?? "An error occured!";

        }
        catch (InvalidOperationException e)
        {
            logger.LogError(e, "Error while adding text");

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while posting text");
        }
        finally
        {

            if (!success)
            {
                dispatcher.Dispatch(new PostFreeTextFailureAction(errorMessage));
            }
        }
    }

    [EffectMethod]
    public async Task HandlePostFreeTextSuccessAction(PostFreeTextSuccessAction receivedAction,
        IDispatcher dispatcher)
    {
        var refreshCalls = receivedAction?.ProcedureCallResponse?.RefreshCalls;
        var basketId = receivedAction?.BasketId;
        stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls, basketId);
    }

    [EffectMethod]
    public async Task HandlePostFreeTextFailureAction(PostFreeTextFailureAction action, IDispatcher dispatcher)
    {
        logger.LogInformation(action.ErrorMessage);
    }
}
