using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos;

public class BasketBlockingReasonDto
{
    public string ReasonId { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string Comment { get; set; }
    public bool UserActive { get; set; }
}
