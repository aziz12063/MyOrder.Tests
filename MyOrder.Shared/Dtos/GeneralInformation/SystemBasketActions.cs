using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class SystemBasketActions
{
    public Field<string?>? Admin { get; set; }

    public Field<List<BasketHistory?>?>? BasketHistory { get; set; }
}