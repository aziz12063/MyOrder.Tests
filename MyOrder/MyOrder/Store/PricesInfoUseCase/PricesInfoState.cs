using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase
{
    [FeatureState]
    public class PricesInfoState
    {
        public BasketPricesInfoDto PricesInfo { get; } = new();
        public bool IsLoading { get; } = true;

        public PricesInfoState() { }

        public PricesInfoState(BasketPricesInfoDto pricesInfo)
        {
            PricesInfo = pricesInfo;
            IsLoading = false;
        }
    }
}
