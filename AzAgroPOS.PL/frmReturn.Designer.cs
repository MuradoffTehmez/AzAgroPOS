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
            this.gbSaleDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1 ... (bütün elementlərin detallı xüsusiyyətləri)
            //
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Satışın Qaytarılması";
            //...
            this.gbSaleDetails.ResumeLayout(false);
            this.gbSaleDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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