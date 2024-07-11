using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class CaseAndProcessInformationDto
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
    }

}
