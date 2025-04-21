using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryAccountsState : StateBase, IAccountsState
{
    public List<AccountDto?>? Accounts { get; }
    public List<AccountDto?>? SearchedAccounts { get; }

    public DeliveryAccountsState() : base(true) { }

#warning Temporary fix for state management. Remove oldState parameter, and refactor to use records.
    //oldState is used to copy the old state and update the partialnew state
    public DeliveryAccountsState(List<AccountDto?>? accountList, bool isSearch, DeliveryAccountsState oldState) : base(false)
    {
        if (isSearch)
        {
            // Temporary fix to keep the old state of accounts
            Accounts = oldState.Accounts;
            SearchedAccounts = accountList;
        }
        else
            Accounts = accountList;
    }
}
