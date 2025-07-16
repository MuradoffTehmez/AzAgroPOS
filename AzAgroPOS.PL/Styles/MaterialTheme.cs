using MaterialSkin;
using MaterialSkin.Controls;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Styles
{
    public static class MaterialTheme
    {
        public static MaterialSkinManager MaterialSkinManager { get; private set; }

        static MaterialTheme()
        {
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.WHITE);
        }

        public static void ApplyMaterialTheme(Form form)
        {
            if (form is MaterialForm materialForm)
            {
                MaterialSkinManager.AddFormToManage(materialForm);
            }
        }

        public static MaterialButton CreateMaterialButton(string text, IconChar icon, Color backColor, Point location, Size size)
        {
            var button = new MaterialButton
            {
                Text = $"  {text}",
                Size = size,
                Location = location,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            // Add icon
            var iconPic = new IconPictureBox
            {
                Size = new Size(16, 16),
                Location = new Point(8, (button.Height - 16) / 2),
                IconChar = icon,
                IconColor = Color.White,
                IconSize = 16,
                BackColor = Color.Transparent
            };
            button.Controls.Add(iconPic);

            return button;
        }

        public static MaterialTextBox CreateMaterialTextBox(string hint, IconChar icon, Point location, Size size)
        {
            var textBox = new MaterialTextBox
            {
                Size = size,
                Location = location,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Hint = hint,
                BackColor = Color.FromArgb(69, 69, 72),
                ForeColor = Color.White
            };
            
            // Add icon as a separate control since LeadingIcon doesn't accept IconChar directly
            var iconPic = new IconPictureBox
            {
                Size = new Size(16, 16),
                Location = new Point(8, (textBox.Height - 16) / 2),
                IconChar = icon,
                IconColor = Color.FromArgb(150, 150, 150),
                IconSize = 16,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            textBox.Controls.Add(iconPic);
            
            return textBox;
        }

        public static MaterialLabel CreateMaterialLabel(string text, Font font, Color foreColor, Point location, bool autoSize = true)
        {
            return new MaterialLabel
            {
                Text = text,
                Font = font,
                ForeColor = foreColor,
                AutoSize = autoSize,
                Location = location,
                BackColor = Color.Transparent
            };
        }

        public static Panel CreateMaterialCard(Size size, Point location, Color backColor)
        {
            var panel = new Panel
            {
                Size = size,
                Location = location,
                BackColor = backColor
            };

            panel.Paint += (sender, e) =>
            {
                var graphics = e.Graphics;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw shadow
                var shadowRect = new Rectangle(3, 3, panel.Width, panel.Height);
                using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                {
                    graphics.FillRectangle(shadowBrush, shadowRect);
                }

                // Draw card background
                using (var cardBrush = new SolidBrush(backColor))
                {
                    graphics.FillRectangle(cardBrush, panel.ClientRectangle);
                }

                // Draw subtle border
                using (var borderPen = new Pen(Color.FromArgb(100, 100, 100), 1))
                {
                    graphics.DrawRectangle(borderPen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            };

            return panel;
        }

        public static void ApplyMaterialDataGridView(DataGridView dataGridView)
        {
            // Apply dark theme to DataGridView
            dataGridView.BackgroundColor = Color.FromArgb(55, 55, 58);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Header styling
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(83, 101, 201);
            dataGridView.ColumnHeadersHeight = 40;

            // Cell styling
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(69, 69, 72);
            dataGridView.DefaultCellStyle.ForeColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            
            // Row styling
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(75, 75, 78);
            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(69, 69, 72);
            dataGridView.GridColor = Color.FromArgb(90, 90, 90);
            dataGridView.RowTemplate.Height = 35;

            // Remove row headers
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
        }

        public static void SetLightTheme()
        {
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.BLACK);
        }

        public static void SetDarkTheme()
        {
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Pink200,
                TextShade.WHITE);
        }

        public static void ApplyHoverEffect(Control control, Color normalColor, Color hoverColor)
        {
            control.MouseEnter += (s, e) => control.BackColor = hoverColor;
            control.MouseLeave += (s, e) => control.BackColor = normalColor;
        }

        public static void AddRippleEffect(MaterialButton button)
        {
            // MaterialButton already has ripple effect built-in
            button.UseAccentColor = true;
            button.UseVisualStyleBackColor = true;
        }

        public static class Colors
        {
            public static readonly Color DarkBackground = Color.FromArgb(45, 45, 48);
            public static readonly Color DarkSurface = Color.FromArgb(55, 55, 58);
            public static readonly Color DarkCard = Color.FromArgb(69, 69, 72);
            public static readonly Color DarkBorder = Color.FromArgb(90, 90, 90);
            public static readonly Color Primary = Color.FromArgb(63, 81, 181);
            public static readonly Color PrimaryDark = Color.FromArgb(48, 63, 159);
            public static readonly Color Secondary = Color.FromArgb(76, 175, 80);
            public static readonly Color Accent = Color.FromArgb(255, 64, 129);
            public static readonly Color Warning = Color.FromArgb(255, 152, 0);
            public static readonly Color Error = Color.FromArgb(244, 67, 54);
            public static readonly Color Success = Color.FromArgb(76, 175, 80);
            public static readonly Color Info = Color.FromArgb(33, 150, 243);
            public static readonly Color TextPrimary = Color.White;
            public static readonly Color TextSecondary = Color.FromArgb(180, 180, 180);
            public static readonly Color TextMuted = Color.FromArgb(120, 120, 120);
        }
    }
}