namespace MyOrder.Shared.Dtos.Lines;

public class BasketPriceLinesDto
{
    public List<BasketPriceLine?>? PriceLines { get; set; }

    public bool? QuantityVisible { get; set; }
    public bool? CatalogPriceVisible { get; set; }
    public bool? DiscountRateVisible { get; set; }
    public bool? MultiplePriceVisible { get; set; }
    public bool? MarginRateVisible { get; set; }
}
