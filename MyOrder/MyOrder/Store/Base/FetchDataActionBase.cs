namespace MyOrder.Store.Base;

public abstract class FetchDataActionBase
{
    protected FetchDataActionBase(StateBase? state)
    {
        state?.MakeDirty();
    }
}

