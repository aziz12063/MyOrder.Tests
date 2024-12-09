using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Lines;

public class BasketLineDto
{
    public long RecId { get; set; }
    public Field<int?>? LineNum { get; set; } // RW
    public bool? IsCustomLineNum { get; set; }
    public List<BasketValueDto?>? LineTags { get; set; }
    public Field<string?>? ItemId { get; set; }// RW
    public Field<string?>? ItemProperties { get; set; }
    public Field<string?>? Name { get; set; } // RW
    public Field<string?>? InventLocationId { get; set; }  // RW
    public Field<int?>? SalesQuantity { get; set; }  //RW
    public Field<decimal?>? SalesPrice { get; set; }  //RW
    public List<BasketValueDto?>? DiscountTypes { get; set; }
    public Field<BasketValueDto?>? DiscountType { get; set; }  //RW
    public Field<decimal?>? LineAmount { get; set; }  //RW
    public Field<bool?>? IsUpselling { get; set; }

    // =============================================================================================================
    // Article detail
    // =============================================================================================================

    public Field<BasketValueDto?>? UpdateReason { get; set; }  //RW
    public Field<int?>? InitialSalesQuantity { get; set; }  //RW
    public Field<int?>? MultipleQuantity { get; set; }  //NULL
    public Field<decimal?>? VatRate { get; set; }  //RW
    public Field<string?>? Note { get; set; }  //NULL
    public Field<string?>? ProductInfo { get; set; }  //NULL

    // =============================================================================================================
    // Stock quantities
    // =============================================================================================================

    public bool IsCustomLogisticFlow { get; set; }  //
    public Field<BasketValueDto?>? LogisticFlow { get; set; }  //RW
    public Field<int?>? PhysicalAvailableQuantity { get; set; }  //ONLY FOR D
    public Field<int?>? OnOrderQuantity { get; set; }  // ONLY FOR D
    public Field<int?>? PaletteQuantity { get; set; }  //ONLY FOR D
    public Field<int?>? QuantityAtPaletteThreshold { get; set; }  //ONLY FOR D
    public Field<string?>? ItemType { get; set; }  //ONLY FOR D
    public Field<DateTime?>? DeliveryDate { get; set; }  //RW
    public Field<bool?>? IsCustomDeliveryDate { get; set; }  //RW
    public Field<int?>? ItemPhysicalInventQuantity { get; set; }  //ONLY FOR D
    public Field<int?>? ItemReservPhysicalQuantity { get; set; }  //ONLY FOR D
    public Field<int?>? ItemPhysicalAvailableQuantity { get; set; } // ONLY FOR D
    public Field<int?>? ItemOnOrderQuantity { get; set; }  //ONLY FOR D
    public Field<int?>? ItemOrderedQuantity { get; set; }  //ONLY FOR D
    public Field<int?>? ItemOrderedAvailableQuantity { get; set; }  //ONLY FOR D
    public Field<string?>? SupplyFamily { get; set; }  //ONLY FOR D
    public Field<string?>? ItemManager { get; set; }  //ONLY FOR D
    public Field<string?>? TransportMode { get; set; }  //ONLY FOR D
    public Field<string?>? PurchaseId { get; set; }  // COULD BE HIDDEN

    // =============================================================================================================
    // PriceLines quantities
    // =============================================================================================================

    public Field<string?>? DiscountDescription { get; set; }  //ONLY FOR D
    public Field<decimal?>? DiscountRate { get; set; }  //RO
    public Field<decimal?>? DiscountPrice { get; set; }  //RO
    public BasketPriceLinesDto? Prices { get; set; }  //NULL

    // =============================================================================================================
    // Overrides
    // =============================================================================================================

    public override bool Equals(object? obj)
    {
        if (obj is not BasketLineDto item) return false;
        return item.RecId == RecId;
    }

    public override int GetHashCode() => RecId.GetHashCode();
}