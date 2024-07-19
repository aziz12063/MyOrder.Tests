using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class SalesOriginsDto
    {
        public List<SaleOrigin> SalesOrigins { get; set; } = [];
    }

    public class SaleOrigin
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}

