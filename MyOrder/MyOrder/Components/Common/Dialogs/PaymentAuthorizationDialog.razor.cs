using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos.Invoice;
using MyOrder.Store.InvoiceInfoUseCase;

namespace MyOrder.Components.Common.Dialogs;

public partial class PaymentAuthorizationDialog : FluxorComponent
{
    [Inject]
    private IState<PaymentAuthorizationState> PaymentAuthorizationState { get; set; } = null!;
    [Inject]
    private IDispatcher Dispatcher { get; set; } = null!;
    [CascadingParameter]
    private MudDialogInstance DialogInstance { get; set; } = null!;

    private PaymentAuthorizationDto PaymentAuthorization => PaymentAuthorizationState.Value.PaymentAuthorization;

    private int ActiveTabIndex { get; set; } = 0;
    private SendPaymentLinkMode SendPaymentLinkMode { get; set; } = SendPaymentLinkMode.Phone;

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new FetchPaymentAuthorizationAction(PaymentAuthorizationState.Value));
        base.OnInitialized();
    }

    private void OnCloseClicked() => DialogInstance.Cancel();
}
