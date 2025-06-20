using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.DeliveryInfoUseCase;

[FeatureState]
public record DeliveryAccountsState(
    List<AccountDto?> Accounts,
    List<AccountDto?> SearchedAccounts) : StateBase, IAccountsState
{
    public DeliveryAccountsState() : this([], []) { }
}
