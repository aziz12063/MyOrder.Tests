using Fluxor;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.InvoiceInfoUseCase;

[FeatureState]
public record InvoiceAccountsState(
    List<AccountDto?> Accounts,
    List<AccountDto?> SearchedAccounts) : StateBase, IAccountsState
{
    public InvoiceAccountsState() : this([], []) { }
}
