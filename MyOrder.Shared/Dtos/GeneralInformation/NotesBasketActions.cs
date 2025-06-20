using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public record NotesBasketActions(
    Field<string?>? OrderNote,
    Field<string?>? Attachments,
    string? MenuLabel) : BasketActionsBase(MenuLabel);