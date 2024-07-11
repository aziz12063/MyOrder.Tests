using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class StatusAndFlagsDto
    {
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
    }

}
