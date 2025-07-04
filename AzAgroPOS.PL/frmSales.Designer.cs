namespace AzAgroPOS.PL
{
    partial class frmSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcodeSearch = new System.Windows.Forms.TextBox();
            this.dgvSalesCart = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnDecreaseQty = new System.Windows.Forms.Button();
            this.btnIncreaseQty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesCart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Məhsulun Barkodunu daxil et:";
            // 
            // txtBarcodeSearch
            // 
            this.txtBarcodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeSearch.Location = new System.Drawing.Point(235, 12);
            this.txtBarcodeSearch.Name = "txtBarcodeSearch";
            this.txtBarcodeSearch.Size = new System.Drawing.Size(800, 26);
            this.txtBarcodeSearch.TabIndex = 1;
            this.txtBarcodeSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeSearch_KeyDown);
            // 
            // dgvSalesCart
            // 
            this.dgvSalesCart.AllowUserToAddRows = false;
            this.dgvSalesCart.AllowUserToDeleteRows = false;
            this.dgvSalesCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSalesCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSalesCart.ColumnHeadersHeight = 40;
            this.dgvSalesCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesCart.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSalesCart.EnableHeadersVisualStyles = false;
            this.dgvSalesCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgvSalesCart.Location = new System.Drawing.Point(12, 50);
            this.dgvSalesCart.MultiSelect = false;
            this.dgvSalesCart.Name = "dgvSalesCart";
            this.dgvSalesCart.ReadOnly = true;
            this.dgvSalesCart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesCart.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSalesCart.RowHeadersVisible = false;
            this.dgvSalesCart.RowHeadersWidth = 30;
            this.dgvSalesCart.RowTemplate.Height = 35;
            this.dgvSalesCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesCart.Size = new System.Drawing.Size(1023, 450);
            this.dgvSalesCart.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.btnSelectCustomer);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Controls.Add(this.btnCompleteSale);
            this.panel1.Controls.Add(this.lblTotalPrice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 100);
            this.panel1.TabIndex = 3;
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSelectCustomer.FlatAppearance.BorderSize = 0;
            this.btnSelectCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSelectCustomer.Location = new System.Drawing.Point(690, 20);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(150, 60);
            this.btnSelectCustomer.TabIndex = 4;
            this.btnSelectCustomer.Text = "Müştəri Seç";
            this.btnSelectCustomer.UseVisualStyleBackColor = false;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(350, 38);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(180, 24);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Qeydiyyatsız Müştəri";
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompleteSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCompleteSale.FlatAppearance.BorderSize = 0;
            this.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(850, 20);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(160, 60);
            this.btnCompleteSale.TabIndex = 2;
            this.btnCompleteSale.Text = "Satışı Tamamla";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(200, 30);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(101, 31);
            this.lblTotalPrice.TabIndex = 1;
            this.lblTotalPrice.Text = "0.00 ₼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yekun Məbləğ:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnRemoveItem);
            this.panel2.Controls.Add(this.btnDecreaseQty);
            this.panel2.Controls.Add(this.btnIncreaseQty);
            this.panel2.Location = new System.Drawing.Point(1041, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 450);
            this.panel2.TabIndex = 4;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(10, 150);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(80, 50);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "Sil";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnDecreaseQty
            // 
            this.btnDecreaseQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnDecreaseQty.FlatAppearance.BorderSize = 0;
            this.btnDecreaseQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseQty.ForeColor = System.Drawing.Color.White;
            this.btnDecreaseQty.Location = new System.Drawing.Point(10, 80);
            this.btnDecreaseQty.Name = "btnDecreaseQty";
            this.btnDecreaseQty.Size = new System.Drawing.Size(80, 50);
            this.btnDecreaseQty.TabIndex = 1;
            this.btnDecreaseQty.Text = "-";
            this.btnDecreaseQty.UseVisualStyleBackColor = false;
            this.btnDecreaseQty.Click += new System.EventHandler(this.btnDecreaseQty_Click);
            // 
            // btnIncreaseQty
            // 
            this.btnIncreaseQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnIncreaseQty.FlatAppearance.BorderSize = 0;
            this.btnIncreaseQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreaseQty.ForeColor = System.Drawing.Color.White;
            this.btnIncreaseQty.Location = new System.Drawing.Point(10, 10);
            this.btnIncreaseQty.Name = "btnIncreaseQty";
            this.btnIncreaseQty.Size = new System.Drawing.Size(80, 50);
            this.btnIncreaseQty.TabIndex = 0;
            this.btnIncreaseQty.Text = "+";
            this.btnIncreaseQty.UseVisualStyleBackColor = false;
            this.btnIncreaseQty.Click += new System.EventHandler(this.btnIncreaseQty_Click);
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1153, 618);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSalesCart);
            this.Controls.Add(this.txtBarcodeSearch);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Satış Əməliyyatı";
            this.Load += new System.EventHandler(this.frmSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesCart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcodeSearch;
        private System.Windows.Forms.DataGridView dgvSalesCart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnDecreaseQty;
        private System.Windows.Forms.Button btnIncreaseQty;
    }
}