using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.Lines
{
    public class BasketOrderLinesDto
    {
        public List<BasketLineDto?>? lines { get; set; }
    }
}
