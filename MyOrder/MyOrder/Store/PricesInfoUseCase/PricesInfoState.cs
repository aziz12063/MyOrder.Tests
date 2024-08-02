using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase
{
    [FeatureState]
    public class PricesInfoState
    {
        public BasketPricesInfoDto PricesInfo { get; } = new();
        public List<BasketValueDto> Coupons { get; } = new();
        public List<BasketValueDto> WarrantyCostOptions { get; } = new();
        public List<BasketValueDto> ShippingCostOptions { get; } = new();
        public bool IsLoading { get; } = true;

        public PricesInfoState() { }

        public PricesInfoState(BasketPricesInfoDto pricesInfo, List<BasketValueDto> coupons,
            List<BasketValueDto> warrantyCostOptions, List<BasketValueDto> shippingCostOptions)
        {
            PricesInfo = pricesInfo;
            Coupons = coupons;
            WarrantyCostOptions = warrantyCostOptions;
            ShippingCostOptions = shippingCostOptions;
            IsLoading = false;
        }
    }
}
