using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
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
    public partial class BorcManagementForm : BaseForm
    {
        private readonly BorcService _borcService;
        private readonly IServiceProvider _serviceProvider;

        public BorcManagementForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _borcService = serviceProvider.GetRequiredService<BorcService>();
            _currentUser = currentUser;
            SetupModernDesign();
            this.Load += BorcManagementForm_Load;
        }

        // Backward compatibility constructor
        public BorcManagementForm(Istifadeci currentUser) : this(currentUser, Program.ServiceProvider)
        {
        }

        private async void BorcManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            await LoadDebtsAsync();
            LoadCustomers();
            LoadStatistics();
        }

        protected override async void OnFormLoad()
        {
            await LoadDebtsAsync();
        }

        private void SetupModernDesign()
        {
            // Set main form properties
            this.Text = "💰 Borc İdarəetməsi";
            this.BackColor = ModernTheme.Colors.Background;
            this.Font = ModernTheme.Fonts.Body;
            this.WindowState = FormWindowState.Maximized;
            
            // Create main layout
            CreateModernLayout();
            
            // Apply modern theme to all controls
            ModernTheme.ApplyModernStyle(this);
        }

        private void CreateModernLayout()
        {
            // Create header panel
            var headerPanel = ModernTheme.CreateHeader("Borc İdarəetməsi");
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
            filterPanel.Height = 80;
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
                Text = "Statistika",
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(ModernTheme.Layout.Padding, 10)
            };
            panel.Controls.Add(titleLabel);

            int x = ModernTheme.Layout.Padding;
            int y = 40;

            // Total Debt
            var totalDebtPanel = CreateStatCard("Ümumi Borc", "0 ₼", ModernTheme.Colors.Primary);
            totalDebtPanel.Location = new Point(x, y);
            totalDebtPanel.Size = new Size(180, 60);
            panel.Controls.Add(totalDebtPanel);

            // Overdue Debt
            x += 200;
            var overduePanel = CreateStatCard("Gecikmiş Borc", "0 ₼", ModernTheme.Colors.Warning);
            overduePanel.Location = new Point(x, y);
            overduePanel.Size = new Size(180, 60);
            panel.Controls.Add(overduePanel);

            // Interest
            x += 200;
            var interestPanel = CreateStatCard("Faiz", "0 ₼", ModernTheme.Colors.Info);
            interestPanel.Location = new Point(x, y);
            interestPanel.Size = new Size(180, 60);
            panel.Controls.Add(interestPanel);

            // Customer Count
            x += 200;
            var customerPanel = CreateStatCard("Müştəri Sayı", "0", ModernTheme.Colors.Secondary);
            customerPanel.Location = new Point(x, y);
            customerPanel.Size = new Size(180, 60);
            panel.Controls.Add(customerPanel);

            // Initialize labels for updating
            lblTotalDebt = totalDebtPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            lblOverdueDebt = overduePanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            lblTotalInterest = interestPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            lblCustomerCount = customerPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");

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
            panel.Height = 80;
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

            // Customer dropdown
            var customerLabel = new Label
            {
                Text = "Müştəri:",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                AutoSize = true,
                Location = new Point(ModernTheme.Layout.Padding, 40)
            };
            panel.Controls.Add(customerLabel);

            cmbCustomer = new ComboBox
            {
                Location = new Point(80, 37),
                Size = new Size(200, ModernTheme.Layout.InputHeight),
                Font = ModernTheme.Fonts.Body,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            ModernTheme.ApplyComboBoxStyle(cmbCustomer);
            panel.Controls.Add(cmbCustomer);

            // Filter button
            var btnFilter = new Button
            {
                Text = "🔍 Filtr",
                Location = new Point(300, 37),
                Size = new Size(100, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnFilter.Click += btnFilterByStatus_Click;
            ModernTheme.ApplyButtonStyle(btnFilter);
            panel.Controls.Add(btnFilter);

            // Refresh button
            var btnRefresh = new Button
            {
                Text = "🔄 Yenilə",
                Location = new Point(410, 37),
                Size = new Size(100, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnRefresh.Click += btnRefresh_Click;
            ModernTheme.ApplyButtonStyle(btnRefresh);
            panel.Controls.Add(btnRefresh);

            return panel;
        }

        private Panel CreateDataGridPanel()
        {
            var panel = ModernTheme.CreateCard();
            panel.Margin = new Padding(0, 0, 0, ModernTheme.Layout.Margin);

            var titleLabel = new Label
            {
                Text = "Borc Siyahısı",
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(ModernTheme.Layout.Padding, 10)
            };
            panel.Controls.Add(titleLabel);

            dgvDebts = new DataGridView
            {
                Location = new Point(ModernTheme.Layout.Padding, 40),
                Size = new Size(panel.Width - (ModernTheme.Layout.Padding * 2), 
                               panel.Height - 60),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvDebts.CellDoubleClick += dgvDebts_CellDoubleClick;
            panel.Controls.Add(dgvDebts);

            return panel;
        }

        private Panel CreateActionButtonsPanel()
        {
            var panel = ModernTheme.CreateCard();
            panel.Height = 60;

            // Add debt button
            var btnAddDebt = new Button
            {
                Text = "➕ Borc Əlavə Et",
                Location = new Point(ModernTheme.Layout.Padding, 15),
                Size = new Size(150, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnAddDebt.Click += btnAddDebt_Click;
            ModernTheme.ApplyButtonStyle(btnAddDebt, true);
            panel.Controls.Add(btnAddDebt);

            // Add payment button
            var btnAddPayment = new Button
            {
                Text = "💳 Ödəniş Et",
                Location = new Point(180, 15),
                Size = new Size(130, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnAddPayment.Click += btnAddPayment_Click;
            ModernTheme.ApplyButtonStyle(btnAddPayment);
            panel.Controls.Add(btnAddPayment);

            // View details button
            var btnViewDetails = new Button
            {
                Text = "📊 Təfərrüatlar",
                Location = new Point(320, 15),
                Size = new Size(130, ModernTheme.Layout.ButtonHeight),
                Font = ModernTheme.Fonts.Button
            };
            btnViewDetails.Click += btnViewDetails_Click;
            ModernTheme.ApplyButtonStyle(btnViewDetails);
            panel.Controls.Add(btnViewDetails);

            return panel;
        }


        private void SetupDataGridView()
        {
            if (dgvDebts != null)
            {
                ModernTheme.ApplyDataGridViewStyle(dgvDebts);
            }
        }

        private async Task LoadDebtsAsync()
        {
            await ExecuteAsync(async () =>
            {
                var repository = _serviceProvider.GetRequiredService<MusteriBorcRepository>();
                var debts = await repository.GetFilteredDebtsAsync(null, null, null, null, 100, 1);
                
                var displayData = debts.Select(d => new
                {
                    d.Id,
                    BorcNomresi = d.BorcNomresiFormatli,
                    MusteriAdi = d.Musteri != null ? d.Musteri.Ad : "Naməlum",
                    BorcMeblegi = d.BorcMeblegi.ToString("C"),
                    QalanBorc = d.QalanBorc.ToString("C"),
                    OdemeYuzdesi = d.OdemeYuzdesi.ToString("F1") + "%",
                    Status = d.StatusAzerbaycan,
                    GecikmeDurumu = d.GecikmeDurumu,
                    BorcTarixi = d.BorcTarixi.ToString("dd.MM.yyyy"),
                    SonOdemeTarixi = d.SonOdemeTarixi.ToString("dd.MM.yyyy")
                }).ToList();

                dgvDebts.DataSource = displayData;
                
                dgvDebts.Columns["Id"].Visible = false;
                dgvDebts.Columns["BorcNomresi"].HeaderText = "Borc №";
                dgvDebts.Columns["MusteriAdi"].HeaderText = "Müştəri";
                dgvDebts.Columns["BorcMeblegi"].HeaderText = "Borc Məbləği";
                dgvDebts.Columns["QalanBorc"].HeaderText = "Qalan Borc";
                dgvDebts.Columns["OdemeYuzdesi"].HeaderText = "Ödəniş %";
                dgvDebts.Columns["Status"].HeaderText = "Status";
                dgvDebts.Columns["GecikmeDurumu"].HeaderText = "Gecikməsi";
                dgvDebts.Columns["BorcTarixi"].HeaderText = "Borc Tarixi";
                dgvDebts.Columns["SonOdemeTarixi"].HeaderText = "Son Ödəmə";
            }, "Borc məlumatları yüklənərkən xəta baş verdi");
        }

        private async void LoadDebts()
        {
            await LoadDebtsAsync();
        }

        private void LoadCustomers()
        {
            Execute(() =>
            {
                var repository = _serviceProvider.GetRequiredService<MusteriRepository>();
                var customers = repository.GetAllActive();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "TamAd";
                cmbCustomer.ValueMember = "Id";
                cmbCustomer.SelectedIndex = -1;
            }, "Müştəri məlumatları yüklənərkən xəta baş verdi");
        }

        private void LoadStatistics()
        {
            try
            {
                var summary = _borcService.GetDebtSummary();
                
                lblTotalDebt.Text = summary.ContainsKey("UmumiBorc") ? 
                    summary["UmumiBorc"].ToString("C") : "0 ₼";
                lblOverdueDebt.Text = summary.ContainsKey("GecikmisBorc") ? 
                    summary["GecikmisBorc"].ToString("C") : "0 ₼";
                lblTotalInterest.Text = summary.ContainsKey("UmumiFaiz") ? 
                    summary["UmumiFaiz"].ToString("C") : "0 ₼";
                lblCustomerCount.Text = summary.ContainsKey("MusteriSayi") ? 
                    summary["MusteriSayi"].ToString() : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Statistik məlumatlar yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDebt_Click(object sender, EventArgs e)
        {
            var addForm = new BorcAddForm(_currentUser);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadDebts();
                LoadStatistics();
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (dgvDebts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa ödəniş üçün borc seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedDebtId = (int)dgvDebts.SelectedRows[0].Cells["Id"].Value;
            var paymentForm = new BorcPaymentForm(selectedDebtId, _currentUser);
            if (paymentForm.ShowDialog() == DialogResult.OK)
            {
                LoadDebts();
                LoadStatistics();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvDebts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zəhmət olmasa təfərrüatlar üçün borc seçin.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedDebtId = (int)dgvDebts.SelectedRows[0].Cells["Id"].Value;
            var detailsForm = new BorcDetailsForm(selectedDebtId, _currentUser);
            detailsForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDebts();
            LoadStatistics();
        }

        private void btnFilterByStatus_Click(object sender, EventArgs e)
        {
            var filterForm = new BorcFilterForm();
            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                ApplyFilters(filterForm.SelectedStatus, filterForm.SelectedCustomerId, 
                    filterForm.StartDate, filterForm.EndDate);
            }
        }

        private void ApplyFilters(string status, int? customerId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var debts = _borcService.GetAllDebts().AsQueryable();

                if (!string.IsNullOrEmpty(status))
                    debts = debts.Where(d => d.Status == status);

                if (customerId.HasValue)
                    debts = debts.Where(d => d.MusteriId == customerId.Value);

                if (startDate.HasValue)
                    debts = debts.Where(d => d.BorcTarixi >= startDate.Value);

                if (endDate.HasValue)
                    debts = debts.Where(d => d.BorcTarixi <= endDate.Value);

                var filteredDebts = debts.Select(d => new
                {
                    d.Id,
                    BorcNomresi = d.BorcNomresiFormatli,
                    MusteriAdi = d.Musteri != null ? d.Musteri.Ad : "Naməlum",
                    BorcMeblegi = d.BorcMeblegi.ToString("C"),
                    QalanBorc = d.QalanBorc.ToString("C"),
                    OdemeYuzdesi = d.OdemeYuzdesi.ToString("F1") + "%",
                    Status = d.StatusAzerbaycan,
                    GecikmeDurumu = d.GecikmeDurumu,
                    BorcTarixi = d.BorcTarixi.ToString("dd.MM.yyyy"),
                    SonOdemeTarixi = d.SonOdemeTarixi.ToString("dd.MM.yyyy")
                }).ToList();

                dgvDebts.DataSource = filteredDebts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filtr tətbiq edilərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDebts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context?.Dispose();
        //        components?.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}