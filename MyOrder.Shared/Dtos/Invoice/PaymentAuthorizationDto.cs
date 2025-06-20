using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Invoice;

public record PaymentAuthorizationDto(
    string PanelLabel,
    bool HasOngoingAuthorization,

    [property: DisplayOnlyField]
    Field<string> ContactName,

    Field<SendPaymentLinkMode?> SendPaymentLinkMode,
    Field<string> ContactPhone,
    Field<string> ContactEmail,

    [property: DisplayOnlyField]
    Field<string> SalesId,

    [property: DisplayOnlyField]
    Field<string> AuthorizationNumber,

    [property: DisplayOnlyField]
    Field<decimal?> AuthorizationAmount,

    [property: DisplayOnlyField]
    Field<DateTime?> AuthorizationDate,

    [property: DisplayOnlyField]
    Field<string> AuthorizationStatus,

    [property: DisplayOnlyField]
    PaymentAuthorizationActions Actions);

public enum SendPaymentLinkMode
{
    Phone,
    Email
}