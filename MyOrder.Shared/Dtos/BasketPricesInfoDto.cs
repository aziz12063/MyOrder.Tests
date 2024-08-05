using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos;
    public class BasketPricesInfoDto
{
    // Column 1
    public Field<string> Coupon { get; set; } = new() { Value = string.Empty };
    public Field<decimal?> FreeShippingAmountThreshold { get; set; } = new() { Value = null };
    public Field<decimal?> GiftAmountThreshold { get; set; } = new() { Value = null };
    public Field<string> ProductsInfo { get; set; } = new() { Value = string.Empty };

    // Column 2
    public Field<decimal> ProductsNetAmount { get; set; } = new() { Value = 0 };
    public Field<string> WarrantyCostOption { get; set; } = new() { Value = string.Empty };
    public Field<decimal> WarrantyCostAmount { get; set; }  = new() { Value = 0 };
    public Field<string> ShippingCostOption { get; set; } = new() { Value = string.Empty };
    public Field<decimal> ShippingCostAmount { get; set; } = new() { Value = 0 };
    public Field<string> LogisticInfo { get; set; } = new() { Value = string.Empty };

    // Column 3
    public Field<decimal> TotalNetAmount { get; set; } = new() { Value = 0 };
    public Field<decimal> VatAmount { get; set; }= new() { Value = 0 };
    public Field<decimal> TotalGrossAmount { get; set; } = new() { Value = 0 };
    public Field<string> FirstDeliveryDate { get; set; } = new() { Value = string.Empty };
    public Field<string?> LastDeliveryDate { get; set; } = new() { Value = null };

    // Column 4
    public Field<int> OrderDiscountRate { get; set; } = new() { Value = 0 };
    public Field<bool> OrderLastColumnDiscount { get; set; } = new() { Value = false };
    public Field<decimal> DiscountAmount { get; set; } = new() { Value = 0 };
    public Field<decimal> AdditionalSalesAmount { get; set; } = new() { Value = 0 };
    public Field<decimal> TotalWeight { get; set; } = new() { Value = 0 };
    public Field<decimal> TotalVolume { get; set; } = new() { Value = 0 };
}