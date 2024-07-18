using Fluxor;

public class LoggingMiddleware : Middleware
{
    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        Console.WriteLine("InitializeAsync");
        return base.InitializeAsync(dispatcher, store);
    }

    public override void AfterInitializeAllMiddlewares()
    {
        Console.WriteLine("AfterInitializeAllMiddlewares");
    }

    public override bool MayDispatchAction(object action)
    {
        Console.WriteLine("MayDispatchAction");
        return true;
    }

    public override void BeforeDispatch(object action)
    {
        Console.WriteLine("BeforeDispatch");
    }

    public override void AfterDispatch(object action)
    {
        base.AfterDispatch(action);
    }
}