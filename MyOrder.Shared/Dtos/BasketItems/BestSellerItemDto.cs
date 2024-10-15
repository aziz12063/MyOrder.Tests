namespace MyOrder.Shared.Dtos.BasketItems;

public record BestSellerItemDto(string? ItemId, string? SiteUrl, string? CatalogUrl,
    string? Description, string? Category1, string? Category2, string? Category3,
    int? MultipleQuantity, string? Status, bool? IsBlocked, int? Quantity, decimal? Turnover) 
    : BasketItemDto(ItemId, SiteUrl, CatalogUrl, Description, Category1, Category2,
        Category3, MultipleQuantity, Status, IsBlocked);