namespace AzAgroPOS.PL
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAppearance = new System.Windows.Forms.TabPage();
            this.panelTheme = new System.Windows.Forms.Panel();
            this.rbDarkTheme = new System.Windows.Forms.RadioButton();
            this.rbLightTheme = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageManagement = new System.Windows.Forms.TabPage();
            this.panelManagement = new System.Windows.Forms.Panel();
            this.btnAuditLog = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageAppearance.SuspendLayout();
            this.panelTheme.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.tabPageManagement.SuspendLayout();
            this.panelManagement.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAppearance);
            this.tabControl1.Controls.Add(this.tabPageManagement);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAppearance
            // 
            this.tabPageAppearance.BackColor = System.Drawing.Color.White;
            this.tabPageAppearance.Controls.Add(this.panelTheme);
            this.tabPageAppearance.Controls.Add(this.panelLanguage);
            this.tabPageAppearance.Location = new System.Drawing.Point(4, 34);
            this.tabPageAppearance.Name = "tabPageAppearance";
            this.tabPageAppearance.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageAppearance.Size = new System.Drawing.Size(792, 462);
            this.tabPageAppearance.TabIndex = 0;
            this.tabPageAppearance.Text = "Görünüş Ayarları";
            // 
            // panelTheme
            // 
            this.panelTheme.BackColor = System.Drawing.Color.White;
            this.panelTheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTheme.Controls.Add(this.rbDarkTheme);
            this.panelTheme.Controls.Add(this.rbLightTheme);
            this.panelTheme.Controls.Add(this.label1);
            this.panelTheme.Location = new System.Drawing.Point(13, 13);
            this.panelTheme.Name = "panelTheme";
            this.panelTheme.Padding = new System.Windows.Forms.Padding(10);
            this.panelTheme.Size = new System.Drawing.Size(350, 150);
            this.panelTheme.TabIndex = 0;
            // 
            // rbDarkTheme
            // 
            this.rbDarkTheme.AutoSize = true;
            this.rbDarkTheme.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDarkTheme.Location = new System.Drawing.Point(13, 85);
            this.rbDarkTheme.Name = "rbDarkTheme";
            this.rbDarkTheme.Size = new System.Drawing.Size(125, 27);
            this.rbDarkTheme.TabIndex = 2;
            this.rbDarkTheme.TabStop = true;
            this.rbDarkTheme.Text = "Qaranlıq Tema";
            this.rbDarkTheme.UseVisualStyleBackColor = true;
            // 
            // rbLightTheme
            // 
            this.rbLightTheme.AutoSize = true;
            this.rbLightTheme.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLightTheme.Location = new System.Drawing.Point(13, 52);
            this.rbLightTheme.Name = "rbLightTheme";
            this.rbLightTheme.Size = new System.Drawing.Size(102, 27);
            this.rbLightTheme.TabIndex = 1;
            this.rbLightTheme.TabStop = true;
            this.rbLightTheme.Text = "Açıq Tema";
            this.rbLightTheme.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tema Seçimi";
            // 
            // panelLanguage
            // 
            this.panelLanguage.BackColor = System.Drawing.Color.White;
            this.panelLanguage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLanguage.Controls.Add(this.cmbLanguage);
            this.panelLanguage.Controls.Add(this.label2);
            this.panelLanguage.Location = new System.Drawing.Point(13, 180);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Padding = new System.Windows.Forms.Padding(10);
            this.panelLanguage.Size = new System.Drawing.Size(350, 150);
            this.panelLanguage.TabIndex = 1;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Azərbaycanca",
            "English",
            "Русский"});
            this.cmbLanguage.Location = new System.Drawing.Point(13, 52);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(300, 31);
            this.cmbLanguage.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dil Seçimi";
            // 
            // tabPageManagement
            // 
            this.tabPageManagement.BackColor = System.Drawing.Color.White;
            this.tabPageManagement.Controls.Add(this.panelManagement);
            this.tabPageManagement.Location = new System.Drawing.Point(4, 34);
            this.tabPageManagement.Name = "tabPageManagement";
            this.tabPageManagement.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageManagement.Size = new System.Drawing.Size(792, 462);
            this.tabPageManagement.TabIndex = 1;
            this.tabPageManagement.Text = "İdarəetmə";
            // 
            // panelManagement
            // 
            this.panelManagement.BackColor = System.Drawing.Color.White;
            this.panelManagement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelManagement.Controls.Add(this.btnAuditLog);
            this.panelManagement.Controls.Add(this.btnUsers);
            this.panelManagement.Location = new System.Drawing.Point(13, 13);
            this.panelManagement.Name = "panelManagement";
            this.panelManagement.Padding = new System.Windows.Forms.Padding(10);
            this.panelManagement.Size = new System.Drawing.Size(350, 150);
            this.panelManagement.TabIndex = 0;
            // 
            // btnAuditLog
            // 
            this.btnAuditLog.BackColor = System.Drawing.Color.White;
            this.btnAuditLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAuditLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditLog.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditLog.Image = ((System.Drawing.Image)(resources.GetObject("btnAuditLog.Image")));
            this.btnAuditLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLog.Location = new System.Drawing.Point(13, 85);
            this.btnAuditLog.Name = "btnAuditLog";
            this.btnAuditLog.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAuditLog.Size = new System.Drawing.Size(300, 40);
            this.btnAuditLog.TabIndex = 1;
            this.btnAuditLog.Text = "Audit Log";
            this.btnAuditLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAuditLog.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.White;
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(13, 35);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(300, 40);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "İstifadəçilərin İdarə Edilməsi";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnSaveSettings);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(800, 70);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSaveSettings.FlatAppearance.BorderSize = 0;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(630, 10);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(160, 50);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Yadda Saxla";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(460, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelButtons);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tənzimləmələr";
            //this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageAppearance.ResumeLayout(false);
            this.panelTheme.ResumeLayout(false);
            this.panelTheme.PerformLayout();
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguage.PerformLayout();
            this.tabPageManagement.ResumeLayout(false);
            this.panelManagement.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAppearance;
        private System.Windows.Forms.Panel panelTheme;
        private System.Windows.Forms.RadioButton rbDarkTheme;
        private System.Windows.Forms.RadioButton rbLightTheme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageManagement;
        private System.Windows.Forms.Panel panelManagement;
        private System.Windows.Forms.Button btnAuditLog;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancel;
    }
}