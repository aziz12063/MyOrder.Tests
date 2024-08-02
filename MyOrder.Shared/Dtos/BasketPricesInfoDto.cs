using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketPricesInfoDto
    {
        // Column 1
        public Field<string> Coupon { get; set; } = new Field<string> {Value = "coupon" };
        public Field<decimal> FreeShippingAmountThreshold { get; set; } = new Field<decimal> { Value = 1 };
        public Field<decimal> GiftAmountThreshold { get; set; } = new Field<decimal> { Value = 1 };
        public Field<string> ProductsInfo { get; set; } = new Field<string> { Value = "ProdInfo" };

        // Column 2
        public Field<decimal> ProductsNetAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<string> WarrantyCostOption { get; set; } = new Field<string> { Value = "WarCosOption" };
        public Field<decimal> WarrantyCostAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<string> ShippingCostOption { get; set; } = new Field<string> { Value = "ShipCoOption" };
        public Field<decimal> ShippingCostAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<string> LogisticInfo { get; set; } = new Field<string> { Value = "LogiInfo" };

        // Column 3
        public Field<decimal> TotalNetAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<decimal> VatAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<decimal> TotalGrossAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<string> FirstDeliveryDate { get; set; } = new Field<string> { Value = "FirstDelDate" };
        public Field<string?> FastDeliveryDate { get; set; } = new Field<string> { Value = "FastDelDate" };

        // Column 4
        public Field<int> OrderDiscountRate { get; set; } = new Field<int> { Value = 1 };
        public Field<bool> OrderLastColumnDiscount { get; set; } = new Field<bool> { Value = true };
        public Field<decimal> DdiscountAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<decimal> AdditionalSalesAmount { get; set; } = new Field<decimal> { Value = 1 };
        public Field<decimal> TotalWeight { get; set; } = new Field<decimal> { Value = 1 };
        public Field<decimal> TotalVolume { get; set; } = new Field<decimal> { Value = 1 };
    }
}