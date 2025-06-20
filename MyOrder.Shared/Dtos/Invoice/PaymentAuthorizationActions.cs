using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Invoice;

public record PaymentAuthorizationActions(
    [property: DisplayOnlyField]
    Field<string> StartPaymentAuthorization,
    [property: DisplayOnlyField]
    Field<string> CheckPaymentAuthorization,
    [property: DisplayOnlyField]
    Field<string> CancelPaymentAuthorization);