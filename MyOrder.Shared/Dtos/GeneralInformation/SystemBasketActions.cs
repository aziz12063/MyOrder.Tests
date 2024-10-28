using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class SystemBasketActions : BasketActionsBase
{
    public Field<string?>? Profile { get; set; }
    public Field<string?>? Settings { get; set; }
}