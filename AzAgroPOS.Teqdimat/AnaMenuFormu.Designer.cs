// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnaMenuFormu
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
            btnMehsulIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnYeniSatis = new MaterialSkin.Controls.MaterialButton();
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
            btnMehsulIdareetme.Location = new Point(231, 164);
            btnMehsulIdareetme.Margin = new Padding(5, 7, 5, 7);
            btnMehsulIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulIdareetme.Name = "btnMehsulIdareetme";
            btnMehsulIdareetme.NoAccentTextColor = Color.Empty;
            btnMehsulIdareetme.Size = new Size(472, 78);
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
            btnYeniSatis.Location = new Point(231, 256);
            btnYeniSatis.Margin = new Padding(5, 7, 5, 7);
            btnYeniSatis.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniSatis.Name = "btnYeniSatis";
            btnYeniSatis.NoAccentTextColor = Color.Empty;
            btnYeniSatis.Size = new Size(472, 78);
            btnYeniSatis.TabIndex = 1;
            btnYeniSatis.Text = "Yeni Satış";
            btnYeniSatis.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYeniSatis.UseAccentColor = false;
            btnYeniSatis.UseVisualStyleBackColor = false;
            btnYeniSatis.Click += btnYeniSatis_Click;
            // 
            // AnaMenuFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(btnYeniSatis);
            Controls.Add(btnMehsulIdareetme);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AnaMenuFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Ana Menyu";
            ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnMehsulIdareetme;
        private MaterialSkin.Controls.MaterialButton btnYeniSatis;
    }
}