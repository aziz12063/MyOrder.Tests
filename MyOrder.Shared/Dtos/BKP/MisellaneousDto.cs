using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class MiscellaneousDto
    {
        public string Eanlog_GlnExternDeliverTo { get; set; }
        public string EskerType { get; set; }
        public string EskerUrl { get; set; }
        public string FaxNumber { get; set; }
        public string FsCustomerLastRequestId { get; set; }
        public decimal FsMarginPercent { get; set; }
        public string FsName { get; set; }
        public string FsVendorsIds { get; set; }
        public decimal MyDiscountPercent { get; set; }
        public bool MyLastColumnDiscount { get; set; }
        public string MyMarketingGiftItemId { get; set; }
        public string MyOrderApiDeliverToAccount { get; set; }
        public string MyPackageInsertItemId { get; set; }
        public int MyPrintSupport { get; set; }
        public string MySponsorAccountId { get; set; }
        public string MySponsorContactId { get; set; }
        public string MyWarrantyMode { get; set; }
        public string MyWelcomePackItemId { get; set; }
        public decimal OrigDeliveryAmount { get; set; }
        public string OrigDeliveryMarkupCode { get; set; }
        public string OrigInvoiceAccount { get; set; }
        public decimal OrigWarrantyAmount { get; set; }
        public string OrigWarrantyMarkupCode { get; set; }
        public string RAJ_CodeFsTime { get; set; }
        public int RAJ_CompleteDelivery { get; set; }
        public int RAJ_CustPrepaSpe { get; set; }
        public string RAJ_DeliveryAddressId { get; set; }
        public string RAJ_DeliveryContact { get; set; }
        public string RAJ_DeliveryContactDirectPhone { get; set; }
        public string RAJ_DeliveryContactEmail { get; set; }
        public string RAJ_DeliveryContactMobilePhone { get; set; }
        public string RAJ_DeliveryContactName { get; set; }
        public string RAJ_ExecutingService { get; set; }
        public string RAJ_FirstInvoice { get; set; }
        public string RAJ_FirstPackingSlip { get; set; }
        public DateTime RAJ_FsNeedDate { get; set; }
        public string RAJ_GenericDlvMode { get; set; }
        public DateTime RAJ_ImperativeDate { get; set; }
        public string RAJ_LegalCommitment { get; set; }
        public int RAJ_WebDeliveryDate { get; set; }
        public string RAJ_WebSalesId { get; set; }
        public int RAJ_WebSalesNotes { get; set; }
        public List<object> WmsOrderTransInfos { get; set; }
    }

}
