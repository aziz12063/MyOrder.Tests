namespace MyOrder.Shared.Events;

public class ApiTimeoutEvent(string message,
     Exception? exception = null) : InfrastructureFailureEvent(message, exception)
{
}
