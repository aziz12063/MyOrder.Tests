using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class OrderInformationDto
    {
        public DateTime OrderDate { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public string PurchOrderFormNum { get; set; } = string.Empty;
        public string QuotationCategory { get; set; } = string.Empty;
        public string QuotationId { get; set; } = string.Empty;
        public int QuotationStatus { get; set; }
        public string SalesId { get; set; }
        public string SalesIdRef { get; set; }
        public string SalesName { get; set; }
        public string SalesOriginId { get; set; }
        public string SalesPoolId { get; set; }
        public string SalesResponsible { get; set; }
        public int SalesStatus { get; set; }
        public string TemplateSalesId { get; set; }
        public string CampaignId { get; set; }
        public string CustAccount { get; set; }
        public string CustPurchaseOrder { get; set; }
        public string OriginOrderId { get; set; }
        public int OriginOrderType { get; set; }
        public string OrderNote { get; set; }
        public double OrderVolume { get; set; }
        public double OrderWeight { get; set; }
        public string SmmCampaignId { get; set; }
        public DateTime QuotationExpiryDate { get; set; }
        public string QuotationName { get; set; }
    }

}
