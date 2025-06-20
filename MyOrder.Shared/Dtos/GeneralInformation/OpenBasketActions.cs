using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record OpenBasketActions(
    Field<NewBasketAction?>? NewBasket,
    Field<string?>? OpenBasket,
    Field<string?>? CloneBasket,
    string? LabelMenu) : BasketActionsBase(LabelMenu);