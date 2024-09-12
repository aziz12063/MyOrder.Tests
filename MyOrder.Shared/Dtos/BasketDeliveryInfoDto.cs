using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public class BasketDeliveryInfoDto
{
    public string? PanelLabel { get; set; }
    public string? AccountSectionLabel { get; set; }
    public string? ContactSectionLabel { get; set; }
    public string? InformationSectionLabel { get; set; }
    public Field<AccountDto?>? Account { get; set; }
    public Field<ContactDto?>? Contact { get; set; }
    public Field<string?>? DeliveryMode { get; set; }
    public Field<bool?>? CompleteDelivery { get; set; }
    public Field<DateTime?>? ImperativeDate { get; set; }
    public Field<List<string?>?>? OrderDocuments { get; set; }
    public Field<string?>? Note { get; set; }
    public Field<bool?>? NoteMustBeSaved { get; set; }
}