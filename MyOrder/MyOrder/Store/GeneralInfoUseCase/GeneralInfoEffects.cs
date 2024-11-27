using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.GeneralInfoUseCase
{
    public class GeneralInfoEffects(IGeneralInfoRepository generalInfoRepository, ILogger<GeneralInfoEffects> logger
        , AuthenticationStateProvider authenticationStateProvider)
    {
        [EffectMethod]
        public async Task HandleFetchGeneralInfo(FetchGeneralInfoAction action, IDispatcher dispatcher)
        {
            try
            {
                logger.LogInformation("Fetching general info for {BasketId}", action.BasketId);
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
    }
}
