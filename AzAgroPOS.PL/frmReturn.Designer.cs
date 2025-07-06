namespace AzAgroPOS.PL
{
    partial class frmReturn
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnFindSale = new System.Windows.Forms.Button();
            this.txtChequeNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSaleDetails = new System.Windows.Forms.GroupBox();
            this.dgvReturnedItems = new System.Windows.Forms.DataGridView();
            this.btnProcessReturn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblKassir = new System.Windows.Forms.Label();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.lblTarix = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.gbSaleDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.btnFindSale);
            this.panelTop.Controls.Add(this.txtChequeNumber);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(982, 70);
            this.panelTop.TabIndex = 0;
            // 
            // btnFindSale
            // 
            this.btnFindSale.Location = new System.Drawing.Point(544, 19);
            this.btnFindSale.Name = "btnFindSale";
            this.btnFindSale.Size = new System.Drawing.Size(125, 32);
            this.btnFindSale.TabIndex = 2;
            this.btnFindSale.Text = "Axtar";
            this.btnFindSale.UseVisualStyleBackColor = true;
            this.btnFindSale.Click += new System.EventHandler(this.btnFindSale_Click);
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNumber.Location = new System.Drawing.Point(146, 20);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Size = new System.Drawing.Size(380, 31);
            this.txtChequeNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Çek Nömrəsi:";
            // 
            // gbSaleDetails
            // 
            this.gbSaleDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSaleDetails.Controls.Add(this.dgvReturnedItems);
            this.gbSaleDetails.Controls.Add(this.btnProcessReturn);
            this.gbSaleDetails.Controls.Add(this.tableLayoutPanel1);
            this.gbSaleDetails.Location = new System.Drawing.Point(12, 76);
            this.gbSaleDetails.Name = "gbSaleDetails";
            this.gbSaleDetails.Size = new System.Drawing.Size(958, 465);
            this.gbSaleDetails.TabIndex = 1;
            this.gbSaleDetails.TabStop = false;
            this.gbSaleDetails.Text = "Satış Məlumatları";
            // 
            // dgvReturnedItems
            // 
            this.dgvReturnedItems.AllowUserToAddRows = false;
            this.dgvReturnedItems.AllowUserToDeleteRows = false;
            this.dgvReturnedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReturnedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnedItems.Location = new System.Drawing.Point(17, 85);
            this.dgvReturnedItems.Name = "dgvReturnedItems";
            this.dgvReturnedItems.ReadOnly = true;
            this.dgvReturnedItems.RowHeadersWidth = 51;
            this.dgvReturnedItems.RowTemplate.Height = 24;
            this.dgvReturnedItems.Size = new System.Drawing.Size(924, 305);
            this.dgvReturnedItems.TabIndex = 4;
            // 
            // btnProcessReturn
            // 
            this.btnProcessReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessReturn.Enabled = false;
            this.btnProcessReturn.Location = new System.Drawing.Point(753, 406);
            this.btnProcessReturn.Name = "btnProcessReturn";
            this.btnProcessReturn.Size = new System.Drawing.Size(188, 43);
            this.btnProcessReturn.TabIndex = 3;
            this.btnProcessReturn.Text = "Qaytarmanı Təsdiqlə";
            this.btnProcessReturn.UseVisualStyleBackColor = true;
            this.btnProcessReturn.Click += new System.EventHandler(this.btnProcessReturn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.lblKassir, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMusteri, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTarix, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 50);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblKassir
            // 
            this.lblKassir.AutoSize = true;
            this.lblKassir.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKassir.Location = new System.Drawing.Point(637, 0);
            this.lblKassir.Name = "lblKassir";
            this.lblKassir.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblKassir.Size = new System.Drawing.Size(63, 28);
            this.lblKassir.TabIndex = 2;
            this.lblKassir.Text = "Kassir:";
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusteri.Location = new System.Drawing.Point(320, 0);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblMusteri.Size = new System.Drawing.Size(71, 28);
            this.lblMusteri.TabIndex = 1;
            this.lblMusteri.Text = "Müştəri:";
            // 
            // lblTarix
            // 
            this.lblTarix.AutoSize = true;
            this.lblTarix.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarix.Location = new System.Drawing.Point(3, 0);
            this.lblTarix.Name = "lblTarix";
            this.lblTarix.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTarix.Size = new System.Drawing.Size(49, 28);
            this.lblTarix.TabIndex = 0;
            this.lblTarix.Text = "Tarix:";
            // 
            // frmReturn
            // 
            this.AcceptButton = this.btnFindSale;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.gbSaleDetails);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "frmReturn";
            this.Text = "Satışın Qaytarılması";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.gbSaleDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnFindSale;
        private System.Windows.Forms.TextBox txtChequeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSaleDetails;
        private System.Windows.Forms.Label lblTarix;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.Label lblKassir;
        private System.Windows.Forms.Button btnProcessReturn;
        private System.Windows.Forms.DataGridView dgvReturnedItems;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}