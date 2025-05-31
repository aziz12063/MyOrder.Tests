using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public class BasketDeliveryInfoDto
{
    public string? PanelLabel { get; set; }
    public string? AccountSectionLabel { get; set; }
    public string? ContactSectionLabel { get; set; }
    public string? InformationSectionLabel { get; set; }
#warning TODO: Refactor to use another model that reflects the delivery account actions and not the delivery account draft actions
    public DeliveryAccountDraftActions? AccountActions { get; set; }
    public Field<AccountDto?>? Account { get; set; }
    public Field<ContactDto?>? Contact { get; set; }
    public Field<BasketValueDto?>? DeliveryMode { get; set; }
    public Field<bool?>? CompleteDelivery { get; set; }
    public Field<DateTime?>? ImperativeDate { get; set; }
    public Field<string?>? OrderDocuments { get; set; }
    public Field<string?>? Note { get; set; }
    public Field<bool?>? NoteMustBeSaved { get; set; }
}