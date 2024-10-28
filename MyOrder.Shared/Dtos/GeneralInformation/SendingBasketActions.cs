using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class SendingBasketActions : BasketActionsBase
{
    public Field<string?>? ComfirmOrder { get; set; }
}