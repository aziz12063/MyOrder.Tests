using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public record DeliveryContactSectionActions(
    Field<string?>? EditContact,
    Field<string?>? AddContact,
    Field<string?>? RemoveContact,
    Field<string?>? SalesforceLink,
    Field<string?>? ClickToCall)
    : ContactSectionActions(
        SalesforceLink,
        ClickToCall);