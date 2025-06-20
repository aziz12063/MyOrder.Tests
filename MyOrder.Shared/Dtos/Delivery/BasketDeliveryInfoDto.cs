using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public record BasketDeliveryInfoDto(
    string? PanelLabel,
    string? AccountSectionLabel,
    string? ContactSectionLabel,
    string? InformationSectionLabel,
#warning TODO: Refactor to use another model that reflects the delivery account actions and not the delivery account draft actions
    Field<AccountDto?>? Account,
    DeliveryAccountDraftActions? AccountActions,
    Field<ContactDto?>? Contact,
    DeliveryContactSectionActions? ContactActions,
    Field<BasketValueDto?>? DeliveryMode,
    Field<bool?>? CompleteDelivery,
    Field<DateTime?>? ImperativeDate,
    Field<string?>? OrderDocuments,
    Field<string?>? Note,
    Field<bool?>? NoteMustBeSaved
    );