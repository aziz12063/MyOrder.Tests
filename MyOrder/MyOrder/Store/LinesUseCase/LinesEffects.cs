using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;

namespace MyOrder.Store.LinesUseCase;

public class LinesEffects(IOrderLinesRepository basketLinesRepository, IStateResolver stateResolver,
    ILogger<LinesEffects> logger)
{
    private readonly IOrderLinesRepository _basketRepository = basketLinesRepository
        ?? throw new ArgumentNullException(nameof(basketLinesRepository));
    private readonly IStateResolver _stateResolver = stateResolver
        ?? throw new ArgumentNullException(nameof(stateResolver));
    private readonly ILogger<LinesEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchLinesAction(FetchLinesAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Fetching lines");
            var lines = await _basketRepository.GetOrderLinesAsync();

            dispatcher.Dispatch(new FetchLinesSuccessAction(lines));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while fetching lines");
            dispatcher.Dispatch(new FetchLinesFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleDuplicateLinesAction(DuplicateLinesAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Duplicating lines.");
            var response = await _basketRepository.DuplicateOrderLinesAsync(action.LinesIds);

            dispatcher.Dispatch(new EffectOnLinesSuccessAction(response));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while duplicating lines");
            dispatcher.Dispatch(new EffectOnLinesFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleDeleteLinesAction(DeleteLinesAction action, IDispatcher dispatcher)
    {
        try
        {
            _logger.LogInformation("Deleting lines.");
            var response = await _basketRepository.DeleteOrderLinesAsync(action.LinesIds);

            dispatcher.Dispatch(new EffectOnLinesSuccessAction(response));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while deleting lines");
            dispatcher.Dispatch(new EffectOnLinesFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandleEffectOnLineSuccessAction(EffectOnLinesSuccessAction receivedAction, IDispatcher dispatcher)
    {
        var refreshCalls = receivedAction?.ProcedureCallResponseDto?.RefreshCalls;
        _stateResolver.DispatchRefreshCalls(dispatcher, refreshCalls);
    }

    [EffectMethod]
    public async Task HandleEffectOnLineFailureAction(EffectOnLinesFailureAction receivedAction, IDispatcher dispatcher)
    {
        _logger.LogError("Error while performing action on lines: {ErrorMessage}", receivedAction.ErrorMessage);
    }
}
