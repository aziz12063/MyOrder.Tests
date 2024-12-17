using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;

namespace MyOrder.Components.Childs.Header;

public partial class NewDeliveryAccountDialog : FluxorComponentBase<NewDeliveryAccountState, FetchNewDeliveryAccountAction>
{
    [Parameter]
    public string? AccountId { get; set; }
    private DeliveryAccountDraft? DeliveryAccountDraft { get; set; }
    private bool _isLoading = true;

    protected override FetchNewDeliveryAccountAction CreateFetchAction(NewDeliveryAccountState state, string basketId) =>
        string.IsNullOrEmpty(AccountId) ? new(state, basketId) : new(state, basketId, AccountId);

    protected override void CacheNewFields()
    {
        DeliveryAccountDraft = State?.Value.DeliveryAccountDraft
            ?? throw new ArgumentNullException("DeliveryAccountDraft is null in NewDeliveryAccountState");
        _isLoading = State.Value.IsLoading;
    }
}