using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record PaymentAuthorizationState(
    PaymentAuthorizationDto PaymentAuthorization) : StateBase
{
    public PaymentAuthorizationState() : this((PaymentAuthorizationDto)null!) { }
}