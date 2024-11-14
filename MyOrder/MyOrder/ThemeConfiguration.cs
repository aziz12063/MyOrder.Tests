using MudBlazor;

namespace MyOrder;

public static class ThemeConfiguration
{
    public static MudTheme RajaTheme { get => rajaMudTheme; }
    public static MudTheme VikingTheme { get => vikingMudTheme; }

    public static readonly MudTheme rajaMudTheme = new()
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
        ZIndex = new ZIndex
        {
            Drawer = 1100,
            Popover = 1300,
            AppBar = 1200,
            Dialog = 1400,
            Snackbar = 1500,
            Tooltip = 1600
        }
    };

    public static readonly MudTheme vikingMudTheme = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#424242",  // Dark gray for primary elements to create a more neutral feel
            Secondary = "#D32F2F",  // Signature red for accents
            AppbarBackground = "#594ae2ff",  // Slightly darker gray app bar for better visual separation
            Background = "#F5F5F5",  // Soft light background for content areas
            Surface = "#F9F9F9",  // Slightly off-white surfaces for better contrast against background
            DrawerBackground = "#DDDDDD",  // Darker gray background for drawers to create better separation
            DrawerText = "#212121",  // Dark gray text in drawer for readability
            //DrawerHighlight = "#EEEEEE",  // Highlight for selected elements in drawer
            TextPrimary = "#212121",  // Dark gray for primary text
            TextSecondary = "#616161",  // Medium gray for secondary text for a softer contrast
            ActionDefault = "#D32F2F",  // Default action color (signature red for accents)
            //ActionHover = "#C62828",  // Darker red for button hover effect
            ActionDisabled = "#BDBDBD",  // Disabled action color
            ActionDisabledBackground = "#E0E0E0",  // Disabled action background
            Divider = "#BDBDBD",  // Divider color
            DividerLight = "#E0E0E0",  // Lighter dividers for a cleaner look
            //DividerThickness = "2px",  // Increased divider thickness for better element distinction
            HoverOpacity = 0.15f,  // Increased hover effect for better feedback
            Success = "#4CAF50",  // Green for success messages
            Error = "#B00020",  // Darker red for error messages to contrast against primary accents
            Warning = "#FF9800",  // Orange for warnings
            Info = "#1976D2",  // Blue for informational messages to align with the brand
            TableLines = "#FAFAFA",  // Soft shade for table headers and alternate rows for better readability
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = "0.00938em",
            },
            H6 = new H6
            {
                FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                FontSize = "1.25rem",
                FontWeight = 500,
                LineHeight = 1.6,
                LetterSpacing = "0.0075em",
            },
            Subtitle1 = new Subtitle1
            {
                FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 500,  // Increased weight to emphasize important elements
                LineHeight = 1.75,
                LetterSpacing = "0.00938em",
            },
            Subtitle2 = new Subtitle2
            {
                FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.57,
                LetterSpacing = "0.00714em",
            },
            Body2 = new Body2
            {
                FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                FontSize = "0.813rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = "0.01071em",
            },
            Caption = new Caption
            {
                FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 1.66,
                LetterSpacing = "0.03333em",
            },
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "8px",  // Slightly softer border for a modern yet professional look
        },
    };

    public static void ApplyCustomMudGlobals()
    {
        MudGlobal.InputDefaults.ShrinkLabel = true;
        MudGlobal.InputDefaults.Margin = Margin.Dense;
        MudGlobal.TooltipDefaults.Delay = TimeSpan.FromMilliseconds(650);
        MudGlobal.TooltipDefaults.Duration = TimeSpan.FromMilliseconds(100);
    }
}
