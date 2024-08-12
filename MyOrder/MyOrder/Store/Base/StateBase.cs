namespace MyOrder.Store.Base;

public abstract class StateBase(bool isLoading)
{
    public bool IsLoading { get; protected set; } = isLoading;

    /// <summary>
    /// Make the state dirty
    /// Setting IsLoading to true means we are loading the data for the next state
    /// </summary>
    public void MakeDirty()
    {
        IsLoading = true;
    }
}

