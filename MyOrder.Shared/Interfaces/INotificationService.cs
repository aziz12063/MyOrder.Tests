using MyOrder.Shared.Enums;

namespace MyOrder.Shared.Interfaces;

/// <summary>
/// Defines methods for displaying user-friendly notifications and progress indicators
/// during app interactions with the backend.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Displays a message to the user.
    /// </summary>
    /// <param name="message">The message to be displayed.</param>
    /// <param name="type">The type of notification (e.g., Info, Success, Warning, Error). Default is Info.</param>
    void ShowMessage(string message, NotificationType type = NotificationType.Info);

    /// <summary>
    /// Displays a progress indicator with an optional message.
    /// </summary>
    /// <param name="message">An optional message to be displayed alongside the progress indicator. Default is null.</param>
    void ShowProgress(string? message = null);

    /// <summary>
    /// Hides the currently displayed progress indicator.
    /// </summary>
    void HideProgress();
}