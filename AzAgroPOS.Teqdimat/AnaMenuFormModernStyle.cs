using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    /// <summary>
    /// Ana Menu formasına modern stil tətbiq edən helper class
    /// </summary>
    public static class AnaMenuFormModernStyle
    {
        // Modern rəng sxemi
        public static class Colors
        {
            // Sidebar rəngləri
            public static readonly Color SidebarBackground = Color.FromArgb(45, 52, 67);
            public static readonly Color SidebarUserPanel = Color.FromArgb(52, 73, 94);
            public static readonly Color SidebarText = Color.FromArgb(236, 240, 241);
            public static readonly Color SidebarButtonHover = Color.FromArgb(52, 73, 94);
            public static readonly Color SidebarButtonActive = Color.FromArgb(41, 128, 185);

            // Dashboard rəngləri
            public static readonly Color CardBackground = Color.White;
            public static readonly Color CardBorder = Color.FromArgb(220, 223, 230);
            public static readonly Color CardTitle = Color.FromArgb(52, 73, 94);
            public static readonly Color CardValue = Color.FromArgb(41, 128, 185);

            // Accent rəngləri
            public static readonly Color Primary = Color.FromArgb(41, 128, 185);
            public static readonly Color Success = Color.FromArgb(39, 174, 96);
            public static readonly Color Warning = Color.FromArgb(243, 156, 18);
            public static readonly Color Danger = Color.FromArgb(231, 76, 60);
            public static readonly Color Info = Color.FromArgb(52, 152, 219);
        }

        /// <summary>
        /// Bütün menu düymələrinə modern stil tətbiq edir
        /// </summary>
        public static void ApplyModernStyle(Panel menuPanel)
        {
            // Panel özünə stil
            menuPanel.BackColor = Colors.SidebarBackground;
            menuPanel.ForeColor = Colors.SidebarText;

            // Bütün düymələri tap və stil tətbiq et
            foreach (Control control in menuPanel.Controls)
            {
                if (control is MaterialButton button)
                {
                    StyleButton(button);
                }
                else if (control is Panel panel && (panel.Name == "separator1" || panel.Name == "separator2"))
                {
                    // Separator stilini yenilə
                    panel.BackColor = Color.FromArgb(60, 67, 82);
                    panel.Height = 1;
                }
                else if (control is Panel userPanel && userPanel.Name == "pnlUserInfo")
                {
                    StyleUserPanel(userPanel);
                }
            }
        }

        /// <summary>
        /// Material Button-a modern stil tətbiq edir
        /// </summary>
        private static void StyleButton(MaterialButton button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = Colors.SidebarText;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Colors.SidebarButtonHover;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button.Height = 48;
            button.Padding = new Padding(15, 0, 15, 0);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Margin = new Padding(5, 2, 5, 2);

            // Material button specific
            button.HighEmphasis = false;
            button.Type = MaterialButton.MaterialButtonType.Text;
            button.UseAccentColor = false;
        }

        /// <summary>
        /// User panel-a modern stil tətbiq edir
        /// </summary>
        private static void StyleUserPanel(Panel userPanel)
        {
            userPanel.BackColor = Colors.SidebarUserPanel;
            userPanel.ForeColor = Colors.SidebarText;
            userPanel.Padding = new Padding(15);
            userPanel.Height = 90;

            foreach (Control control in userPanel.Controls)
            {
                if (control is Label label)
                {
                    label.BackColor = Color.Transparent;
                    label.ForeColor = Colors.SidebarText;
                    label.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
                }
                else if (control is PictureBox picBox)
                {
                    picBox.BackColor = Color.Transparent;
                    picBox.Size = new Size(55, 55);
                }
            }
        }

        /// <summary>
        /// Dashboard card-larına modern stil tətbiq edir
        /// </summary>
        public static void StyleDashboardCards(Panel dashboardPanel)
        {
            foreach (Control control in dashboardPanel.Controls)
            {
                if (control is MaterialCard card)
                {
                    StyleCard(card);
                }
            }
        }

        /// <summary>
        /// Tək bir card-a modern stil tətbiq edir
        /// </summary>
        private static void StyleCard(MaterialCard card)
        {
            card.BackColor = Colors.CardBackground;
            card.Padding = new Padding(10);
            card.Size = new Size(150, 55);

            foreach (Control control in card.Controls)
            {
                if (control is Label label)
                {
                    label.BackColor = Color.Transparent;

                    // Value label-ı böyük və primary rəngdə göstər
                    if (label.Name.Contains("Value"))
                    {
                        label.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
                        label.ForeColor = Colors.CardValue;
                        label.Dock = DockStyle.Bottom;
                    }
                    // Title label-ı kiçik və solğun göstər
                    else
                    {
                        label.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
                        label.ForeColor = Colors.CardTitle;
                        label.Dock = DockStyle.Top;
                    }
                }
            }
        }

        /// <summary>
        /// Aktiv düyməyə vurğu əlavə edir
        /// </summary>
        public static void HighlightActiveButton(MaterialButton button)
        {
            button.BackColor = Colors.SidebarButtonActive;
            button.ForeColor = Color.White;
            button.Type = MaterialButton.MaterialButtonType.Contained;
            button.HighEmphasis = true;
        }

        /// <summary>
        /// Düyməni normal vəziyyətə qaytarır
        /// </summary>
        public static void ResetButton(MaterialButton button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = Colors.SidebarText;
            button.Type = MaterialButton.MaterialButtonType.Text;
            button.HighEmphasis = false;
        }
    }
}
