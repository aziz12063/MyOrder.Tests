using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase
{
    public class FetchPricesInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchPricesInfoSuccessAction(BasketPricesInfoDto pricesInfo, List<BasketValueDto> coupons,
        List<BasketValueDto> warrantyCostOptions, List<BasketValueDto> shippingCostOptions)
    {
        public BasketPricesInfoDto PricesInfo { get; } = pricesInfo;
        public List<BasketValueDto> Coupons { get; } = coupons;
        public List<BasketValueDto> WarrantyCostOptions { get; } = warrantyCostOptions;
        public List<BasketValueDto> ShippingCostOptions { get; } = shippingCostOptions;
    }

    public class FetchPricesInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
