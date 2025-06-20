using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;
public record BasketPricesInfoDto(
    string? PanelLabel,

    // Column 1
    Field<BasketValueDto?>? Coupon,

    [property: DisplayOnlyField]
    Field<decimal?>? FreeShippingAmountThreshold,

    [property: DisplayOnlyField]
    Field<decimal?>? GiftAmountThreshold,

    [property: DisplayOnlyField]
    Field<string?>? ProductsInfo,

    // Column 2
    [property: DisplayOnlyField]
    Field<decimal?>? ProductsNetAmount,

    Field<BasketValueDto?>? WarrantyCostOption,
    Field<decimal?>? WarrantyCostAmount,
    Field<BasketValueDto?>? ShippingCostOption,
    Field<decimal?>? ShippingCostAmount,

    [property: DisplayOnlyField]
    Field<string?>? LogisticInfo,

    // Column 3
    [property: DisplayOnlyField]
    Field<decimal?>? TotalNetAmount,

    [property: DisplayOnlyField]
    Field<decimal?>? VatAmount,

    [property: DisplayOnlyField]
    Field<decimal?>? TotalGrossAmount,

    [property: DisplayOnlyField]
    Field<string?>? DeliveryDates,

        // Column 4
    [property: DisplayOnlyField]
    Field<int?>? OrderDiscountRate,

    [property: DisplayOnlyField]
    Field<bool?>? OrderLastColumnDiscount,

    [property: DisplayOnlyField]
    Field<decimal?>? DiscountAmount,

    [property: DisplayOnlyField]
    Field<decimal?>? AdditionalSalesAmount,

    [property: DisplayOnlyField]
    Field<decimal?>? TotalWeight,

    [property: DisplayOnlyField]
    Field<decimal?>? TotalVolume);