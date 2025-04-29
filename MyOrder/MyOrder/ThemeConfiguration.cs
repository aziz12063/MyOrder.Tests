using MudBlazor;

namespace MyOrder;

public static class ThemeConfiguration
{
    public static MudTheme RajaTheme { get => rajaMudTheme; }
    //public static MudTheme VikingTheme { get => vikingMudTheme; }

    public static readonly MudTheme rajaMudTheme = new()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#276EF1",
            PrimaryContrastText = "#FFFFFF",
            PrimaryDarken = "#1A56C8",
            PrimaryLighten = "#538BFF",

            Secondary = "#5C6BC0",
            SecondaryContrastText = "#FFFFFF",
            SecondaryDarken = "#3949AB",
            SecondaryLighten = "#8E99F3",

            Tertiary = "#9FA8DA",
            TertiaryContrastText = "#212121",
            TertiaryDarken = "#7986CB",
            TertiaryLighten = "#C5CAE9",

            Info = "#00ACC1",
            InfoContrastText = "#FFFFFF",
            InfoDarken = "#00838F",
            InfoLighten = "#4DD0E1",

            Success = "#3AA655",
            SuccessContrastText = "#FFFFFF",
            SuccessDarken = "#2E7D32",
            SuccessLighten = "#66BB6A",

            Warning = "#F2994A",
            WarningContrastText = "#FFFFFF",
            WarningDarken = "#EF6C00",
            WarningLighten = "#FFB74D",

            Error = "#D44333",
            ErrorContrastText = "#FFFFFF",
            ErrorDarken = "#B71C1C",
            ErrorLighten = "#E57373",

            Black = "#000000",
            Dark = "#212121",
            DarkContrastText = "#FFFFFF",
            DarkDarken = "#000000",
            DarkLighten = "#484848",

            White = "#FFFFFF",
            GrayDefault = "#9E9E9E",
            GrayLight = "#E0E0E0",
            GrayLighter = "#F5F5F5",
            GrayDark = "#757575",
            GrayDarker = "#424242",

            Background = "#FFFFFF",
            BackgroundGray = "#F4F5F7",
            Surface = "#FFFFFF",
            DrawerBackground = "#FFFFFF",
            DrawerText = "#212121",
            DrawerIcon = "#757575",

            AppbarBackground = "#FFFFFF",
            AppbarText = "#212121",

            LinesDefault = "#DDE2E6",
            LinesInputs = "#B0BEC5",
            TableLines = "#ECEFF1",
            TableStriped = "#F9FAFB",
            TableHover = "#E3F2FD",
            DividerLight = "#ECEFF1",
            Divider = "#CFD8DC",

            TextPrimary = "#212121",
            TextSecondary = "#757575",
            TextDisabled = "#BDBDBD",

            ActionDefault = "#276EF1",
            ActionDisabled = "#BDBDBD",
            ActionDisabledBackground = "#E0E0E0",
            HoverOpacity = 0.08f,
            RippleOpacity = 0.12f,
            RippleOpacitySecondary = 0.2f,

            OverlayDark = "rgba(33,33,33,0.5)",
            OverlayLight = "rgba(255,255,255,0.5)",

