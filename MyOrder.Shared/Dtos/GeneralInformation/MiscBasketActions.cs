using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class MiscBasketActions
{
    public Field<string?>? ConfirmOrder { get; set; }

    public Field<string?>? BlockingReasons { get; set; }

    public Field<string?>? Note { get; set; }

    public Field<string?>? OrderHistory { get; set; }
}