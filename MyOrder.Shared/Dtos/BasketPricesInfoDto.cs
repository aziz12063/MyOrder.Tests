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
        public Field<string> Coupon { get; set; }
        public Field<decimal?> FreeShippingAmountThreshold { get; set; }
        public Field<decimal?> GiftAmountThreshold { get; set; }
        public Field<string> ProductsInfo { get; set; }

        // Column 2
        public Field<decimal> ProductsNetAmount { get; set; }
        public Field<string> WarrantyCostOption { get; set; }
        public Field<decimal> WarrantyCostAmount { get; set; }
        public Field<string> ShippingCostOption { get; set; }
        public Field<decimal> ShippingCostAmount { get; set; }
        public Field<string> LogisticInfo { get; set; }

        // Column 3
        public Field<decimal> TotalNetAmount { get; set; }
        public Field<decimal> VatAmount { get; set; }
        public Field<decimal> TotalGrossAmount { get; set; }
        public Field<string> FirstDeliveryDate { get; set; }
        public Field<string?> FastDeliveryDate { get; set; }

        // Column 4
        public Field<int> OrderDiscountRate { get; set; }
        public Field<bool> OrderLastColumnDiscount { get; set; }
        public Field<decimal> DdiscountAmount { get; set; }
        public Field<decimal> AdditionalSalesAmount { get; set; }
        public Field<decimal> TotalWeight { get; set; }
        public Field<decimal> TotalVolume { get; set; }
    }
}