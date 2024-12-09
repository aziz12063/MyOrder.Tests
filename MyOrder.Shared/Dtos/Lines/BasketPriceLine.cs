namespace MyOrder.Shared.Dtos.Lines;

public class BasketPriceLine
{
    public bool? IsCurrent { get; set; }
    public int? Quantity { get; set; }
    public decimal? CatalogPrice { get; set; }
    public decimal? DiscountPrice { get; set; }
    public decimal? MultiplePrice { get; set; }
    public int? DiscountRate { get; set; }
    public int? MarginRate { get; set; }
}