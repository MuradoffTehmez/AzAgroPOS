namespace AzAgroPOS.PL
{
    partial class frmReturn
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtChequeNumber = new System.Windows.Forms.TextBox();
            this.btnFindSale = new System.Windows.Forms.Button();
            this.gbSaleDetails = new System.Windows.Forms.GroupBox();
            this.lblKassir = new System.Windows.Forms.Label();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.lblTarix = new System.Windows.Forms.Label();
            this.dgvReturnedItems = new System.Windows.Forms.DataGridView();
            this.btnProcessReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Location = new System.Drawing.Point(0, 0);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Size = new System.Drawing.Size(100, 20);
            this.txtChequeNumber.TabIndex = 0;
            // 
            // btnFindSale
            // 
            this.btnFindSale.Location = new System.Drawing.Point(0, 0);
            this.btnFindSale.Name = "btnFindSale";
            this.btnFindSale.Size = new System.Drawing.Size(75, 23);
            this.btnFindSale.TabIndex = 0;
            // 
            // gbSaleDetails
            // 
            this.gbSaleDetails.Location = new System.Drawing.Point(0, 0);
            this.gbSaleDetails.Name = "gbSaleDetails";
            this.gbSaleDetails.Size = new System.Drawing.Size(200, 100);
            this.gbSaleDetails.TabIndex = 0;
            this.gbSaleDetails.TabStop = false;
            // 
            // lblKassir
            // 
            this.lblKassir.Location = new System.Drawing.Point(0, 0);
            this.lblKassir.Name = "lblKassir";
            this.lblKassir.Size = new System.Drawing.Size(100, 23);
            this.lblKassir.TabIndex = 0;
            // 
            // lblMusteri
            // 
            this.lblMusteri.Location = new System.Drawing.Point(0, 0);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(100, 23);
            this.lblMusteri.TabIndex = 0;
            // 
            // lblTarix
            // 
            this.lblTarix.Location = new System.Drawing.Point(0, 0);
            this.lblTarix.Name = "lblTarix";
            this.lblTarix.Size = new System.Drawing.Size(100, 23);
            this.lblTarix.TabIndex = 0;
            // 
            // dgvReturnedItems
            // 
            this.dgvReturnedItems.Location = new System.Drawing.Point(0, 0);
            this.dgvReturnedItems.Name = "dgvReturnedItems";
            this.dgvReturnedItems.Size = new System.Drawing.Size(240, 150);
            this.dgvReturnedItems.TabIndex = 0;
            // 
            // btnProcessReturn
            // 
            this.btnProcessReturn.Location = new System.Drawing.Point(0, 0);
            this.btnProcessReturn.Name = "btnProcessReturn";
            this.btnProcessReturn.Size = new System.Drawing.Size(75, 23);
            this.btnProcessReturn.TabIndex = 0;
            // 
            // frmReturn
            // 
            this.ClientSize = new System.Drawing.Size(1219, 606);
            this.Name = "frmReturn";
            this.Text = "Satışın Qaytarılması";
            this.Load += new System.EventHandler(this.frmReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChequeNumber;
        private System.Windows.Forms.Button btnFindSale;
        private System.Windows.Forms.GroupBox gbSaleDetails;
        private System.Windows.Forms.DataGridView dgvReturnedItems;
        private System.Windows.Forms.Button btnProcessReturn;
        private System.Windows.Forms.Label lblKassir;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.Label lblTarix;
    }
}