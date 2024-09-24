using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.CreateBasketUseCase;

public class CreateBasketEffects(IBasketRepository basketRepository, ILogger<OrderInfoEffects> logger,
    IUrlService urlService, NavigationManager navigationManager)
{
    [EffectMethod]
    public async Task HandleCreateBasketAction(CreateBasketAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await basketRepository.PostNewBasketAsync(action.NewBasketRequest);
            dispatcher.Dispatch(new CreateBasketSuccessAction(response));
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while creating a new basket");
            dispatcher.Dispatch(new CreateBasketFailureAction(e.Message));
        }
    }

    [EffectMethod]
    public Task HandleCreateBasketSuccessAction(CreateBasketSuccessAction action, IDispatcher dispatcher)
    {
        var basketId = action.NewBasketResponse?.BasketId;

        if (!string.IsNullOrWhiteSpace(basketId))
        {
            navigationManager.NavigateTo(urlService.GetBasketUrl(basketId), true);
        }
        else
        {
            var url = action.NewBasketResponse?.Url;
            if (!string.IsNullOrWhiteSpace(url))
            {
                navigationManager.NavigateTo(url);
            }
            else
            {
                //Error
            }
        }
        return Task.CompletedTask;
    }
}
