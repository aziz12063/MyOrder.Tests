using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos;
using MyOrder.Store;
using MyOrder.Store.Base;

namespace MyOrder.Components.Common.Dialogs;

public partial class SearchContactDialog<TState, TFetchAction>
    : FluxorComponentBase<TState, TFetchAction>, IHandleEvent
    where TState : StateBase, IContactsState
    where TFetchAction : class, IFetchContactsAction // Update to record later
{
    private List<ContactDto?>? Contacts => State.Value.Contacts;
    private List<ContactDto?>? FilteredContacts => State.Value.FilteredContacts;
    private string? _filterString = null;

    [Parameter, EditorRequired]
    public EventCallback<ContactDto> ContactClicked { get; set; }
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }

    protected override TFetchAction CreateFetchAction() =>
        CreateFetchAction(null, true);

    private static TFetchAction CreateFetchAction(string? filter = null, bool? search = true) =>
        Activator.CreateInstance(typeof(TFetchAction), filter, search) as TFetchAction
        ?? throw new InvalidOperationException($"Unable to create instance of {typeof(TFetchAction)}.");

    private static bool QuickFilter(ContactDto? item) =>
        item is not null && !string.IsNullOrWhiteSpace(item.ContactId);

    private List<ContactDto?>? DisplayedItems() =>
        string.IsNullOrEmpty(_filterString) ? Contacts : FilteredContacts;

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(CreateFetchAction(_filterString, true));
    }

    private async Task OnContactClick(ContactDto contact)
    {
        await ContactClicked.InvokeAsync(contact);

        MudDialog.Close();
    }

    //Necessary to preserve the internal state of childs (FilterItems)
    Task IHandleEvent.HandleEventAsync(
        EventCallbackWorkItem callback, object? arg) =>
        callback.InvokeAsync(arg);
}
