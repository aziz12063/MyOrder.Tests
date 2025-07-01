using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class DeliveryInstructionsDialog : FluxorComponentBase<NewDeliveryAccountState, FetchNewDeliveryAccountAction>
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; } = null!;
    [Parameter]
    public string? AccountId { get; set; }
    private DeliveryAccountDraft DeliveryAccountDraft => State.Value.DeliveryAccountDraft;

    protected override FetchNewDeliveryAccountAction CreateFetchAction() =>
       string.IsNullOrEmpty(AccountId) ? new() : new(AccountId);

    protected override void OnInitialized()
    {
        // Initialize the state for the new delivery account
        Dispatcher.Dispatch(new ResetNewDeliveryAccountAction());
        base.OnInitialized();
    }
}
