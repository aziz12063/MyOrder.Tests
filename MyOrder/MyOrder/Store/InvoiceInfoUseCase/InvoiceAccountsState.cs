using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public class InvoiceAccountsState : StateBase, IAccountsState
{
    public List<AccountDto?>? Accounts { get; }
    public List<AccountDto?>? SearchedAccounts { get; }

    public InvoiceAccountsState() : base(true) { }

#warning Temporary fix for state management. Remove oldState parameter, and refactor to use records.
    //oldState is used to copy the old state and update the partialnew state
    public InvoiceAccountsState(List<AccountDto?>? accountList, bool isSearch, InvoiceAccountsState oldState) : base(false)
    {
        if (isSearch)
        {
            Accounts = oldState.Accounts;
            SearchedAccounts = accountList;
        }
        else
            Accounts = accountList;
    }
}
