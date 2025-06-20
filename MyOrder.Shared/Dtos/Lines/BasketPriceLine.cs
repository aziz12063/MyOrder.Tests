namespace MyOrder.Shared.Dtos.Lines;

public record BasketPriceLine(
    bool? IsCurrent,
    int? Quantity,
    decimal? CatalogPrice,
    decimal? DiscountPrice,
    decimal? MultiplePrice,
    int? DiscountRate,
    int? MarginRate);