namespace MyOrder.Store;

public interface IFetchAccountsAction
{
    public string? Filter { get; }
    public bool? IsSearch { get; }
}
