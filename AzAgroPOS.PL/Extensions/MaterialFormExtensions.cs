using MaterialSkin;
using MaterialSkin.Controls;
using FontAwesome.Sharp;
using AzAgroPOS.PL.Styles;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Extensions
{
    public static class MaterialFormExtensions
    {
        public static void ApplyMaterialDesign(this Form form)
        {
            if (form is MaterialForm materialForm)
            {
                MaterialTheme.ApplyMaterialTheme(materialForm);
            }
            else
            {
                // Apply material-like styling to regular forms
                form.BackColor = MaterialTheme.Colors.DarkBackground;
                form.ForeColor = MaterialTheme.Colors.TextPrimary;
                form.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                
                ApplyMaterialStyleToControls(form);
            }
        }

        private static void ApplyMaterialStyleToControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                switch (control)
                {
                    case Button btn:
                        ApplyMaterialButtonStyle(btn);
                        break;
                    case TextBox txt:
                        ApplyMaterialTextBoxStyle(txt);
                        break;
                    case ComboBox cmb:
                        ApplyMaterialComboBoxStyle(cmb);
                        break;
                    case DataGridView dgv:
                        MaterialTheme.ApplyMaterialDataGridView(dgv);
                        break;
                    case Panel panel:
                        ApplyMaterialPanelStyle(panel);
                        break;
                    case Label lbl:
                        ApplyMaterialLabelStyle(lbl);
                        break;
                    case GroupBox gb:
                        ApplyMaterialGroupBoxStyle(gb);
                        break;
                    case TabControl tab:
                        ApplyMaterialTabControlStyle(tab);
                        break;
                }

                // Recursively apply to child controls
                if (control.HasChildren)
                {
                    ApplyMaterialStyleToControls(control);
                }
            }
        }

        private static void ApplyMaterialButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.BackColor = MaterialTheme.Colors.Primary;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Height = Math.Max(button.Height, 36);

            // Add hover effect
            MaterialTheme.ApplyHoverEffect(button, 
                MaterialTheme.Colors.Primary, 
                MaterialTheme.Colors.PrimaryDark);

            // Add ripple effect simulation
            button.Paint += (sender, e) =>
            {
                var graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw button background with slight gradient
                using (var brush = new LinearGradientBrush(button.ClientRectangle, 
                    button.BackColor, 
                    ControlPaint.Dark(button.BackColor, 0.1f), 
                    LinearGradientMode.Vertical))
                {
                    graphics.FillRectangle(brush, button.ClientRectangle);
                }
            };
        }

        private static void ApplyMaterialTextBoxStyle(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            textBox.BackColor = MaterialTheme.Colors.DarkCard;
            textBox.ForeColor = MaterialTheme.Colors.TextPrimary;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Height = Math.Max(textBox.Height, 32);
            textBox.Padding = new Padding(8);

            // Add focus effect
            textBox.GotFocus += (s, e) =>
            {
                textBox.BackColor = MaterialTheme.Colors.DarkSurface;
            };

            textBox.LostFocus += (s, e) =>
            {
                textBox.BackColor = MaterialTheme.Colors.DarkCard;
            };
        }

        private static void ApplyMaterialComboBoxStyle(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            comboBox.BackColor = MaterialTheme.Colors.DarkCard;
            comboBox.ForeColor = MaterialTheme.Colors.TextPrimary;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Height = Math.Max(comboBox.Height, 32);
        }

        private static void ApplyMaterialPanelStyle(Panel panel)
        {
            // Apply card-like styling to panels
            if (panel.Name.Contains("Card") || panel.Name.Contains("card"))
            {
                panel.BackColor = MaterialTheme.Colors.DarkCard;
                
                panel.Paint += (sender, e) =>
                {
                    var graphics = e.Graphics;
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    // Draw subtle shadow
                    var shadowRect = new Rectangle(2, 2, panel.Width, panel.Height);
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                    {
                        graphics.FillRectangle(shadowBrush, shadowRect);
                    }
                    
                    // Draw card background
                    using (var cardBrush = new SolidBrush(panel.BackColor))
                    {
                        graphics.FillRectangle(cardBrush, panel.ClientRectangle);
                    }
                    
                    // Draw subtle border
                    using (var borderPen = new Pen(MaterialTheme.Colors.DarkBorder, 1))
                    {
                        graphics.DrawRectangle(borderPen, 0, 0, panel.Width - 1, panel.Height - 1);
                    }
                };
            }
            else
            {
                panel.BackColor = MaterialTheme.Colors.DarkBackground;
            }
        }

        private static void ApplyMaterialLabelStyle(Label label)
        {
            label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label.ForeColor = MaterialTheme.Colors.TextPrimary;
            label.BackColor = Color.Transparent;
            
            // Apply different styles based on label purpose
            if (label.Name.Contains("Title") || label.Name.Contains("title"))
            {
                label.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            }
            else if (label.Name.Contains("Heading") || label.Name.Contains("heading"))
            {
                label.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
            else if (label.Name.Contains("Caption") || label.Name.Contains("caption"))
            {
                label.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                label.ForeColor = MaterialTheme.Colors.TextSecondary;
            }
        }

        private static void ApplyMaterialGroupBoxStyle(GroupBox groupBox)
        {
            groupBox.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            groupBox.ForeColor = MaterialTheme.Colors.TextPrimary;
            groupBox.BackColor = Color.Transparent;
            
            groupBox.Paint += (sender, e) =>
            {
                var graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Draw custom border
                using (var borderPen = new Pen(MaterialTheme.Colors.Primary, 2))
                {
                    graphics.DrawRectangle(borderPen, 1, 8, groupBox.Width - 2, groupBox.Height - 10);
                }
                
                // Draw title background
                var titleSize = graphics.MeasureString(groupBox.Text, groupBox.Font);
                using (var titleBrush = new SolidBrush(MaterialTheme.Colors.DarkBackground))
                {
                    graphics.FillRectangle(titleBrush, 10, 0, titleSize.Width + 4, titleSize.Height);
                }
            };
        }

        private static void ApplyMaterialTabControlStyle(TabControl tabControl)
        {
            tabControl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.ItemSize = new Size(100, 40);
            
            tabControl.DrawItem += (sender, e) =>
            {
                var graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                var isSelected = e.Index == tabControl.SelectedIndex;
                var backColor = isSelected ? MaterialTheme.Colors.Primary : MaterialTheme.Colors.DarkCard;
                var foreColor = isSelected ? Color.White : MaterialTheme.Colors.TextSecondary;
                
                // Draw tab background
                using (var brush = new SolidBrush(backColor))
                {
                    graphics.FillRectangle(brush, e.Bounds);
                }
                
                // Draw tab text
                using (var brush = new SolidBrush(foreColor))
                {
                    var stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    graphics.DrawString(tabControl.TabPages[e.Index].Text, 
                        tabControl.Font, brush, e.Bounds, stringFormat);
                }
                
                // Draw selection indicator
                if (isSelected)
                {
                    using (var pen = new Pen(MaterialTheme.Colors.Accent, 3))
                    {
                        graphics.DrawLine(pen, e.Bounds.X, e.Bounds.Bottom - 2, 
                            e.Bounds.Right, e.Bounds.Bottom - 2);
                    }
                }
            };
        }

        public static IconButton CreateIconButton(string text, IconChar icon, Color backColor, Size size)
        {
            var button = new IconButton
            {
                Text = text,
                Size = size,
                IconChar = icon,
                IconColor = Color.White,
                IconSize = 16,
                TextAlign = ContentAlignment.MiddleRight,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };

            button.FlatAppearance.BorderSize = 0;
            MaterialTheme.ApplyHoverEffect(button, backColor, ControlPaint.Dark(backColor, 0.1f));

            return button;
        }

        public static void AddGlowEffect(Control control, Color glowColor)
        {
            control.Paint += (sender, e) =>
            {
                var graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                using (var path = new GraphicsPath())
                {
                    path.AddRectangle(control.ClientRectangle);
                    using (var brush = new PathGradientBrush(path))
                    {
                        brush.CenterColor = Color.Transparent;
                        brush.SurroundColors = new[] { Color.FromArgb(50, glowColor) };
                        graphics.FillPath(brush, path);
                    }
                }
            };
        }
    }
}