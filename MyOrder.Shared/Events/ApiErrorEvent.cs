namespace MyOrder.Shared.Events;

public class ApiErrorEvent(string message, int statusCode, 
    Exception? exception = null) : InfrastructureFailureEvent(message, exception)
{
    public int StatusCode { get; } = statusCode;
}
