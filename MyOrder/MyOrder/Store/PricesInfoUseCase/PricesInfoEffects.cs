using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.PricesInfoUseCase;

public class PricesInfoEffects(IPricesInfoRepository _pricesInfoRepository, ILogger<PricesInfoEffects> logger)
{
    private readonly IPricesInfoRepository pricesInfoRepository = _pricesInfoRepository
        ?? throw new ArgumentNullException(nameof(_pricesInfoRepository));
    private readonly ILogger<PricesInfoEffects> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));

    [EffectMethod]
    public async Task HandleFetchPricesInfoAction(FetchPricesInfoAction action, IDispatcher dispatcher)
    {
        try
        {
            var pricesInfoTask = await pricesInfoRepository.GetBasketPricesInfoAsync();

            dispatcher.Dispatch(new FetchPricesInfoSuccessAction(pricesInfoTask));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while fetching prices info");
            dispatcher.Dispatch(new FetchPricesInfoFailureAction(e.Message));
        }
    }
}
