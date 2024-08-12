using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.PricesInfoUseCase
{
    [FeatureState]
    public class PricesInfoState : StateBase
    {
        public BasketPricesInfoDto? PricesInfo { get; }
        public List<BasketValueDto?>? Coupons { get; }
        public List<BasketValueDto?>? WarrantyCostOptions { get; }
        public List<BasketValueDto?>? ShippingCostOptions { get; }

        public PricesInfoState() : base(true) { }

        public PricesInfoState(BasketPricesInfoDto? pricesInfo, List<BasketValueDto?>? coupons,
            List<BasketValueDto?>? warrantyCostOptions, List<BasketValueDto?>? shippingCostOptions) : base(false)
        {
            PricesInfo = pricesInfo;
            Coupons = coupons;
            WarrantyCostOptions = warrantyCostOptions;
            ShippingCostOptions = shippingCostOptions;
        }
    }
}
