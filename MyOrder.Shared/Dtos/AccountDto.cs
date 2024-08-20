using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos;

public class AccountDto
{
    public string? AccountId { get; set; }
    public string? Name { get; set; }
    public string? Recipient { get; set; }
    public string? Building { get; set; }
    public string? Street { get; set; }
    public string? Locality { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CellularPhone { get; set; }
    public bool? Blocked { get; set; }

    public override string ToString() => $"{AccountId} - {Name} - {ZipCode}";
}

