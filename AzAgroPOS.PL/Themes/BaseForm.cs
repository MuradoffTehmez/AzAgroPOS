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
            this.Padding = new Padding(20); // Add padding for better spacing
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
            else if (control is NumericUpDown)
                StyleNumericUpDown((NumericUpDown)control);
            else if (control is DateTimePicker)
                StyleDateTimePicker((DateTimePicker)control);
        }

        private void StyleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = FontStyles.Button;
            button.Padding = new Padding(12, 6, 12, 6);
            button.ForeColor = ColorPalette.White;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(
                Math.Min(button.BackColor.R + 20, 255),
                Math.Min(button.BackColor.G + 20, 255),
                Math.Min(button.BackColor.B + 20, 255)
            );

            string tag = button.Tag != null ? button.Tag.ToString() : string.Empty;

            if (tag == "Primary")
                button.BackColor = ColorPalette.Primary;
            else if (tag == "Success")
                button.BackColor = ColorPalette.Success;
            else if (tag == "Danger")
                button.BackColor = ColorPalette.Danger;
            else if (tag == "Warning")
                button.BackColor = ColorPalette.Warning;
            else if (tag == "Info")
                button.BackColor = ColorPalette.Info;
            else if (tag == "Large")
            {
                button.BackColor = ColorPalette.Primary;
                button.Font = FontStyles.ButtonLarge;
                button.Padding = new Padding(16, 8, 16, 8);
            }
            else
                button.BackColor = ColorPalette.Secondary;
        }

        private void StyleLabel(Label label)
        {
            label.ForeColor = ColorPalette.TextPrimary;
            label.Font = FontStyles.Label;
            label.BackColor = Color.Transparent;

            if (label.Tag?.ToString() == "Title")
            {
                label.Font = FontStyles.Title;
                label.ForeColor = ColorPalette.Primary;
            }
            else if (label.Tag?.ToString() == "Subtitle")
            {
                label.Font = FontStyles.Subtitle;
                label.ForeColor = ColorPalette.TextSecondary;
            }
            else if (label.Tag?.ToString() == "Bold")
            {
                label.Font = FontStyles.LabelBold;
            }
        }

        private void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = FontStyles.Input;
            textBox.ForeColor = ColorPalette.TextPrimary;
            textBox.BackColor = ColorPalette.InputBackground;
            textBox.Margin = new Padding(0, 0, 0, 10);
        }

        private void StyleComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = FontStyles.Input;
            comboBox.ForeColor = ColorPalette.TextPrimary;
            comboBox.BackColor = ColorPalette.InputBackground;
            comboBox.Margin = new Padding(0, 0, 0, 10);
        }

        private void StyleGroupBox(GroupBox groupBox)
        {
            groupBox.Font = FontStyles.GroupHeader;
            groupBox.ForeColor = ColorPalette.TextSecondary;
            groupBox.BackColor = Color.Transparent;
            groupBox.Padding = new Padding(10, 15, 10, 15);
        }

        private void StylePanel(Panel panel)
        {
            panel.BackColor = ColorPalette.PanelBackground;
            panel.Padding = new Padding(10);
            panel.BorderStyle = BorderStyle.FixedSingle;
            //panel.BorderColor = ColorPalette.Border;
        }

        private void StyleTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.Normal;
            tabControl.Font = FontStyles.Body;
            tabControl.BackColor = ColorPalette.Background;
            tabControl.ForeColor = ColorPalette.TextPrimary;
            tabControl.Padding = new Point(12, 4);
        }

        private void StyleCheckBox(CheckBox checkBox)
        {
            checkBox.Font = FontStyles.Body;
            checkBox.ForeColor = ColorPalette.TextPrimary;
            checkBox.BackColor = Color.Transparent;
            checkBox.AutoSize = true;
            checkBox.FlatStyle = FlatStyle.Flat;
        }

        private void StyleRadioButton(RadioButton radioButton)
        {
            radioButton.Font = FontStyles.Body;
            radioButton.ForeColor = ColorPalette.TextPrimary;
            radioButton.BackColor = Color.Transparent;
            radioButton.AutoSize = true;
            radioButton.FlatStyle = FlatStyle.Flat;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorPalette.CardBackground;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = ColorPalette.Border;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorPalette.Hover;

            dgv.DefaultCellStyle.Font = FontStyles.DataGridCell;
            dgv.DefaultCellStyle.BackColor = ColorPalette.CardBackground;
            dgv.DefaultCellStyle.ForeColor = ColorPalette.TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = ColorPalette.PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor = ColorPalette.TextPrimary;
            dgv.DefaultCellStyle.Padding = new Padding(5);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPalette.Primary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorPalette.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontStyles.DataGridHeader;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
        }

        private void StyleNumericUpDown(NumericUpDown numeric)
        {
            numeric.BorderStyle = BorderStyle.FixedSingle;
            numeric.Font = FontStyles.Input;
            numeric.ForeColor = ColorPalette.TextPrimary;
            numeric.BackColor = ColorPalette.InputBackground;
            numeric.Margin = new Padding(0, 0, 0, 10);
        }

        private void StyleDateTimePicker(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Font = FontStyles.Input;
            dateTimePicker.ForeColor = ColorPalette.TextPrimary;
            dateTimePicker.BackColor = ColorPalette.InputBackground;
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Margin = new Padding(0, 0, 0, 10);
        }
    }
}