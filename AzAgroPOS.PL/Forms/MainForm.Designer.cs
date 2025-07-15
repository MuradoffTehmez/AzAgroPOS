namespace AzAgroPOS.PL.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRepairManagement = new System.Windows.Forms.Button();
            this.btnDebtManagement = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.pnlCustomerSubmenu = new System.Windows.Forms.Panel();
            this.btnCustomerGroups = new System.Windows.Forms.Button();
            this.btnCustomerList = new System.Windows.Forms.Button();
            this.btnCustomerAdd = new System.Windows.Forms.Button();
            this.btnCustomerManagement = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.grpQuickActions = new System.Windows.Forms.GroupBox();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.btnQuickInventory = new System.Windows.Forms.Button();
            this.btnQuickCustomerAdd = new System.Windows.Forms.Button();
            this.btnQuickPOS = new System.Windows.Forms.Button();
            this.grpQuickStats = new System.Windows.Forms.GroupBox();
            this.lblStatTotalValue = new System.Windows.Forms.Label();
            this.lblStatTodaySales = new System.Windows.Forms.Label();
            this.lblStatTotalProducts = new System.Windows.Forms.Label();
            this.lblStatTotalCustomers = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlCustomerSubmenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.grpQuickActions.SuspendLayout();
            this.grpQuickStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnReports);
            this.pnlSidebar.Controls.Add(this.btnRepairManagement);
            this.pnlSidebar.Controls.Add(this.btnDebtManagement);
            this.pnlSidebar.Controls.Add(this.btnPOS);
            this.pnlSidebar.Controls.Add(this.btnInventory);
            this.pnlSidebar.Controls.Add(this.pnlCustomerSubmenu);
            this.pnlSidebar.Controls.Add(this.btnCustomerManagement);
            this.pnlSidebar.Controls.Add(this.btnUserManagement);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.lblAppTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(280, 800);
            this.pnlSidebar.TabIndex = 0;
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
            // btnRepairManagement
            // 
            this.btnRepairManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRepairManagement.FlatAppearance.BorderSize = 0;
            this.btnRepairManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRepairManagement.ForeColor = System.Drawing.Color.White;
            this.btnRepairManagement.Location = new System.Drawing.Point(20, 500);
            this.btnRepairManagement.Name = "btnRepairManagement";
            this.btnRepairManagement.Size = new System.Drawing.Size(240, 45);
            this.btnRepairManagement.TabIndex = 7;
            this.btnRepairManagement.Text = "🔧 Təmir İdarəetməsi";
            this.btnRepairManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepairManagement.UseVisualStyleBackColor = false;
            this.btnRepairManagement.Click += new System.EventHandler(this.btnRepairManagement_Click);
            // 
            // btnDebtManagement
            // 
            this.btnDebtManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDebtManagement.FlatAppearance.BorderSize = 0;
            this.btnDebtManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebtManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDebtManagement.ForeColor = System.Drawing.Color.White;
            this.btnDebtManagement.Location = new System.Drawing.Point(20, 440);
            this.btnDebtManagement.Name = "btnDebtManagement";
            this.btnDebtManagement.Size = new System.Drawing.Size(240, 45);
            this.btnDebtManagement.TabIndex = 6;
            this.btnDebtManagement.Text = "💳 Borc İdarəetməsi";
            this.btnDebtManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDebtManagement.UseVisualStyleBackColor = false;
            this.btnDebtManagement.Click += new System.EventHandler(this.btnDebtManagement_Click);
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
            // pnlCustomerSubmenu
            // 
            this.pnlCustomerSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlCustomerSubmenu.Controls.Add(this.btnCustomerGroups);
            this.pnlCustomerSubmenu.Controls.Add(this.btnCustomerList);
            this.pnlCustomerSubmenu.Controls.Add(this.btnCustomerAdd);
            this.pnlCustomerSubmenu.Location = new System.Drawing.Point(20, 225);
            this.pnlCustomerSubmenu.Name = "pnlCustomerSubmenu";
            this.pnlCustomerSubmenu.Size = new System.Drawing.Size(240, 135);
            this.pnlCustomerSubmenu.TabIndex = 4;
            this.pnlCustomerSubmenu.Visible = false;
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
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(20, 130);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(240, 45);
            this.btnUserManagement.TabIndex = 2;
            this.btnUserManagement.Text = "👤 İstifadəçi İdarəetməsi";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
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
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 20);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(187, 32);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "🌾 AzAgroPOS";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlHeader.Controls.Add(this.lblUserRole);
            this.pnlHeader.Controls.Add(this.lblWelcomeMessage);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(280, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(920, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserRole.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUserRole.Location = new System.Drawing.Point(20, 50);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(101, 21);
            this.lblUserRole.TabIndex = 1;
            this.lblUserRole.Text = "Rol: İstifadəçi";
            // 
            // lblWelcomeMessage
            // 
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblWelcomeMessage.Location = new System.Drawing.Point(20, 20);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(245, 30);
            this.lblWelcomeMessage.TabIndex = 0;
            this.lblWelcomeMessage.Text = "Xoş gəldiniz, İstifadəçi";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlDashboard);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(280, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(920, 720);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.White;
            this.pnlDashboard.Controls.Add(this.lblDashboardTitle);
            this.pnlDashboard.Controls.Add(this.grpQuickActions);
            this.pnlDashboard.Controls.Add(this.grpQuickStats);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(920, 720);
            this.pnlDashboard.TabIndex = 0;
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
            this.grpQuickStats.Controls.Add(this.lblStatTotalValue);
            this.grpQuickStats.Controls.Add(this.lblStatTodaySales);
            this.grpQuickStats.Controls.Add(this.lblStatTotalProducts);
            this.grpQuickStats.Controls.Add(this.lblStatTotalCustomers);
            this.grpQuickStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpQuickStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpQuickStats.Location = new System.Drawing.Point(30, 90);
            this.grpQuickStats.Name = "grpQuickStats";
            this.grpQuickStats.Size = new System.Drawing.Size(860, 150);
            this.grpQuickStats.TabIndex = 1;
            this.grpQuickStats.TabStop = false;
            this.grpQuickStats.Text = "📊 Tez Statistikalar";
            // 
            // lblStatTotalValue
            // 
            this.lblStatTotalValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblStatTotalValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatTotalValue.ForeColor = System.Drawing.Color.White;
            this.lblStatTotalValue.Location = new System.Drawing.Point(630, 40);
            this.lblStatTotalValue.Name = "lblStatTotalValue";
            this.lblStatTotalValue.Size = new System.Drawing.Size(180, 80);
            this.lblStatTotalValue.TabIndex = 3;
            this.lblStatTotalValue.Text = "💰 Ümumi Dəyər\n\n₼12,345";
            this.lblStatTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatTodaySales
            // 
            this.lblStatTodaySales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblStatTodaySales.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatTodaySales.ForeColor = System.Drawing.Color.White;
            this.lblStatTodaySales.Location = new System.Drawing.Point(430, 40);
            this.lblStatTodaySales.Name = "lblStatTodaySales";
            this.lblStatTodaySales.Size = new System.Drawing.Size(180, 80);
            this.lblStatTodaySales.TabIndex = 2;
            this.lblStatTodaySales.Text = "🛒 Bugünkü Satış\n\n89";
            this.lblStatTodaySales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatTotalProducts
            // 
            this.lblStatTotalProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblStatTotalProducts.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatTotalProducts.ForeColor = System.Drawing.Color.White;
            this.lblStatTotalProducts.Location = new System.Drawing.Point(230, 40);
            this.lblStatTotalProducts.Name = "lblStatTotalProducts";
            this.lblStatTotalProducts.Size = new System.Drawing.Size(180, 80);
            this.lblStatTotalProducts.TabIndex = 1;
            this.lblStatTotalProducts.Text = "📦 Məhsullar\n\n567";
            this.lblStatTotalProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatTotalCustomers
            // 
            this.lblStatTotalCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblStatTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatTotalCustomers.ForeColor = System.Drawing.Color.White;
            this.lblStatTotalCustomers.Location = new System.Drawing.Point(30, 40);
            this.lblStatTotalCustomers.Name = "lblStatTotalCustomers";
            this.lblStatTotalCustomers.Size = new System.Drawing.Size(180, 80);
            this.lblStatTotalCustomers.TabIndex = 0;
            this.lblStatTotalCustomers.Text = "👥 Müştərilər\n\n1,234";
            this.lblStatTotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzAgroPOS - Ana Səhifə";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlCustomerSubmenu.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.grpQuickActions.ResumeLayout(false);
            this.grpQuickStats.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnCustomerManagement;
        private System.Windows.Forms.Panel pnlCustomerSubmenu;
        private System.Windows.Forms.Button btnCustomerAdd;
        private System.Windows.Forms.Button btnCustomerList;
        private System.Windows.Forms.Button btnCustomerGroups;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnDebtManagement;
        private System.Windows.Forms.Button btnRepairManagement;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.GroupBox grpQuickStats;
        private System.Windows.Forms.Label lblStatTotalCustomers;
        private System.Windows.Forms.Label lblStatTotalProducts;
        private System.Windows.Forms.Label lblStatTodaySales;
        private System.Windows.Forms.Label lblStatTotalValue;
        private System.Windows.Forms.GroupBox grpQuickActions;
        private System.Windows.Forms.Button btnQuickPOS;
        private System.Windows.Forms.Button btnQuickCustomerAdd;
        private System.Windows.Forms.Button btnQuickInventory;
        private System.Windows.Forms.Button btnQuickReports;
    }
}