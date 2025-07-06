using System.Drawing;

namespace AzAgroPOS.PL.Themes
{
    public static class ColorPalette
    {
        // Light Theme Colors
        public static readonly Color Background = Color.FromArgb(250, 250, 252);
        public static readonly Color InputBackground = Color.White;
        public static readonly Color PanelBackground = Color.FromArgb(240, 242, 245);
        public static readonly Color CardBackground = Color.White;

        // Text Colors
        public static readonly Color TextPrimary = Color.FromArgb(33, 37, 41);
        public static readonly Color TextSecondary = Color.FromArgb(108, 117, 125);
        public static readonly Color TextMuted = Color.FromArgb(173, 181, 189);

        // Base Colors
        public static readonly Color White = Color.White;
        public static readonly Color Black = Color.FromArgb(33, 37, 41);

        // Theme Colors
        public static readonly Color Primary = Color.FromArgb(13, 110, 253);
        public static readonly Color PrimaryLight = Color.FromArgb(207, 226, 255);
        public static readonly Color Secondary = Color.FromArgb(108, 117, 125);
        public static readonly Color Success = Color.FromArgb(25, 135, 84);
        public static readonly Color Danger = Color.FromArgb(220, 53, 69);
        public static readonly Color Warning = Color.FromArgb(255, 193, 7);
        public static readonly Color Info = Color.FromArgb(13, 202, 240);

        // Additional Colors
        public static readonly Color Sidebar = Color.FromArgb(44, 48, 53);
        public static readonly Color Border = Color.FromArgb(222, 226, 230);
        public static readonly Color Hover = Color.FromArgb(248, 249, 250);

        // Dark Theme Colors (optional)
        public static readonly Color DarkBackground = Color.FromArgb(33, 37, 41);
        public static readonly Color DarkTextPrimary = Color.FromArgb(248, 249, 250);
    }
}