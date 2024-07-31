using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketDeliveryInfoDto
    {
        public Field<AccountDto>? Account { get; set; }
        public Field<ContactDto>? Contact { get; set; }
        public Field<string>? DeliveryMode { get; set; }
        public Field<bool?>? CompleteDelivery { get; set; }
        public Field<string?>? ImperativeDate { get; set; }
        public Field<List<string?>?>? OrderDocuments { get; set; }
        public Field<string?>? Note { get; set; }
        public Field<bool?>? NoteMustBeSaved { get; set; }
    }
}
