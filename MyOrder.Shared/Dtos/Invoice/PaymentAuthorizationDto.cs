using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Invoice;

public record PaymentAuthorizationDto(
    Field<string> ContactName,
    Field<SendPaymentLinkMode?> SendPaymentLinkMode,
    Field<string> ContactPhone,
    Field<string> ContactEmail,
    Field<string> SalesId,
    Field<string> AuthorizationNumber,
    Field<decimal?> AuthorizationAmount,
    Field<DateTime?> AuthorizationDate,
    Field<string> AuthorizationStatus,
    PaymentAuthorizationActions Actions);

public enum SendPaymentLinkMode
{
    Phone,
    Email
}