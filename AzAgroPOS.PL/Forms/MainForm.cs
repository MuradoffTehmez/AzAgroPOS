using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.PL.Forms;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using AzAgroPOS.BLL.Services;
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
            LoadUserInfo();
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
                lblWelcome.Text = $"Xoş gəldiniz, {_currentUser.TamAd}";
                lblRole.Text = $"Rol: {_currentUser.Rol?.Ad ?? "Təyin edilməyib"}";
                
                // Admin roluna əsasən menyu elementlərini göstər/gizlət
                bool isAdmin = _currentUser.Rol?.Ad == SystemConstants.Roles.Administrator;
                bool isManager = _currentUser.Rol?.Ad == SystemConstants.Roles.Manager || isAdmin;
                
                btnUserManagement.Visible = isAdmin;
                btnSettings.Visible = isAdmin;
                btnReports.Visible = isManager;
                btnInventory.Visible = isManager;
                btnDebtManagement.Visible = isManager;
                btnRepairManagement.Visible = true;
                
                // Müştəri idarəetməsi və POS bütün istifadəçilər üçün görünür
                btnCustomerManagement.Visible = true;
                btnPOS.Visible = true;
                btnDashboard.Visible = true;
                
                // Initialize dashboard as default view
                dashboardPanel.Visible = true;
                customerSubmenu.Visible = false;
                btnDashboard.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parametrlər funksiyası tezliklə əlavə ediləcək.", 
                "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Initialize dashboard with mock data
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                // Real data from database - get actual statistics
                var musteriService = new MusteriService();
                var mehsulService = new MehsulService();
                
                // Get real customer count
                int totalCustomers = musteriService.GetAllCustomers().Count();
                if (lblTotalCustomers != null)
                    lblTotalCustomers.Text = $"👥 Müştərilər\n\n{totalCustomers:N0}";
                
                // Get real product count
                int totalProducts = mehsulService.GetAllActive().Count;
                if (lblTotalProducts != null)
                    lblTotalProducts.Text = $"📦 Məhsullar\n\n{totalProducts:N0}";
                
                // Today's sales - placeholder for now (would need sales service)
                var todaySales = new Random().Next(50, 200);
                if (lblTodaySales != null)
                    lblTodaySales.Text = $"🛒 Bugünkü Satış\n\n{todaySales}";
                
                // Total value - placeholder for now
                var totalValue = new Random().Next(10000, 50000);
                if (lblTotalValue != null)
                    lblTotalValue.Text = $"💰 Ümumi Dəyər\n\n₼{totalValue:N0}";
            }
            catch (Exception ex)
            {
                // Fallback to mock data if there's an error
                if (lblTotalCustomers != null)
                    lblTotalCustomers.Text = "👥 Müştərilər\n\n---";
                if (lblTotalProducts != null)
                    lblTotalProducts.Text = "📦 Məhsullar\n\n---";
                if (lblTodaySales != null)
                    lblTodaySales.Text = "🛒 Bugünkü Satış\n\n---";
                if (lblTotalValue != null)
                    lblTotalValue.Text = "💰 Ümumi Dəyər\n\n---";
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
            
            // Create modern layout
            CreateModernLayout();
            
            // Apply modern theme to all controls
            ModernTheme.ApplyModernStyle(this);
        }

        private void CreateModernLayout()
        {
            this.SuspendLayout();

            // Create main layout panels
            CreateTopPanel();
            CreateSidebarPanel();
            CreateMainContentPanel();
            CreateDashboardPanel();

            this.ResumeLayout(false);
        }

        private void CreateTopPanel()
        {
            topPanel = new Panel
            {
                Height = 70,
                Dock = DockStyle.Top,
                BackColor = ModernTheme.Colors.Primary
            };
            topPanel.Paint += TopPanel_Paint;

            // Welcome label
            lblWelcome = new Label
            {
                Text = "Xoş gəldiniz",
                Font = ModernTheme.Fonts.Heading,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            topPanel.Controls.Add(lblWelcome);

            // Role label
            lblRole = new Label
            {
                Text = "Rol: ---",
                Font = ModernTheme.Fonts.Body,
                ForeColor = Color.FromArgb(220, 255, 255, 255),
                AutoSize = true,
                Location = new Point(20, 40)
            };
            topPanel.Controls.Add(lblRole);

            // Logout button
            var btnLogout = new Button
            {
                Text = "🚪 Çıxış",
                Size = new Size(100, 35),
                Location = new Point(this.Width - 120, 20),
                Font = ModernTheme.Fonts.Button,
                BackColor = ModernTheme.Colors.Danger,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += btnLogout_Click;
            topPanel.Controls.Add(btnLogout);

            this.Controls.Add(topPanel);
        }

        private void CreateSidebarPanel()
        {
            sidebarPanel = new Panel
            {
                Width = 220,
                Dock = DockStyle.Left,
                BackColor = ModernTheme.Colors.Primary
            };
            sidebarPanel.Paint += SidebarPanel_Paint;

            // Create menu buttons
            CreateMenuButtons();

            this.Controls.Add(sidebarPanel);
        }

        private void CreateMenuButtons()
        {
            int yPos = 20;
            int buttonHeight = 50;
            int spacing = 5;

            // Dashboard button
            var btnDashboard = CreateMenuButton("🏠 Ana Səhifə", yPos);
            btnDashboard.Click += btnDashboard_Click;
            btnDashboard.BackColor = ModernTheme.Colors.PrimaryDark; // Active by default
            sidebarPanel.Controls.Add(btnDashboard);
            yPos += buttonHeight + spacing;

            // Customer Management button
            var btnCustomers = CreateMenuButton("👥 Müştərilər", yPos);
            btnCustomers.Click += btnCustomerManagement_Click;
            sidebarPanel.Controls.Add(btnCustomers);
            yPos += buttonHeight + spacing;

            // Inventory button
            var btnInventory = CreateMenuButton("📦 Anbar", yPos);
            btnInventory.Click += btnInventory_Click;
            sidebarPanel.Controls.Add(btnInventory);
            yPos += buttonHeight + spacing;

            // POS button
            var btnPOS = CreateMenuButton("🛒 Satış", yPos);
            btnPOS.Click += btnPOS_Click;
            sidebarPanel.Controls.Add(btnPOS);
            yPos += buttonHeight + spacing;

            // Debt Management button
            var btnDebtManagement = CreateMenuButton("💰 Borc İdarəsi", yPos);
            btnDebtManagement.Click += btnDebtManagement_Click;
            sidebarPanel.Controls.Add(btnDebtManagement);
            yPos += buttonHeight + spacing;

            // Repair Management button
            var btnRepairManagement = CreateMenuButton("🔧 Təmir", yPos);
            btnRepairManagement.Click += btnRepairManagement_Click;
            sidebarPanel.Controls.Add(btnRepairManagement);
            yPos += buttonHeight + spacing;

            // Reports button
            var btnReports = CreateMenuButton("📊 Hesabatlar", yPos);
            btnReports.Click += btnReports_Click;
            sidebarPanel.Controls.Add(btnReports);
            yPos += buttonHeight + spacing;

            // User Management button
            var btnUserManagement = CreateMenuButton("👤 İstifadəçilər", yPos);
            btnUserManagement.Click += btnUserManagement_Click;
            sidebarPanel.Controls.Add(btnUserManagement);
            yPos += buttonHeight + spacing;

            // Settings button
            var btnSettings = CreateMenuButton("⚙️ Parametrlər", yPos);
            btnSettings.Click += btnSettings_Click;
            sidebarPanel.Controls.Add(btnSettings);
        }

        private Button CreateMenuButton(string text, int yPos)
        {
            var button = new Button
            {
                Text = text,
                Size = new Size(200, 45),
                Location = new Point(10, yPos),
                Font = ModernTheme.Fonts.Button,
                BackColor = ModernTheme.Colors.Primary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            button.MouseEnter += (s, e) => button.BackColor = ModernTheme.Colors.PrimaryDark;
            button.MouseLeave += (s, e) => 
            {
                if (button.BackColor == ModernTheme.Colors.PrimaryDark && !IsActiveButton(button))
                    button.BackColor = ModernTheme.Colors.Primary;
            };
            return button;
        }

        private bool IsActiveButton(Button button)
        {
            return button.BackColor == ModernTheme.Colors.PrimaryDark;
        }

        private void CreateMainContentPanel()
        {
            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.Colors.Background,
                Padding = new Padding(20)
            };

            this.Controls.Add(mainContentPanel);
        }

        private void CreateDashboardPanel()
        {
            dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.Colors.Background
            };

            // Create dashboard content
            CreateDashboardContent();

            mainContentPanel.Controls.Add(dashboardPanel);
        }

        private void CreateDashboardContent()
        {
            // Dashboard title
            var titleLabel = new Label
            {
                Text = "İdarəetmə Paneli",
                Font = ModernTheme.Fonts.Title,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(0, 0)
            };
            dashboardPanel.Controls.Add(titleLabel);

            // Statistics cards
            CreateStatisticsCards();

            // Recent activity panel
            CreateRecentActivityPanel();
        }

        private void CreateStatisticsCards()
        {
            int x = 0;
            int y = 60;
            int cardWidth = 250;
            int cardHeight = 120;
            int spacing = 20;

            // Total Customers card
            var customersCard = CreateStatisticCard("👥 Müştərilər", "0", ModernTheme.Colors.Primary);
            customersCard.Location = new Point(x, y);
            customersCard.Size = new Size(cardWidth, cardHeight);
            lblTotalCustomers = customersCard.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            dashboardPanel.Controls.Add(customersCard);

            // Total Products card
            x += cardWidth + spacing;
            var productsCard = CreateStatisticCard("📦 Məhsullar", "0", ModernTheme.Colors.Secondary);
            productsCard.Location = new Point(x, y);
            productsCard.Size = new Size(cardWidth, cardHeight);
            lblTotalProducts = productsCard.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            dashboardPanel.Controls.Add(productsCard);

            // Today's Sales card
            x += cardWidth + spacing;
            var salesCard = CreateStatisticCard("🛒 Bugünkü Satış", "0", ModernTheme.Colors.Warning);
            salesCard.Location = new Point(x, y);
            salesCard.Size = new Size(cardWidth, cardHeight);
            lblTodaySales = salesCard.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            dashboardPanel.Controls.Add(salesCard);

            // Total Value card
            x += cardWidth + spacing;
            var valueCard = CreateStatisticCard("💰 Ümumi Dəyər", "₼0", ModernTheme.Colors.Info);
            valueCard.Location = new Point(x, y);
            valueCard.Size = new Size(cardWidth, cardHeight);
            lblTotalValue = valueCard.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "value");
            dashboardPanel.Controls.Add(valueCard);
        }

        private Panel CreateStatisticCard(string title, string value, Color color)
        {
            var card = new Panel
            {
                BackColor = color,
                Padding = new Padding(20)
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = ModernTheme.Fonts.Body,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(0, 10)
            };
            card.Controls.Add(titleLabel);

            var valueLabel = new Label
            {
                Text = value,
                Font = ModernTheme.Fonts.Title,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(0, 40),
                Tag = "value"
            };
            card.Controls.Add(valueLabel);

            return card;
        }

        private void CreateRecentActivityPanel()
        {
            var activityPanel = ModernTheme.CreateCard();
            activityPanel.Location = new Point(0, 220);
            activityPanel.Size = new Size(800, 300);

            var titleLabel = new Label
            {
                Text = "Son Fəaliyyətlər",
                Font = ModernTheme.Fonts.SubHeading,
                ForeColor = ModernTheme.Colors.TextPrimary,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            activityPanel.Controls.Add(titleLabel);

            var activityList = new Label
            {
                Text = "• Yeni müştəri əlavə edildi\n• Məhsul anbarı yeniləndi\n• Satış hesabatı hazırlandı\n• Sistem yeniləndi",
                Font = ModernTheme.Fonts.Body,
                ForeColor = ModernTheme.Colors.TextSecondary,
                Location = new Point(20, 60),
                Size = new Size(750, 200)
            };
            activityPanel.Controls.Add(activityList);

            dashboardPanel.Controls.Add(activityPanel);
        }

        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                topPanel.ClientRectangle,
                ModernTheme.Colors.Primary,
                ModernTheme.Colors.PrimaryDark,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, topPanel.ClientRectangle);
            }
        }

        private void SidebarPanel_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                sidebarPanel.ClientRectangle,
                ModernTheme.Colors.Primary,
                ModernTheme.Colors.PrimaryDark,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, sidebarPanel.ClientRectangle);
            }
        }

        private void ShowDashboard()
        {
            if (dashboardPanel != null)
            {
                dashboardPanel.Visible = true;
                dashboardPanel.BringToFront();
            }
        }

        private void ToggleCustomerSubmenu()
        {
            if (customerSubmenu != null)
            {
                customerSubmenu.Visible = !customerSubmenu.Visible;
            }
        }

        private void SetMenuVisibility(bool isAdmin, bool isManager)
        {
            // Implementation for setting menu visibility based on roles
            foreach (Control control in sidebarPanel.Controls)
            {
                if (control is Button btn)
                {
                    // Show/hide based on role
                    if (btn.Text.Contains("İstifadəçilər") || btn.Text.Contains("Parametrlər"))
                    {
                        btn.Visible = isAdmin;
                    }
                    else if (btn.Text.Contains("Hesabatlar") || btn.Text.Contains("Anbar") || btn.Text.Contains("Borc"))
                    {
                        btn.Visible = isManager;
                    }
                    else
                    {
                        btn.Visible = true;
                    }
                }
            }
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
    }
}