            Skeleton = "#E0E0E0"
        },
        Typography = new Typography
        {
            Default = new DefaultTypography
            { 
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem", 
                FontWeight = "400", 
                LineHeight = "1.5", 
                LetterSpacing = "0.00938em"
            },
            H1 = new H6Typography
            { 
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "2.5rem",
                FontWeight = "300", 
                LineHeight = "1.2", 
                LetterSpacing = "-0.01562em" 
            },
            H2 = new H2Typography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"], 
                FontSize = "2rem",
                FontWeight = "300",
                LineHeight = "1.3", 
                LetterSpacing = "-0.00833em" 
            },
            H3 = new H3Typography
            { 
                FontFamily = ["Roboto", "Arial", "sans-serif"], 
                FontSize = "1.75rem", 
                FontWeight = "400",
                LineHeight = "1.4", 
                LetterSpacing = "0em"
            },
            H4 = new H4Typography
            { 
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.5rem",
                FontWeight = "400",
                LineHeight = "1.4",
                LetterSpacing = "0.00735em" 
            },
            H5 = new H5Typography
            { 
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1.25rem", 
                FontWeight = "500", 
                LineHeight = "1.5", 
                LetterSpacing = "0em"
            },
            H6 = new H6Typography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"], 
                FontSize = "1.125rem",
                FontWeight = "600",
                LineHeight = "1.6",
                LetterSpacing = "0.0075em"
            },
            Subtitle1 = new Subtitle1Typography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = "500",
                LineHeight = "1.6",
                LetterSpacing = "0.00938em"
            },
            Subtitle2 = new Subtitle2Typography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.9375rem",
                FontWeight = "500",
                LineHeight = "1.57",
                LetterSpacing = "0.00938em"
            },
            Body1 = new Body1Typography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = "400",
                LineHeight = "1.5",
                LetterSpacing = "0.01071em"
            },
            Body2 = new Body2Typography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.875rem",
                FontWeight = "400",
                LineHeight = "1.43",
                LetterSpacing = "0.01071em"
            },
            Caption = new CaptionTypography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.875rem",
                FontWeight = "400",
                LineHeight = "1.66",
                LetterSpacing = "0.03333em",
                TextTransform = "none"
            },
            Button = new ButtonTypography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "1rem",
                FontWeight = "600",
                LineHeight = "1.75",
                LetterSpacing = "0.02857em",
                TextTransform = "uppercase"
            },
            Overline = new OverlineTypography
            {
                FontFamily = ["Roboto", "Arial", "sans-serif"],
                FontSize = "0.75rem",
                FontWeight = "400",
                LineHeight = "2.66",
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

    //public static readonly MudTheme vikingMudTheme = new()
    //{
    //    PaletteLight = new PaletteLight
    //    {
    //        Primary = "#424242",  // Dark gray for primary elements to create a more neutral feel
    //        Secondary = "#D32F2F",  // Signature red for accents
    //        AppbarBackground = "#594ae2ff",  // Slightly darker gray app bar for better visual separation
    //        Background = "#F5F5F5",  // Soft light background for content areas
    //        Surface = "#F9F9F9",  // Slightly off-white surfaces for better contrast against background
    //        DrawerBackground = "#DDDDDD",  // Darker gray background for drawers to create better separation
    //        DrawerText = "#212121",  // Dark gray text in drawer for readability
    //        //DrawerHighlight = "#EEEEEE",  // Highlight for selected elements in drawer
    //        TextPrimary = "#212121",  // Dark gray for primary text
    //        TextSecondary = "#616161",  // Medium gray for secondary text for a softer contrast
    //        ActionDefault = "#D32F2F",  // Default action color (signature red for accents)
    //        //ActionHover = "#C62828",  // Darker red for button hover effect
    //        ActionDisabled = "#BDBDBD",  // Disabled action color
    //        ActionDisabledBackground = "#E0E0E0",  // Disabled action background
    //        Divider = "#BDBDBD",  // Divider color
    //        DividerLight = "#E0E0E0",  // Lighter dividers for a cleaner look
    //        //DividerThickness = "2px",  // Increased divider thickness for better element distinction
    //        HoverOpacity = 0.15f,  // Increased hover effect for better feedback
    //        Success = "#4CAF50",  // Green for success messages
    //        Error = "#B00020",  // Darker red for error messages to contrast against primary accents
    //        Warning = "#FF9800",  // Orange for warnings
    //        Info = "#1976D2",  // Blue for informational messages to align with the brand
    //        TableLines = "#FAFAFA",  // Soft shade for table headers and alternate rows for better readability
    //    },
    //    Typography = new Typography
    //    {
    //        Default = new Default
    //        {
    //            FontFamily = ["Roboto", "Arial", "sans-serif"],
    //            FontSize = "0.875rem",
    //            FontWeight = 400,
    //            LineHeight = 1.5,
    //            LetterSpacing = "0.00938em",
    //        },
    //        H6 = new H6
    //        {
    //            FontFamily = ["Roboto", "Arial", "sans-serif"],
    //            FontSize = "1.25rem",
    //            FontWeight = 500,
    //            LineHeight = 1.6,
    //            LetterSpacing = "0.0075em",
    //        },
    //        Subtitle1 = new Subtitle1
    //        {
    //            FontFamily = ["Roboto", "Arial", "sans-serif"],
    //            FontSize = "1rem",
    //            FontWeight = 500,  // Increased weight to emphasize important elements
    //            LineHeight = 1.75,
    //            LetterSpacing = "0.00938em",
    //        },
    //        Subtitle2 = new Subtitle2
    //        {
    //            FontFamily = ["Roboto", "Arial", "sans-serif"],
    //            FontSize = "0.875rem",
    //            FontWeight = 400,
    //            LineHeight = 1.57,
    //            LetterSpacing = "0.00714em",
    //        },
    //        Body2 = new Body2
    //        {
    //            FontFamily = ["Roboto", "Arial", "sans-serif"],
    //            FontSize = "0.813rem",
    //            FontWeight = 400,
    //            LineHeight = 1.43,
    //            LetterSpacing = "0.01071em",
    //        },
    //        Caption = new Caption
    //        {
    //            FontFamily = ["Roboto", "Arial", "sans-serif"],
    //            FontSize = "0.75rem",
    //            FontWeight = 400,
    //            LineHeight = 1.66,
    //            LetterSpacing = "0.03333em",
    //        },
    //    },
    //    LayoutProperties = new LayoutProperties
    //    {
    //        DefaultBorderRadius = "8px",
    //    },
    //};

    public static void ApplyCustomMudGlobals()
    {
        MudGlobal.InputDefaults.ShrinkLabel = true;
        MudGlobal.InputDefaults.Margin = Margin.Dense;
        MudGlobal.TooltipDefaults.Delay = TimeSpan.FromMilliseconds(650);
        MudGlobal.TooltipDefaults.Duration = TimeSpan.FromMilliseconds(100);
    }
}
