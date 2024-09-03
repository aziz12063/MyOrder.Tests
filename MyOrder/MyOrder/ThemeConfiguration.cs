using MudBlazor;

namespace MyOrder
{
    public static class ThemeConfiguration
    {
        public static readonly MudTheme mudTheme = new MudTheme
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#3B82F6",  // Primary Blue
                Secondary = "#6366F1",  // Secondary Purple
                Tertiary = "#10B981",  // Tertiary Green
                Info = "#2563EB",  // Info Blue
                Success = "#059669",  // Success Green
                Warning = "#F59E0B",  // Warning Yellow
                Error = "#EF4444",  // Error Red
                Background = "#F9FAFB",  // Light Background
                BackgroundGray = "#E0E0E0",
                Surface = "#FFFFFF",  // White Surface
                DrawerBackground = "#F3F4F6",
                AppbarBackground = "#1E293B",
                AppbarText = "#FFFFFF",
                TextPrimary = "#111827",
                TextSecondary = "#6B7280",
                ActionDefault = "#3B82F6",
                ActionDisabled = "#9CA3AF",
                ActionDisabledBackground = "#E5E7EB",
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
                    FontSize = "1rem",
                    FontWeight = 600,  // Slightly bolder font weight
                    LineHeight = 1.75,
                    LetterSpacing = "0.00938em",
                },
                Subtitle2 = new Subtitle2
                {
                    FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                    FontSize = "0.875rem",
                    FontWeight = 500,
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
                DefaultBorderRadius = "4px",  // Softer borders
            }
        };

        public static MudTheme MyTheme { get => mudTheme; }
    }

}
