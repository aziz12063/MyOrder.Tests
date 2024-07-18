using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketGeneralInfoDto
    {
        public string? OrderType { get; set; }
        public string? BasketId { get; set; }
        public string? OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderDate { get; set; }
        public string? SalesResponsible { get; set; }
    }
}
