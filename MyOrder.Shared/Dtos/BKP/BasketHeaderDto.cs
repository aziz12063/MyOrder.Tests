using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class BasketHeaderDto
    {
        public string BlockingReasonIds { get; set; }
        public string CaseContactEmail { get; set; }
        public string CaseContactId { get; set; }
        public string CaseDescription { get; set; }
        public string CaseId { get; set; }
        public string CasePriority { get; set; }
        public string CaseReason { get; set; }
        public string CaseStatus { get; set; }
        public int DelayedSubmitRetryCount { get; set; }
        public string InitBlockingReasonIds { get; set; }
        public string InternetBlockingReasonDetails { get; set; }
        public string InternetBlockingReasonIds { get; set; }
        public string InventLocationId { get; set; }
        public string MomDeliveryBuilding { get; set; }
        public string MomDeliveryLocality { get; set; }
        public string MomDeliveryRecipient { get; set; }

        public string ContactPersonId { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddressCC { get; set; }
        public string InvoiceId { get; set; }
        public long InvoiceRecId { get; set; }
        public string InvoiceAccount { get; set; }
        public string InvoiceEmail { get; set; }
        public string InvoiceNote { get; set; }
        public int InvoiceShipMode { get; set; }
        public string SponsorName { get; set; }
        public string SponsorAccountEmail { get; set; }
        public string SponsorAccountFaxNumber { get; set; }
        public string SponsorAccountPhone { get; set; }
        public string SponsorCompanyIdSiret { get; set; }
        public string SponsorCompanyIdNaf { get; set; }
        public string SponsorCountry { get; set; }
        public string SponsorCountryRegionId { get; set; }
        public string SponsorCounty { get; set; }
        public string SponsorCity { get; set; }
        public string SponsorStreet { get; set; }
        public string SponsorZipCode { get; set; }
        public int SponsorWarranty { get; set; }
        public bool SponsorIsVIP { get; set; }
        public bool SponsorIsExport { get; set; }
        public bool SponsorIsIndividual { get; set; }
        public bool SponsorIsInternal { get; set; }
        public string SponsorLastName { get; set; }
        public string SponsorFirstName { get; set; }
        public string SponsorPhone { get; set; }
        public string SponsorEmail { get; set; }
        public string SponsorFaxNumber { get; set; }
        public int SponsorOrderValueType { get; set; }
        public string SponsorPaymMode { get; set; }
        public string SponsorPaymTermId { get; set; }
        public string SponsorCustInventLocation { get; set; }
        public string SponsorDeliveryNote { get; set; }
        public string SponsorDlvTerm { get; set; }
        public string SponsorBusRelNote { get; set; }
        public int SponsorBlocked { get; set; }
        public int SponsorCompleteDelivery { get; set; }
        public int SponsorPrepaSpe { get; set; }
        public string SponsorPriceGroup { get; set; }
        public int SponsorPublicEntities { get; set; }
        public string SponsorPurchaseCardAccount { get; set; }
        public string SponsorRecipient { get; set; }
        public string SponsorSalesPoolId { get; set; }
        public int SponsorSalesUnderDelivery { get; set; }
        public string SponsorSocialTitle { get; set; }

        public int DeliveryAddressType { get; set; }
        public decimal DeliveryAmount { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountryRegionId { get; set; }
        public string DeliveryCounty { get; set; }
        public int DeliveryFeeMode { get; set; }
        public string DeliveryMarkupCode { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryNote { get; set; }
        public string DeliveryStreet { get; set; }
        public decimal DeliveryVoucherAmount { get; set; }
        public string DeliveryZipCode { get; set; }
        public string DlvMode { get; set; }
        public string FirstDeliveryDate { get; set; }
        public string LastDeliveryDate { get; set; }
        public string MyDeliveryAddressId { get; set; }
        public string MyDeliveryContactId { get; set; }
        public string MyDeliveryFeeMode { get; set; }
        public string ReceiptDateRequested { get; set; }

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

        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDateTime { get; set; }
        public string DataAreaId { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public string ModifiedDateTime { get; set; }
        public long RecId { get; set; }
        public int RecVersion { get; set; }
        public string AxSynchroDateTime { get; set; }
        public string AxUpdateStartTime { get; set; }
        public string AxUpdateEndTime { get; set; }
        public int AxUpdateProgress { get; set; }
        public string AxModifiedDateTime { get; set; }

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
        public string RAJ_FsNeedDate { get; set; }
        public string RAJ_GenericDlvMode { get; set; }
        public string RAJ_ImperativeDate { get; set; }
        public string RAJ_LegalCommitment { get; set; }
        public int RAJ_WebDeliveryDate { get; set; }
        public string RAJ_WebSalesId { get; set; }
        public int RAJ_WebSalesNotes { get; set; }
        public List<object> WmsOrderTransInfos { get; set; }

        public string OrderDate { get; set; }
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
        public string QuotationExpiryDate { get; set; }
        public string QuotationName { get; set; }

        public bool IsApi { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsManualSalesQty { get; set; }
        public bool IsProcessLockable { get; set; }
        public bool IsProcessStarted { get; set; }
        public int MomStatus { get; set; }
        public bool IsInitialized { get; set; }
        public bool IsCompleteDelivery { get; set; }
        public bool IsCompleteDeliveryCorrect { get; set; }
        public bool IsDeliveryDateCorrect { get; set; }
        public bool IsDeliveryNoteSaved { get; set; }
        public bool IsPrepaSpe { get; set; }
        public bool IsSponsorAccountUptodate { get; set; }
        public bool IsSponsorContactUptodate { get; set; }
        public bool IsWarrantyAvailable { get; set; }
        public bool IsBasketSleeping { get; set; }
        public string MomClaimNumber { get; set; }

        public int? MyOrderApiId { get; set; }
        public int MyOrderApiType { get; set; }
        public string OldCreatedBy { get; set; }
        public string? OldCreatedDateTime { get; set; }

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
        public string? SponsorLastOrderDate { get; set; }
        public string SponsorLocality { get; set; }
        public bool SponsorNoGift { get; set; }
        public string SponsorTaxGroup { get; set; }
        public string TaxGroup { get; set; }
    }
}
