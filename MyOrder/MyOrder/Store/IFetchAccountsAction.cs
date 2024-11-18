namespace MyOrder.Store;

public interface IFetchAccountsAction
{
    public string BasketId { get; }
    public string? Filter { get; }
}
