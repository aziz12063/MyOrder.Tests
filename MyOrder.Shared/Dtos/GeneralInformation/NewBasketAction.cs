using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record NewBasketAction(
    Field<string?>? Account,
    Field<string?>? Contact);
