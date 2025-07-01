using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Utils;
using MyOrder.Store.GlobalOperationsUseCase;

namespace MyOrder.Store.ReloadUseCase;

public class ReloadEffects(
    ILogger<ReloadEffects> logger,
    IBasketActionsRepository basketActionsRepository,
    IState<GlobalOperationsState> globalOperationsState,
    NavigationManager navigationManager)
{
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));
    private readonly ILogger<ReloadEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    private readonly IState<GlobalOperationsState> _globalOperationsState = globalOperationsState
        ?? throw new ArgumentNullException(nameof(globalOperationsState));

    [EffectMethod]
    public async Task HandleReloadAction(ReloadAction action, IDispatcher dispatcher)
    {
        var operationName = "reloadBasket";
        // check if app is blocked
        if (_globalOperationsState.Value.IsGlobalBlocked)
        {
            // also log the on going operation from the state in addition to the new one
            _logger.LogError("Global operations are blocked, cannot execute : {OperationName}\n" +
                "--- at: {StackTrace}",
                operationName,
                LogUtility.GetStackTrace());

#warning remove this throw when feature is ready
            throw new InvalidOperationException("Global operations are blocked, cannot post procedure call.");
            //return;
        }

        var operationId = Guid.NewGuid();

        dispatcher.Dispatch(new StartBlockingOpAction(operationId, operationName));

        try
        {
            var response = await _basketActionsRepository.ReloadOrderContextAsync();
            dispatcher.Dispatch(new ReloadSuccessAction(response));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while reloading basket.");
        }
        finally
        {
#warning Review this when feature is ready
            dispatcher.Dispatch(new CompleteBlockingOpAction(
                    operationId,
                    CompletionStatus.Unknown,
                    string.Empty));
        }
    }

    [EffectMethod]
    public async Task HandleReloadSuccessAction(ReloadSuccessAction action, IDispatcher dispatcher)
    {
        logger.LogInformation("Basket reloaded successfully");
        navigationManager.Refresh(true);
    }

    [EffectMethod]
    public async Task HandleReloadFailureAction(ReloadFailureAction action, IDispatcher dispatcher)
    {
        logger.LogError("Error while reloading basket");
        navigationManager.Refresh(true);
    }
}
