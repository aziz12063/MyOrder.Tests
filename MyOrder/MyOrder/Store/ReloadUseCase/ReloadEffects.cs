using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.ReloadUseCase;

public class ReloadEffects(ILogger<ReloadEffects> logger, IBasketRepository basketRepository,
    NavigationManager navigationManager)
{
    [EffectMethod]
    public async Task HandleReloadAction(ReloadAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await basketRepository.ReloadOrderContextAsync(action.BasketId);
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
