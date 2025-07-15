using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class GiderAddForm : BaseForm
    {
        private readonly GiderService _giderService;
        private readonly IServiceProvider _serviceProvider;

        // UI Controls
        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlForm;
        private Panel pnlButtons;
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblAmount;
        private NumericUpDown nudAmount;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPaymentMethod;
        private ComboBox cmbPaymentMethod;
        private Label lblNotes;
        private TextBox txtNotes;
        private CheckBox chkRequiresApproval;
        private Button btnSave;
        private Button btnCancel;

        public GiderAddForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _giderService = serviceProvider.GetRequiredService<GiderService>();
            _currentUser = currentUser;
            InitializeCustomComponents();
            SetupModernDesign();
        }

        public GiderAddForm(Istifadeci currentUser) : this(currentUser, Program.ServiceProvider)
        {
        }

        private void InitializeCustomComponents()
        {
            // Form settings
            this.Text = "Yeni Gidər Əlavə Et";
            this.Size = new Size(600, 700);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = ModernTheme.Colors.Background;

            // Main panel
            pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(20)
            };

            // Header panel
            pnlHeader = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = ModernTheme.Colors.Primary
            };
            pnlHeader.Paint += PnlHeader_Paint;

            lblTitle = new Label
            {
                Text = "💰 Yeni Gidər Əlavə Et",
                Font = ModernTheme.Fonts.Heading,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 18)
            };
            pnlHeader.Controls.Add(lblTitle);

            // Form panel
            pnlForm = ModernTheme.CreateCard();
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.Padding = new Padding(30);

            // Buttons panel
            pnlButtons = new Panel
            {
                Height = 60,
                Dock = DockStyle.Bottom,
                BackColor = ModernTheme.Colors.Surface,
                Padding = new Padding(20, 10, 20, 10)
            };

            CreateFormControls();
            CreateButtons();
            LoadData();

            // Add controls to main panel
            pnlMain.Controls.AddRange(new Control[] { pnlForm, pnlButtons });

            // Add controls to form
            this.Controls.AddRange(new Control[] { pnlHeader, pnlMain });
        }

        private void CreateFormControls()
        {
            int y = 20;
            int labelHeight = 25;
            int inputHeight = 35;
            int spacing = 15;

            // Expense Name
            lblName = new Label
            {
                Text = "Gidər Adı *",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblName);

            y += labelHeight + 5;
            txtName = new TextBox
            {
                Location = new Point(0, y),
                Size = new Size(500, inputHeight),
                Font = ModernTheme.Fonts.Body
            };
            ModernTheme.ApplyTextBoxStyle(txtName);
            pnlForm.Controls.Add(txtName);

            y += inputHeight + spacing;

            // Description
            lblDescription = new Label
            {
                Text = "Açıqlama",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblDescription);

            y += labelHeight + 5;
            txtDescription = new TextBox
            {
                Location = new Point(0, y),
                Size = new Size(500, 60),
                Font = ModernTheme.Fonts.Body,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            ModernTheme.ApplyTextBoxStyle(txtDescription);
            pnlForm.Controls.Add(txtDescription);

            y += 60 + spacing;

            // Amount
            lblAmount = new Label
            {
                Text = "Məbləğ (₼) *",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblAmount);

            y += labelHeight + 5;
            nudAmount = new NumericUpDown
            {
                Location = new Point(0, y),
                Size = new Size(200, inputHeight),
                Font = ModernTheme.Fonts.Body,
                DecimalPlaces = 2,
                Maximum = 999999.99m,
                Minimum = 0.01m,
                Value = 1.00m
            };
            pnlForm.Controls.Add(nudAmount);

            y += inputHeight + spacing;

            // Date
            lblDate = new Label
            {
                Text = "Tarix *",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblDate);

            y += labelHeight + 5;
            dtpDate = new DateTimePicker
            {
                Location = new Point(0, y),
                Size = new Size(200, inputHeight),
                Font = ModernTheme.Fonts.Body,
                Value = DateTime.Now
            };
            pnlForm.Controls.Add(dtpDate);

            y += inputHeight + spacing;

            // Category
            lblCategory = new Label
            {
                Text = "Kateqoriya *",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblCategory);

            y += labelHeight + 5;
            cmbCategory = new ComboBox
            {
                Location = new Point(0, y),
                Size = new Size(300, inputHeight),
                Font = ModernTheme.Fonts.Body,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            ModernTheme.ApplyComboBoxStyle(cmbCategory);
            pnlForm.Controls.Add(cmbCategory);

            y += inputHeight + spacing;

            // Payment Method
            lblPaymentMethod = new Label
            {
                Text = "Ödəmə Üsulu",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblPaymentMethod);

            y += labelHeight + 5;
            cmbPaymentMethod = new ComboBox
            {
                Location = new Point(0, y),
                Size = new Size(300, inputHeight),
                Font = ModernTheme.Fonts.Body,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            ModernTheme.ApplyComboBoxStyle(cmbPaymentMethod);
            pnlForm.Controls.Add(cmbPaymentMethod);

            y += inputHeight + spacing;

            // Notes
            lblNotes = new Label
            {
                Text = "Qeyd",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, labelHeight)
            };
            pnlForm.Controls.Add(lblNotes);

            y += labelHeight + 5;
            txtNotes = new TextBox
            {
                Location = new Point(0, y),
                Size = new Size(500, 60),
                Font = ModernTheme.Fonts.Body,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            ModernTheme.ApplyTextBoxStyle(txtNotes);
            pnlForm.Controls.Add(txtNotes);

            y += 60 + spacing;

            // Requires Approval checkbox
            chkRequiresApproval = new CheckBox
            {
                Text = "Təsdiq tələb edir",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(200, 25),
                Checked = true
            };
            pnlForm.Controls.Add(chkRequiresApproval);
        }

        private void CreateButtons()
        {
            // Save button
            btnSave = new Button
            {
                Text = "💾 Yadda Saxla",
                Size = new Size(120, 40),
                Location = new Point(pnlButtons.Width - 260, 10),
                Font = ModernTheme.Fonts.Button,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnSave.Click += BtnSave_Click;
            ModernTheme.ApplyButtonStyle(btnSave, true);
            pnlButtons.Controls.Add(btnSave);

            // Cancel button
            btnCancel = new Button
            {
                Text = "❌ Ləğv Et",
                Size = new Size(120, 40),
                Location = new Point(pnlButtons.Width - 130, 10),
                Font = ModernTheme.Fonts.Button,
                DialogResult = DialogResult.Cancel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnCancel.Click += BtnCancel_Click;
            ModernTheme.ApplyButtonStyle(btnCancel, false);
            pnlButtons.Controls.Add(btnCancel);

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void LoadData()
        {
            // Load categories
            var categories = _giderService.GetExpenseCategories();
            cmbCategory.Items.AddRange(categories.ToArray());
            if (categories.Count > 0)
                cmbCategory.SelectedIndex = 0;

            // Load payment methods
            var paymentMethods = _giderService.GetPaymentMethods();
            cmbPaymentMethod.Items.AddRange(paymentMethods.ToArray());
            if (paymentMethods.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
        }

        private void SetupModernDesign()
        {
            ModernTheme.ApplyModernStyle(this);
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnlHeader.ClientRectangle,
                ModernTheme.Colors.Primary,
                ModernTheme.Colors.PrimaryDark,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                btnSave.Enabled = false;
                btnSave.Text = "Yadda saxlanılır...";

                var expense = new Gider
                {
                    Ad = txtName.Text.Trim(),
                    Aciqlama = txtDescription.Text.Trim(),
                    Mebleg = nudAmount.Value,
                    Tarix = dtpDate.Value,
                    Kateqoriya = cmbCategory.SelectedItem?.ToString(),
                    OdemeUsulu = cmbPaymentMethod.SelectedItem?.ToString(),
                    Qeyd = txtNotes.Text.Trim(),
                    IstifadeciId = _currentUser.Id,
                    TesdiqEdildi = !chkRequiresApproval.Checked // If doesn't require approval, auto-approve
                };

                if (!chkRequiresApproval.Checked)
                {
                    expense.TesdiqTarixi = DateTime.Now;
                    expense.Tesdiqleyen = _currentUser.TamAd;
                }

                await _giderService.CreateExpenseAsync(expense);

                MessageBox.Show("Gidər uğurla əlavə edildi.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gidər əlavə edilərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Yadda Saxla";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (HasUnsavedChanges())
            {
                if (MessageBox.Show("Edilmiş dəyişikliklər yadda saxlanılmayacaq. Çıxmaq istədiyinizə əminsiniz?", 
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Gidər adı mütləqdir.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Məbləğ sıfırdan böyük olmalıdır.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudAmount.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Kateqoriya seçilməlidir.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (dtpDate.Value > DateTime.Now)
            {
                MessageBox.Show("Gidər tarixi bugündən sonra ola bilməz.", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
                return false;
            }

            return true;
        }

        private bool HasUnsavedChanges()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text) ||
                   !string.IsNullOrWhiteSpace(txtDescription.Text) ||
                   nudAmount.Value != 1.00m ||
                   cmbCategory.SelectedIndex >= 0 ||
                   !string.IsNullOrWhiteSpace(txtNotes.Text);
        }
    }
}