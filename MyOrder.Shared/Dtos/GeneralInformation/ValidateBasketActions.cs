using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record ValidateBasketActions(
    Field<string?>? LockOrder,
    Field<string?>? Sales,
    Field<string?>? Quotation,
    Field<string?>? PriceConfirm,
    string? MenuLabel) : BasketActionsBase(MenuLabel);