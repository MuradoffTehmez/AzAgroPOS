using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.PL.Forms;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using AzAgroPOS.PL.Security;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MainForm : BaseForm
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthorizationService _authorizationService;

        public MainForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authorizationService = serviceProvider.GetRequiredService<IAuthorizationService>();
            _currentUser = currentUser;
            SetupModernDesign();
            // LoadUserInfo will be called after the controls are created
            this.Load += MainForm_Load;
            
            // MDI Container setup
            this.IsMdiContainer = true;
        }

        /// <summary>
        /// Memory leak problemini həll edən generic form management metodu
        /// Eyni tipli formdan yalnız bir nüsxəni açır
        /// </summary>
        private void OpenMdiForm<T>() where T : Form, new()
        {
            // Yoxlayırıq ki, bu tipdə bir pəncərə artıq açıqdırmı
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(T))
                {
                    form.Activate(); // Əgər açıqdırsa, sadəcə ön plana gətiririk
                    return;
                }
            }

            // Əgər açıq deyilsə, yenisini yaradırıq
            T newForm = new T();
            newForm.MdiParent = this;
            newForm.Show();
        }

        /// <summary>
        /// Constructor parametrli formlar üçün generic metod
        /// </summary>
        private void OpenMdiForm<T>(params object[] args) where T : Form
        {
            // Yoxlayırıq ki, bu tipdə bir pəncərə artıq açıqdırmı
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(T))
                {
                    form.Activate(); // Əgər açıqdırsa, sadəcə ön plana gətiririk
                    return;
                }
            }

            // Əgər açıq deyilsə, yenisini yaradırıq
            T newForm = (T)Activator.CreateInstance(typeof(T), args);
            newForm.MdiParent = this;
            newForm.Show();
        }

        // Backward compatibility constructor
        public MainForm(Istifadeci currentUser) : this(currentUser, Program.ServiceProvider)
        {
        }

        private void LoadUserInfo()
        {
            if (_currentUser != null)
            {
                // Use Designer-generated controls
                lblWelcomeMessage.Text = $"Xoş gəldiniz, {_currentUser.TamAd}";
                lblUserRole.Text = $"Rol: {_currentUser.Rol?.Ad ?? "Təyin edilməyib"}";
                
                // Admin roluna əsasən menyu elementlərini göstər/gizlət
                bool isAdmin = _currentUser.Rol?.Ad == SystemConstants.Roles.Administrator;
                bool isManager = _currentUser.Rol?.Ad == SystemConstants.Roles.Manager || isAdmin;
                
                // Initialize dashboard as default view
                if (pnlDashboard != null)
                {
                    pnlDashboard.Visible = true;
                }
                
                // Initialize customer submenu if it exists
                if (pnlCustomerSubmenu != null)
                {
                    pnlCustomerSubmenu.Visible = false;
                }
                
                // Initialize dashboard button color
                if (btnDashboard != null)
                {
                    btnDashboard.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
                }
                
                // Set menu visibility based on roles
                SetMenuVisibility(isAdmin, isManager);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
            
            // Update button appearance
            ResetButtonColors();
            if (sender is Button btn)
            {
                btn.BackColor = ModernTheme.Colors.PrimaryDark;
            }
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            ToggleCustomerSubmenu();
            
            // Update button appearance
            ResetButtonColors();
            if (sender is Button btn)
            {
                btn.BackColor = ModernTheme.Colors.PrimaryDark;
            }
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            OpenMdiForm<MusteriAddForm>(_currentUser);
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            OpenMdiForm<MusteriManagementForm>(_currentUser);
        }

        private void btnCustomerGroups_Click(object sender, EventArgs e)
        {
            OpenMdiForm<MusteriGroupManagementForm>(_currentUser);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            OpenMdiForm<ProductManagementForm>(_currentUser);
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            OpenMdiForm<UserManagementForm>(_currentUser);
        }

        private void btnDebtManagement_Click(object sender, EventArgs e)
        {
            OpenMdiForm<BorcManagementForm>(_currentUser);
        }

        private void btnRepairManagement_Click(object sender, EventArgs e)
        {
            OpenMdiForm<TamirManagementForm>(_currentUser);
        }

        private void btnExpenseManagement_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMdiForm<GiderManagementForm>(_currentUser, _serviceProvider);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gidər idarəetməsi formu açılarkən xəta baş verdi:\n\n{ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMdiForm<SistemAyarlariForm>(_currentUser, _serviceProvider);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sistem ayarları formu açılarkən xəta baş verdi:\n\n{ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShiftManagement_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMdiForm<NovbeIdaretmesiForm>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Növbə idarəetməsi açılarkən xəta: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackupSystem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMdiForm<BackupForm>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup sistemi açılarkən xəta: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMdiForm<BildirisForm>(_currentUser.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bildiriş sistemi açılarkən xəta: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrinterManagement_Click(object sender, EventArgs e)
        {
            try
            {
                OpenMdiForm<PrinterForm>(_currentUser.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printer idarəetməsi açılarkən xəta: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetButtonColors()
        {
            var normalColor = ModernTheme.Colors.Primary;
            var activeColor = ModernTheme.Colors.PrimaryDark;
            
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = normalColor;
                }
            }
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            OpenMdiForm<POSForm>();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Show Reports submenu
            ShowReportsMenu();
        }

        private void ShowReportsMenu()
        {
            var reportsMenu = new ContextMenuStrip();
            
            // Sales Reports
            var salesReportItem = new ToolStripMenuItem("📊 Satış Hesabatları");
            salesReportItem.Click += (s, e) => {
                var salesReportForm = new SalesReportForm();
                salesReportForm.ShowDialog();
            };
            
            // Debt Analysis
            var debtAnalysisItem = new ToolStripMenuItem("💰 Borc Analizi");
            debtAnalysisItem.Click += (s, e) => {
                var debtAnalysisForm = new DebtAnalysisForm();
                debtAnalysisForm.ShowDialog();
            };
            
            // Repair Analytics
            var repairAnalyticsItem = new ToolStripMenuItem("🔧 Təmir Analitikası");
            repairAnalyticsItem.Click += (s, e) => {
                var repairAnalyticsForm = new RepairAnalyticsForm();
                repairAnalyticsForm.ShowDialog();
            };
            
            // Customer Analytics
            var customerAnalyticsItem = new ToolStripMenuItem("👥 Müştəri Analitikası");
            customerAnalyticsItem.Click += (s, e) => {
                ShowCustomerAnalyticsMenu();
            };
            
            // Employee Performance
            var employeePerformanceItem = new ToolStripMenuItem("⭐ İşçi Performansı");
            employeePerformanceItem.Click += (s, e) => {
                ShowEmployeePerformanceMenu();
            };
            
            // Add separator
            var separator = new ToolStripSeparator();
            
            // Export Options
            var exportItem = new ToolStripMenuItem("📤 Toplu İxrac");
            exportItem.Click += (s, e) => {
                ShowExportOptionsDialog();
            };
            
            reportsMenu.Items.AddRange(new ToolStripItem[] {
                salesReportItem,
                debtAnalysisItem, 
                repairAnalyticsItem,
                customerAnalyticsItem,
                employeePerformanceItem,
                separator,
                exportItem
            });
            
            // Show menu at button location
            var buttonLocation = btnReports.PointToScreen(new System.Drawing.Point(0, btnReports.Height));
            reportsMenu.Show(buttonLocation);
        }

        private void ShowCustomerAnalyticsMenu()
        {
            var customerMenu = new ContextMenuStrip();
            
            var summaryItem = new ToolStripMenuItem("Müştəri Xülasəsi");
            summaryItem.Click += (s, e) => {
                MessageBox.Show("Müştəri xülasəsi formu açılacaq.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            var individualItem = new ToolStripMenuItem("Fərdi Müştəri Analizi");
            individualItem.Click += (s, e) => {
                MessageBox.Show("Fərdi müştəri analizi formu açılacaq.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            customerMenu.Items.AddRange(new ToolStripItem[] { summaryItem, individualItem });
            customerMenu.Show(Cursor.Position);
        }

        private void ShowEmployeePerformanceMenu()
        {
            var employeeMenu = new ContextMenuStrip();
            
            var summaryItem = new ToolStripMenuItem("İşçi Xülasəsi");
            summaryItem.Click += (s, e) => {
                MessageBox.Show("İşçi xülasəsi formu açılacaq.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            var individualItem = new ToolStripMenuItem("Fərdi Performans");
            individualItem.Click += (s, e) => {
                MessageBox.Show("Fərdi performans formu açılacaq.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            var shiftsItem = new ToolStripMenuItem("Növbə İdarəetməsi");
            shiftsItem.Click += (s, e) => {
                MessageBox.Show("Növbə idarəetmə formu açılacaq.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            
            employeeMenu.Items.AddRange(new ToolStripItem[] { summaryItem, individualItem, shiftsItem });
            employeeMenu.Show(Cursor.Position);
        }

        private void ShowExportOptionsDialog()
        {
            var exportDialog = new Form
            {
                Text = "Toplu İxrac Seçimləri",
                Size = new System.Drawing.Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var label = new Label
            {
                Text = "İxrac ediləcək hesabat növlərini seçin:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(350, 20)
            };

            var salesCheck = new CheckBox { Text = "Satış Hesabatları", Location = new System.Drawing.Point(20, 50), Checked = true };
            var debtCheck = new CheckBox { Text = "Borc Analizi", Location = new System.Drawing.Point(20, 80), Checked = true };
            var repairCheck = new CheckBox { Text = "Təmir Analitikası", Location = new System.Drawing.Point(20, 110), Checked = false };
            var customerCheck = new CheckBox { Text = "Müştəri Analitikası", Location = new System.Drawing.Point(20, 140), Checked = false };

            var exportButton = new Button
            {
                Text = "İxrac Et",
                Location = new System.Drawing.Point(200, 200),
                Size = new System.Drawing.Size(80, 30)
            };

            var cancelButton = new Button
            {
                Text = "Ləğv Et",
                Location = new System.Drawing.Point(290, 200),
                Size = new System.Drawing.Size(80, 30)
            };

            exportButton.Click += (s, e) => {
                var selectedReports = new List<string>();
                if (salesCheck.Checked) selectedReports.Add("Satış");
                if (debtCheck.Checked) selectedReports.Add("Borc");
                if (repairCheck.Checked) selectedReports.Add("Təmir");
                if (customerCheck.Checked) selectedReports.Add("Müştəri");

                if (selectedReports.Any())
                {
                    MessageBox.Show($"Seçilən hesabatlar ixrac ediləcək: {string.Join(", ", selectedReports)}", 
                        "İxrac", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    exportDialog.Close();
                }
                else
                {
                    MessageBox.Show("Ən azı bir hesabat növü seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            cancelButton.Click += (s, e) => exportDialog.Close();

            exportDialog.Controls.AddRange(new Control[] { 
                label, salesCheck, debtCheck, repairCheck, customerCheck, exportButton, cancelButton 
            });

            exportDialog.ShowDialog(this);
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sistemdən çıxmaq istədiyinizə əminsiniz?", "Təsdiq", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Session-ı təmizlə
                SessionManager.ClearSession();
                
                // MainForm-u gizlət
                this.Hide();
                
                // Yeni login form yarat
                using var scope = _serviceProvider.CreateScope();
                var loginForm = new MaterialModernLoginForm(scope.ServiceProvider);
                
                // Login form-u göstər və nəticəni yoxla
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Əgər yenidən login oldusa, MainForm-u yenilə
                    this.Show();
                }
                else
                {
                    // Login ləğv edilibsə, proqramı bağla
                    Application.Exit();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #if DEBUG
        /// <summary>
        /// Development məqsədilə ConfigProtector test button əlavə edir
        /// </summary>
        private void AddConfigProtectionTestButton()
        {
            try
            {
                var testButton = new Button
                {
                    Text = "🔐 Config Test",
                    Size = new Size(240, 35),
                    Location = new Point(20, 600),
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.FromArgb(230, 126, 34),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleCenter,
                    UseVisualStyleBackColor = false
                };
                
                testButton.FlatAppearance.BorderSize = 0;
                testButton.Click += TestButton_Click;
                
                // Add to sidebar panel
                pnlSidebar.Controls.Add(testButton);
            }
            catch (Exception ex)
            {
                // Test button əlavə etmək əsas proqramı pozmamalı
                Console.WriteLine($"Test button əlavə edilmədi: {ex.Message}");
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var testMenu = new ContextMenuStrip();
            
            testMenu.Items.Add("🔍 Protection Status", null, (s, args) => 
                ConfigProtectionTest.ShowProtectionStatus());
            
            testMenu.Items.Add("✅ Validate Config", null, (s, args) => 
                ConfigProtectionTest.ValidateConfigFile());
            
            testMenu.Items.Add("🔐 Test DPAPI", null, (s, args) => 
                ConfigProtectionTest.TestDPAPI());
            
            testMenu.Show(sender as Control, new Point(0, (sender as Control).Height));
        }
        #endif

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Load user info after all controls are created
            LoadUserInfo();
            
            // Menyu və düymələrin icazə yoxlaması
            await CheckMenuPermissions();
            
            // Initialize dashboard with mock data
            LoadDashboardData();
        }

        /// <summary>
        /// Mərkəzləşdirilmiş İcazə Yoxlaması - Menyu və Düymələr
        /// </summary>
        private async Task CheckMenuPermissions()
        {
            try
            {
                // Sidebar menyu düymələri icazə yoxlaması
                await CheckButtonPermission(btnCustomerManagement, SystemConstants.Permissions.Musteri.View);
                await CheckButtonPermission(btnInventory, SystemConstants.Permissions.Anbar.View);
                await CheckButtonPermission(btnPOS, SystemConstants.Permissions.Satis.Create);
                await CheckButtonPermission(btnDebtManagement, SystemConstants.Permissions.Musteri.ViewDebt);
                await CheckButtonPermission(btnRepairManagement, SystemConstants.Permissions.Tamir.View);
                await CheckButtonPermission(btnReports, SystemConstants.Permissions.Hesabat.ViewSales);
                await CheckButtonPermission(btnUserManagement, SystemConstants.Permissions.Istifadeci.View);
                await CheckButtonPermission(btnSettings, SystemConstants.Permissions.Sistem.ManageSettings);

                // Quick Action düymələri icazə yoxlaması
                await CheckButtonPermission(btnQuickPOS, SystemConstants.Permissions.Satis.Create);
                await CheckButtonPermission(btnQuickCustomerAdd, SystemConstants.Permissions.Musteri.Create);
                await CheckButtonPermission(btnQuickInventory, SystemConstants.Permissions.Anbar.View);
                await CheckButtonPermission(btnQuickReports, SystemConstants.Permissions.Hesabat.ViewSales);

                // Customer submenu düymələri icazə yoxlaması
                await CheckButtonPermission(btnCustomerAdd, SystemConstants.Permissions.Musteri.Create);
                await CheckButtonPermission(btnCustomerList, SystemConstants.Permissions.Musteri.View);
                await CheckButtonPermission(btnCustomerGroups, SystemConstants.Permissions.Musteri.View);

                // Admin icazəsi olanlara təkmil funksiyalar
                if (await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.AdminAccess))
                {
                    // Admin-ə xüsusi funksiyalar aktiv et
                    EnableAdminFeatures();
                }
            }
            catch (Exception ex)
            {
                ShowError($"İcazə yoxlaması zamanı xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Fərdi düymə icazə yoxlaması
        /// </summary>
        private async Task CheckButtonPermission(Button button, string permission)
        {
            if (button != null)
            {
                bool hasPermission = await _authorizationService.HasPermissionAsync(permission);
                button.Enabled = hasPermission;
                
                // Vizual göstərici: İcazəsi olmayan düymələr solğun görünür
                if (!hasPermission)
                {
                    button.BackColor = Color.FromArgb(200, 200, 200); // Boz rəng
                    button.ForeColor = Color.Gray;
                    button.Cursor = Cursors.No;
                    
                    // Tooltip əlavə et
                    var tooltip = new ToolTip();
                    tooltip.SetToolTip(button, "Bu əməliyyat üçün icazəniz yoxdur");
                }
            }
        }

        /// <summary>
        /// Admin xüsusi funksiyalarını aktiv edir
        /// </summary>
        private void EnableAdminFeatures()
        {
            // Admin üçün əlavə menyu bəndləri və ya xüsusi düymələr aktiv et
            // Məsələn: Database backup, system logs, advanced settings və s.
        }

        private void LoadDashboardData()
        {
            try
            {
                // Real data from database - get actual statistics
                var musteriService = ServiceFactory.CreateMusteriService();
                var mehsulService = ServiceFactory.CreateMehsulService();
                
                // Get real customer count
                int totalCustomers = musteriService.GetAllCustomers().Count();
                if (lblStatTotalCustomers != null)
                    lblStatTotalCustomers.Text = $"👥 Müştərilər\n\n{totalCustomers:N0}";
                
                // Get real product count
                int totalProducts = mehsulService.GetAllActive().Count;
                if (lblStatTotalProducts != null)
                    lblStatTotalProducts.Text = $"📦 Məhsullar\n\n{totalProducts:N0}";
                
                // Today's sales - placeholder for now (would need sales service)
                var todaySales = new Random().Next(50, 200);
                if (lblStatTodaySales != null)
                    lblStatTodaySales.Text = $"🛒 Bugünkü Satış\n\n{todaySales}";
                
                // Total value - placeholder for now
                var totalValue = new Random().Next(10000, 50000);
                if (lblStatTotalValue != null)
                    lblStatTotalValue.Text = $"💰 Ümumi Dəyər\n\n₼{totalValue:N0}";
            }
            catch (Exception ex)
            {
                // Fallback to mock data if there's an error
                if (lblStatTotalCustomers != null)
                    lblStatTotalCustomers.Text = "👥 Müştərilər\n\n---";
                if (lblStatTotalProducts != null)
                    lblStatTotalProducts.Text = "📦 Məhsullar\n\n---";
                if (lblStatTodaySales != null)
                    lblStatTodaySales.Text = "🛒 Bugünkü Satış\n\n---";
                if (lblStatTotalValue != null)
                    lblStatTotalValue.Text = "💰 Ümumi Dəyər\n\n---";
            }
        }

        private void SetupModernDesign()
        {
            // Set main form properties
            this.Text = "🌾 AzAgroPOS - Kənd Təsərrüfatı İdarəetmə Sistemi";
            this.BackColor = ModernTheme.Colors.Background;
            this.Font = ModernTheme.Fonts.Body;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Apply modern theme to all controls
            ModernTheme.ApplyModernStyle(this);
            
            // Add expense management button if not in designer
            AddExpenseManagementButton();
            
            // Debug: Connection string protection test (development only)
            #if DEBUG
            AddConfigProtectionTestButton();
            #endif
        }

        private void AddExpenseManagementButton()
        {
            // Add expense management button dynamically since it's not in Designer
            if (btnExpenseManagement == null)
            {
                btnExpenseManagement = new Button
                {
                    Text = "💰 Gidər İdarəsi",
                    Size = new Size(240, 45),
                    Location = new Point(20, 555), // Position after repair management
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    BackColor = Color.FromArgb(52, 73, 94),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    TextAlign = ContentAlignment.MiddleLeft,
                    UseVisualStyleBackColor = false
                };
                
                btnExpenseManagement.FlatAppearance.BorderSize = 0;
                btnExpenseManagement.Click += btnExpenseManagement_Click;
                
                // Add to sidebar panel
                pnlSidebar.Controls.Add(btnExpenseManagement);
            }
        }

        private void ShowDashboard()
        {
            if (pnlDashboard != null)
            {
                pnlDashboard.Visible = true;
                pnlDashboard.BringToFront();
            }
        }

        private void ToggleCustomerSubmenu()
        {
            if (pnlCustomerSubmenu != null)
            {
                pnlCustomerSubmenu.Visible = !pnlCustomerSubmenu.Visible;
            }
        }

        private void SetMenuVisibility(bool isAdmin, bool isManager)
        {
            // Set visibility for buttons based on roles
            if (btnUserManagement != null)
                btnUserManagement.Visible = isAdmin;
            if (btnSettings != null)
                btnSettings.Visible = isAdmin;
            if (btnReports != null)
                btnReports.Visible = isManager;
            if (btnInventory != null)
                btnInventory.Visible = isManager;
            if (btnDebtManagement != null)
                btnDebtManagement.Visible = isManager;
            if (btnExpenseManagement != null)
                btnExpenseManagement.Visible = isManager;
            
            // These are always visible
            if (btnDashboard != null)
                btnDashboard.Visible = true;
            if (btnCustomerManagement != null)
                btnCustomerManagement.Visible = true;
            if (btnPOS != null)
                btnPOS.Visible = true;
            if (btnRepairManagement != null)
                btnRepairManagement.Visible = true;
        }

        // Control declarations
        private Panel topPanel;
        private Panel mainContentPanel;
        private Panel dashboardPanel;
        private Panel customerSubmenu;
        private Label lblWelcome;
        private Label lblRole;
        private Label lblTotalCustomers;
        private Label lblTotalProducts;
        private Label lblTodaySales;
        private Label lblTotalValue;
        
        // Additional button for expense management (not in Designer)
        private Button btnExpenseManagement;
    }
}