using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class CustomerAndSponsorInformationDto
    {
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
    }

}
