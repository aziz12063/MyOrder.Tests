namespace MyOrder.Shared.Events;

public class InfrastructureFailureEvent(string message, 
    Exception? exception = null)
{
    public string Message { get; } = message;
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public Exception? Exception { get; } = exception;
}
