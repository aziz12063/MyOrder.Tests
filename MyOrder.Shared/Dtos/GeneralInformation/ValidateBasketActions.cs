using MyOrder.Shared.Dtos.SharedComponents;
using System.Runtime.Serialization;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class ValidateBasketActions
{
    public Field<string?>? LockOrder { get; set; }
    public Field<string?>? Sales { get; set; }
    public Field<string?>? Quotation { get; set; }
    public Field<string?>? PriceConfirm { get; set; }
}