namespace AzAgroPOS.PL.Forms
{
    partial class RepairAnalyticsForm
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
            pnlControls = new System.Windows.Forms.Panel();
            lblStartDate = new System.Windows.Forms.Label();
            dtpStartDate = new System.Windows.Forms.DateTimePicker();
            lblEndDate = new System.Windows.Forms.Label();
            dtpEndDate = new System.Windows.Forms.DateTimePicker();
            btnGenerate = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
            pnlSummary = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            pnlControls.SuspendLayout();
            SuspendLayout();
            // 
            // pnlControls
            // 
            pnlControls.Controls.Add(lblStartDate);
            pnlControls.Controls.Add(dtpStartDate);
            pnlControls.Controls.Add(lblEndDate);
            pnlControls.Controls.Add(dtpEndDate);
            pnlControls.Controls.Add(btnGenerate);
            pnlControls.Controls.Add(btnExport);
            pnlControls.Controls.Add(lblTitle);
            pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            pnlControls.Location = new System.Drawing.Point(0, 0);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new System.Drawing.Size(1200, 60);
            pnlControls.TabIndex = 0;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new System.Drawing.Point(10, 20);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(60, 15);
            lblStartDate.TabIndex = 0;
            lblStartDate.Text = "Başlanğıc:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new System.Drawing.Point(85, 18);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(120, 23);
            dtpStartDate.TabIndex = 1;
            dtpStartDate.Value = new System.DateTime(2025, 6, 17, 17, 22, 53, 126);
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new System.Drawing.Point(220, 20);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new System.Drawing.Size(41, 15);
            lblEndDate.TabIndex = 2;
            lblEndDate.Text = "Bitmə:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new System.Drawing.Point(275, 18);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new System.Drawing.Size(120, 23);
            dtpEndDate.TabIndex = 3;
            dtpEndDate.Value = new System.DateTime(2025, 7, 17, 17, 22, 53, 130);
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = System.Drawing.Color.LightBlue;
            btnGenerate.Location = new System.Drawing.Point(570, 17);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(100, 25);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "Hesabat Al";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click_1;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.LightGreen;
            btnExport.Enabled = false;
            btnExport.Location = new System.Drawing.Point(680, 17);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(80, 25);
            btnExport.TabIndex = 5;
            btnExport.Text = "İxrac Et";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click_1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.Location = new System.Drawing.Point(800, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(128, 17);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Təmir Analitikası";
            // 
            // pnlSummary
            // 
            pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSummary.Location = new System.Drawing.Point(0, 60);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new System.Drawing.Size(1200, 100);
            pnlSummary.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 160);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1200, 640);
            tabControl.TabIndex = 2;
            // 
            // RepairAnalyticsForm
            // 
            ClientSize = new System.Drawing.Size(1200, 800);
            Controls.Add(tabControl);
            Controls.Add(pnlSummary);
            Controls.Add(pnlControls);
            Name = "RepairAnalyticsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Təmir Analitikası";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.TabControl tabControl;
    }
}