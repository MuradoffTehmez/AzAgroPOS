namespace AzAgroPOS.PL.Forms
{
    partial class TamirManagementForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMonthlyRevenue = new System.Windows.Forms.Label();
            this.lblMonthlyRevenueLabel = new System.Windows.Forms.Label();
            this.lblOverdueRepairs = new System.Windows.Forms.Label();
            this.lblOverdueRepairsLabel = new System.Windows.Forms.Label();
            this.lblCompletedRepairs = new System.Windows.Forms.Label();
            this.lblCompletedRepairsLabel = new System.Windows.Forms.Label();
            this.lblReadyForDelivery = new System.Windows.Forms.Label();
            this.lblReadyForDeliveryLabel = new System.Windows.Forms.Label();
            this.lblActiveRepairs = new System.Windows.Forms.Label();
            this.lblActiveRepairsLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDeliverRepair = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnAssignWorker = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnNewRepair = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvRepairs = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 80);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(373, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔧 Təmir/Servis İdarəetməsi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblMonthlyRevenue);
            this.panel2.Controls.Add(this.lblMonthlyRevenueLabel);
            this.panel2.Controls.Add(this.lblOverdueRepairs);
            this.panel2.Controls.Add(this.lblOverdueRepairsLabel);
            this.panel2.Controls.Add(this.lblCompletedRepairs);
            this.panel2.Controls.Add(this.lblCompletedRepairsLabel);
            this.panel2.Controls.Add(this.lblReadyForDelivery);
            this.panel2.Controls.Add(this.lblReadyForDeliveryLabel);
            this.panel2.Controls.Add(this.lblActiveRepairs);
            this.panel2.Controls.Add(this.lblActiveRepairsLabel);
            this.panel2.Location = new System.Drawing.Point(20, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1260, 100);
            this.panel2.TabIndex = 1;
            // 
            // lblActiveRepairsLabel
            // 
            this.lblActiveRepairsLabel.AutoSize = true;
            this.lblActiveRepairsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActiveRepairsLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblActiveRepairsLabel.Location = new System.Drawing.Point(30, 20);
            this.lblActiveRepairsLabel.Name = "lblActiveRepairsLabel";
            this.lblActiveRepairsLabel.Size = new System.Drawing.Size(87, 19);
            this.lblActiveRepairsLabel.TabIndex = 0;
            this.lblActiveRepairsLabel.Text = "Aktiv Təmirlər";
            // 
            // lblActiveRepairs
            // 
            this.lblActiveRepairs.AutoSize = true;
            this.lblActiveRepairs.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblActiveRepairs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblActiveRepairs.Location = new System.Drawing.Point(30, 45);
            this.lblActiveRepairs.Name = "lblActiveRepairs";
            this.lblActiveRepairs.Size = new System.Drawing.Size(25, 30);
            this.lblActiveRepairs.TabIndex = 1;
            this.lblActiveRepairs.Text = "0";
            // 
            // lblReadyForDeliveryLabel
            // 
            this.lblReadyForDeliveryLabel.AutoSize = true;
            this.lblReadyForDeliveryLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReadyForDeliveryLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblReadyForDeliveryLabel.Location = new System.Drawing.Point(280, 20);
            this.lblReadyForDeliveryLabel.Name = "lblReadyForDeliveryLabel";
            this.lblReadyForDeliveryLabel.Size = new System.Drawing.Size(91, 19);
            this.lblReadyForDeliveryLabel.TabIndex = 2;
            this.lblReadyForDeliveryLabel.Text = "Təhvil Hazırı";
            // 
            // lblReadyForDelivery
            // 
            this.lblReadyForDelivery.AutoSize = true;
            this.lblReadyForDelivery.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblReadyForDelivery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblReadyForDelivery.Location = new System.Drawing.Point(280, 45);
            this.lblReadyForDelivery.Name = "lblReadyForDelivery";
            this.lblReadyForDelivery.Size = new System.Drawing.Size(25, 30);
            this.lblReadyForDelivery.TabIndex = 3;
            this.lblReadyForDelivery.Text = "0";
            // 
            // lblCompletedRepairsLabel
            // 
            this.lblCompletedRepairsLabel.AutoSize = true;
            this.lblCompletedRepairsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCompletedRepairsLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCompletedRepairsLabel.Location = new System.Drawing.Point(530, 20);
            this.lblCompletedRepairsLabel.Name = "lblCompletedRepairsLabel";
            this.lblCompletedRepairsLabel.Size = new System.Drawing.Size(122, 19);
            this.lblCompletedRepairsLabel.TabIndex = 4;
            this.lblCompletedRepairsLabel.Text = "Tamamlanan (Ay)";
            // 
            // lblCompletedRepairs
            // 
            this.lblCompletedRepairs.AutoSize = true;
            this.lblCompletedRepairs.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCompletedRepairs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblCompletedRepairs.Location = new System.Drawing.Point(530, 45);
            this.lblCompletedRepairs.Name = "lblCompletedRepairs";
            this.lblCompletedRepairs.Size = new System.Drawing.Size(25, 30);
            this.lblCompletedRepairs.TabIndex = 5;
            this.lblCompletedRepairs.Text = "0";
            // 
            // lblOverdueRepairsLabel
            // 
            this.lblOverdueRepairsLabel.AutoSize = true;
            this.lblOverdueRepairsLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOverdueRepairsLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblOverdueRepairsLabel.Location = new System.Drawing.Point(780, 20);
            this.lblOverdueRepairsLabel.Name = "lblOverdueRepairsLabel";
            this.lblOverdueRepairsLabel.Size = new System.Drawing.Size(103, 19);
            this.lblOverdueRepairsLabel.TabIndex = 6;
            this.lblOverdueRepairsLabel.Text = "Gecikmiş İşlər";
            // 
            // lblOverdueRepairs
            // 
            this.lblOverdueRepairs.AutoSize = true;
            this.lblOverdueRepairs.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblOverdueRepairs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOverdueRepairs.Location = new System.Drawing.Point(780, 45);
            this.lblOverdueRepairs.Name = "lblOverdueRepairs";
            this.lblOverdueRepairs.Size = new System.Drawing.Size(25, 30);
            this.lblOverdueRepairs.TabIndex = 7;
            this.lblOverdueRepairs.Text = "0";
            // 
            // lblMonthlyRevenueLabel
            // 
            this.lblMonthlyRevenueLabel.AutoSize = true;
            this.lblMonthlyRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMonthlyRevenueLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMonthlyRevenueLabel.Location = new System.Drawing.Point(1030, 20);
            this.lblMonthlyRevenueLabel.Name = "lblMonthlyRevenueLabel";
            this.lblMonthlyRevenueLabel.Size = new System.Drawing.Size(88, 19);
            this.lblMonthlyRevenueLabel.TabIndex = 8;
            this.lblMonthlyRevenueLabel.Text = "Aylıq Gəlir";
            // 
            // lblMonthlyRevenue
            // 
            this.lblMonthlyRevenue.AutoSize = true;
            this.lblMonthlyRevenue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblMonthlyRevenue.Location = new System.Drawing.Point(1030, 45);
            this.lblMonthlyRevenue.Name = "lblMonthlyRevenue";
            this.lblMonthlyRevenue.Size = new System.Drawing.Size(47, 30);
            this.lblMonthlyRevenue.TabIndex = 9;
            this.lblMonthlyRevenue.Text = "0 ₼";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblCustomer);
            this.panel3.Controls.Add(this.cmbCustomer);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnFilter);
            this.panel3.Controls.Add(this.btnDeliverRepair);
            this.panel3.Controls.Add(this.btnUpdateStatus);
            this.panel3.Controls.Add(this.btnAssignWorker);
            this.panel3.Controls.Add(this.btnViewDetails);
            this.panel3.Controls.Add(this.btnNewRepair);
            this.panel3.Location = new System.Drawing.Point(20, 220);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1260, 80);
            this.panel3.TabIndex = 2;
            // 
            // btnNewRepair
            // 
            this.btnNewRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnNewRepair.FlatAppearance.BorderSize = 0;
            this.btnNewRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRepair.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewRepair.ForeColor = System.Drawing.Color.White;
            this.btnNewRepair.Location = new System.Drawing.Point(30, 20);
            this.btnNewRepair.Name = "btnNewRepair";
            this.btnNewRepair.Size = new System.Drawing.Size(140, 40);
            this.btnNewRepair.TabIndex = 0;
            this.btnNewRepair.Text = "➕ Yeni Təmir";
            this.btnNewRepair.UseVisualStyleBackColor = false;
            this.btnNewRepair.Click += new System.EventHandler(this.btnNewRepair_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(190, 20);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(140, 40);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "📄 Təfərrüat";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnAssignWorker
            // 
            this.btnAssignWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnAssignWorker.FlatAppearance.BorderSize = 0;
            this.btnAssignWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignWorker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAssignWorker.ForeColor = System.Drawing.Color.White;
            this.btnAssignWorker.Location = new System.Drawing.Point(350, 20);
            this.btnAssignWorker.Name = "btnAssignWorker";
            this.btnAssignWorker.Size = new System.Drawing.Size(140, 40);
            this.btnAssignWorker.TabIndex = 2;
            this.btnAssignWorker.Text = "👤 İşçi Təyinatı";
            this.btnAssignWorker.UseVisualStyleBackColor = false;
            this.btnAssignWorker.Click += new System.EventHandler(this.btnAssignWorker_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(510, 20);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(140, 40);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "🔄 Status Yenilə";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnDeliverRepair
            // 
            this.btnDeliverRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDeliverRepair.FlatAppearance.BorderSize = 0;
            this.btnDeliverRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliverRepair.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeliverRepair.ForeColor = System.Drawing.Color.White;
            this.btnDeliverRepair.Location = new System.Drawing.Point(670, 20);
            this.btnDeliverRepair.Name = "btnDeliverRepair";
            this.btnDeliverRepair.Size = new System.Drawing.Size(140, 40);
            this.btnDeliverRepair.TabIndex = 4;
            this.btnDeliverRepair.Text = "✅ Təhvil Ver";
            this.btnDeliverRepair.UseVisualStyleBackColor = false;
            this.btnDeliverRepair.Click += new System.EventHandler(this.btnDeliverRepair_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(830, 20);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(140, 40);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "🔍 Filtr";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(990, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 40);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 Yenilə";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(1150, 25);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(100, 25);
            this.cmbCustomer.TabIndex = 7;
            this.cmbCustomer.Visible = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomer.Location = new System.Drawing.Point(1140, 28);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(0, 19);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.dgvRepairs);
            this.panel4.Location = new System.Drawing.Point(20, 320);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1260, 400);
            this.panel4.TabIndex = 3;
            // 
            // dgvRepairs
            // 
            this.dgvRepairs.AllowUserToAddRows = false;
            this.dgvRepairs.AllowUserToDeleteRows = false;
            this.dgvRepairs.BackgroundColor = System.Drawing.Color.White;
            this.dgvRepairs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRepairs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRepairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRepairs.Location = new System.Drawing.Point(0, 0);
            this.dgvRepairs.MultiSelect = false;
            this.dgvRepairs.Name = "dgvRepairs";
            this.dgvRepairs.ReadOnly = true;
            this.dgvRepairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRepairs.Size = new System.Drawing.Size(1260, 400);
            this.dgvRepairs.TabIndex = 0;
            this.dgvRepairs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRepairs_CellDoubleClick);
            // 
            // TamirManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1300, 740);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TamirManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Təmir/Servis İdarəetməsi";
            this.Load += new System.EventHandler(this.TamirManagementForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMonthlyRevenue;
        private System.Windows.Forms.Label lblMonthlyRevenueLabel;
        private System.Windows.Forms.Label lblOverdueRepairs;
        private System.Windows.Forms.Label lblOverdueRepairsLabel;
        private System.Windows.Forms.Label lblCompletedRepairs;
        private System.Windows.Forms.Label lblCompletedRepairsLabel;
        private System.Windows.Forms.Label lblReadyForDelivery;
        private System.Windows.Forms.Label lblReadyForDeliveryLabel;
        private System.Windows.Forms.Label lblActiveRepairs;
        private System.Windows.Forms.Label lblActiveRepairsLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDeliverRepair;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnAssignWorker;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnNewRepair;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvRepairs;
    }
}