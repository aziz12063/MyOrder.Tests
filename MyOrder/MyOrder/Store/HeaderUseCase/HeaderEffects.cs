using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.HeaderUseCase
{
    public class HeaderEffects
    {
        private readonly IBasketRepository basketRepository;
        private readonly IDispatcher dispatcher;
        private readonly ILogger<HeaderEffects> logger;

        public HeaderEffects(IBasketRepository basketRepository, IDispatcher dispatcher, ILogger<HeaderEffects> logger)
        {
            this.basketRepository = basketRepository;
            this.dispatcher = dispatcher;
            this.logger = logger;
            
           Console.WriteLine("HeaderEffects created");
        }

        [EffectMethod]
        public async Task HandleFetchGeneralInfoAction(FetchGeneralInfoAction action, IDispatcher dispatcher)
        { 
            this.logger.LogInformation(message: "HandleFetchGeneralInfoAction");  

            if (action.BasketId == null)
            {
                dispatcher.Dispatch(new FetchGeneralInfoFailureAction("BasketId is required"));
                return;
            }

            try
            {
                logger.LogInformation("Fetching general infos for {BasketId}", action.BasketId);
                var basketInfo = await basketRepository.GetBasketGeneralInfoAsync(action.BasketId);
                dispatcher.Dispatch(new FetchGeneralInfoSuccessAction(basketInfo));
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error fetching general infos for {BasketId}", action.BasketId);
                dispatcher.Dispatch(new FetchGeneralInfoFailureAction(ex.Message));
            }
        }
    }
}