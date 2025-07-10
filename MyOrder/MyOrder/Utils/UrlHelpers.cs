using Microsoft.AspNetCore.Components;

namespace MyOrder.Utils;

public static class UrlHelpers
{
    /// <summary>
    /// Converts an **absolute** or **relative** URL coming from the server
    /// into something you can pass straight to NavigationManager.NavigateTo().
    ///
    /// * Strips scheme/host/port.
    /// * Preserves path, query, and fragment.
    /// * Honors <base href="…">   (works even when the app sits in /MyApp/).
    /// </summary>
    public static string ToAppRelative(this string serverUrl, NavigationManager nav)
    {
        if (string.IsNullOrWhiteSpace(serverUrl))
            throw new ArgumentNullException(nameof(serverUrl));

        // 1)  Parse – tolerate both absolute & already-relative forms.
        var uri = Uri.TryCreate(serverUrl, UriKind.Absolute, out var abs)
                  ? abs
                  : new Uri(serverUrl, UriKind.Relative);

        var pathQueryFragment = uri.IsAbsoluteUri
                                ? $"{uri.AbsolutePath}{uri.Query}{uri.Fragment}"
                                : serverUrl;                 // already relative

        // 2)  If the app is hosted under a virtual dir, lop that off too.
        var basePath = new Uri(nav.BaseUri).AbsolutePath;     
        if (basePath != "/" &&
            pathQueryFragment.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
        {
            pathQueryFragment = pathQueryFragment[basePath.Length..];
            if (pathQueryFragment.StartsWith('/'))
                pathQueryFragment = pathQueryFragment[1..];
        }

        return pathQueryFragment;
    }
}
