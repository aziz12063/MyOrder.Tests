using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class CancelBasketActions : BasketActionsBase
{
    public Field<string?>? CancelBasket { get; set; }
    public Field<string?>? CancelOrderAndPayment { get; set; }
    public Field<string?>? CancelOrder { get; set; }
}