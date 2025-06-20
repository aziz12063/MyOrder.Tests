namespace MyOrder.Store;

public interface IFetchContactsAction
{
    public string? Filter { get; }
    public bool? Search { get; }
}
