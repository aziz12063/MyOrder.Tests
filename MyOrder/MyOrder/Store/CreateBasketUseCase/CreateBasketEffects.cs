using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Utils;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.CreateBasketUseCase;

public class CreateBasketEffects(
    IBasketActionsRepository basketActionsRepository, 
    IBasketService basketService,
    ILogger<OrderInfoEffects> logger, 
    IUrlService urlService, 
    NavigationManager navigationManager,
    IState<GlobalOperationsState> globalOperationsState)
{
    private readonly IBasketActionsRepository _basketActionsRepository = basketActionsRepository
        ?? throw new ArgumentNullException(nameof(basketActionsRepository));
    private readonly IBasketService _basketService = basketService
        ?? throw new ArgumentNullException(nameof(basketService));
    private readonly ILogger<OrderInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    private readonly IUrlService _urlService = urlService
        ?? throw new ArgumentNullException(nameof(urlService));
    private readonly IState<GlobalOperationsState> _globalOperationsState = globalOperationsState
        ?? throw new ArgumentNullException(nameof(globalOperationsState));


    [EffectMethod]
    public async Task HandleCreateBasketAction(CreateBasketAction action, IDispatcher dispatcher)
    {
        var operationName = action.OperationName;

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
            var response = await _basketActionsRepository.PostNewBasketAsync(action.NewBasketRequest);
            dispatcher.Dispatch(new CreateBasketSuccessAction(response));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating a new basket");
            dispatcher.Dispatch(new CreateBasketFailureAction(e.Message));
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
