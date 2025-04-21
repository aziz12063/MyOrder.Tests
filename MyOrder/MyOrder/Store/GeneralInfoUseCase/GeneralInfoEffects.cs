using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Infrastructure.Repositories.Implementations;
using MyOrder.Services;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Store.ProcedureCallUseCase;

namespace MyOrder.Store.GeneralInfoUseCase;

public class GeneralInfoEffects(IGeneralInfoRepository generalInfoRepository,
    IBasketActionsRepository basketActionsRepository,
    IStateResolver stateResolver,
    ILogger<GeneralInfoEffects> logger,
    AuthenticationStateProvider authenticationStateProvider)
{
    [EffectMethod]
    public async Task HandleFetchGeneralInfo(FetchGeneralInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            logger.LogInformation("Fetching general info.");
            var basketGeneralInfo = await generalInfoRepository.GetBasketGeneralInfoAsync();

            logger.LogInformation("Retrieving authenticated user info.");
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();

            dispatcher.Dispatch(new FetchGeneralInfoSuccessAction(basketGeneralInfo, authState.User));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching general info data");
            dispatcher.Dispatch(new FetchGeneralInfoFailureAction(ex.Message));
        }
    }

    [EffectMethod]
    public async Task HandlePublishBasket(PublishBasketAction action, IDispatcher dispatcher)
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        var pollingTask = PollForProgressAsync(dispatcher, cancellationTokenSource.Token);

        try
        {
            logger.LogInformation("Publishing basket.");

            var response = await basketActionsRepository.PostProcedureCallAsync(action.ProcedureCall!);

            cancellationTokenSource.Cancel();

            stateResolver.DispatchRefreshCalls(dispatcher, response?.RefreshCalls);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error publishing basket");
        }

        try
        {
            await pollingTask;
        }
        catch (TaskCanceledException)
        { }
    }

    private async Task PollForProgressAsync(IDispatcher dispatcher, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var progressResponse = await generalInfoRepository.BasketPublicationStateAsync(cancellationToken);
                dispatcher.Dispatch(new UpdateBasketPublicationStateAction(progressResponse));

                await Task.Delay(1000, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                dispatcher.Dispatch(new UpdateBasketPublicationStateAction(null));
                break;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error polling for progress");
                throw;
            }
        }
    }
}
