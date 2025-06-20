using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record LogsBasketActions(
    Field<string?>? PublicationLogs,
    Field<string?>? OrderDiary,
    Field<string?>? EdiMessages,
    string? MenuLabel) : BasketActionsBase(MenuLabel);