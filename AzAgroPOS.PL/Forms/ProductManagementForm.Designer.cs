namespace AzAgroPOS.PL.Forms
{
    partial class ProductManagementForm
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
            pnlTop = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            pnlFilter = new System.Windows.Forms.Panel();
            btnClearFilter = new System.Windows.Forms.Button();
            cmbStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            cmbCategory = new System.Windows.Forms.ComboBox();
            lblCategory = new System.Windows.Forms.Label();
            btnSearch = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            lblSearch = new System.Windows.Forms.Label();
            pnlButtons = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            btnLowStock = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            dgvProducts = new System.Windows.Forms.DataGridView();
            pnlStats = new System.Windows.Forms.Panel();
            lblStockValue = new System.Windows.Forms.Label();
            lblLowStockCount = new System.Windows.Forms.Label();
            lblActiveCount = new System.Windows.Forms.Label();
            lblTotalCount = new System.Windows.Forms.Label();
            pnlTop.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlStats.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1200, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(279, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📦 Məhsul İdarəetməsi";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            pnlFilter.Controls.Add(btnClearFilter);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(cmbCategory);
            pnlFilter.Controls.Add(lblCategory);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilter.Location = new System.Drawing.Point(0, 60);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(1200, 80);
            pnlFilter.TabIndex = 1;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearFilter.ForeColor = System.Drawing.Color.White;
            btnClearFilter.Location = new System.Drawing.Point(1000, 25);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new System.Drawing.Size(111, 30);
            btnClearFilter.TabIndex = 7;
            btnClearFilter.Text = "\U0001f9f9 Təmizlə";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new System.Drawing.Point(787, 20);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new System.Drawing.Size(120, 29);
            cmbStatus.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(720, 28);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(52, 21);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new System.Drawing.Point(520, 25);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new System.Drawing.Size(180, 29);
            cmbCategory.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new System.Drawing.Point(420, 28);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(84, 21);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Kateqoriya";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(330, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(80, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Axtar";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(100, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(220, 29);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 28);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(60, 21);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Axtarış:";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Controls.Add(btnExport);
            pnlButtons.Controls.Add(btnLowStock);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlButtons.Location = new System.Drawing.Point(0, 600);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new System.Drawing.Size(1200, 60);
            pnlButtons.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1078, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(102, 35);
            btnClose.TabIndex = 5;
            btnClose.Text = "❌ Bağla";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.Location = new System.Drawing.Point(480, 13);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(120, 35);
            btnExport.TabIndex = 4;
            btnExport.Text = "📊 Excel Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnLowStock
            // 
            btnLowStock.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            btnLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLowStock.ForeColor = System.Drawing.Color.White;
            btnLowStock.Location = new System.Drawing.Point(330, 13);
            btnLowStock.Name = "btnLowStock";
            btnLowStock.Size = new System.Drawing.Size(144, 35);
            btnLowStock.TabIndex = 3;
            btnLowStock.Text = "⚠️ Az Stoklu";
            btnLowStock.UseVisualStyleBackColor = false;
            btnLowStock.Click += btnLowStock_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(250, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(70, 35);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Sil";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.Location = new System.Drawing.Point(121, 15);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(120, 35);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Düzəliş";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(20, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(95, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Əlavə";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = System.Drawing.Color.White;
            dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvProducts.Location = new System.Drawing.Point(0, 200);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 25;
            dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new System.Drawing.Size(1200, 400);
            dgvProducts.TabIndex = 3;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
            // 
            // pnlStats
            // 
            pnlStats.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            pnlStats.Controls.Add(lblStockValue);
            pnlStats.Controls.Add(lblLowStockCount);
            pnlStats.Controls.Add(lblActiveCount);
            pnlStats.Controls.Add(lblTotalCount);
            pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            pnlStats.Location = new System.Drawing.Point(0, 140);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new System.Drawing.Size(1200, 60);
            pnlStats.TabIndex = 4;
            // 
            // lblStockValue
            // 
            lblStockValue.AutoSize = true;
            lblStockValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblStockValue.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            lblStockValue.Location = new System.Drawing.Point(900, 20);
            lblStockValue.Name = "lblStockValue";
            lblStockValue.Size = new System.Drawing.Size(180, 21);
            lblStockValue.TabIndex = 3;
            lblStockValue.Text = "💰 Stok Dəyəri: 0 AZN";
            // 
            // lblLowStockCount
            // 
            lblLowStockCount.AutoSize = true;
            lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblLowStockCount.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            lblLowStockCount.Location = new System.Drawing.Point(600, 20);
            lblLowStockCount.Name = "lblLowStockCount";
            lblLowStockCount.Size = new System.Drawing.Size(126, 21);
            lblLowStockCount.TabIndex = 2;
            lblLowStockCount.Text = "⚠️ Az Stoklu: 0";
            // 
            // lblActiveCount
            // 
            lblActiveCount.AutoSize = true;
            lblActiveCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblActiveCount.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            lblActiveCount.Location = new System.Drawing.Point(300, 20);
            lblActiveCount.Name = "lblActiveCount";
            lblActiveCount.Size = new System.Drawing.Size(94, 21);
            lblActiveCount.TabIndex = 1;
            lblActiveCount.Text = "✅ Aktiv: 0";
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            lblTotalCount.Location = new System.Drawing.Point(20, 20);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new System.Drawing.Size(93, 21);
            lblTotalCount.TabIndex = 0;
            lblTotalCount.Text = "📊 Cəmi: 0";
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 660);
            Controls.Add(dgvProducts);
            Controls.Add(pnlStats);
            Controls.Add(pnlButtons);
            Controls.Add(pnlFilter);
            Controls.Add(pnlTop);
            Font = new System.Drawing.Font("Segoe UI", 12F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            MaximizeBox = false;
            Name = "ProductManagementForm";
            Text = "📦 Məhsul İdarəetməsi - AzAgroPOS";
            Load += ProductManagementForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnLowStock;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStockValue;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnClearFilter;
    }
}