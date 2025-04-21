using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Invoice;

public record PaymentAuthorizationActions(
    Field<string> StartPaymentAuthorization,
    Field<string> CheckPaymentAuthorization);