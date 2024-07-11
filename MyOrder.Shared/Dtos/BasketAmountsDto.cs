using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketAmountsDto
    {
        public string AdditionalSales { get; set; }
        public string AmountWithoutVat { get; set; }
        public string? Availability { get; set; }
        public string DeliveryAmount { get; set; }
        public string? DeliveryMarkupCode { get; set; }
        public string? DiffFranco { get; set; }
        public string? DiffKdo { get; set; }
        public string DiscountAmount { get; set; }
        public string? GiftDescription { get; set; }
        public string? GiftInfo { get; set; }
        public string? InventLocationIds { get; set; }
        public bool IsBasketEmpty { get; set; }
        public bool IsWarrantyAvailable { get; set; }
        public string? MarketingGiftItemId { get; set; }
        public string OnOrderAmount { get; set; }
        public string? PackageInsertItemId { get; set; }
        public string PhysicalAvailableAmount { get; set; }
        public string ProductsNetAmount { get; set; }
        public string ProductsVatAmount { get; set; }
        public string? ReceptionDate { get; set; }
        public string TotalPurchasePrice { get; set; }
        public string TotalVolume { get; set; }
        public string TotalWeight { get; set; }
        public string VatAmount { get; set; }
        public List<VatRate> VatRates { get; set; } = new();
        public string WarrantyAmount { get; set; }
        public string? WarrantyMarkupCode { get; set; }
        public string? WelcomePackItemId { get; set; }
    }


    public class VatRate
    {
        public int Key { get; set; }
        public double Value { get; set; }
    }
}
