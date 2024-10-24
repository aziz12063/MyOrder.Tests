using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class CancelBasketActions
{
    public Field<string?>? CancelBasket { get; set; }
    public Field<string?>? CancelOrder { get; set; }
    public Field<string?>? CancelOrderButKeepPayment { get; set; }
}