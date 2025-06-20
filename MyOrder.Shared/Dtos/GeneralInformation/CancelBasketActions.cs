using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record CancelBasketActions(
    Field<string?>? CancelBasket,
    Field<string?>? CancelOrderAndPayment,
    Field<string?>? CancelOrder,
    string? MenuLabel) : BasketActionsBase(MenuLabel);