namespace AzAgroPOS.PL.Forms
{
    partial class SalesReportForm
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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblAverageOrder = new System.Windows.Forms.Label();
            this.lblDiscountPercent = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.chartSales = new System.Windows.Forms.Panel();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(85, 18);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 22);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Value = new System.DateTime(2023, 11, 1, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(275, 18);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 22);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.Value = new System.DateTime(2023, 11, 1, 0, 0, 0, 0);
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Günlük",
            "Aylıq",
            "Sərbəst"});
            this.cmbReportType.Location = new System.Drawing.Point(455, 18);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(100, 24);
            this.cmbReportType.TabIndex = 2;
            this.cmbReportType.SelectedIndex = 2;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.LightBlue;
            this.btnGenerate.Location = new System.Drawing.Point(570, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 25);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Hesabat Al";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.LightGreen;
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(680, 17);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 25);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "İxrac Et";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.lblDiscountPercent);
            this.pnlSummary.Controls.Add(this.lblAverageOrder);
            this.pnlSummary.Controls.Add(this.lblNetAmount);
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.lblTotalSales);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 60);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1200, 100);
            this.pnlSummary.TabIndex = 5;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.Location = new System.Drawing.Point(20, 15);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(96, 18);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "Satış Sayı: -";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 40);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(130, 18);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "Ümumi Məbləğ: -";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmount.ForeColor = System.Drawing.Color.Green;
            this.lblNetAmount.Location = new System.Drawing.Point(250, 15);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(104, 18);
            this.lblNetAmount.TabIndex = 2;
            this.lblNetAmount.Text = "Net Məbləğ: -";
            // 
            // lblAverageOrder
            // 
            this.lblAverageOrder.AutoSize = true;
            this.lblAverageOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageOrder.Location = new System.Drawing.Point(250, 40);
            this.lblAverageOrder.Name = "lblAverageOrder";
            this.lblAverageOrder.Size = new System.Drawing.Size(112, 18);
            this.lblAverageOrder.TabIndex = 3;
            this.lblAverageOrder.Text = "Orta Sifariş: -";
            // 
            // lblDiscountPercent
            // 
            this.lblDiscountPercent.AutoSize = true;
            this.lblDiscountPercent.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountPercent.ForeColor = System.Drawing.Color.Orange;
            this.lblDiscountPercent.Location = new System.Drawing.Point(480, 15);
            this.lblDiscountPercent.Name = "lblDiscountPercent";
            this.lblDiscountPercent.Size = new System.Drawing.Size(93, 18);
            this.lblDiscountPercent.TabIndex = 4;
            this.lblDiscountPercent.Text = "Endirim %: -";
            // 
            // dgvTopProducts
            // 
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            this.dgvTopProducts.AutoGenerateColumns = false;
            this.dgvTopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvTopProducts.Name = "dgvTopProducts";
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersWidth = 51;
            this.dgvTopProducts.RowTemplate.Height = 24;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.Size = new System.Drawing.Size(1200, 500);
            this.dgvTopProducts.TabIndex = 6;
            // 
            // chartSales
            // 
            this.chartSales.BackColor = System.Drawing.Color.LightBlue;
            this.chartSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSales.Location = new System.Drawing.Point(0, 0);
            this.chartSales.Name = "chartSales";
            this.chartSales.Size = new System.Drawing.Size(1200, 300);
            this.chartSales.TabIndex = 7;
            // 
            // SalesReportForm
            // 
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.dgvTopProducts);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Name = "SalesReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satış Hesabatları";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblDiscountPercent;
        private System.Windows.Forms.Label lblAverageOrder;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Panel chartSales;
    }
}