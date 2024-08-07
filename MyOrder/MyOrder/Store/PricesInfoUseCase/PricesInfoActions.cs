using MyOrder.Components.Childs.Header;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.PricesInfoUseCase
{
    public class FetchPricesInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }


    public class FetchPricesInfoSuccessAction(BasketPricesInfoDto? pricesInfo, List<BasketValueDto?>? coupons,
        List<BasketValueDto?>? warrantyCostOptions, List<BasketValueDto?>? shippingCostOptions)
    {
        public BasketPricesInfoDto? PricesInfo { get; } = pricesInfo;
        public List<BasketValueDto?>? Coupons { get; } = coupons;
        public List<BasketValueDto?>? WarrantyCostOptions { get; } = warrantyCostOptions;
        public List<BasketValueDto?>? ShippingCostOptions { get; } = shippingCostOptions;

    }

    public class FetchPricesInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }

    // to delete
    public class NoDataLoadedAction
    {

        public BasketPricesInfoDto? PricesInfo = new()
        {
            // Column 1
            Coupon = new Field<string?> { Value = null },
            //Coupon = new Field<string?> { Value = "DISCOUNT10" },
            FreeShippingAmountThreshold = new Field<decimal?> { Value = 50.00m },
            GiftAmountThreshold = new Field<decimal?> { Value = 100.00m },
            ProductsInfo = new Field<string?> { Value = "Product A, Product B" },

            // Column 2
            ProductsNetAmount = new Field<decimal?> { Value = 150.00m },
            WarrantyCostOption = new Field<string?> { Value = "Standard" },
            WarrantyCostAmount = new Field<decimal?> { Value = 20.00m },
            ShippingCostOption = new Field<string?> { Value = "Express" },
            ShippingCostAmount = new Field<decimal?> { Value = 10.00m },
            LogisticInfo = new Field<string?> { Value = "Warehouse 1" },

            // Column 3
            TotalNetAmount = new Field<decimal?> { Value = 180.00m },
            VatAmount = new Field<decimal?> { Value = 36.00m },
            TotalGrossAmount = new Field<decimal?> { Value = 216.00m },
            FirstDeliveryDate = new Field<string?> { Value = "2024-08-01" },
            LastDeliveryDate = new Field<string?> { Value = "2024-08-05" },

            // Column 4
            OrderDiscountRate = new Field<int?> { Value = 10 },
            OrderLastColumnDiscount = new Field<bool?> { Value = true },
            DiscountAmount = new Field<decimal?> { Value = 18.00m },
            AdditionalSalesAmount = new Field<decimal?> { Value = 5.00m },
            TotalWeight = new Field<decimal?> { Value = 15.00m },
            TotalVolume = new Field<decimal?> { Value = 0.50m }
        };

        public List<BasketValueDto?>? Coupons = null;

        //public List<BasketValueDto?>? Coupons = new List<BasketValueDto?>
        //{
        //    new BasketValueDto { Description = "10% Off", Value = "10PERCENT" },
        //    new BasketValueDto { Description = "Free Shipping", Value = "FREESHIP" },
        //    new BasketValueDto { Description = "Black Friday Deal", Value = "BLACKFRIDAY" }
        //};

        public List<BasketValueDto?>? WarrantyCostOptions = new List<BasketValueDto?>
        {
            new BasketValueDto { Description = "Standard Warranty", Value = "STANDARD" },
            new BasketValueDto { Description = "Extended Warranty", Value = "EXTENDED" }
        };
        public List<BasketValueDto?>? ShippingCostOptions = new List<BasketValueDto?>
        {
            new BasketValueDto { Description = "Standard Shipping", Value = "STANDARD" },
            null,
            new BasketValueDto { Description = "Express Shipping", Value = "EXPRESS" }
            
        };
    }
}
