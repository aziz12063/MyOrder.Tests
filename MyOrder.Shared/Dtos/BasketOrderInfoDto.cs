using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketOrderInfoDto
    {
        public AccountDto Account { get; set; } = new();
        public ContactDto Contact { get; set; } = new();
        public string? NafCode { get; set; }
        public string? ActivityArea { get; set; }
        public List<string> Tags { get; set; } = [];
        public string? SalesOriginId { get; set; }
        public string? WebOriginId { get; set; }
        public string? SalesPoolId { get; set; }
        public string? PurchOrderFormNum { get; set; }
        public string? Note { get; set; }
    }

    public class AccountDto
    {
        public string? AccountNum { get; set; }
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
        public bool Blocked { get; set; }
    }

    public class ContactDto
    {
        public string? ContactId { get; set; }
        public string? SocialTitle { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CellularPhone { get; set; }
    }
}
