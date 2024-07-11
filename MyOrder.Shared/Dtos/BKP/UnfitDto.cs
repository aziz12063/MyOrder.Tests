using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class UnfitDto
    {
        public int? MyOrderApiId { get; set; }
        public int MyOrderApiType { get; set; }
        public string OldCreatedBy { get; set; }
        public DateTime? OldCreatedDateTime { get; set; }

        public string RAJ_FsRequestId { get; set; }
        public string RAJ_OrigSalesId { get; set; }
        public string RAJ_WebOriginId { get; set; }
        public int? RebillVoucherId { get; set; }
        public int? ReturnSalesId { get; set; }

        public int SavType { get; set; }

        public string SponsorAccountCellularPhone { get; set; }
        public string SponsorBuilding { get; set; }
        public string SponsorCalcMethodId { get; set; }
        public string SponsorCellularPhone { get; set; }
        public string SponsorContractGroupId { get; set; }
        public bool SponsorDontPrintByProvider { get; set; }
        public string SponsorDontPrintReason { get; set; }
        public string SponsorInvoiceEmail { get; set; }
        public string SponsorInvoiceNote { get; set; }
        public int SponsorInvoiceShipMode { get; set; }
        public DateTime? SponsorLastOrderDate { get; set; }
        public string SponsorLocality { get; set; }
        public bool SponsorNoGift { get; set; }
        public string SponsorTaxGroup { get; set; }
        public string TaxGroup { get; set; }
    }
}
