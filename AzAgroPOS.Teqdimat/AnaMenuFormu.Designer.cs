// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnaMenuFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.btnMehsulIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnYeniSatis = new MaterialSkin.Controls.MaterialButton();
            this.btnNisyeIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnTemirIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // btnMehsulIdareetme
            this.btnMehsulIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMehsulIdareetme.AutoSize = false;
            this.btnMehsulIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMehsulIdareetme.HighEmphasis = true;
            this.btnMehsulIdareetme.Location = new System.Drawing.Point(198, 86);
            this.btnMehsulIdareetme.Name = "btnMehsulIdareetme";
            this.btnMehsulIdareetme.Size = new System.Drawing.Size(405, 68);
            this.btnMehsulIdareetme.Text = "Məhsulları İdarə Et";
            this.btnMehsulIdareetme.Click += new System.EventHandler(this.btnMehsulIdareetme_Click);
            // btnYeniSatis
            this.btnYeniSatis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnYeniSatis.AutoSize = false;
            this.btnYeniSatis.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYeniSatis.HighEmphasis = true;
            this.btnYeniSatis.Location = new System.Drawing.Point(198, 166);
            this.btnYeniSatis.Name = "btnYeniSatis";
            this.btnYeniSatis.Size = new System.Drawing.Size(405, 68);
            this.btnYeniSatis.Text = "Yeni Satış";
            this.btnYeniSatis.Click += new System.EventHandler(this.btnYeniSatis_Click);
            // btnNisyeIdareetme
            this.btnNisyeIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNisyeIdareetme.AutoSize = false;
            this.btnNisyeIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNisyeIdareetme.HighEmphasis = true;
            this.btnNisyeIdareetme.Location = new System.Drawing.Point(198, 246);
            this.btnNisyeIdareetme.Name = "btnNisyeIdareetme";
            this.btnNisyeIdareetme.Size = new System.Drawing.Size(405, 68);
            this.btnNisyeIdareetme.Text = "Nisyə / Borc İdarəetməsi";
            this.btnNisyeIdareetme.Click += new System.EventHandler(this.btnNisyeIdareetme_Click);
            // btnTemirIdareetme
            this.btnTemirIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemirIdareetme.AutoSize = false;
            this.btnTemirIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTemirIdareetme.HighEmphasis = true;
            this.btnTemirIdareetme.Location = new System.Drawing.Point(198, 326);
            this.btnTemirIdareetme.Name = "btnTemirIdareetme";
            this.btnTemirIdareetme.Size = new System.Drawing.Size(405, 68);
            this.btnTemirIdareetme.Text = "Təmir İdarəetməsi";
            this.btnTemirIdareetme.Click += new System.EventHandler(this.btnTemirIdareetme_Click);
            // AnaMenuFormu
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.btnTemirIdareetme);
            this.Controls.Add(this.btnNisyeIdareetme);
            this.Controls.Add(this.btnYeniSatis);
            this.Controls.Add(this.btnMehsulIdareetme);
            this.Name = "AnaMenuFormu";
            this.Text = "AzAgroPOS - Ana Menyu";
            this.ResumeLayout(false);
        }
        #endregion
        private MaterialSkin.Controls.MaterialButton btnMehsulIdareetme;
        private MaterialSkin.Controls.MaterialButton btnYeniSatis;
        private MaterialSkin.Controls.MaterialButton btnNisyeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnTemirIdareetme;
    }
}