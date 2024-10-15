namespace MyOrder.Shared.Dtos.BasketItems;

public record BasketItemDto(string? ItemId, string? SiteUrl, string? CatalogUrl,
    string? Description, string? Category1, string? Category2, string? Category3,
    int? MultipleQuantity, string? Status, bool? IsBlocked);
