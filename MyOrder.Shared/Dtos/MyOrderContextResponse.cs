using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos;

public abstract class MyOrderContextResponse
{
    public bool? Success { get; set; }
    public string? Message { get; set; }
    public string? ErrorCause { get; set; }
}

