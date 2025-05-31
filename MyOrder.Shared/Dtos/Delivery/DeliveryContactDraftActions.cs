using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public record DeliveryContactDraftActions(
    Field<string?>? EditContact,
    Field<string?>? AddContact,
    Field<string?>? CancelContact);