using System;
using System.Drawing;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Themes
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            InitializeBaseSettings();
        }

        private void InitializeBaseSettings()
        {
            this.BackColor = ColorPalette.Background;
            this.Font = FontStyles.Body;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyThemeToControls(this.Controls);
        }

        private void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                ApplyStyleToControl(control);

                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }

        private void ApplyStyleToControl(Control control)
        {
            if (control is Button)
                StyleButton((Button)control);
            else if (control is Label)
                StyleLabel((Label)control);
            else if (control is TextBox)
                StyleTextBox((TextBox)control);
            else if (control is ComboBox)
                StyleComboBox((ComboBox)control);
            else if (control is GroupBox)
                StyleGroupBox((GroupBox)control);
            else if (control is Panel)
                StylePanel((Panel)control);
            else if (control is TabControl)
                StyleTabControl((TabControl)control);
            else if (control is CheckBox)
                StyleCheckBox((CheckBox)control);
            else if (control is RadioButton)
                StyleRadioButton((RadioButton)control);
            else if (control is DataGridView)
                StyleDataGridView((DataGridView)control);
        }

        private void StyleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = FontStyles.Button;
            button.Padding = new Padding(10, 5, 10, 5);
            button.ForeColor = ColorPalette.White;

            string tag = button.Tag != null ? button.Tag.ToString() : string.Empty;

            if (tag == "Primary")
                button.BackColor = ColorPalette.Primary;
            else if (tag == "Success")
                button.BackColor = ColorPalette.Success;
            else if (tag == "Danger")
                button.BackColor = ColorPalette.Danger;
            else
                button.BackColor = ColorPalette.Secondary;
        }

        private void StyleLabel(Label label)
        {
            label.ForeColor = ColorPalette.TextPrimary;
            label.Font = FontStyles.Label;
            label.BackColor = Color.Transparent;
        }

        private void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = FontStyles.Input;
            textBox.ForeColor = ColorPalette.TextPrimary;
            textBox.BackColor = ColorPalette.InputBackground;
        }

        private void StyleComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = FontStyles.Input;
            comboBox.ForeColor = ColorPalette.TextPrimary;
            comboBox.BackColor = ColorPalette.InputBackground;
        }

        private void StyleGroupBox(GroupBox groupBox)
        {
            groupBox.Font = FontStyles.GroupHeader;
            groupBox.ForeColor = ColorPalette.TextSecondary;
            groupBox.BackColor = Color.Transparent;
            groupBox.Padding = new Padding(10);
        }

        private void StylePanel(Panel panel)
        {
            panel.BackColor = ColorPalette.PanelBackground;
        }

        private void StyleTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.Normal;
            tabControl.Font = FontStyles.Body;
            tabControl.BackColor = ColorPalette.Background;
            tabControl.ForeColor = ColorPalette.TextPrimary;
        }

        private void StyleCheckBox(CheckBox checkBox)
        {
            checkBox.Font = FontStyles.Body;
            checkBox.ForeColor = ColorPalette.TextPrimary;
            checkBox.BackColor = Color.Transparent;
            checkBox.AutoSize = true;
        }

        private void StyleRadioButton(RadioButton radioButton)
        {
            radioButton.Font = FontStyles.Body;
            radioButton.ForeColor = ColorPalette.TextPrimary;
            radioButton.BackColor = Color.Transparent;
            radioButton.AutoSize = true;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorPalette.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPalette.Sidebar;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorPalette.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}
