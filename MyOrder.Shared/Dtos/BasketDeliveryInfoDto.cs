using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos;
public class BasketDeliveryInfoDto
{
    public Field<AccountDto>? Account { get; set; } = new() { Value = new AccountDto() };
    public Field<ContactDto>? Contact { get; set; } = new() { Value = new ContactDto() };
    public Field<string>? DeliveryMode { get; set; } = new();
    public Field<bool?>? CompleteDelivery { get; set; } = new();
    public Field<string?>? ImperativeDate { get; set; } = new();
    public Field<List<string?>?>? OrderDocuments { get; set; } = new() { Value = [] };
    public Field<string?>? Note { get; set; } = new();
    public Field<bool?>? NoteMustBeSaved { get; set; } = new();
}