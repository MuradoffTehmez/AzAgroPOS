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
    public partial class GiderEditForm : BaseForm
    {
        private readonly GiderService _giderService;
        private readonly IServiceProvider _serviceProvider;
        private readonly int _expenseId;
        private Gider _originalExpense;

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
        private Label lblApprovalStatus;
        private Label lblApprovalInfo;
        private Button btnSave;
        private Button btnCancel;

        public GiderEditForm(int expenseId, Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            _expenseId = expenseId;
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _giderService = serviceProvider.GetRequiredService<GiderService>();
            _currentUser = currentUser;
            InitializeCustomComponents();
            SetupModernDesign();
            this.Load += GiderEditForm_Load;
        }

        public GiderEditForm(int expenseId, Istifadeci currentUser) : this(expenseId, currentUser, Program.ServiceProvider)
        {
        }

        private async void GiderEditForm_Load(object sender, EventArgs e)
        {
            await LoadExpenseAsync();
        }

        private void InitializeCustomComponents()
        {
            // Form settings
            this.Text = "Gidər Redaktəsi";
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
                BackColor = ModernTheme.Colors.Warning
            };
            pnlHeader.Paint += PnlHeader_Paint;

            lblTitle = new Label
            {
                Text = "✏️ Gidər Redaktəsi",
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

            // Approval Status Info
            lblApprovalStatus = new Label
            {
                Text = "Status:",
                Font = ModernTheme.Fonts.BodyBold,
                ForeColor = ModernTheme.Colors.TextPrimary,
                Location = new Point(0, y),
                Size = new Size(80, labelHeight)
            };
            pnlForm.Controls.Add(lblApprovalStatus);

            lblApprovalInfo = new Label
            {
                Text = "Yüklənir...",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.Warning,
                Location = new Point(90, y),
                Size = new Size(300, labelHeight)
            };
            pnlForm.Controls.Add(lblApprovalInfo);

            y += labelHeight + spacing;

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
                Minimum = 0.01m
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
                Font = ModernTheme.Fonts.Body
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

            // Load payment methods
            var paymentMethods = _giderService.GetPaymentMethods();
            cmbPaymentMethod.Items.AddRange(paymentMethods.ToArray());
        }

        private async Task LoadExpenseAsync()
        {
            try
            {
                _originalExpense = await _giderService.GetExpenseByIdAsync(_expenseId);
                if (_originalExpense == null)
                {
                    MessageBox.Show("Gidər tapılmadı.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Populate form with expense data
                txtName.Text = _originalExpense.Ad;
                txtDescription.Text = _originalExpense.Aciqlama ?? "";
                nudAmount.Value = _originalExpense.Mebleg;
                dtpDate.Value = _originalExpense.Tarix;
                txtNotes.Text = _originalExpense.Qeyd ?? "";

                // Set category
                if (!string.IsNullOrEmpty(_originalExpense.Kateqoriya))
                {
                    var categoryIndex = cmbCategory.Items.IndexOf(_originalExpense.Kateqoriya);
                    if (categoryIndex >= 0)
                        cmbCategory.SelectedIndex = categoryIndex;
                }

                // Set payment method
                if (!string.IsNullOrEmpty(_originalExpense.OdemeUsulu))
                {
                    var paymentIndex = cmbPaymentMethod.Items.IndexOf(_originalExpense.OdemeUsulu);
                    if (paymentIndex >= 0)
                        cmbPaymentMethod.SelectedIndex = paymentIndex;
                }

                // Update approval status display
                UpdateApprovalStatusDisplay();

                // Disable editing if already approved
                if (_originalExpense.TesdiqEdildi)
                {
                    DisableFormForApprovedExpense();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gidər yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void UpdateApprovalStatusDisplay()
        {
            if (_originalExpense.TesdiqEdildi)
            {
                lblApprovalInfo.Text = $"Təsdiqləndi - {_originalExpense.Tesdiqleyen} ({_originalExpense.TesdiqTarixi?.ToString("dd.MM.yyyy HH:mm")})";
                lblApprovalInfo.ForeColor = ModernTheme.Colors.Success;
            }
            else
            {
                lblApprovalInfo.Text = "Təsdiq gözləyir";
                lblApprovalInfo.ForeColor = ModernTheme.Colors.Warning;
            }
        }

        private void DisableFormForApprovedExpense()
        {
            txtName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            nudAmount.Enabled = false;
            dtpDate.Enabled = false;
            cmbCategory.Enabled = false;
            cmbPaymentMethod.Enabled = false;
            txtNotes.ReadOnly = true;
            btnSave.Enabled = false;
            btnSave.Text = "Təsdiqlənib (Dəyişdirilə bilməz)";

            // Change form colors to indicate read-only
            pnlHeader.BackColor = ModernTheme.Colors.TextSecondary;
            lblTitle.Text = "📋 Gidər Məlumatları (Oxunur)";
        }

        private void SetupModernDesign()
        {
            ModernTheme.ApplyModernStyle(this);
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnlHeader.ClientRectangle,
                pnlHeader.BackColor,
                Color.FromArgb(Math.Max(0, pnlHeader.BackColor.R - 30),
                              Math.Max(0, pnlHeader.BackColor.G - 30),
                              Math.Max(0, pnlHeader.BackColor.B - 30)),
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

                if (_originalExpense.TesdiqEdildi)
                {
                    MessageBox.Show("Təsdiqlənmiş gidər dəyişdirilə bilməz.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnSave.Enabled = false;
                btnSave.Text = "Yadda saxlanılır...";

                // Update expense properties
                _originalExpense.Ad = txtName.Text.Trim();
                _originalExpense.Aciqlama = txtDescription.Text.Trim();
                _originalExpense.Mebleg = nudAmount.Value;
                _originalExpense.Tarix = dtpDate.Value;
                _originalExpense.Kateqoriya = cmbCategory.SelectedItem?.ToString();
                _originalExpense.OdemeUsulu = cmbPaymentMethod.SelectedItem?.ToString();
                _originalExpense.Qeyd = txtNotes.Text.Trim();

                await _giderService.UpdateExpenseAsync(_originalExpense);

                MessageBox.Show("Gidər uğurla yeniləndi.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gidər yenilənərkən xəta: {ex.Message}", "Xəta", 
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
            if (_originalExpense == null)
                return false;

            return txtName.Text.Trim() != _originalExpense.Ad ||
                   txtDescription.Text.Trim() != (_originalExpense.Aciqlama ?? "") ||
                   nudAmount.Value != _originalExpense.Mebleg ||
                   dtpDate.Value.Date != _originalExpense.Tarix.Date ||
                   cmbCategory.SelectedItem?.ToString() != _originalExpense.Kateqoriya ||
                   cmbPaymentMethod.SelectedItem?.ToString() != _originalExpense.OdemeUsulu ||
                   txtNotes.Text.Trim() != (_originalExpense.Qeyd ?? "");
        }
    }
}