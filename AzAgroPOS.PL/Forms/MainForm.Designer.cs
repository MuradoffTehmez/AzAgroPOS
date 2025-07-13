namespace AzAgroPOS.PL.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnRoleManagement = new System.Windows.Forms.Button();
            this.btnProductManagement = new System.Windows.Forms.Button();
            this.btnCategoryManagement = new System.Windows.Forms.Button();
            this.btnWarehouseManagement = new System.Windows.Forms.Button();
            this.btnDebtManagement = new System.Windows.Forms.Button();
            this.btnRepairManagement = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(200, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(528, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🌾 AzAgroPOS İdarəetmə Sistemi";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(180, 21);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Xoş gəldiniz, İstifadəçi";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblRole.ForeColor = System.Drawing.Color.DarkGray;
            this.lblRole.Location = new System.Drawing.Point(20, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(91, 19);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Rol: İstifadəçi";
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(30, 30);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(200, 60);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "➕ Yeni İstifadəçi";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(250, 30);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(200, 60);
            this.btnUserManagement.TabIndex = 4;
            this.btnUserManagement.Text = "👥 İstifadəçi İdarəetməsi";
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnRoleManagement
            // 
            this.btnRoleManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnRoleManagement.FlatAppearance.BorderSize = 0;
            this.btnRoleManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRoleManagement.ForeColor = System.Drawing.Color.White;
            this.btnRoleManagement.Location = new System.Drawing.Point(470, 30);
            this.btnRoleManagement.Name = "btnRoleManagement";
            this.btnRoleManagement.Size = new System.Drawing.Size(200, 60);
            this.btnRoleManagement.TabIndex = 5;
            this.btnRoleManagement.Text = "🔐 Rol İdarəetməsi";
            this.btnRoleManagement.UseVisualStyleBackColor = false;
            this.btnRoleManagement.Click += new System.EventHandler(this.btnRoleManagement_Click);
            // 
            // btnProductManagement
            // 
            this.btnProductManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProductManagement.FlatAppearance.BorderSize = 0;
            this.btnProductManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProductManagement.ForeColor = System.Drawing.Color.White;
            this.btnProductManagement.Location = new System.Drawing.Point(30, 120);
            this.btnProductManagement.Name = "btnProductManagement";
            this.btnProductManagement.Size = new System.Drawing.Size(200, 60);
            this.btnProductManagement.TabIndex = 8;
            this.btnProductManagement.Text = "📦 Məhsul İdarəetməsi";
            this.btnProductManagement.UseVisualStyleBackColor = false;
            this.btnProductManagement.Click += new System.EventHandler(this.btnProductManagement_Click);
            // 
            // btnCategoryManagement
            // 
            this.btnCategoryManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnCategoryManagement.FlatAppearance.BorderSize = 0;
            this.btnCategoryManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCategoryManagement.ForeColor = System.Drawing.Color.White;
            this.btnCategoryManagement.Location = new System.Drawing.Point(250, 120);
            this.btnCategoryManagement.Name = "btnCategoryManagement";
            this.btnCategoryManagement.Size = new System.Drawing.Size(200, 60);
            this.btnCategoryManagement.TabIndex = 9;
            this.btnCategoryManagement.Text = "📂 Kateqoriya İdarəetməsi";
            this.btnCategoryManagement.UseVisualStyleBackColor = false;
            this.btnCategoryManagement.Click += new System.EventHandler(this.btnCategoryManagement_Click);
            // 
            // btnWarehouseManagement
            // 
            this.btnWarehouseManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnWarehouseManagement.FlatAppearance.BorderSize = 0;
            this.btnWarehouseManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouseManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnWarehouseManagement.ForeColor = System.Drawing.Color.White;
            this.btnWarehouseManagement.Location = new System.Drawing.Point(470, 120);
            this.btnWarehouseManagement.Name = "btnWarehouseManagement";
            this.btnWarehouseManagement.Size = new System.Drawing.Size(200, 60);
            this.btnWarehouseManagement.TabIndex = 10;
            this.btnWarehouseManagement.Text = "🏭 Anbar İdarəetməsi";
            this.btnWarehouseManagement.UseVisualStyleBackColor = false;
            this.btnWarehouseManagement.Click += new System.EventHandler(this.btnWarehouseManagement_Click);
            // 
            // btnDebtManagement
            // 
            this.btnDebtManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDebtManagement.FlatAppearance.BorderSize = 0;
            this.btnDebtManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebtManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDebtManagement.ForeColor = System.Drawing.Color.White;
            this.btnDebtManagement.Location = new System.Drawing.Point(30, 200);
            this.btnDebtManagement.Name = "btnDebtManagement";
            this.btnDebtManagement.Size = new System.Drawing.Size(200, 60);
            this.btnDebtManagement.TabIndex = 11;
            this.btnDebtManagement.Text = "💳 Borc/Nisyə İdarəetməsi";
            this.btnDebtManagement.UseVisualStyleBackColor = false;
            this.btnDebtManagement.Click += new System.EventHandler(this.btnDebtManagement_Click);
            // 
            // btnRepairManagement
            // 
            this.btnRepairManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnRepairManagement.FlatAppearance.BorderSize = 0;
            this.btnRepairManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRepairManagement.ForeColor = System.Drawing.Color.White;
            this.btnRepairManagement.Location = new System.Drawing.Point(250, 200);
            this.btnRepairManagement.Name = "btnRepairManagement";
            this.btnRepairManagement.Size = new System.Drawing.Size(200, 60);
            this.btnRepairManagement.TabIndex = 12;
            this.btnRepairManagement.Text = "🔧 Təmir/Servis İdarəetməsi";
            this.btnRepairManagement.UseVisualStyleBackColor = false;
            this.btnRepairManagement.Click += new System.EventHandler(this.btnRepairManagement_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.Location = new System.Drawing.Point(470, 200);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(200, 60);
            this.btnPOS.TabIndex = 13;
            this.btnPOS.Text = "🛒 Satış POS";
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(30, 280);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 60);
            this.btnReports.TabIndex = 14;
            this.btnReports.Text = "📊 Hesabatlar";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(250, 280);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(200, 60);
            this.btnSettings.TabIndex = 15;
            this.btnSettings.Text = "⚙️ Parametrlər";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(470, 280);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 60);
            this.btnLogout.TabIndex = 16;
            this.btnLogout.Text = "🚪 Sistemdən Çıx";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 80);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Controls.Add(this.btnPOS);
            this.panel2.Controls.Add(this.btnRepairManagement);
            this.panel2.Controls.Add(this.btnDebtManagement);
            this.panel2.Controls.Add(this.btnWarehouseManagement);
            this.panel2.Controls.Add(this.btnUserManagement);
            this.panel2.Controls.Add(this.btnRoleManagement);
            this.panel2.Controls.Add(this.btnProductManagement);
            this.panel2.Controls.Add(this.btnCategoryManagement);
            this.panel2.Controls.Add(this.btnAddUser);
            this.panel2.Location = new System.Drawing.Point(50, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 370);
            this.panel2.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzAgroPOS - Ana Səhifə";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnRoleManagement;
        private System.Windows.Forms.Button btnProductManagement;
        private System.Windows.Forms.Button btnCategoryManagement;
        private System.Windows.Forms.Button btnWarehouseManagement;
        private System.Windows.Forms.Button btnDebtManagement;
        private System.Windows.Forms.Button btnRepairManagement;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}