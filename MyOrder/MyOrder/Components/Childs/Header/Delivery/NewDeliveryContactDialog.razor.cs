using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Store.DeliveryInfoUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class NewDeliveryContactDialog : FluxorComponentBase<NewDeliveryContactState, FetchNewDeliveryContactAction>
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; } = null!;
    [Parameter]
    public string? ContactId { get; set; }
    private DeliveryContactDraft? DeliveryContactDraft => State.Value.DeliveryContactDraft;

    protected override FetchNewDeliveryContactAction CreateFetchAction() =>
        string.IsNullOrEmpty(ContactId) ? new() : new(ContactId);
}
