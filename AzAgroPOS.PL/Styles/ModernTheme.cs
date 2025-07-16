using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Styles
{
    public static class ModernTheme
    {
        // Modern Color Palette
        public static class Colors
        {
            // Primary Colors - Now dynamic
            public static Color Primary { get; set; } = Color.FromArgb(52, 152, 219);     // Modern Blue
            public static Color PrimaryDark { get; set; } = Color.FromArgb(41, 128, 185);  // Darker Blue
            public static Color PrimaryLight { get; set; } = Color.FromArgb(174, 214, 241); // Light Blue
            
            // Secondary Colors
            public static readonly Color Secondary = Color.FromArgb(46, 204, 113);    // Green
            public static readonly Color SecondaryDark = Color.FromArgb(39, 174, 96); // Dark Green
            public static readonly Color Success = Color.FromArgb(46, 204, 113);      // Success Green
            
            // Accent Colors
            public static readonly Color Accent = Color.FromArgb(241, 196, 15);       // Gold
            public static readonly Color Warning = Color.FromArgb(230, 126, 34);      // Orange
            public static readonly Color Danger = Color.FromArgb(231, 76, 60);        // Red
            public static readonly Color Info = Color.FromArgb(142, 68, 173);         // Purple
            
            // Neutral Colors
            public static readonly Color Background = Color.FromArgb(248, 249, 250);   // Light Gray
            public static readonly Color Surface = Color.White;                       // White
            public static readonly Color CardBackground = Color.FromArgb(255, 255, 255); // Pure White
            
            // Text Colors
            public static readonly Color TextPrimary = Color.FromArgb(33, 37, 41);    // Dark Gray
            public static readonly Color TextSecondary = Color.FromArgb(108, 117, 125); // Medium Gray
            public static readonly Color TextMuted = Color.FromArgb(173, 181, 189);   // Light Gray
            public static readonly Color TextOnPrimary = Color.White;                 // White text on primary
            
            // Border Colors
            public static readonly Color Border = Color.FromArgb(222, 226, 230);      // Light Border
            public static readonly Color BorderFocus = Color.FromArgb(128, 189, 255); // Focus Border
            
            // Shadow
            public static readonly Color Shadow = Color.FromArgb(50, 0, 0, 0);        // Semi-transparent black
        }

        // Typography
        public static class Fonts
        {
            public static readonly Font Title = new Font("Segoe UI", 24F, FontStyle.Bold);
            public static readonly Font Heading = new Font("Segoe UI", 18F, FontStyle.Bold);
            public static readonly Font SubHeading = new Font("Segoe UI", 14F, FontStyle.Bold);
            public static readonly Font Body = new Font("Segoe UI", 10F, FontStyle.Regular);
            public static readonly Font BodyBold = new Font("Segoe UI", 10F, FontStyle.Bold);
            public static readonly Font Caption = new Font("Segoe UI", 9F, FontStyle.Regular);
            public static readonly Font Button = new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        // Sizes and Spacing
        public static class Layout
        {
            public const int Padding = 20;
            public const int PaddingSmall = 10;
            public const int PaddingLarge = 30;
            public const int Margin = 15;
            public const int MarginSmall = 8;
            public const int MarginLarge = 25;
            public const int BorderRadius = 8;
            public const int ButtonHeight = 36;
            public const int InputHeight = 32;
            public const int HeaderHeight = 60;
            public const int SidebarWidth = 250;
        }

        // Apply modern styling to forms
        public static void ApplyModernStyle(Form form)
        {
            form.BackColor = Colors.Background;
            form.Font = Fonts.Body;
            form.ForeColor = Colors.TextPrimary;
            
            // Apply styles to all child controls
            ApplyStylesToControls(form.Controls);
        }

        private static void ApplyStylesToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Button btn:
                        ApplyButtonStyle(btn);
                        break;
                    case TextBox txt:
                        ApplyTextBoxStyle(txt);
                        break;
                    case ComboBox cmb:
                        ApplyComboBoxStyle(cmb);
                        break;
                    case DataGridView dgv:
                        ApplyDataGridViewStyle(dgv);
                        break;
                    case Panel panel:
                        ApplyPanelStyle(panel);
                        break;
                    case Label lbl:
                        ApplyLabelStyle(lbl);
                        break;
                    case GroupBox gb:
                        ApplyGroupBoxStyle(gb);
                        break;
                }

                // Recursively apply to child controls
                if (control.HasChildren)
                {
                    ApplyStylesToControls(control.Controls);
                }
            }
        }

        public static void ApplyButtonStyle(Button button, bool isPrimary = false)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Font = Fonts.Button;
            button.Height = Layout.ButtonHeight;
            button.Cursor = Cursors.Hand;
            
            if (isPrimary)
            {
                button.BackColor = Colors.Primary;
                button.ForeColor = Colors.TextOnPrimary;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Colors.Primary;
            }
            else
            {
                button.BackColor = Colors.Surface;
                button.ForeColor = Colors.TextPrimary;
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = Colors.Border;
            }

            // Hover effects
            button.MouseEnter += (s, e) =>
            {
                if (isPrimary)
                {
                    button.BackColor = Colors.PrimaryDark;
                }
                else
                {
                    button.BackColor = Colors.Background;
                }
            };

            button.MouseLeave += (s, e) =>
            {
                if (isPrimary)
                {
                    button.BackColor = Colors.Primary;
                }
                else
                {
                    button.BackColor = Colors.Surface;
                }
            };
        }

        public static void ApplyTextBoxStyle(TextBox textBox)
        {
            textBox.Font = Fonts.Body;
            textBox.Height = Layout.InputHeight;
            textBox.BackColor = Colors.Surface;
            textBox.ForeColor = Colors.TextPrimary;
            textBox.BorderStyle = BorderStyle.FixedSingle;

            // Add placeholder-like behavior if needed
            textBox.GotFocus += (s, e) =>
            {
                if (textBox.ForeColor == Colors.TextMuted)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Colors.TextPrimary;
                }
            };
        }

        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.Font = Fonts.Body;
            comboBox.Height = Layout.InputHeight;
            comboBox.BackColor = Colors.Surface;
            comboBox.ForeColor = Colors.TextPrimary;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        public static void ApplyDataGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Colors.Surface;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Header styling
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Colors.Primary;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Colors.TextOnPrimary;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = Fonts.BodyBold;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Colors.PrimaryDark;
            dataGridView.ColumnHeadersHeight = 40;

            // Cell styling
            dataGridView.DefaultCellStyle.BackColor = Colors.Surface;
            dataGridView.DefaultCellStyle.ForeColor = Colors.TextPrimary;
            dataGridView.DefaultCellStyle.Font = Fonts.Body;
            dataGridView.DefaultCellStyle.SelectionBackColor = Colors.PrimaryLight;
            dataGridView.DefaultCellStyle.SelectionForeColor = Colors.TextPrimary;
            
            // Row styling
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Colors.Background;
            dataGridView.RowsDefaultCellStyle.BackColor = Colors.Surface;
            dataGridView.GridColor = Colors.Border;
            dataGridView.RowTemplate.Height = 35;

            // Remove row headers
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
        }

        public static void ApplyPanelStyle(Panel panel, bool isCard = false)
        {
            if (isCard)
            {
                panel.BackColor = Colors.CardBackground;
                panel.Padding = new Padding(Layout.Padding);
            }
            else
            {
                panel.BackColor = Colors.Background;
            }
        }

        public static void ApplyLabelStyle(Label label, bool isHeading = false)
        {
            if (isHeading)
            {
                label.Font = Fonts.SubHeading;
                label.ForeColor = Colors.TextPrimary;
            }
            else
            {
                label.Font = Fonts.Body;
                label.ForeColor = Colors.TextSecondary;
            }
        }

        public static void ApplyGroupBoxStyle(GroupBox groupBox)
        {
            groupBox.Font = Fonts.BodyBold;
            groupBox.ForeColor = Colors.TextPrimary;
        }

        // Create a modern card panel
        public static Panel CreateCard()
        {
            var panel = new Panel
            {
                BackColor = Colors.CardBackground,
                Padding = new Padding(Layout.Padding)
            };
            
            panel.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                using (var pen = new Pen(Colors.Border))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };

            return panel;
        }

        // Create a modern header panel
        public static Panel CreateHeader(string title)
        {
            var panel = new Panel
            {
                Height = Layout.HeaderHeight,
                BackColor = Colors.Primary,
                Dock = DockStyle.Top
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = Fonts.Heading,
                ForeColor = Colors.TextOnPrimary,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(Layout.Padding, 0, 0, 0)
            };

            panel.Controls.Add(lblTitle);
            return panel;
        }

        // Theme Management
        public static void SetPrimaryColor(Color color)
        {
            Colors.Primary = color;
            Colors.PrimaryDark = DarkenColor(color, 20);
            Colors.PrimaryLight = LightenColor(color, 40);
        }

        public static void ApplyTheme(string themeName)
        {
            switch (themeName.ToLower())
            {
                case "modern":
                    SetPrimaryColor(Color.FromArgb(52, 152, 219)); // Blue
                    break;
                case "classic":
                    SetPrimaryColor(Color.FromArgb(52, 73, 94)); // Dark Gray
                    break;
                case "dark":
                    SetPrimaryColor(Color.FromArgb(44, 62, 80)); // Dark Blue-Gray
                    break;
                case "light":
                    SetPrimaryColor(Color.FromArgb(74, 144, 226)); // Light Blue
                    break;
                default:
                    SetPrimaryColor(Color.FromArgb(52, 152, 219)); // Default Blue
                    break;
            }
        }

        private static Color DarkenColor(Color color, int percent)
        {
            var factor = 1.0 - (percent / 100.0);
            return Color.FromArgb(
                (int)(color.R * factor),
                (int)(color.G * factor),
                (int)(color.B * factor)
            );
        }

        private static Color LightenColor(Color color, int percent)
        {
            var factor = percent / 100.0;
            return Color.FromArgb(
                Math.Min(255, (int)(color.R + (255 - color.R) * factor)),
                Math.Min(255, (int)(color.G + (255 - color.G) * factor)),
                Math.Min(255, (int)(color.B + (255 - color.B) * factor))
            );
        }

        // Apply settings-based theme
        public static async System.Threading.Tasks.Task ApplySettingsThemeAsync(AzAgroPOS.BLL.Services.SistemAyarlariService settingsService)
        {
            try
            {
                var themeName = await settingsService.GetCurrentThemeAsync();
                var primaryColor = await settingsService.GetPrimaryColorAsync();
                
                ApplyTheme(themeName);
                SetPrimaryColor(primaryColor);
            }
            catch (System.Exception)
            {
                // Use default theme on error
                ApplyTheme("modern");
            }
        }

        // Apply card style to a panel
        public static void ApplyCardStyle(Panel panel)
        {
            panel.BackColor = Colors.CardBackground;
            panel.Padding = new Padding(Layout.Padding);
            
            panel.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                using (var pen = new Pen(Colors.Border))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };
        }

        // Draw a tab item
        public static void DrawTabItem(TabControl tabControl, DrawItemEventArgs e)
        {
            if (tabControl == null) return;
            
            var tabPage = tabControl.TabPages[e.Index];
            var isSelected = e.Index == tabControl.SelectedIndex;
            
            // Set colors
            var backColor = isSelected ? Colors.Primary : Colors.Background;
            var foreColor = isSelected ? Colors.TextOnPrimary : Colors.TextPrimary;
            
            // Draw background
            using (var brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            
            // Draw text
            using (var brush = new SolidBrush(foreColor))
            {
                var stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(tabPage.Text, Fonts.Body, brush, e.Bounds, stringFormat);
            }
        }

        // Backward compatibility properties - accessible directly from ModernTheme
        public static Color BackgroundColor => Colors.Background;
        public static Color TextColor => Colors.TextPrimary;
        public static Color PrimaryColor => Colors.Primary;
        public static Color SuccessColor => Colors.Success;
        public static Color WarningColor => Colors.Warning;
        public static Color DangerColor => Colors.Danger;
        public static Color InfoColor => Colors.Info;
    }
}