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
    private List<AccountDto?>? _searchedAccounts;
    private string? _filterString = null;

    [Parameter, EditorRequired]
    public EventCallback<AccountDto> AccountClicked { get; set; }

    [Parameter, EditorRequired]
    public EventCallback AddNewAccountClicked { get; set; }

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; }

    protected override TFetchAction CreateFetchAction(TState state) =>
        CreateFetchAction(state, null);

    private static TFetchAction CreateFetchAction(TState state, string? filter = null, bool search = true) =>
        Activator.CreateInstance(typeof(TFetchAction), state, filter, search) as TFetchAction
            ?? throw new InvalidOperationException($"Unable to create instance of {typeof(TFetchAction)}.");

    protected override void CacheNewFields()
    {
        _searchedAccounts = State.Value.SearchedAccounts;
    }

    private static bool QuickFilter(AccountDto? item) =>
        item is not null && !string.IsNullOrWhiteSpace(item.AccountId);

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(CreateFetchAction(State.Value, _filterString));
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