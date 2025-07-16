using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class GiderManagementForm : BaseForm
    {
        private readonly GiderService _giderService;
        private readonly IServiceProvider _serviceProvider;

        // UI Controls
        private Panel pnlHeader;
        private Panel pnlStats;
        private Panel pnlControls;
        private Panel pnlData;
        private DataGridView dgvExpenses;
        private ComboBox cmbCategory;
        private ComboBox cmbApprovalStatus;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClearFilter;
        private Button btnAddExpense;
        private Button btnEditExpense;
        private Button btnApproveExpense;
        private Button btnDeleteExpense;
        private Button btnRefresh;
        private Label lblFormTitle;
        private Label lblTotalExpenses;
        private Label lblPendingExpenses;
        private Label lblMonthlyExpenses;
        private Label lblCategoryCount;

        public GiderManagementForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _giderService = serviceProvider.GetRequiredService<GiderService>();
            _currentUser = currentUser;
            SetupModernDesign();
            this.Load += GiderManagementForm_Load;
        }

        public GiderManagementForm(Istifadeci currentUser) : this(currentUser, Program.ServiceProvider)
        {
        }

        private async void GiderManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCategories();
            await LoadExpensesAsync();
            await LoadStatisticsAsync();
        }

        protected override async void OnFormLoad()
        {
            await LoadExpensesAsync();
        }

        private void SetupModernDesign()
        {
            this.Text = "💰 Gidər İdarəetməsi";
            this.BackColor = ModernTheme.Colors.Background;
            this.Font = ModernTheme.Fonts.Body;
            this.WindowState = FormWindowState.Maximized;
            
            CreateModernLayout();
            ModernTheme.ApplyModernStyle(this);
        }

        private void CreateModernLayout()
        {
            // Create header panel
            var headerPanel = ModernTheme.CreateHeader("Gidər İdarəetməsi");
            this.Controls.Add(headerPanel);

            // Create main content panel
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.Colors.Background,
                Padding = new Padding(ModernTheme.Layout.Padding)
            };
            
            // Create statistics panel
            var statsPanel = CreateStatisticsPanel();
            statsPanel.Dock = DockStyle.Top;
            statsPanel.Height = 120;
            mainPanel.Controls.Add(statsPanel);

            // Create filter panel
            var filterPanel = CreateFilterPanel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 100;
            mainPanel.Controls.Add(filterPanel);

            // Create data grid panel
            var gridPanel = CreateDataGridPanel();
            gridPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(gridPanel);

            // Create action buttons panel
            var buttonPanel = CreateActionButtonsPanel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 60;
            mainPanel.Controls.Add(buttonPanel);

            this.Controls.Add(mainPanel);
        }

        private Panel CreateStatisticsPanel()
        {
            var panel = ModernTheme.CreateCard();
            panel.Height = 120;
            panel.Margin = new Padding(0, 0, 0, ModernTheme.Layout.Margin);

            var titleLabel = new Label
            {
                Text = "Gidər Statistikaları",
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(ModernTheme.Layout.Padding, 10)
            };
            panel.Controls.Add(titleLabel);

            int x = ModernTheme.Layout.Padding;
            int y = 40;

            // Total Expenses
            var totalPanel = CreateStatCard("Ümumi Gidər", "0 ₼", ModernTheme.Colors.Danger);
            totalPanel.Location = new Point(x, y);
            totalPanel.Size = new Size(200, 60);
            panel.Controls.Add(totalPanel);

            // Pending Expenses
            x += 220;
            var pendingPanel = CreateStatCard("Gözləyən", "0 ₼", ModernTheme.Colors.Warning);
            pendingPanel.Location = new Point(x, y);
            pendingPanel.Size = new Size(200, 60);
            panel.Controls.Add(pendingPanel);

            // Monthly Expenses
            x += 220;
            var monthlyPanel = CreateStatCard("Bu Ay", "0 ₼", ModernTheme.Colors.Info);
            monthlyPanel.Location = new Point(x, y);
            monthlyPanel.Size = new Size(200, 60);
            panel.Controls.Add(monthlyPanel);

            // Category Count
            x += 220;
            var categoryPanel = CreateStatCard("Kateqoriya Sayı", "0", ModernTheme.Colors.Secondary);
            categoryPanel.Location = new Point(x, y);
            categoryPanel.Size = new Size(200, 60);
            panel.Controls.Add(categoryPanel);

            // Initialize labels for updating
            lblTotalExpenses = totalPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            lblPendingExpenses = pendingPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            lblMonthlyExpenses = monthlyPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            lblCategoryCount = categoryPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");

            return panel;
        }

        private Panel CreateStatCard(string title, string value, Color color)
        {
            var panel = new Panel
            {
                BackColor = color,
                Padding = new Padding(15, 10, 15, 10)
            };

            var titleLbl = new Label
            {
                Text = title,
                Font = ModernTheme.Fonts.Caption,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(0, 5)
            };
            panel.Controls.Add(titleLbl);

            var valueLbl = new Label
            {
                Text = value,
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(0, 25),
                Tag = "value"
            };
            panel.Controls.Add(valueLbl);

            return panel;
        }

        private Panel CreateFilterPanel()
        {
            var panel = ModernTheme.CreateCard();
            panel.Height = 100;
            panel.Margin = new Padding(0, 0, 0, ModernTheme.Layout.Margin);

            var titleLabel = new Label
            {
                Text = "Filtr və Axtarış",
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(ModernTheme.Layout.Padding, 10)
            };
            panel.Controls.Add(titleLabel);

            // First row
            int x = ModernTheme.Layout.Padding;
            int y = 40;

            // Search textbox
            var searchLabel = new Label
            {
                Text = "Axtarış:",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(x, y - 2)
            };
            panel.Controls.Add(searchLabel);

            txtSearch = new TextBox
            {
                Location = new Point(x + 60, y - 5),
                Size = new Size(150, ModernTheme.Layout.InputHeight),
                Font = ModernTheme.Fonts.Body
            };
            ModernTheme.ApplyTextBoxStyle(txtSearch);
            panel.Controls.Add(txtSearch);

            // Category dropdown
            x += 230;
            var categoryLabel = new Label
            {
                Text = "Kateqoriya:",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(x, y - 2)
            };
            panel.Controls.Add(categoryLabel);

            cmbCategory = new ComboBox
            {
                Location = new Point(x + 80, y - 5),
                Size = new Size(150, ModernTheme.Layout.InputHeight),
                Font = ModernTheme.Fonts.Body,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            ModernTheme.ApplyComboBoxStyle(cmbCategory);
            panel.Controls.Add(cmbCategory);

            // Approval status dropdown
            x += 250;
            var statusLabel = new Label
            {
                Text = "Status:",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(x, y - 2)
            };
            panel.Controls.Add(statusLabel);

            cmbApprovalStatus = new ComboBox
            {
                Location = new Point(x + 60, y - 5),
                Size = new Size(120, ModernTheme.Layout.InputHeight),
                Font = ModernTheme.Fonts.Body,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbApprovalStatus.Items.AddRange(new[] { "Hamısı", "Təsdiqləndi", "Gözləyir" });
            cmbApprovalStatus.SelectedIndex = 0;
            ModernTheme.ApplyComboBoxStyle(cmbApprovalStatus);
            panel.Controls.Add(cmbApprovalStatus);

            // Second row
            x = ModernTheme.Layout.Padding;
            y += 35;

            // Date range
            var dateLabel = new Label
            {
                Text = "Tarix aralığı:",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(x, y - 2)
            };
            panel.Controls.Add(dateLabel);

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(x + 100, y - 5),
                Size = new Size(120, ModernTheme.Layout.InputHeight),
                Font = ModernTheme.Fonts.Body,
                Value = DateTime.Now.AddMonths(-1)
            };
            panel.Controls.Add(dtpStartDate);

            x += 240;
            var toLabel = new Label
            {
                Text = "-",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(x, y - 2)
            };
            panel.Controls.Add(toLabel);

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(x + 20, y - 5),
                Size = new Size(120, ModernTheme.Layout.InputHeight),
                Font = ModernTheme.Fonts.Body,
                Value = DateTime.Now
            };
            panel.Controls.Add(dtpEndDate);

            // Buttons
            x += 160;
            btnSearch = new Button
            {
                Text = "🔍 Axtar",
                Location = new Point(x, y - 5),
                Size = new Size(80, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnSearch.Click += BtnSearch_Click;
            ModernTheme.ApplyButtonStyle(btnSearch);
            panel.Controls.Add(btnSearch);

            x += 100;
            btnClearFilter = new Button
            {
                Text = "🗑️ Təmizlə",
                Location = new Point(x, y - 5),
                Size = new Size(90, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnClearFilter.Click += BtnClearFilter_Click;
            ModernTheme.ApplyButtonStyle(btnClearFilter, false);
            panel.Controls.Add(btnClearFilter);

            return panel;
        }

        private Panel CreateDataGridPanel()
        {
            var panel = ModernTheme.CreateCard();
            panel.Margin = new Padding(0, 0, 0, ModernTheme.Layout.Margin);

            var titleLabel = new Label
            {
                Text = "Gidər Siyahısı",
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(ModernTheme.Layout.Padding, 10)
            };
            panel.Controls.Add(titleLabel);

            dgvExpenses = new DataGridView
            {
                Location = new Point(ModernTheme.Layout.Padding, 40),
                Size = new Size(panel.Width - (ModernTheme.Layout.Padding * 2), 
                               panel.Height - 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            dgvExpenses.CellDoubleClick += DgvExpenses_CellDoubleClick;
            panel.Controls.Add(dgvExpenses);

            return panel;
        }

        private Panel CreateActionButtonsPanel()
        {
            var panel = ModernTheme.CreateCard();
            panel.Height = 60;

            // Add expense button
            btnAddExpense = new Button
            {
                Text = "➕ Gidər Əlavə Et",
                Location = new Point(ModernTheme.Layout.Padding, 15),
                Size = new Size(150, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnAddExpense.Click += BtnAddExpense_Click;
            ModernTheme.ApplyButtonStyle(btnAddExpense, true);
            panel.Controls.Add(btnAddExpense);

            // Edit expense button
            btnEditExpense = new Button
            {
                Text = "✏️ Redaktə Et",
                Location = new Point(180, 15),
                Size = new Size(120, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnEditExpense.Click += BtnEditExpense_Click;
            ModernTheme.ApplyButtonStyle(btnEditExpense);
            panel.Controls.Add(btnEditExpense);

            // Approve expense button
            btnApproveExpense = new Button
            {
                Text = "✅ Təsdiqlə",
                Location = new Point(320, 15),
                Size = new Size(120, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnApproveExpense.Click += BtnApproveExpense_Click;
            ModernTheme.ApplyButtonStyle(btnApproveExpense);
            panel.Controls.Add(btnApproveExpense);

            // Delete expense button
            btnDeleteExpense = new Button
            {
                Text = "🗑️ Sil",
                Location = new Point(460, 15),
                Size = new Size(100, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnDeleteExpense.Click += BtnDeleteExpense_Click;
            ModernTheme.ApplyButtonStyle(btnDeleteExpense, false);
            btnDeleteExpense.BackColor = ModernTheme.Colors.Danger;
            btnDeleteExpense.ForeColor = Color.White;
            panel.Controls.Add(btnDeleteExpense);

            // Refresh button
            btnRefresh = new Button
            {
                Text = "🔄 Yenilə",
                Location = new Point(580, 15),
                Size = new Size(100, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnRefresh.Click += BtnRefresh_Click;
            ModernTheme.ApplyButtonStyle(btnRefresh);
            panel.Controls.Add(btnRefresh);

            return panel;
        }

        private void SetupDataGridView()
        {
            if (dgvExpenses != null)
            {
                ModernTheme.ApplyDataGridViewStyle(dgvExpenses);
            }
        }

        private void LoadCategories()
        {
            var categories = _giderService.GetExpenseCategories();
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Hamısı");
            cmbCategory.Items.AddRange(categories.ToArray());
            cmbCategory.SelectedIndex = 0;
        }

        private async Task LoadExpensesAsync()
        {
            await ExecuteAsync(async () =>
            {
                var expenses = await _giderService.GetAllExpensesAsync();
                
                var displayData = expenses.Select(e => new
                {
                    e.Id,
                    Ad = e.Ad,
                    Kateqoriya = e.Kateqoriya,
                    Mebleg = e.MeblegFormatli,
                    Tarix = e.TarixFormatli,
                    Status = e.StatusText,
                    OdemeUsulu = e.OdemeUsulu ?? "Təyin edilməyib",
                    Istifadeci = e.Istifadeci?.TamAd ?? "Naməlum",
                    Aciqlama = e.Aciqlama ?? ""
                }).ToList();

                dgvExpenses.DataSource = displayData;
                
                if (dgvExpenses.Columns.Count > 0)
                {
                    dgvExpenses.Columns["Id"].Visible = false;
                    dgvExpenses.Columns["Ad"].HeaderText = "Gidər Adı";
                    dgvExpenses.Columns["Kateqoriya"].HeaderText = "Kateqoriya";
                    dgvExpenses.Columns["Mebleg"].HeaderText = "Məbləğ";
                    dgvExpenses.Columns["Tarix"].HeaderText = "Tarix";
                    dgvExpenses.Columns["Status"].HeaderText = "Status";
                    dgvExpenses.Columns["OdemeUsulu"].HeaderText = "Ödəmə Üsulu";
                    dgvExpenses.Columns["Istifadeci"].HeaderText = "İstifadəçi";
                    dgvExpenses.Columns["Aciqlama"].HeaderText = "Açıqlama";
                }
            }, "Gidər məlumatları yüklənərkən xəta baş verdi");
        }

        private async Task LoadStatisticsAsync()
        {
            try
            {
                var summary = await _giderService.GetExpenseSummaryAsync();
                var monthlyExpenses = await _giderService.GetMonthlyExpensesAsync(DateTime.Now.Year, DateTime.Now.Month);
                var categories = _giderService.GetExpenseCategories();
                
                lblTotalExpenses.Text = summary.TotalExpensesFormatted;
                lblPendingExpenses.Text = summary.PendingExpensesFormatted;
                lblMonthlyExpenses.Text = monthlyExpenses.ToString("C");
                lblCategoryCount.Text = categories.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Statistik məlumatlar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await ApplyFiltersAsync();
        }

        private async void BtnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbApprovalStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            await LoadExpensesAsync();
        }

        private async Task ApplyFiltersAsync()
        {
            await ExecuteAsync(async () =>
            {
                var expenses = await _giderService.GetAllExpensesAsync();

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var searchTerm = txtSearch.Text.ToLower();
                    expenses = expenses.Where(e => 
                        e.Ad.ToLower().Contains(searchTerm) ||
                        e.Aciqlama?.ToLower().Contains(searchTerm) == true ||
                        e.Kateqoriya.ToLower().Contains(searchTerm)).ToArray();
                }

                // Apply category filter
                if (cmbCategory.SelectedIndex > 0)
                {
                    var selectedCategory = cmbCategory.SelectedItem.ToString();
                    expenses = expenses.Where(e => e.Kateqoriya == selectedCategory).ToArray();
                }

                // Apply approval status filter
                if (cmbApprovalStatus.SelectedIndex > 0)
                {
                    var isApproved = cmbApprovalStatus.SelectedIndex == 1;
                    expenses = expenses.Where(e => e.TesdiqEdildi == isApproved).ToArray();
                }

                // Apply date range filter
                expenses = expenses.Where(e => 
                    e.Tarix >= dtpStartDate.Value.Date && 
                    e.Tarix <= dtpEndDate.Value.Date).ToArray();

                var displayData = expenses.Select(e => new
                {
                    e.Id,
                    Ad = e.Ad,
                    Kateqoriya = e.Kateqoriya,
                    Mebleg = e.MeblegFormatli,
                    Tarix = e.TarixFormatli,
                    Status = e.StatusText,
                    OdemeUsulu = e.OdemeUsulu ?? "Təyin edilməyib",
                    Istifadeci = e.Istifadeci?.TamAd ?? "Naməlum",
                    Aciqlama = e.Aciqlama ?? ""
                }).ToList();

                dgvExpenses.DataSource = displayData;
            }, "Filtr tətbiq edilərkən xəta baş verdi");
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            var addForm = new GiderAddForm(_currentUser, _serviceProvider);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                BtnRefresh_Click(sender, e);
            }
        }

        private void BtnEditExpense_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa redaktə üçün gidər seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedExpenseId = (int)dgvExpenses.SelectedRows[0].Cells["Id"].Value;
            var editForm = new GiderEditForm(selectedExpenseId, _currentUser, _serviceProvider);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                BtnRefresh_Click(sender, e);
            }
        }

        private async void BtnApproveExpense_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa təsdiqlə üçün gidər seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedExpenseId = (int)dgvExpenses.SelectedRows[0].Cells["Id"].Value;
            var selectedStatus = dgvExpenses.SelectedRows[0].Cells["Status"].Value.ToString();

            if (selectedStatus == "Təsdiqləndi")
            {
                MessageBox.Show("Bu gidər artıq təsdiqlənib.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bu gidəri təsdiqləmək istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await ExecuteAsync(async () =>
                {
                    await _giderService.ApproveExpenseAsync(selectedExpenseId, _currentUser.TamAd);
                    MessageBox.Show("Gidər uğurla təsdiqləndi.", "Uğur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadExpensesAsync();
                    await LoadStatisticsAsync();
                }, "Gidər təsdiqlənərkən xəta baş verdi");
            }
        }

        private async void BtnDeleteExpense_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa silmək üçün gidər seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedExpenseId = (int)dgvExpenses.SelectedRows[0].Cells["Id"].Value;
            var selectedExpenseName = dgvExpenses.SelectedRows[0].Cells["Ad"].Value.ToString();

            if (MessageBox.Show($"'{selectedExpenseName}' gidərini silmək istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await ExecuteAsync(async () =>
                {
                    await _giderService.DeleteExpenseAsync(selectedExpenseId);
                    MessageBox.Show("Gidər uğurla silindi.", "Uğur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadExpensesAsync();
                    await LoadStatisticsAsync();
                }, "Gidər silinərkən xəta baş verdi");
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadExpensesAsync();
            await LoadStatisticsAsync();
        }

        private void DgvExpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditExpense_Click(sender, e);
            }
        }
    }
}