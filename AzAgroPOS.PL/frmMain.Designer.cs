namespace AzAgroPOS.PL
{
    partial class frmMain
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

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.faylToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.çıxışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.təmirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müştərilərToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesabatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tənzimləmələrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faylToolStripMenuItem,
            this.satışToolStripMenuItem,
            this.anbarToolStripMenuItem,
            this.təmirToolStripMenuItem,
            this.müştərilərToolStripMenuItem,
            this.hesabatlarToolStripMenuItem,
            this.tənzimləmələrToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // faylToolStripMenuItem
            // 
            this.faylToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.çıxışToolStripMenuItem});
            this.faylToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.faylToolStripMenuItem.Name = "faylToolStripMenuItem";
            this.faylToolStripMenuItem.Size = new System.Drawing.Size(45, 23);
            this.faylToolStripMenuItem.Text = "Fayl";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(102, 6);
            // 
            // çıxışToolStripMenuItem
            // 
            this.çıxışToolStripMenuItem.Name = "çıxışToolStripMenuItem";
            this.çıxışToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.çıxışToolStripMenuItem.Text = "Çıxış";
            this.çıxışToolStripMenuItem.Click += new System.EventHandler(this.çıxışToolStripMenuItem_Click);
            // 
            // satışToolStripMenuItem
            // 
            this.satışToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.satışToolStripMenuItem.Name = "satışToolStripMenuItem";
            this.satışToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
            this.satışToolStripMenuItem.Text = "Satış";
            this.satışToolStripMenuItem.Click += new System.EventHandler(this.satışToolStripMenuItem_Click);
            // 
            // anbarToolStripMenuItem
            // 
            this.anbarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.anbarToolStripMenuItem.Name = "anbarToolStripMenuItem";
            this.anbarToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.anbarToolStripMenuItem.Text = "Anbar";
            this.anbarToolStripMenuItem.Click += new System.EventHandler(this.anbarToolStripMenuItem_Click_1);
            // 
            // təmirToolStripMenuItem
            // 
            this.təmirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.təmirToolStripMenuItem.Name = "təmirToolStripMenuItem";
            this.təmirToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.təmirToolStripMenuItem.Text = "Təmir";
            this.təmirToolStripMenuItem.Click += new System.EventHandler(this.təmirToolStripMenuItem_Click);
            // 
            // müştərilərToolStripMenuItem
            // 
            this.müştərilərToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.müştərilərToolStripMenuItem.Name = "müştərilərToolStripMenuItem";
            this.müştərilərToolStripMenuItem.Size = new System.Drawing.Size(83, 23);
            this.müştərilərToolStripMenuItem.Text = "Müştərilər";
            this.müştərilərToolStripMenuItem.Click += new System.EventHandler(this.müştərilərToolStripMenuItem_Click);
            // 
            // hesabatlarToolStripMenuItem
            // 
            this.hesabatlarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hesabatlarToolStripMenuItem.Name = "hesabatlarToolStripMenuItem";
            this.hesabatlarToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
            this.hesabatlarToolStripMenuItem.Text = "Hesabatlar";
            this.hesabatlarToolStripMenuItem.Click += new System.EventHandler(this.hesabatlarToolStripMenuItem_Click);
            // 
            // tənzimləmələrToolStripMenuItem
            // 
            this.tənzimləmələrToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tənzimləmələrToolStripMenuItem.Name = "tənzimləmələrToolStripMenuItem";
            this.tənzimləmələrToolStripMenuItem.Size = new System.Drawing.Size(108, 23);
            this.tənzimləmələrToolStripMenuItem.Text = "Tənzimləmələr";
            this.tənzimləmələrToolStripMenuItem.Click += new System.EventHandler(this.tənzimləmələrToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCurrentUser,
            this.toolStripStatusSeparator,
            this.lblDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(66, 17);
            this.lblCurrentUser.Text = "Hazırlanır...";
            // 
            // toolStripStatusSeparator
            // 
            this.toolStripStatusSeparator.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusSeparator.Name = "toolStripStatusSeparator";
            this.toolStripStatusSeparator.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusSeparator.Text = "|";
            // 
            // lblDateTime
            // 
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(0, 17);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 27);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 623);
            this.panelMain.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 672);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzAgroPOS - Ana Pəncərə";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem faylToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıxışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem təmirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem müştərilərToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hesabatlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tənzimləmələrToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSeparator;
        private System.Windows.Forms.Panel panelMain;
    }
}