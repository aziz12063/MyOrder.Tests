using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class DeliveryInformationDto
    {
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
        public DateTime FirstDeliveryDate { get; set; }
        public DateTime LastDeliveryDate { get; set; }
        public string MyDeliveryAddressId { get; set; }
        public string MyDeliveryContactId { get; set; }
        public string MyDeliveryFeeMode { get; set; }
        public DateTime ReceiptDateRequested { get; set; }
    }

}
