using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase
{
    [FeatureState]
    public class PricesInfoState
    {
        public BasketPricesInfoDto? PricesInfo { get; }
        public List<BasketValueDto?>? Coupons { get; }
        public List<BasketValueDto?>? WarrantyCostOptions { get; }
        public List<BasketValueDto?>? ShippingCostOptions { get; }
        public bool IsLoading { get; } = true;

        public PricesInfoState() { }

        public PricesInfoState(BasketPricesInfoDto? pricesInfo, List<BasketValueDto?>? coupons,
            List<BasketValueDto?>? warrantyCostOptions, List<BasketValueDto?>? shippingCostOptions, bool isLoading)
        {
            PricesInfo = pricesInfo;
            Coupons = coupons;
            WarrantyCostOptions = warrantyCostOptions;
            ShippingCostOptions = shippingCostOptions;
            IsLoading = isLoading;
        }
    }
}
