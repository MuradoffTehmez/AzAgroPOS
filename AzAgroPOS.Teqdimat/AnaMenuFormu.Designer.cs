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
            this.btnNovbeIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnIstifadeciIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnNovbeIdareetme
            // 
            this.btnNovbeIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNovbeIdareetme.AutoSize = false;
            this.btnNovbeIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNovbeIdareetme.HighEmphasis = true;
            this.btnNovbeIdareetme.Location = new System.Drawing.Point(50, 90);
            this.btnNovbeIdareetme.Name = "btnNovbeIdareetme";
            this.btnNovbeIdareetme.Size = new System.Drawing.Size(250, 68);
            this.btnNovbeIdareetme.Text = "Növbəni İdarə Et";
            this.btnNovbeIdareetme.Click += new System.EventHandler(this.btnNovbeIdareetme_Click);
            // 
            // btnYeniSatis
            // 
            this.btnYeniSatis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnYeniSatis.AutoSize = false;
            this.btnYeniSatis.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYeniSatis.HighEmphasis = true;
            this.btnYeniSatis.Location = new System.Drawing.Point(50, 170);
            this.btnYeniSatis.Name = "btnYeniSatis";
            this.btnYeniSatis.Size = new System.Drawing.Size(250, 68);
            this.btnYeniSatis.Text = "Yeni Satış";
            this.btnYeniSatis.Click += new System.EventHandler(this.btnYeniSatis_Click);
            // 
            // btnMehsulIdareetme
            // 
            this.btnMehsulIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMehsulIdareetme.AutoSize = false;
            this.btnMehsulIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMehsulIdareetme.HighEmphasis = true;
            this.btnMehsulIdareetme.Location = new System.Drawing.Point(320, 90);
            this.btnMehsulIdareetme.Name = "btnMehsulIdareetme";
            this.btnMehsulIdareetme.Size = new System.Drawing.Size(250, 68);
            this.btnMehsulIdareetme.Text = "Məhsulları İdarə Et";
            this.btnMehsulIdareetme.Click += new System.EventHandler(this.btnMehsulIdareetme_Click);
            // 
            // btnNisyeIdareetme
            // 
            this.btnNisyeIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNisyeIdareetme.AutoSize = false;
            this.btnNisyeIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNisyeIdareetme.HighEmphasis = true;
            this.btnNisyeIdareetme.Location = new System.Drawing.Point(320, 170);
            this.btnNisyeIdareetme.Name = "btnNisyeIdareetme";
            this.btnNisyeIdareetme.Size = new System.Drawing.Size(250, 68);
            this.btnNisyeIdareetme.Text = "Nisyə / Borc İdarəetməsi";
            this.btnNisyeIdareetme.Click += new System.EventHandler(this.btnNisyeIdareetme_Click);
            // 
            // btnTemirIdareetme
            // 
            this.btnTemirIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemirIdareetme.AutoSize = false;
            this.btnTemirIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTemirIdareetme.HighEmphasis = true;
            this.btnTemirIdareetme.Location = new System.Drawing.Point(50, 250);
            this.btnTemirIdareetme.Name = "btnTemirIdareetme";
            this.btnTemirIdareetme.Size = new System.Drawing.Size(250, 68);
            this.btnTemirIdareetme.Text = "Təmir İdarəetməsi";
            this.btnTemirIdareetme.Click += new System.EventHandler(this.btnTemirIdareetme_Click);
            // 
            // btnIstifadeciIdareetme
            // 
            this.btnIstifadeciIdareetme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIstifadeciIdareetme.AutoSize = false;
            this.btnIstifadeciIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnIstifadeciIdareetme.HighEmphasis = true;
            this.btnIstifadeciIdareetme.Location = new System.Drawing.Point(320, 250);
            this.btnIstifadeciIdareetme.Name = "btnIstifadeciIdareetme";
            this.btnIstifadeciIdareetme.Size = new System.Drawing.Size(250, 68);
            this.btnIstifadeciIdareetme.Text = "İstifadəçiləri İdarə Et";
            this.btnIstifadeciIdareetme.Click += new System.EventHandler(this.btnIstifadeciIdareetme_Click);
            // 
            // AnaMenuFormu
            // 
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Controls.Add(this.btnIstifadeciIdareetme);
            this.Controls.Add(this.btnTemirIdareetme);
            this.Controls.Add(this.btnNisyeIdareetme);
            this.Controls.Add(this.btnMehsulIdareetme);
            this.Controls.Add(this.btnYeniSatis);
            this.Controls.Add(this.btnNovbeIdareetme);
            this.Name = "AnaMenuFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzAgroPOS - Ana Menyu";
            this.ResumeLayout(false);

        }
        #endregion
        private MaterialSkin.Controls.MaterialButton btnMehsulIdareetme;
        private MaterialSkin.Controls.MaterialButton btnYeniSatis;
        private MaterialSkin.Controls.MaterialButton btnNisyeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnTemirIdareetme;
        private MaterialSkin.Controls.MaterialButton btnNovbeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnIstifadeciIdareetme;
    }
}