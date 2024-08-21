using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Services;

public interface IExceptionHandler
{
    /// <summary>
    /// Handles the provided exception by logging it and triggering any necessary notifications.
    /// </summary>
    /// <param name="exception">The exception to handle.</param>
    void HandleException(Exception exception);

    /// <summary>
    /// Clears the current exception and notifies subscribers.
    /// </summary>
    void ClearException();

    /// <summary>
    /// Gets the current exception being handled, if any.
    /// </summary>
    /// <returns>The current exception, or null if none is being handled.</returns>
    Exception? GetCurrentException();

    /// <summary>
    /// Event triggered when an exception is handled.
    /// </summary>
    event Action? OnExceptionOccurred;
}
