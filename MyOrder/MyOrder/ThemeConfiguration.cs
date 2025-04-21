using MudBlazor;

namespace MyOrder;

public static class ThemeConfiguration
{
    public static MudTheme RajaTheme { get => rajaMudTheme; }
    public static MudTheme VikingTheme { get => vikingMudTheme; }

    public static readonly MudTheme rajaMudTheme = new()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#0A74DA",
            Secondary = "#FF4081",
            AppbarBackground = "#F5F5F5", // <- Better than pure white
            AppbarText = "#212121",
            Background = "#F9FAFB",
            Surface = "#FFFFFF",
            DrawerBackground = "#F9FAFB",
            DrawerText = "#212121",
            TextPrimary = "#212121",
            TextSecondary = "#616161",
            ActionDefault = "#0A74DA",
            ActionDisabled = "#BDBDBD",
            ActionDisabledBackground = "#E0E0E0",
            Divider = "#E0E0E0",
            DividerLight = "#F0F0F0",
            HoverOpacity = 0.06f,
            Success = "#4CAF50",
            Error = "#F44336",
            Warning = "#FB8C00",
            Info = "#2196F3",
            OverlayLight = "#FFFFFFD9",
            TableHover = "#f0f8ff"
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = "0.00938em"
            },
            H1 = new H1
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "2.5rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-0.01562em"
            },
            H2 = new H2
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "2rem",
                FontWeight = 300,
                LineHeight = 1.3,
                LetterSpacing = "-0.00833em"
            },
            H3 = new H3
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.75rem",
                FontWeight = 400,
                LineHeight = 1.4,
                LetterSpacing = "0em"
            },
            H4 = new H4
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.5rem",
                FontWeight = 400,
                LineHeight = 1.4,
                LetterSpacing = "0.00735em"
            },
            H5 = new H5
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.25rem",
                FontWeight = 500,
                LineHeight = 1.5,
                LetterSpacing = "0em"
            },
            H6 = new H6
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.125rem",
                FontWeight = 500,
                LineHeight = 1.6,
                LetterSpacing = "0.0075em"
            },
            Subtitle1 = new Subtitle1
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.125rem",
                FontWeight = 500,
                LineHeight = 1.75,
                LetterSpacing = "0.00938em"
            },
            Subtitle2 = new Subtitle2
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = 500,
                LineHeight = 1.57,
                LetterSpacing = "0.00938em"
            },
            Body1 = new Body1
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = "0.01071em"
            },
            Body2 = new Body2
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.9375rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = "0.01071em"
            },
            Caption = new Caption
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.66,
                LetterSpacing = "0.03333em",
                TextTransform = "none"
            },
            Button = new Button
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = 600,
                LineHeight = 1.75,
                LetterSpacing = "0.02857em",
                TextTransform = "uppercase"
            },
            Input = new Input
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.9375rem",
                FontWeight = 400,
                LineHeight = 1.4,
                LetterSpacing = "0.00938em"
            },
            Overline = new Overline
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 2.66,
                LetterSpacing = "0.08333em",
                TextTransform = "uppercase"
            },
        },
        LayoutProperties = new LayoutProperties
        {
            AppbarHeight= "72px",
            DefaultBorderRadius = "12px",
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
                FontWeight = 500,  // Increased weight to emphasize important elements
                LineHeight = 1.75,
                LetterSpacing = "0.00938em",
            },
            Subtitle2 = new Subtitle2
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.875rem",
                FontWeight = 400,
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
