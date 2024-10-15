namespace MyOrder.Shared.Dtos.BasketItems;

public record OrderedItemsDto(string? ItemId, string? SiteUrl, string? CatalogUrl,
    string? Description, string? Category1, string? Category2, string? Category3,
    int? MultipleQuantity, string? Status, bool? IsBlocked, string? OrderType,
    DateTime? OrderDate, string? OrderId, string? CustomerOrderId, decimal? Price,
    string? Discount, int? Quantity, decimal? Turnover) 
    : BasketItemDto(ItemId, SiteUrl, CatalogUrl, Description, Category1, Category2,
        Category3, MultipleQuantity, Status, IsBlocked);
