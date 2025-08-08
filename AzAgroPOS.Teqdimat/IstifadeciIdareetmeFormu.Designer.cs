// Fayl: AzAgroPOS.Teqdimat/IstifadeciIdareetmeFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class IstifadeciIdareetmeFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvIstifadeciler = new System.Windows.Forms.DataGridView();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.btnSil = new MaterialSkin.Controls.MaterialButton();
            this.btnYarat = new MaterialSkin.Controls.MaterialButton();
            this.cmbRollar = new MaterialSkin.Controls.MaterialComboBox();
            this.txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtTamAd = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIstifadeciler)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIstifadeciler
            // 
            this.dgvIstifadeciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIstifadeciler.Location = new System.Drawing.Point(354, 77);
            this.dgvIstifadeciler.Name = "dgvIstifadeciler";
            this.dgvIstifadeciler.Size = new System.Drawing.Size(528, 381);
            this.dgvIstifadeciler.TabIndex = 0;
            // 
            // materialCard1
            // 
            this.materialCard1.Controls.Add(this.btnSil);
            this.materialCard1.Controls.Add(this.btnYarat);
            this.materialCard1.Controls.Add(this.cmbRollar);
            this.materialCard1.Controls.Add(this.txtParol);
            this.materialCard1.Controls.Add(this.txtTamAd);
            this.materialCard1.Controls.Add(this.txtIstifadeciAdi);
            this.materialCard1.Location = new System.Drawing.Point(17, 77);
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Size = new System.Drawing.Size(316, 381);
            this.materialCard1.TabIndex = 1;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(17, 324);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(64, 36);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYarat
            // 
            this.btnYarat.Location = new System.Drawing.Point(219, 324);
            this.btnYarat.Name = "btnYarat";
            this.btnYarat.Size = new System.Drawing.Size(76, 36);
            this.btnYarat.TabIndex = 4;
            this.btnYarat.Text = "Yarat";
            this.btnYarat.Click += new System.EventHandler(this.btnYarat_Click);
            // 
            // cmbRollar
            // 
            this.cmbRollar.Hint = "Rol";
            this.cmbRollar.Location = new System.Drawing.Point(17, 252);
            this.cmbRollar.Name = "cmbRollar";
            this.cmbRollar.Size = new System.Drawing.Size(278, 49);
            this.cmbRollar.TabIndex = 3;
            // 
            // txtParol
            // 
            this.txtParol.Hint = "Parol";
            this.txtParol.PasswordChar = '*';
            this.txtParol.Location = new System.Drawing.Point(17, 186);
            this.txtParol.Name = "txtParol";
            this.txtParol.Size = new System.Drawing.Size(278, 48);
            this.txtParol.TabIndex = 2;
            // 
            // txtTamAd
            // 
            this.txtTamAd.Hint = "Tam Ad";
            this.txtTamAd.Location = new System.Drawing.Point(17, 101);
            this.txtTamAd.Name = "txtTamAd";
            this.txtTamAd.Size = new System.Drawing.Size(278, 48);
            this.txtTamAd.TabIndex = 1;
            // 
            // txtIstifadeciAdi
            // 
            this.txtIstifadeciAdi.Hint = "İstifadəçi Adı";
            this.txtIstifadeciAdi.Location = new System.Drawing.Point(17, 21);
            this.txtIstifadeciAdi.Name = "txtIstifadeciAdi";
            this.txtIstifadeciAdi.Size = new System.Drawing.Size(278, 48);
            this.txtIstifadeciAdi.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(293, 477);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(40, 20);
            this.txtId.TabIndex = 2;
            this.txtId.Visible = false;
            // 
            // IstifadeciIdareetmeFormu
            // 
            this.ClientSize = new System.Drawing.Size(901, 509);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.dgvIstifadeciler);
            this.Name = "IstifadeciIdareetmeFormu";
            this.Text = "İstifadəçi İdarəetməsi";
            this.Load += new System.EventHandler(this.IstifadeciIdareetmeFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIstifadeciler)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.DataGridView dgvIstifadeciler;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnYarat;
        private MaterialSkin.Controls.MaterialComboBox cmbRollar;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private MaterialSkin.Controls.MaterialTextBox2 txtTamAd;
        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private System.Windows.Forms.TextBox txtId;
    }
}