using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class OpenBasketActions : BasketActionsBase
{
    public Field<NewBasketAction?>? NewBasket { get; set; }
    public Field<string?>? OpenBasket { get; set; }
    public Field<string?>? CloneBasket { get; set; }
}
