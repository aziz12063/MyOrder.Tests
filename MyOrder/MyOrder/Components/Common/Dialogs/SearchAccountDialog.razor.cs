using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Shared.Dtos;
using MyOrder.Store;
using MyOrder.Store.Base;

namespace MyOrder.Components.Common.Dialogs;

public partial class SearchAccountDialog<TState, TFetchAction>
    : FluxorComponentBase<TState, TFetchAction>, IHandleEvent
    where TState : StateBase, IAccountsState
    where TFetchAction : class, IFetchAccountsAction
{
    private List<AccountDto?>? SearchedAccounts => State.Value.SearchedAccounts;
    private string? _filterString = null;

    [Parameter, EditorRequired]
    public EventCallback<AccountDto> AccountClicked { get; set; }

    [Parameter, EditorRequired]
    public EventCallback AddNewAccountClicked { get; set; }

    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; }

    protected override TFetchAction CreateFetchAction() => CreateFetchAction(null);

    private static TFetchAction CreateFetchAction(string? filter = null, bool search = true) =>
        Activator.CreateInstance(typeof(TFetchAction), filter, search) as TFetchAction
            ?? throw new InvalidOperationException($"Unable to create instance of {typeof(TFetchAction)}.");


    private static bool QuickFilter(AccountDto? item) =>
        item is not null && !string.IsNullOrWhiteSpace(item.AccountId);

    private void OnSearchTextChanged()
    {
        Dispatcher.Dispatch(CreateFetchAction(_filterString));
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