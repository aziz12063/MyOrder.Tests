using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Input;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.DeliveryInfoUseCase;
using MyOrder.Store.RessourcesUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class NewDeliveryAccountDialog : FluxorComponentBase<NewDeliveryAccountState, FetchNewDeliveryAccountAction>
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }
    [Inject]
    private IState<RessourcesState> RessourcesState { get; set; }
    [Parameter]
    public string? AccountId { get; set; }
    private DeliveryAccountDraft? DeliveryAccountDraft { get; set; }
    private FieldButton<string?>? LookupButton { get; set; }
    private bool _isLoading = true;

    protected override FetchNewDeliveryAccountAction CreateFetchAction(NewDeliveryAccountState state) =>
        string.IsNullOrEmpty(AccountId) ? new(state) : new(state, AccountId);

    protected override void CacheNewFields()
    {
        DeliveryAccountDraft = State?.Value.DeliveryAccountDraft
            ?? throw new ArgumentNullException("DeliveryAccountDraft is null in NewDeliveryAccountState");
        _isLoading = State.Value.IsLoading;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        
        if(!_isLoading) //Because the lookup button is not rendered yet
            ArgumentNullException.ThrowIfNull(LookupButton, "Couldn't find a reference to the LookupButton in the razor file.");
    }

    private async Task OnAddressFormEnterKeyPressed(KeyboardEventArgs e)
    {
        if (e.Key != "Enter")
            return;
        await LookupButton!.FocusAsync(); // Already checked for null in OnAfterRender
        //ArgumentNullException.ThrowIfNull(DeliveryAccountDraft?.Actions?.AddressLookup);
        //Dispatcher.Dispatch(new PostProcedureCallAction(DeliveryAccountDraft.Actions.AddressLookup.ProcedureCall));
    }

#warning TODO: Implement FocusBack to the address form after the select button is clicked


    private void OnSaveClicked() => MudDialog.Close();

    private static string RowStyleFunc(Address? address)
    {
        var propertyDisplayStyle = address?.IsSelected?.DisplayStyle;
        if (propertyDisplayStyle is null)
            return string.Empty;

        var displayStyle = propertyDisplayStyle.Value;

        return displayStyle switch
        {
            FieldDisplayStyle.Emphasize => "background-color: #c3e6cb",
            FieldDisplayStyle.Warn => "background-color: #f8d7da",
            _ => string.Empty
        };
    }

    private string GetFullAddress(Address? item)
    {
        var parts = new[] { item?.Building, item?.Street, item?.Locality }
                        .Where(s => !string.IsNullOrWhiteSpace(s));
        return string.Join(", ", parts);
    }
}