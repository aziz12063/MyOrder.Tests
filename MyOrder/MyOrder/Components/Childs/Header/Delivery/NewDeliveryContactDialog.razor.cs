using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class NewDeliveryContactDialog : FluxorComponentBase<NewDeliveryContactState, FetchNewDeliveryContactAction>
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }
    [Parameter]
    public string? ContactId { get; set; }
    private DeliveryContactDraft? DeliveryContactDraft { get; set; }
    private bool _isLoading = true;

    protected override FetchNewDeliveryContactAction CreateFetchAction(NewDeliveryContactState state) =>
        string.IsNullOrEmpty(ContactId) ? new(state) : new(state, ContactId);

    protected override void CacheNewFields()
    {
        DeliveryContactDraft = State?.Value.DeliveryContactDraft
            ?? throw new ArgumentNullException("DeliveryContactDraft is null in NewDeliveryContactState");
        _isLoading = State.Value.IsLoading;
    }
}
