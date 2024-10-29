using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class LogsBasketActions : BasketActionsBase
{
    public Field<string?>? OrderDiary { get; set; }
    public Field<string?>? EdiMessages { get; set; }
}