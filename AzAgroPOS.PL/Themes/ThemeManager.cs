using System.Drawing;

namespace AzAgroPOS.PL.Themes
{
    public static class ThemeManager
    {
        // Başlanğıc temasını təyin edirik
        public static AppTheme CurrentTheme { get; set; } = AppTheme.Light;

        // Rəngləri hazırkı temaya uyğun olaraq qaytarır
        public static Color Background => CurrentTheme == AppTheme.Light ? ColorTranslator.FromHtml("#f5f7fa") : ColorTranslator.FromHtml("#1e1e2f");
        public static Color BackgroundSecondary => CurrentTheme == AppTheme.Light ? ColorTranslator.FromHtml("#ffffff") : ColorTranslator.FromHtml("#2c2f4a");
        public static Color TextColor => CurrentTheme == AppTheme.Light ? ColorTranslator.FromHtml("#212529") : ColorTranslator.FromHtml("#f8f9fa");

        public static Color Primary => CurrentTheme == AppTheme.Light ? ColorTranslator.FromHtml("#0d6efd") : ColorTranslator.FromHtml("#3399ff");
        public static Color Success => CurrentTheme == AppTheme.Light ? ColorTranslator.FromHtml("#28a745") : ColorTranslator.FromHtml("#00c16e");
        public static readonly Color Danger = ColorTranslator.FromHtml("#dc3545"); // Bu rəng hər iki temada eyni qala bilər
        public static readonly Color Secondary = ColorTranslator.FromHtml("#6c757d");

        // Stili olan kontrollerlər üçün şriftlər
        public static readonly Font HeaderFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
    }
}