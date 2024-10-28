using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class BlockingBasketActions : BasketActionsBase
{
    public Field<string?>? ValidationRules { get; set; }
    public Field<string?>? BlockingReasons { get; set; }
}