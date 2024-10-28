using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.GeneralInformation;

public class NotesBasketActions : BasketActionsBase
{
    public Field<string?>? OrderNote { get; set; }
    public Field<string?>? Attachments { get; set; }
}