namespace AzAgroPOS.PL.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnCustomerManagement;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnDebtManagement;
        private System.Windows.Forms.Button btnRepairManagement;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel customerSubmenu;
        private System.Windows.Forms.Button btnCustomerAdd;
        private System.Windows.Forms.Button btnCustomerList;
        private System.Windows.Forms.Button btnCustomerGroups;
        private System.Windows.Forms.Panel dashboardPanel;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.GroupBox grpQuickStats;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblTodaySales;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.GroupBox grpQuickActions;
        private System.Windows.Forms.Button btnQuickPOS;
        private System.Windows.Forms.Button btnQuickCustomerAdd;
        private System.Windows.Forms.Button btnQuickInventory;
        private System.Windows.Forms.Button btnQuickReports;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRepairManagement = new System.Windows.Forms.Button();
            this.btnDebtManagement = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.customerSubmenu = new System.Windows.Forms.Panel();
            this.btnCustomerGroups = new System.Windows.Forms.Button();
            this.btnCustomerList = new System.Windows.Forms.Button();
            this.btnCustomerAdd = new System.Windows.Forms.Button();
            this.btnCustomerManagement = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.dashboardPanel = new System.Windows.Forms.Panel();
            this.grpQuickActions = new System.Windows.Forms.GroupBox();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.btnQuickInventory = new System.Windows.Forms.Button();
            this.btnQuickCustomerAdd = new System.Windows.Forms.Button();
            this.btnQuickPOS = new System.Windows.Forms.Button();
            this.grpQuickStats = new System.Windows.Forms.GroupBox();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTodaySales = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.customerSubmenu.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.dashboardPanel.SuspendLayout();
            this.grpQuickActions.SuspendLayout();
            this.grpQuickStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.sidebarPanel.Controls.Add(this.btnLogout);
            this.sidebarPanel.Controls.Add(this.btnSettings);
            this.sidebarPanel.Controls.Add(this.btnReports);
            this.sidebarPanel.Controls.Add(this.btnRepairManagement);
            this.sidebarPanel.Controls.Add(this.btnDebtManagement);
            this.sidebarPanel.Controls.Add(this.btnInventory);
            this.sidebarPanel.Controls.Add(this.btnPOS);
            this.sidebarPanel.Controls.Add(this.customerSubmenu);
            this.sidebarPanel.Controls.Add(this.btnCustomerManagement);
            this.sidebarPanel.Controls.Add(this.btnUserManagement);
            this.sidebarPanel.Controls.Add(this.btnDashboard);
            this.sidebarPanel.Controls.Add(this.lblTitle);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(280, 800);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(20, 740);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(240, 45);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "🚪 Sistemdən Çıx";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(20, 680);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(240, 45);
            this.btnSettings.TabIndex = 10;
            this.btnSettings.Text = "⚙️ Parametrlər";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(20, 620);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(240, 45);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "📊 Hesabatlar";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(20, 380);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(240, 45);
            this.btnInventory.TabIndex = 5;
            this.btnInventory.Text = "📦 Anbar İdarəetməsi";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnDebtManagement
            // 
            this.btnDebtManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDebtManagement.FlatAppearance.BorderSize = 0;
            this.btnDebtManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebtManagement.Font = new System.Drawing.Font(\"Segoe UI\", 12F, System.Drawing.FontStyle.Bold);
            this.btnDebtManagement.ForeColor = System.Drawing.Color.White;
            this.btnDebtManagement.Location = new System.Drawing.Point(20, 440);
            this.btnDebtManagement.Name = \"btnDebtManagement\";
            this.btnDebtManagement.Size = new System.Drawing.Size(240, 45);
            this.btnDebtManagement.TabIndex = 6;
            this.btnDebtManagement.Text = \"💳 Borc İdarəetməsi\";
            this.btnDebtManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDebtManagement.UseVisualStyleBackColor = false;
            this.btnDebtManagement.Click += new System.EventHandler(this.btnDebtManagement_Click);
            // 
            // btnRepairManagement
            // 
            this.btnRepairManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRepairManagement.FlatAppearance.BorderSize = 0;
            this.btnRepairManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairManagement.Font = new System.Drawing.Font(\"Segoe UI\", 12F, System.Drawing.FontStyle.Bold);
            this.btnRepairManagement.ForeColor = System.Drawing.Color.White;
            this.btnRepairManagement.Location = new System.Drawing.Point(20, 500);
            this.btnRepairManagement.Name = \"btnRepairManagement\";
            this.btnRepairManagement.Size = new System.Drawing.Size(240, 45);
            this.btnRepairManagement.TabIndex = 7;
            this.btnRepairManagement.Text = \"🔧 Təmir İdarəetməsi\";
            this.btnRepairManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairManagement.UseVisualStyleBackColor = false;
            this.btnRepairManagement.Click += new System.EventHandler(this.btnRepairManagement_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.Location = new System.Drawing.Point(20, 560);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(240, 45);
            this.btnPOS.TabIndex = 8;
            this.btnPOS.Text = "🛒 Satış POS";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // customerSubmenu
            // 
            this.customerSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.customerSubmenu.Controls.Add(this.btnCustomerGroups);
            this.customerSubmenu.Controls.Add(this.btnCustomerList);
            this.customerSubmenu.Controls.Add(this.btnCustomerAdd);
            this.customerSubmenu.Location = new System.Drawing.Point(20, 225);
            this.customerSubmenu.Name = "customerSubmenu";
            this.customerSubmenu.Size = new System.Drawing.Size(240, 135);
            this.customerSubmenu.TabIndex = 4;
            this.customerSubmenu.Visible = false;
            // 
            // btnCustomerGroups
            // 
            this.btnCustomerGroups.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerGroups.FlatAppearance.BorderSize = 0;
            this.btnCustomerGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerGroups.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomerGroups.ForeColor = System.Drawing.Color.White;
            this.btnCustomerGroups.Location = new System.Drawing.Point(20, 90);
            this.btnCustomerGroups.Name = "btnCustomerGroups";
            this.btnCustomerGroups.Size = new System.Drawing.Size(200, 35);
            this.btnCustomerGroups.TabIndex = 2;
            this.btnCustomerGroups.Text = "🏷️ Müştəri Qrupları";
            this.btnCustomerGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerGroups.UseVisualStyleBackColor = false;
            this.btnCustomerGroups.Click += new System.EventHandler(this.btnCustomerGroups_Click);
            // 
            // btnCustomerList
            // 
            this.btnCustomerList.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerList.FlatAppearance.BorderSize = 0;
            this.btnCustomerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomerList.ForeColor = System.Drawing.Color.White;
            this.btnCustomerList.Location = new System.Drawing.Point(20, 50);
            this.btnCustomerList.Name = "btnCustomerList";
            this.btnCustomerList.Size = new System.Drawing.Size(200, 35);
            this.btnCustomerList.TabIndex = 1;
            this.btnCustomerList.Text = "📋 Müştəri Siyahısı";
            this.btnCustomerList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerList.UseVisualStyleBackColor = false;
            this.btnCustomerList.Click += new System.EventHandler(this.btnCustomerList_Click);
            // 
            // btnCustomerAdd
            // 
            this.btnCustomerAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomerAdd.FlatAppearance.BorderSize = 0;
            this.btnCustomerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomerAdd.ForeColor = System.Drawing.Color.White;
            this.btnCustomerAdd.Location = new System.Drawing.Point(20, 10);
            this.btnCustomerAdd.Name = "btnCustomerAdd";
            this.btnCustomerAdd.Size = new System.Drawing.Size(200, 35);
            this.btnCustomerAdd.TabIndex = 0;
            this.btnCustomerAdd.Text = "➕ Yeni Müştəri";
            this.btnCustomerAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerAdd.UseVisualStyleBackColor = false;
            this.btnCustomerAdd.Click += new System.EventHandler(this.btnCustomerAdd_Click);
            // 
            // btnCustomerManagement
            // 
            this.btnCustomerManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnCustomerManagement.FlatAppearance.BorderSize = 0;
            this.btnCustomerManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCustomerManagement.ForeColor = System.Drawing.Color.White;
            this.btnCustomerManagement.Location = new System.Drawing.Point(20, 180);
            this.btnCustomerManagement.Name = "btnCustomerManagement";
            this.btnCustomerManagement.Size = new System.Drawing.Size(240, 45);
            this.btnCustomerManagement.TabIndex = 3;
            this.btnCustomerManagement.Text = "👥 Müştəri İdarəetməsi";
            this.btnCustomerManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerManagement.UseVisualStyleBackColor = false;
            this.btnCustomerManagement.Click += new System.EventHandler(this.btnCustomerManagement_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(20, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(240, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "🏠 Ana Səhifə";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font(\"Segoe UI\", 12F, System.Drawing.FontStyle.Bold);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(20, 130);
            this.btnUserManagement.Name = \"btnUserManagement\";
            this.btnUserManagement.Size = new System.Drawing.Size(240, 45);
            this.btnUserManagement.TabIndex = 2;
            this.btnUserManagement.Text = \"👤 İstifadəçi İdarəetməsi\";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🌾 AzAgroPOS";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.headerPanel.Controls.Add(this.lblWelcome);
            this.headerPanel.Controls.Add(this.lblRole);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(280, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(920, 80);
            this.headerPanel.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(245, 30);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Xoş gəldiniz, İstifadəçi";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRole.ForeColor = System.Drawing.Color.DarkGray;
            this.lblRole.Location = new System.Drawing.Point(20, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(101, 21);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Rol: İstifadəçi";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.dashboardPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(280, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(920, 720);
            this.contentPanel.TabIndex = 2;
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.BackColor = System.Drawing.Color.White;
            this.dashboardPanel.Controls.Add(this.lblDashboardTitle);
            this.dashboardPanel.Controls.Add(this.grpQuickActions);
            this.dashboardPanel.Controls.Add(this.grpQuickStats);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardPanel.Location = new System.Drawing.Point(0, 0);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(920, 720);
            this.dashboardPanel.TabIndex = 0;
            // 
            // grpQuickActions
            // 
            this.grpQuickActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.grpQuickActions.Controls.Add(this.btnQuickReports);
            this.grpQuickActions.Controls.Add(this.btnQuickInventory);
            this.grpQuickActions.Controls.Add(this.btnQuickCustomerAdd);
            this.grpQuickActions.Controls.Add(this.btnQuickPOS);
            this.grpQuickActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpQuickActions.Location = new System.Drawing.Point(30, 270);
            this.grpQuickActions.Name = "grpQuickActions";
            this.grpQuickActions.Size = new System.Drawing.Size(860, 200);
            this.grpQuickActions.TabIndex = 2;
            this.grpQuickActions.TabStop = false;
            this.grpQuickActions.Text = "⚡ Tez Əməliyyatlar";
            // 
            // btnQuickReports
            // 
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Location = new System.Drawing.Point(650, 40);
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Size = new System.Drawing.Size(180, 120);
            this.btnQuickReports.TabIndex = 3;
            this.btnQuickReports.Text = "📊\n\nHesabatlar";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            this.btnQuickReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnQuickInventory
            // 
            this.btnQuickInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnQuickInventory.FlatAppearance.BorderSize = 0;
            this.btnQuickInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickInventory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickInventory.ForeColor = System.Drawing.Color.White;
            this.btnQuickInventory.Location = new System.Drawing.Point(450, 40);
            this.btnQuickInventory.Name = "btnQuickInventory";
            this.btnQuickInventory.Size = new System.Drawing.Size(180, 120);
            this.btnQuickInventory.TabIndex = 2;
            this.btnQuickInventory.Text = "📦\n\nAnbar";
            this.btnQuickInventory.UseVisualStyleBackColor = false;
            this.btnQuickInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnQuickCustomerAdd
            // 
            this.btnQuickCustomerAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnQuickCustomerAdd.FlatAppearance.BorderSize = 0;
            this.btnQuickCustomerAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickCustomerAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickCustomerAdd.ForeColor = System.Drawing.Color.White;
            this.btnQuickCustomerAdd.Location = new System.Drawing.Point(250, 40);
            this.btnQuickCustomerAdd.Name = "btnQuickCustomerAdd";
            this.btnQuickCustomerAdd.Size = new System.Drawing.Size(180, 120);
            this.btnQuickCustomerAdd.TabIndex = 1;
            this.btnQuickCustomerAdd.Text = "👥\n\nYeni Müştəri";
            this.btnQuickCustomerAdd.UseVisualStyleBackColor = false;
            this.btnQuickCustomerAdd.Click += new System.EventHandler(this.btnCustomerAdd_Click);
            // 
            // btnQuickPOS
            // 
            this.btnQuickPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnQuickPOS.FlatAppearance.BorderSize = 0;
            this.btnQuickPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickPOS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickPOS.ForeColor = System.Drawing.Color.White;
            this.btnQuickPOS.Location = new System.Drawing.Point(50, 40);
            this.btnQuickPOS.Name = "btnQuickPOS";
            this.btnQuickPOS.Size = new System.Drawing.Size(180, 120);
            this.btnQuickPOS.TabIndex = 0;
            this.btnQuickPOS.Text = "🛒\n\nSatış POS";
            this.btnQuickPOS.UseVisualStyleBackColor = false;
            this.btnQuickPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // grpQuickStats
            // 
            this.grpQuickStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.grpQuickStats.Controls.Add(this.lblTotalValue);
            this.grpQuickStats.Controls.Add(this.lblTodaySales);
            this.grpQuickStats.Controls.Add(this.lblTotalProducts);
            this.grpQuickStats.Controls.Add(this.lblTotalCustomers);
            this.grpQuickStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpQuickStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpQuickStats.Location = new System.Drawing.Point(30, 90);
            this.grpQuickStats.Name = "grpQuickStats";
            this.grpQuickStats.Size = new System.Drawing.Size(860, 150);
            this.grpQuickStats.TabIndex = 1;
            this.grpQuickStats.TabStop = false;
            this.grpQuickStats.Text = "📊 Tez Statistikalar";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalValue.Location = new System.Drawing.Point(630, 40);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(180, 80);
            this.lblTotalValue.TabIndex = 3;
            this.lblTotalValue.Text = "💰 Ümumi Dəyər\n\n₼12,345";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTodaySales
            // 
            this.lblTodaySales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblTodaySales.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTodaySales.ForeColor = System.Drawing.Color.White;
            this.lblTodaySales.Location = new System.Drawing.Point(430, 40);
            this.lblTodaySales.Name = "lblTodaySales";
            this.lblTodaySales.Size = new System.Drawing.Size(180, 80);
            this.lblTodaySales.TabIndex = 2;
            this.lblTodaySales.Text = "🛒 Bugünkü Satış\n\n89";
            this.lblTodaySales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblTotalProducts.Location = new System.Drawing.Point(230, 40);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(180, 80);
            this.lblTotalProducts.TabIndex = 1;
            this.lblTotalProducts.Text = "📦 Məhsullar\n\n567";
            this.lblTotalProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.White;
            this.lblTotalCustomers.Location = new System.Drawing.Point(30, 40);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(180, 80);
            this.lblTotalCustomers.TabIndex = 0;
            this.lblTotalCustomers.Text = "👥 Müştərilər\n\n1,234";
            this.lblTotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(23, 24);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(363, 37);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "🏠 Ana Səhifə - Dashboard";
            // 
            // statsPanel
            // 
            this.statsPanel.Location = new System.Drawing.Point(0, 0);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(200, 100);
            this.statsPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzAgroPOS - Ana Səhifə";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            this.customerSubmenu.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.dashboardPanel.ResumeLayout(false);
            this.dashboardPanel.PerformLayout();
            this.grpQuickActions.ResumeLayout(false);
            this.grpQuickStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}