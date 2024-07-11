using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.BKP
{
    public class MetadataDto
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; }
        public string DataAreaId { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDateTime { get; set; }
        public long RecId { get; set; }
        public int RecVersion { get; set; }
        public DateTime AxSynchroDateTime { get; set; }
        public DateTime AxUpdateStartTime { get; set; }
        public DateTime AxUpdateEndTime { get; set; }
        public int AxUpdateProgress { get; set; }
        public DateTime AxModifiedDateTime { get; set; }
    }

}