using Fluxor;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public class PaymentAuthorizationState : StateBase
{
    public PaymentAuthorizationDto PaymentAuthorization { get; set; } = null!;
    public string ErrorMessage { get; set; } = null!;

    public PaymentAuthorizationState() : base(true) { }

    public PaymentAuthorizationState(
        PaymentAuthorizationDto paymentAuthorization,
        string errorMessage) : base(false)
    {
        PaymentAuthorization = paymentAuthorization;
        ErrorMessage = errorMessage;
    }
}