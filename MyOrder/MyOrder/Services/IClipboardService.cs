namespace MyOrder.Services;

/// <summary>
/// Defines clipboard-related operations.
/// </summary>
public interface IClipboardService
{
    /// <summary>
    /// Copies the specified text to the system clipboard.
    /// </summary>
    /// <param name="text">The text to copy.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CopyTextToClipboardAsync(string text);

    /// <summary>
    /// Reads text from the system clipboard.
    /// </summary>
    /// <returns>A task that represents the asynchronous read operation. The task result contains the clipboard text.</returns>
    Task<string> PasteTextFromClipboardAsync();
}
