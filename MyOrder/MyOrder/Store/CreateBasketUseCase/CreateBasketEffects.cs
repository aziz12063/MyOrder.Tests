using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.CreateBasketUseCase;

public class CreateBasketEffects(IBasketActionsRepository basketActionsRepository, IBasketService basketService,
    ILogger<OrderInfoEffects> logger, IUrlService urlService, NavigationManager navigationManager)
{
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));
    private readonly IBasketService _basketService = basketService
        ?? throw new ArgumentNullException(nameof(basketService));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    private readonly IUrlService _urlService = urlService
        ?? throw new ArgumentNullException(nameof(urlService));


    [EffectMethod]
    public async Task HandleCreateBasketAction(CreateBasketAction action, IDispatcher dispatcher)
    {
        try
        {
            var response = await _basketActionsRepository.PostNewBasketAsync(action.NewBasketRequest);
            dispatcher.Dispatch(new CreateBasketSuccessAction(response));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating a new basket");
            dispatcher.Dispatch(new CreateBasketFailureAction(e.Message));
        }
    }

    [EffectMethod]
    public async Task HandleCloneBasketAction(CloneBasketAction action, IDispatcher dispatcher)
    {
        try
        {
            // We need basketId and New=1 to clone and create a new basket
            var response = await _basketActionsRepository.PostNewBasketAsync(
                new Dictionary<string, string> 
                {
                    { "BasketId", _basketService.BasketId },
                    { "New", "1"}
                }!);
            dispatcher.Dispatch(new CreateBasketSuccessAction(response));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating a new basket");
            dispatcher.Dispatch(new CreateBasketFailureAction(e.Message));
        }
    }

    [EffectMethod]
    public Task HandleCreateBasketSuccessAction(CreateBasketSuccessAction action, IDispatcher dispatcher)
    {
        var basketId = action.NewBasketResponse?.BasketId;

        if (!string.IsNullOrWhiteSpace(basketId))
        {
            navigationManager.NavigateTo(_urlService.GetBasketUrl(basketId), true);
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
