using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public record DeliveryContactDraft(
    string? ContactSectionLabel,
    Field<string?>? Type,
    Field<string?>? ContactId,
    Field<string?>? SocialTitle,
    Field<string?>? FirstName,
    Field<string?>? LastName,
    Field<string?>? Email,
    Field<string?>? DirectPhone,
    Field<string?>? CellularPhone,
    DeliveryContactDraftActions? Actions);