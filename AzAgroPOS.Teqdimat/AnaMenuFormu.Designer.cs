// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnaMenuFormu
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            btnMehsulIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnYeniSatis = new MaterialSkin.Controls.MaterialButton();
            btnNisyeIdareetme = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // btnMehsulIdareetme
            // 
            btnMehsulIdareetme.Anchor = AnchorStyles.None;
            btnMehsulIdareetme.AutoSize = false;
            btnMehsulIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnMehsulIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulIdareetme.Depth = 0;
            btnMehsulIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnMehsulIdareetme.HighEmphasis = true;
            btnMehsulIdareetme.Icon = null;
            btnMehsulIdareetme.Location = new Point(198, 105);
            btnMehsulIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnMehsulIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulIdareetme.Name = "btnMehsulIdareetme";
            btnMehsulIdareetme.NoAccentTextColor = Color.Empty;
            btnMehsulIdareetme.Size = new Size(405, 68);
            btnMehsulIdareetme.TabIndex = 0;
            btnMehsulIdareetme.Text = "Məhsulları İdarə Et";
            btnMehsulIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMehsulIdareetme.UseAccentColor = false;
            btnMehsulIdareetme.UseVisualStyleBackColor = false;
            btnMehsulIdareetme.Click += btnMehsulIdareetme_Click;
            // 
            // btnYeniSatis
            // 
            btnYeniSatis.Anchor = AnchorStyles.None;
            btnYeniSatis.AutoSize = false;
            btnYeniSatis.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeniSatis.BackColor = Color.FromArgb(242, 242, 242);
            btnYeniSatis.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeniSatis.Depth = 0;
            btnYeniSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYeniSatis.HighEmphasis = true;
            btnYeniSatis.Icon = null;
            btnYeniSatis.Location = new Point(198, 185);
            btnYeniSatis.Margin = new Padding(4, 6, 4, 6);
            btnYeniSatis.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniSatis.Name = "btnYeniSatis";
            btnYeniSatis.NoAccentTextColor = Color.Empty;
            btnYeniSatis.Size = new Size(405, 68);
            btnYeniSatis.TabIndex = 1;
            btnYeniSatis.Text = "Yeni Satış";
            btnYeniSatis.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYeniSatis.UseAccentColor = false;
            btnYeniSatis.UseVisualStyleBackColor = false;
            btnYeniSatis.Click += btnYeniSatis_Click;
            // 
            // btnNisyeIdareetme
            // 
            btnNisyeIdareetme.Anchor = AnchorStyles.None;
            btnNisyeIdareetme.AutoSize = false;
            btnNisyeIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNisyeIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnNisyeIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNisyeIdareetme.Depth = 0;
            btnNisyeIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNisyeIdareetme.HighEmphasis = true;
            btnNisyeIdareetme.Icon = null;
            btnNisyeIdareetme.Location = new Point(198, 265);
            btnNisyeIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnNisyeIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisyeIdareetme.Name = "btnNisyeIdareetme";
            btnNisyeIdareetme.NoAccentTextColor = Color.Empty;
            btnNisyeIdareetme.Size = new Size(405, 68);
            btnNisyeIdareetme.TabIndex = 2;
            btnNisyeIdareetme.Text = "Nisyə / Borc İdarəetməsi";
            btnNisyeIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNisyeIdareetme.UseAccentColor = false;
            btnNisyeIdareetme.UseVisualStyleBackColor = false;
            btnNisyeIdareetme.Click += btnNisyeIdareetme_Click;
            // 
            // AnaMenuFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(800, 450);
            Controls.Add(btnNisyeIdareetme);
            Controls.Add(btnYeniSatis);
            Controls.Add(btnMehsulIdareetme);
            Name = "AnaMenuFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Ana Menyu";
            ResumeLayout(false);
        }
        #endregion

        private MaterialSkin.Controls.MaterialButton btnMehsulIdareetme;
        private MaterialSkin.Controls.MaterialButton btnYeniSatis;
        private MaterialSkin.Controls.MaterialButton btnNisyeIdareetme;
    }
}