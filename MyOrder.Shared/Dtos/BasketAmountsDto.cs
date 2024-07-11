using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketAmountsDto
    {
        public int AdditionalSales { get; set; }
        public double AmountWithoutVat { get; set; }
        public string? Availability { get; set; }
        public double DeliveryAmount { get; set; }
        public string? DeliveryMarkupCode { get; set; }
        public string? DiffFranco { get; set; }
        public string? DiffKdo { get; set; }
        public double DiscountAmount { get; set; }
        public string? GiftDescription { get; set; }
        public string? GiftInfo { get; set; }
        public string? InventLocationIds { get; set; }
        public bool IsBasketEmpty { get; set; }
        public bool IsWarrantyAvailable { get; set; }
        public string? MarketingGiftItemId { get; set; }
        public double OnOrderAmount { get; set; }
        public string? PackageInsertItemId { get; set; }
        public double PhysicalAvailableAmount { get; set; }
        public double ProductsNetAmount { get; set; }
        public double ProductsVatAmount { get; set; }
        public string? ReceptionDate { get; set; }
        public double TotalPurchasePrice { get; set; }
        public double TotalVolume { get; set; }
        public double TotalWeight { get; set; }
        public double VatAmount { get; set; }
        public List<VatRate> VatRates { get; set; } = new();
        public double WarrantyAmount { get; set; }
        public string? WarrantyMarkupCode { get; set; }
        public string? WelcomePackItemId { get; set; }
    }


    public class VatRate
    {
        public int Key { get; set; }
        public double Value { get; set; }
    }
}
