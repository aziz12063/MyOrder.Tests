using MudBlazor;

namespace MyOrder;

public static class ThemeConfiguration
{
    public static readonly MudTheme mudTheme = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#0A74DA", // Azure-like blue, matching the logo
            Secondary = "#0D47A1", // Darker blue for secondary elements
            AppbarBackground = "#0A74DA", // App bar matches primary color
            Background = "#F5F5F5", // Soft light background for content areas
            Surface = "#FFFFFF", // White surfaces for cards and panels
            DrawerBackground = "#F5F5F5", // Light background for drawers
            DrawerText = "#0A74DA", // Drawer text matching primary color
            TextPrimary = "#212121", // Dark gray for primary text
            TextSecondary = "#757575", // Lighter gray for secondary text
            ActionDefault = "#0A74DA", // Default action color
            ActionDisabled = "#BDBDBD", // Disabled action color
            ActionDisabledBackground = "#E0E0E0", // Disabled action background
            Divider = "#BDBDBD", // Divider color
            DividerLight = "#E0E0E0", // Lighter dividers
            HoverOpacity = 0.08f, // Opacity for hover effect
            Success = "#4CAF50", // Green for success messages
            Error = "#F44336", // Red for error messages
            Warning = "#FF9800", // Orange for warnings
            Info = "#2196F3", // Blue for informational messages
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = "0.00938em",
            },
            H6 = new H6
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.25rem",
                FontWeight = 500,
                LineHeight = 1.6,
                LetterSpacing = "0.0075em",
            },
            Subtitle1 = new Subtitle1
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = 600,  // Slightly bolder font weight
                LineHeight = 1.75,
                LetterSpacing = "0.00938em",
            },
            Subtitle2 = new Subtitle2
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.875rem",
                FontWeight = 500,
                LineHeight = 1.57,
                LetterSpacing = "0.00714em",
            },
            Body2 = new Body2
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.813rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = "0.01071em",
            },
            Caption = new Caption
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 1.66,
                LetterSpacing = "0.03333em",
            },
            
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "15px",  // Softer borders
        },
    };

    public static MudTheme MyTheme { get => mudTheme; }
}
