using MyOrder.Shared.Dtos;

namespace MyOrder.Store;

public interface IAccountsState
{
    public List<AccountDto?>? Accounts { get; }
    public List<AccountDto?>? SearchedAccounts { get; }

    public bool IsLoading { get; }
}
