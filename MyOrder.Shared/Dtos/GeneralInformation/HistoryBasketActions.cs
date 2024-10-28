using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class HistoryBasketActions
{
    public Field<List<BasketHistory?>?>? LastOpenedBaskets { get; set; }
    public Field<string?>? BasketHistory { get; set; }
}