//using System.Drawing;
//using System.Windows.Forms;

//namespace AzAgroPOS.PL.Themes
//{
//    public static class ThemeManager
//    {
//        public static bool IsDarkMode { get; private set; } = false;

//        public static void ToggleTheme()
//        {
//            IsDarkMode = !IsDarkMode;
//            ApplyTheme();
//        }

//        public static void ApplyTheme()
//        {
//            if (IsDarkMode)
//            {
//                ModernColorPalette.Background = ModernColorPalette.DarkBackground;
//                ModernColorPalette.SurfaceLevel1 = ModernColorPalette.DarkSurface;
//                ModernColorPalette.SurfaceLevel2 = Color.FromArgb(60, 60, 60);
//                ModernColorPalette.SurfaceLevel3 = Color.FromArgb(70, 70, 70);
//                ModernColorPalette.TextPrimary = ModernColorPalette.DarkTextPrimary;
//                ModernColorPalette.TextSecondary = ModernColorPalette.DarkTextSecondary;
//                ModernColorPalette.Border = ModernColorPalette.DarkBorder;
//                ModernColorPalette.InputBackground = Color.FromArgb(60, 60, 60);
//                ModernColorPalette.InputBorder = Color.FromArgb(90, 90, 90);
//            }
//            else
//            {
//                ModernColorPalette.Background = Color.FromArgb(250, 250, 250);
//                ModernColorPalette.SurfaceLevel1 = Color.White;
//                ModernColorPalette.SurfaceLevel2 = Color.FromArgb(248, 249, 250);
//                ModernColorPalette.SurfaceLevel3 = Color.FromArgb(241, 243, 245);
//                ModernColorPalette.TextPrimary = Color.FromArgb(33, 33, 33);
//                ModernColorPalette.TextSecondary = Color.FromArgb(117, 117, 117);
//                ModernColorPalette.Border = Color.FromArgb(224, 224, 224);
//                ModernColorPalette.InputBackground = Color.WhiteSmoke;
//                ModernColorPalette.InputBorder = Color.FromArgb(189, 189, 189);
//            }
//        }
//    }
//}