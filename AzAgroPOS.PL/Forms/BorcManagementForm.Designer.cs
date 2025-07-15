namespace AzAgroPOS.PL.Forms
{
    partial class BorcManagementForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalDebtLabel = new System.Windows.Forms.Label();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblOverdueDebtLabel = new System.Windows.Forms.Label();
            this.lblOverdueDebt = new System.Windows.Forms.Label();
            this.lblTotalInterestLabel = new System.Windows.Forms.Label();
            this.lblTotalInterest = new System.Windows.Forms.Label();
            this.lblCustomerCountLabel = new System.Windows.Forms.Label();
            this.lblCustomerCount = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnAddDebt = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnFilterByStatus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvDebts = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(30, 25);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(371, 37);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "💳 Borc/Nisyə İdarəetməsi";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.Controls.Add(this.lblCustomerCount);
            this.pnlStats.Controls.Add(this.lblCustomerCountLabel);
            this.pnlStats.Controls.Add(this.lblTotalInterest);
            this.pnlStats.Controls.Add(this.lblTotalInterestLabel);
            this.pnlStats.Controls.Add(this.lblOverdueDebt);
            this.pnlStats.Controls.Add(this.lblOverdueDebtLabel);
            this.pnlStats.Controls.Add(this.lblTotalDebt);
            this.pnlStats.Controls.Add(this.lblTotalDebtLabel);
            this.pnlStats.Location = new System.Drawing.Point(20, 100);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1160, 100);
            this.pnlStats.TabIndex = 1;
            // 
            // lblTotalDebtLabel
            // 
            this.lblTotalDebtLabel.AutoSize = true;
            this.lblTotalDebtLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalDebtLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTotalDebtLabel.Location = new System.Drawing.Point(30, 20);
            this.lblTotalDebtLabel.Name = "lblTotalDebtLabel";
            this.lblTotalDebtLabel.Size = new System.Drawing.Size(84, 19);
            this.lblTotalDebtLabel.TabIndex = 0;
            this.lblTotalDebtLabel.Text = "Ümumi Borc";
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalDebt.Location = new System.Drawing.Point(30, 45);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(47, 30);
            this.lblTotalDebt.TabIndex = 1;
            this.lblTotalDebt.Text = "0 ₼";
            // 
            // lblOverdueDebtLabel
            // 
            this.lblOverdueDebtLabel.AutoSize = true;
            this.lblOverdueDebtLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOverdueDebtLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblOverdueDebtLabel.Location = new System.Drawing.Point(320, 20);
            this.lblOverdueDebtLabel.Name = "lblOverdueDebtLabel";
            this.lblOverdueDebtLabel.Size = new System.Drawing.Size(98, 19);
            this.lblOverdueDebtLabel.TabIndex = 2;
            this.lblOverdueDebtLabel.Text = "Gecikmiş Borc";
            // 
            // lblOverdueDebt
            // 
            this.lblOverdueDebt.AutoSize = true;
            this.lblOverdueDebt.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblOverdueDebt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblOverdueDebt.Location = new System.Drawing.Point(320, 45);
            this.lblOverdueDebt.Name = "lblOverdueDebt";
            this.lblOverdueDebt.Size = new System.Drawing.Size(47, 30);
            this.lblOverdueDebt.TabIndex = 3;
            this.lblOverdueDebt.Text = "0 ₼";
            // 
            // lblTotalInterestLabel
            // 
            this.lblTotalInterestLabel.AutoSize = true;
            this.lblTotalInterestLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalInterestLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTotalInterestLabel.Location = new System.Drawing.Point(610, 20);
            this.lblTotalInterestLabel.Name = "lblTotalInterestLabel";
            this.lblTotalInterestLabel.Size = new System.Drawing.Size(85, 19);
            this.lblTotalInterestLabel.TabIndex = 4;
            this.lblTotalInterestLabel.Text = "Ümumi Faiz";
            // 
            // lblTotalInterest
            // 
            this.lblTotalInterest.AutoSize = true;
            this.lblTotalInterest.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalInterest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblTotalInterest.Location = new System.Drawing.Point(610, 45);
            this.lblTotalInterest.Name = "lblTotalInterest";
            this.lblTotalInterest.Size = new System.Drawing.Size(47, 30);
            this.lblTotalInterest.TabIndex = 5;
            this.lblTotalInterest.Text = "0 ₼";
            // 
            // lblCustomerCountLabel
            // 
            this.lblCustomerCountLabel.AutoSize = true;
            this.lblCustomerCountLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomerCountLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCustomerCountLabel.Location = new System.Drawing.Point(900, 20);
            this.lblCustomerCountLabel.Name = "lblCustomerCountLabel";
            this.lblCustomerCountLabel.Size = new System.Drawing.Size(109, 19);
            this.lblCustomerCountLabel.TabIndex = 6;
            this.lblCustomerCountLabel.Text = "Borcu olan sayı";
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCustomerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblCustomerCount.Location = new System.Drawing.Point(900, 45);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new System.Drawing.Size(25, 30);
            this.lblCustomerCount.TabIndex = 7;
            this.lblCustomerCount.Text = "0";
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.White;
            this.pnlControls.Controls.Add(this.cmbCustomer);
            this.pnlControls.Controls.Add(this.lblCustomer);
            this.pnlControls.Controls.Add(this.btnRefresh);
            this.pnlControls.Controls.Add(this.btnFilterByStatus);
            this.pnlControls.Controls.Add(this.btnViewDetails);
            this.pnlControls.Controls.Add(this.btnAddPayment);
            this.pnlControls.Controls.Add(this.btnAddDebt);
            this.pnlControls.Location = new System.Drawing.Point(20, 220);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1160, 80);
            this.pnlControls.TabIndex = 2;
            // 
            // btnAddDebt
            // 
            this.btnAddDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddDebt.FlatAppearance.BorderSize = 0;
            this.btnAddDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDebt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddDebt.ForeColor = System.Drawing.Color.White;
            this.btnAddDebt.Location = new System.Drawing.Point(30, 20);
            this.btnAddDebt.Name = "btnAddDebt";
            this.btnAddDebt.Size = new System.Drawing.Size(130, 40);
            this.btnAddDebt.TabIndex = 0;
            this.btnAddDebt.Text = "➕ Yeni Borc";
            this.btnAddDebt.UseVisualStyleBackColor = false;
            this.btnAddDebt.Click += new System.EventHandler(this.btnAddDebt_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddPayment.FlatAppearance.BorderSize = 0;
            this.btnAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(180, 20);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(130, 40);
            this.btnAddPayment.TabIndex = 1;
            this.btnAddPayment.Text = "💰 Ödəniş";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(330, 20);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(130, 40);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "📄 Təfərrüat";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnFilterByStatus
            // 
            this.btnFilterByStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnFilterByStatus.FlatAppearance.BorderSize = 0;
            this.btnFilterByStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterByStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilterByStatus.ForeColor = System.Drawing.Color.White;
            this.btnFilterByStatus.Location = new System.Drawing.Point(480, 20);
            this.btnFilterByStatus.Name = "btnFilterByStatus";
            this.btnFilterByStatus.Size = new System.Drawing.Size(130, 40);
            this.btnFilterByStatus.TabIndex = 3;
            this.btnFilterByStatus.Text = "🔍 Filtr";
            this.btnFilterByStatus.UseVisualStyleBackColor = false;
            this.btnFilterByStatus.Click += new System.EventHandler(this.btnFilterByStatus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(630, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "🔄 Yenilə";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomer.Location = new System.Drawing.Point(810, 28);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(64, 19);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Müştəri:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(880, 25);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(200, 25);
            this.cmbCustomer.TabIndex = 6;
            // 
            // pnlData
            // 
            this.pnlData.BackColor = System.Drawing.Color.White;
            this.pnlData.Controls.Add(this.dgvDebts);
            this.pnlData.Location = new System.Drawing.Point(20, 320);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1160, 400);
            this.pnlData.TabIndex = 3;
            // 
            // dgvDebts
            // 
            this.dgvDebts.AllowUserToAddRows = false;
            this.dgvDebts.AllowUserToDeleteRows = false;
            this.dgvDebts.BackgroundColor = System.Drawing.Color.White;
            this.dgvDebts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDebts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDebts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDebts.Location = new System.Drawing.Point(0, 0);
            this.dgvDebts.MultiSelect = false;
            this.dgvDebts.Name = "dgvDebts";
            this.dgvDebts.ReadOnly = true;
            this.dgvDebts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDebts.Size = new System.Drawing.Size(1160, 400);
            this.dgvDebts.TabIndex = 0;
            this.dgvDebts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDebts_CellDoubleClick);
            // 
            // BorcManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 740);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BorcManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Borc/Nisyə İdarəetməsi";
            this.Load += new System.EventHandler(this.BorcManagementForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalDebtLabel;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblOverdueDebtLabel;
        private System.Windows.Forms.Label lblOverdueDebt;
        private System.Windows.Forms.Label lblTotalInterestLabel;
        private System.Windows.Forms.Label lblTotalInterest;
        private System.Windows.Forms.Label lblCustomerCountLabel;
        private System.Windows.Forms.Label lblCustomerCount;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnAddDebt;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnFilterByStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvDebts;
    }
}