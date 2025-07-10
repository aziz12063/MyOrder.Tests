namespace MyOrder.Services;

/// <summary>
/// Represents a fault ticket containing an error message and an optional return URI.
/// This ticket is typically used by the error page component to display ongoing fault messages
/// and provide a navigation path back to the source.
/// </summary>
public sealed class AppFaultedTicket
{
    /// <summary>
    /// Gets the error message associated with the fault ticket.
    /// </summary>
    public string? Message { get; private set; }

    /// <summary>
    /// Gets the URI to return to after handling the fault, if specified.
    /// </summary>
    public string? ReturnUri { get; private set; }

    /// <summary>
    /// Sets the fault ticket by issuing a new error message and an optional return URI.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    /// <param name="returnUri">The URI to navigate back to (optional).</param>
    public void Issue(string? message, string? returnUri = null)
    {
        Message = message;
        ReturnUri = returnUri;
    }

    /// <summary>
    /// Clears the fault ticket by resetting the error message and return URI.
    /// </summary>
    public void Clear()
    {
        Message = null;
        ReturnUri = null;
    }

    /// <summary>
    /// Gets a value indicating whether the fault ticket contains valid data.
    /// This is true if either the message or the return URI is not null, empty, or whitespace.
    /// </summary>
    public bool IsValid =>
        !string.IsNullOrWhiteSpace(Message) ||
        !string.IsNullOrWhiteSpace(ReturnUri);
}
