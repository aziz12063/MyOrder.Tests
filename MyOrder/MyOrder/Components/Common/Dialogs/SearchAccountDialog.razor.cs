using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos;
using MyOrder.Store;

namespace MyOrder.Components.Common.Dialogs;

public partial class SearchAccountDialog<TState, TFetchAction>
    : FluxorComponentBase<TState, TFetchAction>, IHandleEvent
    where TState : class, IAccountsState
    where TFetchAction : class, IFetchAccountsAction
{
    private List<AccountDto?>? _accounts;
    private List<AccountDto?>? _filteredAccounts;
    private string? _filterString = null;

    [Parameter, EditorRequired]
    public EventCallback<AccountDto> AccountClicked { get; set; }

    [Parameter, EditorRequired]
    public EventCallback AddNewAccountClicked { get; set; }

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    protected override TFetchAction CreateFetchAction(TState state, string basketId) =>
        CreateFetchAction(state, basketId, null);

    private static TFetchAction CreateFetchAction(TState state, string basketId, string? filter = null) =>
        Activator.CreateInstance(typeof(TFetchAction), state, basketId, filter) as TFetchAction
        ?? throw new InvalidOperationException($"Unable to create instance of {typeof(TFetchAction)}.");

    protected override void CacheNewFields()
    {
        _accounts = State.Value.Accounts;
        _filteredAccounts = State.Value.FilteredAccounts;
    }

    private static bool QuickFilter(AccountDto? item) =>
        item is not null && !string.IsNullOrWhiteSpace(item.AccountId);

    private List<AccountDto?>? DisplayedItems() =>
        string.IsNullOrEmpty(_filterString) ? _accounts : _filteredAccounts;

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(CreateFetchAction(State.Value, BasketId, _filterString));
    }

    private async Task OnAccountClick(AccountDto? account)
    {
        if (account is null)
            return;

        await AccountClicked.InvokeAsync(account);

        MudDialog.Close();
    }

    private async Task OnAddNewAddressClick()
    {
        await AddNewAccountClicked.InvokeAsync();
        MudDialog.Close();
    }

    //Necessary to preserve the internal state of childs (FilterItems)
    Task IHandleEvent.HandleEventAsync(
        EventCallbackWorkItem callback, object? arg) =>
        callback.InvokeAsync(arg);
}