namespace MyOrder.Shared.Events;

public class BackendServiceUnavailableEvent(string message, 
    Exception? exception = null) : InfrastructureFailureEvent(message, exception)
{
}
