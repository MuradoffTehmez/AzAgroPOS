using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.PL.Forms;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MainForm : BaseForm
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _currentUser = currentUser;
            SetupModernDesign();
            // LoadUserInfo will be called after the controls are created
            this.Load += MainForm_Load;
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
            var customerAddForm = new MusteriAddForm(_currentUser);
            customerAddForm.ShowDialog();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            var customerListForm = new MusteriManagementForm(_currentUser);
            customerListForm.ShowDialog();
        }

        private void btnCustomerGroups_Click(object sender, EventArgs e)
        {
            var customerGroupsForm = new MusteriGroupManagementForm(_currentUser);
            customerGroupsForm.ShowDialog();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            var productManagementForm = new ProductManagementForm(_currentUser);
            productManagementForm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            var userManagementForm = new UserManagementForm(_currentUser);
            userManagementForm.ShowDialog();
        }

        private void btnDebtManagement_Click(object sender, EventArgs e)
        {
            var debtManagementForm = new BorcManagementForm(_currentUser);
            debtManagementForm.ShowDialog();
        }

        private void btnRepairManagement_Click(object sender, EventArgs e)
        {
            var repairManagementForm = new TamirManagementForm(_currentUser);
            repairManagementForm.ShowDialog();
        }

        private void btnExpenseManagement_Click(object sender, EventArgs e)
        {
            try
            {
                var expenseManagementForm = new GiderManagementForm(_currentUser, _serviceProvider);
                expenseManagementForm.ShowDialog();
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
                var settingsForm = new SistemAyarlariForm(_currentUser, _serviceProvider);
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Settings have been saved, reload theme and other settings
                    MessageBox.Show("Sistem ayarları yeniləndi. Dəyişikliklərin tam tətbiqi üçün proqramı yenidən başladın.", 
                        "Ayarlar Yeniləndi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                var shiftForm = new NovbeIdaretmesiForm();
                shiftForm.ShowDialog();
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
                var backupForm = new BackupForm();
                backupForm.ShowDialog();
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
                var notificationForm = new BildirisForm(_currentUser.Id);
                notificationForm.ShowDialog();
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
                var printerForm = new PrinterForm(_currentUser.Id);
                printerForm.ShowDialog();
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
            
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = normalColor;
                }
            }
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            var posForm = new POSForm();
            posForm.ShowDialog();
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
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load user info after all controls are created
            LoadUserInfo();
            
            // Initialize dashboard with mock data
            LoadDashboardData();
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

        // Designer-generated controls are used instead

        // Designer-generated controls are used instead

        // Designer-generated buttons are used instead

        // All methods removed - Designer-generated controls are used instead

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
        private Panel sidebarPanel;
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