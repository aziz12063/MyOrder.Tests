using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos;
using MyOrder.Store;

namespace MyOrder.Components.Common.Dialogs;

public partial class SearchContactDialog<TState, TFetchAction>
    : FluxorComponentBase<TState, TFetchAction>, IHandleEvent
    where TState : class, IContactsState
    where TFetchAction : class, IFetchContactsAction // Update to record later
{
    private List<ContactDto?>? _contacts;
    private List<ContactDto?>? _filteredContacts;
    private string? _filterString = null;

    [Parameter, EditorRequired]
    public EventCallback<ContactDto> ContactClicked { get; set; }
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }

    protected override TFetchAction CreateFetchAction(TState state) =>
        CreateFetchAction(state, null);

    private static TFetchAction CreateFetchAction(TState state, string? filter = null) =>
        Activator.CreateInstance(typeof(TFetchAction), state, filter) as TFetchAction
        ?? throw new InvalidOperationException($"Unable to create instance of {typeof(TFetchAction)}.");

    protected override void CacheNewFields()
    {
        _contacts = State.Value.Contacts;
        _filteredContacts = State.Value.FilteredContacts;
    }

    private static bool QuickFilter(ContactDto? item) =>
        item is not null && !string.IsNullOrWhiteSpace(item.ContactId);

    private List<ContactDto?>? DisplayedItems() =>
        string.IsNullOrEmpty(_filterString) ? _contacts : _filteredContacts;

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(CreateFetchAction(State.Value, _filterString));
    }

    private async Task OnContactClick(ContactDto? contact)
    {
        if (contact is null)
            return;

        await ContactClicked.InvokeAsync(contact);

        MudDialog.Close();
    }

    //Necessary to preserve the internal state of childs (FilterItems)
    Task IHandleEvent.HandleEventAsync(
        EventCallbackWorkItem callback, object? arg) =>
        callback.InvokeAsync(arg);
}
