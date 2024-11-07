namespace MyOrder.Store;

public interface IFetchContactsAction
{
    public string BasketId { get; }
    public string? Filter { get; }
}
