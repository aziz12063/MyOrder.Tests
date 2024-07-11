using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class FinancialInformationDto
    {
        public decimal TotalAmount { get; set; }
        public string PaymMode { get; set; }
        public string Payment { get; set; }
        public string PaymentTerm { get; set; }
        public decimal WarrantyAmount { get; set; }
        public string WarrantyMarkupCode { get; set; }
        public int WarrantyMode { get; set; }
        public decimal WarrantyVoucherAmount { get; set; }
        public decimal WebAuthorizeNetTransAmount { get; set; }
        public string WebAuthorizeNetTransId { get; set; }
        public int WebCreditCardType { get; set; }
        public decimal? WebDeliveryAmount { get; set; }
        public string WebPaymMode { get; set; }
        public string WebQuotationId { get; set; }
        public decimal? WebTotalGrossAmount { get; set; }
        public decimal? WebWarrantyAmount { get; set; }
    }

}
