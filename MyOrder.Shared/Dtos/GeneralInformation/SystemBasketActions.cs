using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record SystemBasketActions(
    Field<string?>? Profile,
    Field<string?>? Settings,
    string? MenuLabel
    ) : BasketActionsBase(MenuLabel);