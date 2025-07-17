namespace AzAgroPOS.PL.Forms
{
    partial class WarehouseManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name=\"disposing\">true if managed resources should be disposed; otherwise, false.</param>
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLowStockReport = new System.Windows.Forms.Button();
            this.btnStockMovements = new System.Windows.Forms.Button();
            this.btnTransferStock = new System.Windows.Forms.Button();
            this.btnDeleteWarehouse = new System.Windows.Forms.Button();
            this.btnEditWarehouse = new System.Windows.Forms.Button();
            this.btnAddWarehouse = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabWarehouses = new System.Windows.Forms.TabPage();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabWarehouses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            this.tabStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏭 Anbar İdarəetməsi";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnLowStockReport);
            this.pnlButtons.Controls.Add(this.btnStockMovements);
            this.pnlButtons.Controls.Add(this.btnTransferStock);
            this.pnlButtons.Controls.Add(this.btnDeleteWarehouse);
            this.pnlButtons.Controls.Add(this.btnEditWarehouse);
            this.pnlButtons.Controls.Add(this.btnAddWarehouse);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 600);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1200, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1078, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "❌ Bağla";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(966, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 35);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 Yenilə";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLowStockReport
            // 
            this.btnLowStockReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnLowStockReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowStockReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLowStockReport.ForeColor = System.Drawing.Color.White;
            this.btnLowStockReport.Location = new System.Drawing.Point(696, 15);
            this.btnLowStockReport.Name = "btnLowStockReport";
            this.btnLowStockReport.Size = new System.Drawing.Size(130, 35);
            this.btnLowStockReport.TabIndex = 5;
            this.btnLowStockReport.Text = "⚠️ Az Stoklu";
            this.btnLowStockReport.UseVisualStyleBackColor = false;
            this.btnLowStockReport.Click += new System.EventHandler(this.btnLowStockReport_Click);
            // 
            // btnStockMovements
            // 
            this.btnStockMovements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnStockMovements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockMovements.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStockMovements.ForeColor = System.Drawing.Color.White;
            this.btnStockMovements.Location = new System.Drawing.Point(556, 15);
            this.btnStockMovements.Name = "btnStockMovements";
            this.btnStockMovements.Size = new System.Drawing.Size(130, 35);
            this.btnStockMovements.TabIndex = 4;
            this.btnStockMovements.Text = "📋 Hərəkətlər";
            this.btnStockMovements.UseVisualStyleBackColor = false;
            this.btnStockMovements.Click += new System.EventHandler(this.btnStockMovements_Click);
            // 
            // btnTransferStock
            // 
            this.btnTransferStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnTransferStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTransferStock.ForeColor = System.Drawing.Color.White;
            this.btnTransferStock.Location = new System.Drawing.Point(426, 15);
            this.btnTransferStock.Name = "btnTransferStock";
            this.btnTransferStock.Size = new System.Drawing.Size(120, 35);
            this.btnTransferStock.TabIndex = 3;
            this.btnTransferStock.Text = "🔄 Transfer";
            this.btnTransferStock.UseVisualStyleBackColor = false;
            this.btnTransferStock.Click += new System.EventHandler(this.btnTransferStock_Click);
            // 
            // btnDeleteWarehouse
            // 
            this.btnDeleteWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnDeleteWarehouse.Location = new System.Drawing.Point(306, 15);
            this.btnDeleteWarehouse.Name = "btnDeleteWarehouse";
            this.btnDeleteWarehouse.Size = new System.Drawing.Size(110, 35);
            this.btnDeleteWarehouse.TabIndex = 2;
            this.btnDeleteWarehouse.Text = "🗑️ Sil";
            this.btnDeleteWarehouse.UseVisualStyleBackColor = false;
            this.btnDeleteWarehouse.Click += new System.EventHandler(this.btnDeleteWarehouse_Click);
            // 
            // btnEditWarehouse
            // 
            this.btnEditWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnEditWarehouse.Location = new System.Drawing.Point(161, 15);
            this.btnEditWarehouse.Name = "btnEditWarehouse";
            this.btnEditWarehouse.Size = new System.Drawing.Size(135, 35);
            this.btnEditWarehouse.TabIndex = 1;
            this.btnEditWarehouse.Text = "✏️ Düzəliş";
            this.btnEditWarehouse.UseVisualStyleBackColor = false;
            this.btnEditWarehouse.Click += new System.EventHandler(this.btnEditWarehouse_Click);
            // 
            // btnAddWarehouse
            // 
            this.btnAddWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnAddWarehouse.Location = new System.Drawing.Point(20, 15);
            this.btnAddWarehouse.Name = "btnAddWarehouse";
            this.btnAddWarehouse.Size = new System.Drawing.Size(135, 35);
            this.btnAddWarehouse.TabIndex = 0;
            this.btnAddWarehouse.Text = "➕ Yeni Anbar";
            this.btnAddWarehouse.UseVisualStyleBackColor = false;
            this.btnAddWarehouse.Click += new System.EventHandler(this.btnAddWarehouse_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabWarehouses);
            this.tabControl.Controls.Add(this.tabStock);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 540);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabWarehouses
            // 
            this.tabWarehouses.Controls.Add(this.dgvWarehouses);
            this.tabWarehouses.Location = new System.Drawing.Point(4, 28);
            this.tabWarehouses.Name = "tabWarehouses";
            this.tabWarehouses.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarehouses.Size = new System.Drawing.Size(1192, 508);
            this.tabWarehouses.TabIndex = 0;
            this.tabWarehouses.Text = "🏭 Anbarlar";
            this.tabWarehouses.UseVisualStyleBackColor = true;
            // 
            // dgvWarehouses
            // 
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouses.BackgroundColor = System.Drawing.Color.White;
            this.dgvWarehouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarehouses.Location = new System.Drawing.Point(3, 3);
            this.dgvWarehouses.MultiSelect = false;
            this.dgvWarehouses.Name = "dgvWarehouses";
            this.dgvWarehouses.ReadOnly = true;
            this.dgvWarehouses.RowHeadersWidth = 25;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.Size = new System.Drawing.Size(1186, 502);
            this.dgvWarehouses.TabIndex = 0;
            this.dgvWarehouses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouses_CellDoubleClick);
            // 
            // tabStock
            // 
            this.tabStock.Controls.Add(this.dgvStock);
            this.tabStock.Location = new System.Drawing.Point(4, 28);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabStock.Size = new System.Drawing.Size(1192, 508);
            this.tabStock.TabIndex = 1;
            this.tabStock.Text = "📦 Stok Qalıqları";
            this.tabStock.UseVisualStyleBackColor = true;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(3, 3);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 25;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(1186, 502);
            this.dgvStock.TabIndex = 0;
            // 
            // WarehouseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 660);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WarehouseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🏭 Anbar İdarəetməsi - AzAgroPOS";
            this.Load += new System.EventHandler(this.WarehouseManagementForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabWarehouses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            this.tabStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLowStockReport;
        private System.Windows.Forms.Button btnStockMovements;
        private System.Windows.Forms.Button btnTransferStock;
        private System.Windows.Forms.Button btnDeleteWarehouse;
        private System.Windows.Forms.Button btnEditWarehouse;
        private System.Windows.Forms.Button btnAddWarehouse;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabWarehouses;
        private System.Windows.Forms.DataGridView dgvWarehouses;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.DataGridView dgvStock;
    }
}