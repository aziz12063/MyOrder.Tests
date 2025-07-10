using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Input;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Delivery;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Store.DeliveryInfoUseCase;

namespace MyOrder.Components.Childs.Header.Delivery;

public partial class NewDeliveryAccountDialog : FluxorComponentBase<NewDeliveryAccountState, FetchNewDeliveryAccountAction>
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; } = null!;
    [Parameter]
    public string? AccountId { get; set; }
    [Parameter]
    public bool IsNewAccount { get; set; } = false;
    private DeliveryAccountDraft DeliveryAccountDraft => State.Value.DeliveryAccountDraft;
    private FieldButton<string?>? LookupButton { get; set; }

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new ResetNewDeliveryAccountAction());
        base.OnInitialized();
    }

    protected override FetchNewDeliveryAccountAction CreateFetchAction() =>
        IsNewAccount ? new("-") // Use "-" to request a new draft account
        : string.IsNullOrEmpty(AccountId) ? new() 
        : new(AccountId);

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        
        if(Initialized) //Because the lookup button is not rendered yet
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
}