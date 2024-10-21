using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class NewBasketAction
{
    public Field<string?>? Account { get; set; }
    public Field<string?>? Contact { get; set; }
}
