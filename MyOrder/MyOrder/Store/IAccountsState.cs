using MyOrder.Shared.Dtos;

namespace MyOrder.Store;

public interface IAccountsState
{
    public List<AccountDto?>? Accounts { get; }
    public List<AccountDto?>? FilteredAccounts { get; }
    public bool IsLoading { get; }
}
