using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public class InvoiceAccountsState : StateBase, IAccountsState
{
    public List<AccountDto?>? Accounts { get; }
    public List<AccountDto?>? FilteredAccounts { get; }

    public InvoiceAccountsState() : base(true) { }

    public InvoiceAccountsState(List<AccountDto?>? accountList, bool isFiltered) : base(false)
    {
        if (isFiltered)
            FilteredAccounts = accountList;
        else
            Accounts = accountList;
    }
}
