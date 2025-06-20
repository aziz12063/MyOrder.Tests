using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record SendingBasketActions(
    Field<string?>? ConfirmOrder,
    string? MenuLabel) : BasketActionsBase(MenuLabel);