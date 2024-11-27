using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.ReloadUseCase;

public class ReloadEffects(ILogger<ReloadEffects> logger, IBasketActionsRepository basketActionsRepository,
    NavigationManager navigationManager)
{
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));

    [EffectMethod]
    public async Task HandleReloadAction(ReloadAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await _basketActionsRepository.ReloadOrderContextAsync();
            dispatcher.Dispatch(new ReloadSuccessAction(response));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while reloading basket {BasketId}", action.BasketId);
        }
        finally
        {
            //dispatcher.Dispatch(new ReloadFailureAction(response));
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
