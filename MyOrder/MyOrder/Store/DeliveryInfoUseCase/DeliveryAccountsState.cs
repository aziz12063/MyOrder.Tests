using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public class DeliveryAccountsState : StateBase
{
    public List<AccountDto?>? Accounts { get; }
    public List<AccountDto?>? FilteredAccounts { get; }

    public DeliveryAccountsState() : base(true) { }

    public DeliveryAccountsState(List<AccountDto?>? accountList, bool isFiltered) : base(false)
    {
        if (isFiltered)
            FilteredAccounts = accountList;
        else
            Accounts = accountList;
    }
}
