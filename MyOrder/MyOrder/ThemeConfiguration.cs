using MudBlazor;

namespace MyOrder
{
    public static class ThemeConfiguration
    {
        public static readonly MudTheme mudTheme = new MudTheme
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#3B82F6FF",
                Secondary = "#6366F1FF",
                Tertiary = "#10B981FF",
                Info = "#2563EBFF",
                Success = "#059669FF",
                Warning = "#F59E0BFF",
                Error = "#EF4444FF",
                Background = "#F9FAFBFF",
                BackgroundGray = "#E0E0E0FF",
                Surface = "#FFFFFFFF",
                DrawerBackground = "#F3F4F6FF",
                AppbarBackground = "#1E293BFF",
                AppbarText = "#FFFFFFFF",
                TextPrimary = "#111827FF",
                TextSecondary = "#6B7280FF",
                ActionDefault = "#3B82F6FF",
                ActionDisabled = "#9CA3AFFF",
                ActionDisabledBackground = "#E5E7EBFF",
                LinesDefault = "#E0E0E0FF",
                TableLines = "#E0E0E0FF",
                OverlayLight = "#FFFFFFB3",
                OverlayDark = "#00000080"
            },
            PaletteDark = new PaletteDark
            {
                Primary = "#90CAF9FF",
                Secondary = "#9FA8DAFF",
                Tertiary = "#26A69AFF",
                Info = "#42A5F5FF",
                Success = "#66BB6AFF",
                Warning = "#FFA726FF",
                Error = "#EF5350FF",
                Background = "#121212FF",
                BackgroundGray = "#1E1E1EFF",
                Surface = "#1E1E1EFF",
                DrawerBackground = "#1E1E1EFF",
                AppbarBackground = "#212121FF",
                AppbarText = "#FFFFFFFF",
                TextPrimary = "#E0E0E0FF",
                TextSecondary = "#B0BEC5FF",
                ActionDefault = "#90CAF9FF",
                ActionDisabled = "#616161FF",
                ActionDisabledBackground = "#2C2C2CFF",
                LinesDefault = "#2C2C2CFF",
                TableLines = "#2C2C2CFF",
                OverlayLight = "#FFFFFF1A",
                OverlayDark = "#00000080"
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
                H1 = new H1
                {
                    FontFamily = new[] { "Roboto", "Arial", "sans-serif" },
                    FontSize = "6rem",
                    FontWeight = 300,
                    LineHeight = 1.167,
                    LetterSpacing = "-0.01562em",
                },
                // Define other typography elements similarly...
            },
            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "8px"
            }
        };

        public static MudTheme MyTheme { get => mudTheme; }
    }

}
