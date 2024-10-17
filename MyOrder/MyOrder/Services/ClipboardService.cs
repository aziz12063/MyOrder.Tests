using Microsoft.JSInterop;

namespace MyOrder.Services;

/// <summary>
/// Provides clipboard-related functionalities using JavaScript interop.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ClipboardService"/> class.
/// </remarks>
/// <param name="jsRuntime">The JavaScript runtime instance.</param>
public class ClipboardService(IJSRuntime jsRuntime) : IClipboardService
{
    private readonly IJSRuntime _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
    private const string ClipboardHelper = "clipboardHelper";

    /// <inheritdoc />
    public async Task CopyTextToClipboardAsync(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        try
        {
            await _jsRuntime.InvokeVoidAsync($"{ClipboardHelper}.copyTextToClipboard", text);
        }
        catch (JSException jsEx)
        {
            throw new InvalidOperationException("An error occurred while copying text to the clipboard.", jsEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An unexpected error occurred while copying text to the clipboard.", ex);
        }
    }

    /// <inheritdoc />
    public async Task<string> PasteTextFromClipboardAsync()
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>($"{ClipboardHelper}.pasteTextFromClipboard");
        }
        catch (JSException jsEx)
        {
            throw new InvalidOperationException("An error occurred while reading text from the clipboard.", jsEx);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An unexpected error occurred while reading text from the clipboard.", ex);
        }
    }
}