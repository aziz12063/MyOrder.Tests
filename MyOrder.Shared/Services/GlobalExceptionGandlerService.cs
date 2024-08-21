namespace MyOrder.Shared.Services;

public class GlobalExceptionHandlerService : IExceptionHandler
{
    private readonly object _lock = new();
    private Exception? _currentException;

    public event Action? OnExceptionOccurred;

    public void HandleException(Exception exception)
    {
        lock (_lock)
        {
            _currentException = exception;
        }

        // Log the exception (customize logging as needed)
        LogException(exception);

        // Notify subscribers that an exception has occurred
        OnExceptionOccurred?.Invoke();
    }

    public void ClearException()
    {
        lock (_lock)
        {
            _currentException = null;
        }

        OnExceptionOccurred?.Invoke();
    }

    public Exception? GetCurrentException()
    {
        lock (_lock)
        {
            return _currentException;
        }
    }

    private void LogException(Exception exception)
    {
        // Implement your logging here
        // Example: Log to file, database, or external service
        Console.WriteLine($"Exception: {exception.Message}\n{exception.StackTrace}");
    }
}