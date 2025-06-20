using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record HistoryBasketActions(
    Field<List<BasketHistory?>?>? LastOpenedBaskets,
    Field<string?>? BasketHistory,
    string? MenuLabel) : BasketActionsBase(MenuLabel);