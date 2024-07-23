using MudBlazor;

namespace MyOrder
{
    public static class ThemeConfiguration
    {
        public static readonly MudTheme mudTheme = new MudTheme
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#1976D2",  // Soft Blue
                Secondary = "#FF4081",  // Pink Accent
                Tertiary = "#00BFA5",  // Teal
                Info = "#2196F3",  // Info Blue
                Success = "#4CAF50",  // Green
                Warning = "#FF9800",  // Orange
                Error = "#F44336",  // Red
                Background = "#F5F5F5",  // Light Grey
                BackgroundGray = "#E0E0E0",
                Surface = "#FFFFFF",  // White
                DrawerBackground = "#FFFFFF",
                AppbarBackground = "#FFFFFF",  // White Appbar
                AppbarText = "#1976D2",  // Soft Blue for Appbar Text
                TextPrimary = "#212121",  // Dark Grey
                TextSecondary = "#757575",  // Medium Grey
                ActionDefault = "#1976D2",
                ActionDisabled = "#BDBDBD",
                ActionDisabledBackground = "#E0E0E0",
                LinesDefault = "#E0E0E0",
                TableLines = "#E0E0E0",
                OverlayLight = "rgba(255, 255, 255, 0.7)",
                OverlayDark = "rgba(0, 0, 0, 0.5)"
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
                    FontSize = "1rem",  // Smaller font size
                    FontWeight = 500,
                    LineHeight = 1.75,  // Adjust line height for better spacing
                    LetterSpacing = "0.00938em",
                },
                Subtitle2 = new Subtitle2
                {
                    FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                    FontSize = "0.875rem",
                    FontWeight = 700,
                    LineHeight = 1.57,
                    LetterSpacing = "0.00714em",
                },
                Body2 = new Body2
                {
                    FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                    FontSize = "0.875rem",
                    FontWeight = 400,
                    LineHeight = 1.43,
                    LetterSpacing = "0.01071em",
                },
            },
            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "4px",  // Softer borders
            }
        };

        public static MudTheme MyTheme { get => mudTheme; }
    }

}
