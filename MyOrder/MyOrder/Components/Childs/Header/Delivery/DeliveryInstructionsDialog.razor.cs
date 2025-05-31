using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class DeliveryInstructionsDialog : FluxorComponentBase<NewDeliveryAccountState, FetchNewDeliveryAccountAction>
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }
    [Parameter]
    public string? AccountId { get; set; }
    private DeliveryAccountDraft? DeliveryAccountDraft { get; set; }
    private bool _isLoading = true;

    protected override FetchNewDeliveryAccountAction CreateFetchAction(NewDeliveryAccountState state) =>
       string.IsNullOrEmpty(AccountId) ? new(state) : new(state, AccountId);

    protected override void CacheNewFields()
    {
        DeliveryAccountDraft = State?.Value.DeliveryAccountDraft
            ?? throw new ArgumentNullException("DeliveryAccountDraft is null in NewDeliveryAccountState");
        _isLoading = State.Value.IsLoading;
    }
}
