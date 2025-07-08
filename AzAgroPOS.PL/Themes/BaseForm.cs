using AzAgroPOS.PL.Localization;
using System.Drawing;
using System.Windows.Forms;


namespace AzAgroPOS.PL.Themes
{
    public partial class BaseForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
            ApplyBaseStyles();
            LocalizationManager.LanguageChanged += ApplyLocalization;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void ApplyLocalization()
        {
            // Bu metodun məzmunu hər bir formanın özündə yazılacaq.
        }

        /// <summary>
        /// 
        /// </summary>
        private void ApplyBaseStyles()
        {
            this.Font = ThemeManager.BodyFont;
            this.BackColor = ThemeManager.Background;
            this.ForeColor = ThemeManager.TextColor;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Formun daha axıcı görünməsi üçün
            this.DoubleBuffered = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode) // Dizayner pəncərəsində işləməməsi üçün
            {
                ApplyThemeToControls(this.Controls);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controls"></param>

        private void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Button stilləri
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = ThemeManager.ButtonFont;
                    button.ForeColor = Color.White;
                    button.Tag = button.Tag ?? "Secondary"; // Əgər Tag təyin edilməyibsə, standart rəng seçilsin

                    switch (button.Tag.ToString())
                    {
                        case "Primary": button.BackColor = ThemeManager.Primary; break;
                        case "Success": button.BackColor = ThemeManager.Success; break;
                        case "Danger": button.BackColor = ThemeManager.Danger; break;
                        default: button.BackColor = ThemeManager.Secondary; break;
                    }
                }
                // DataGridView stilləri
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = ThemeManager.BackgroundSecondary;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.RowHeadersVisible = false;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.DefaultCellStyle.BackColor = ThemeManager.BackgroundSecondary;
                    dgv.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
                    dgv.DefaultCellStyle.SelectionBackColor = ThemeManager.Primary;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.EnableHeadersVisualStyles = false;

                    if (ThemeManager.CurrentTheme == AppTheme.Light)
                    {
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e9ecef");
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#495057");
                    }
                    else // Dark Theme
                    {
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.Primary;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    }
                }
                // Digər elementlər üçün də stillər əlavə edilə bilər (Label, TextBox vs.)

                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
    }
}