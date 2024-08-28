using MyOrder.Shared.Dtos.SharedComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.Lines
{
    public class BasketLineDto // the comments in this dto are mines
    {

        public Field<int?>? LineNum { get; set; } // RW
        public bool? IsCustomLineNum { get; set; }
        public List<BasketValueDto?>? LineTags { get; set; }
        public Field<string?>? ItemId { get; set; }// RW
        public Field<string?>? Name { get; set; } // RW
        public Field<string?>? InventLocationId { get; set; }  // RW
        public Field<int?>? SalesQuantity { get; set; }  //RW
        public Field<decimal?>? SalesPrice { get; set; }  //RW
        public Field<string?>? DiscountType { get; set; }  //RW
        public Field<decimal?>? LineAmount { get; set; }  //RW

        // =============================================================================================================
        // Article detail
        // =============================================================================================================

        public Field<string?>? UpdateReason { get; set; }  //RW
        public Field<int?>? InitialSalesQuantity { get; set; }  //RW
        public Field<int?>? MultipleQuantity { get; set; }  //NULL
        public Field<decimal?>? VatRate { get; set; }  //RW
        public Field<string?>? Note { get; set; }  //NULL
        public Field<string?>? ProductInfo { get; set; }  //NULL

        // =============================================================================================================
        // Stock quantities
        // =============================================================================================================

        public bool IsCustomLogisticFlow { get; set; }  //
        public Field<string?>? LogisticFlow { get; set; }  //RW
        public Field<int?>? PhysicalAvailableQuantity { get; set; }  //ONLY FOR D
        public Field<int?>? OnOrderQuantity { get; set; }  // ONLY FOR D
        public Field<int?>? PaletteQuantity { get; set; }  //ONLY FOR D
        public Field<int?>? QuantityAtPaletteThreshold { get; set; }  //ONLY FOR D
        public Field<string?>? ItemType { get; set; }  //ONLY FOR D
        public Field<string?>? DeliveryDate { get; set; }  //RW
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
        public Field<string?>? PurchaseId { get; set; }  // CAN BE HIDDEN

        // =============================================================================================================
        // Prices quantities
        // =============================================================================================================

        public Field<string?>? DiscountDescription { get; set; }  //ONLY FOR D
        public Field<decimal?>? DiscountRate { get; set; }  //RO
        public Field<decimal?>? DiscountPrice { get; set; }  //RO
        public List<BasketPriceLine?>? Prices { get; set; }  //NULL
    }

    public class BasketPriceLine
    {
        public int? quantity { get; set; }

        public decimal? catalogPrice { get; set; }

        public decimal? discountPrice { get; set; }

        public decimal? multiplePrice { get; set; }

        public int? discountRate { get; set; }

    }
}
