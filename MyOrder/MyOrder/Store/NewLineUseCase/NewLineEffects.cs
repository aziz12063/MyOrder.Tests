using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Store.NewLineUseCase;

public class NewLineEffects(
    INewOrderLineRepository newOrderLineRepository, 
    IStateResolver stateResolver,
    ILogger<NewLineEffects> logger)
{
    private readonly INewOrderLineRepository _newOrderLineRepository = newOrderLineRepository
        ?? throw new ArgumentNullException(nameof(newOrderLineRepository));
    private readonly IStateResolver _stateResolver = stateResolver
        ?? throw new ArgumentNullException(nameof(stateResolver));
    private readonly ILogger<NewLineEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchNewLineAction(FetchNewLineAction action, IDispatcher dispatcher)
    {
        try
        {
            var basketLine = await _newOrderLineRepository.GetNewLineAsync();
            dispatcher.Dispatch(new FetchNewLineSuccessAction(basketLine));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching new line");
            dispatcher.Dispatch(new FetchNewLineFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleResetNewLineAction(ResetNewLineAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await _newOrderLineRepository.ResetNewLineStateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error resetting new line");
        }
    }

    [EffectMethod]
    public async Task HandleCommitNewLineAction(CommitNewLineAction action, IDispatcher dispatcher)
    {
        string errorMessage = "Fatal. Couldn't commit new line.";
        bool success = false;
        try
        {
            var response = await _newOrderLineRepository.CommitAddNewLineAsync();
            _stateResolver.DispatchRefreshCalls(dispatcher, response?.RefreshCalls);
            if (response?.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    success = true;
                }
                else
                    errorMessage = (response.Message ?? "No line added.");
            }
            else
                errorMessage = (response?.Message ?? "Failed updating field.")
                        + "\n"
                        + (response?.ErrorCause ?? "Unknown error.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error committing new line");
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
        bool success = false;
        if (texts == null || texts.Count == 0)
        {
            _logger.LogError("free text is null or empty");
            return;
        }

        string errorMessage = "";
        try
        {
            var response = await _newOrderLineRepository.CommitAddFreeTextLineAsync(texts);


            if (response == null)
            {
                errorMessage = "Null response returned";
            }
            else if (response.Success == true)
            {
                if (response.UpdateDone == true)
                {
                    _logger.LogInformation($"dispatching PostFreeTextSuccessAction");
                    dispatcher.Dispatch(new PostFreeTextSuccessAction(response));
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
            _logger.LogError(e, "Error while adding text");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while posting text");
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
        _stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls);
    }

    [EffectMethod]
    public async Task HandlePostFreeTextFailureAction(PostFreeTextFailureAction action, IDispatcher dispatcher)
    {
        _logger.LogInformation(action.ErrorMessage);
    }
}