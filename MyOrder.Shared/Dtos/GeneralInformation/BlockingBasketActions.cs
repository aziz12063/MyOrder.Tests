using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record BlockingBasketActions(
    Field<string?>? ValidationRules,
    Field<string?>? BlockingReasons,
    string? MenuLabel) : BasketActionsBase(MenuLabel);