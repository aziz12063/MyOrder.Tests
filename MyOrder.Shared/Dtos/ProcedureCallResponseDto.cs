using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos;

    public class ProcedureCallResponseDto : MyOrderContextResponse
    {
        public bool? UpdateDone { get; set; }
        public List<string>? RefreshCalls { get; set; }
}

