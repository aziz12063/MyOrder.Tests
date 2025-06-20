namespace MyOrder.Shared.Dtos.Lines;

public record BasketPriceLinesDto(
    List<BasketPriceLine?>? PriceLines,
    bool? QuantityVisible,
    bool? CatalogPriceVisible,
    bool? DiscountRateVisible,
    bool? MultiplePriceVisible,
    bool? MarginRateVisible);