// Fayl: AzAgroPOS.Teqdimat/BazaIdareetmeFormu.Designer.cs
using MaterialSkin.Controls;

namespace AzAgroPOS.Teqdimat
{
    partial class BazaIdareetmeFormu
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
            groupBox1 = new GroupBox();
            lblBazaOlcusu = new MaterialLabel();
            lblSonBackup = new MaterialLabel();
            btnYenile = new MaterialButton();
            groupBox2 = new GroupBox();
            btnBackupYarat = new MaterialButton();
            btnRestoreEt = new MaterialButton();
            btnQovluguAc = new MaterialButton();
            btnBackupSil = new MaterialButton();
            groupBox3 = new GroupBox();
            lstBackuplar = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            materialLabel1 = new MaterialLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.FromArgb(242, 242, 242);
            groupBox1.Controls.Add(lblBazaOlcusu);
            groupBox1.Controls.Add(lblSonBackup);
            groupBox1.Controls.Add(btnYenile);
            groupBox1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            groupBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            groupBox1.Location = new Point(12, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(960, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Verilənlər Bazası Məlumatı";
            // 
            // lblBazaOlcusu
            // 
            lblBazaOlcusu.AutoSize = true;
            lblBazaOlcusu.BackColor = Color.FromArgb(242, 242, 242);
            lblBazaOlcusu.Depth = 0;
            lblBazaOlcusu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBazaOlcusu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBazaOlcusu.Location = new Point(20, 30);
            lblBazaOlcusu.MouseState = MaterialSkin.MouseState.HOVER;
            lblBazaOlcusu.Name = "lblBazaOlcusu";
            lblBazaOlcusu.Size = new Size(219, 19);
            lblBazaOlcusu.TabIndex = 0;
            lblBazaOlcusu.Text = "Verilənlər Bazası Ölçüsü: --- MB";
            // 
            // lblSonBackup
            // 
            lblSonBackup.AutoSize = true;
            lblSonBackup.BackColor = Color.FromArgb(242, 242, 242);
            lblSonBackup.Depth = 0;
            lblSonBackup.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSonBackup.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSonBackup.Location = new Point(20, 60);
            lblSonBackup.MouseState = MaterialSkin.MouseState.HOVER;
            lblSonBackup.Name = "lblSonBackup";
            lblSonBackup.Size = new Size(106, 19);
            lblSonBackup.TabIndex = 1;
            lblSonBackup.Text = "Son Backup: ---";
            // 
            // btnYenile
            // 
            btnYenile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYenile.AutoSize = false;
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(820, 30);
            btnYenile.Margin = new Padding(4, 6, 4, 6);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(120, 50);
            btnYenile.TabIndex = 2;
            btnYenile.Text = "Yenilə";
            btnYenile.Type = MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = Color.FromArgb(242, 242, 242);
            groupBox2.Controls.Add(btnBackupYarat);
            groupBox2.Controls.Add(btnRestoreEt);
            groupBox2.Controls.Add(btnQovluguAc);
            groupBox2.Controls.Add(btnBackupSil);
            groupBox2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            groupBox2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            groupBox2.Location = new Point(12, 190);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(960, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Əməliyyatlar";
            // 
            // btnBackupYarat
            // 
            btnBackupYarat.AutoSize = false;
            btnBackupYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackupYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnBackupYarat.Density = MaterialButton.MaterialButtonDensity.Default;
            btnBackupYarat.Depth = 0;
            btnBackupYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBackupYarat.HighEmphasis = true;
            btnBackupYarat.Icon = null;
            btnBackupYarat.Location = new Point(20, 35);
            btnBackupYarat.Margin = new Padding(4, 6, 4, 6);
            btnBackupYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackupYarat.Name = "btnBackupYarat";
            btnBackupYarat.NoAccentTextColor = Color.Empty;
            btnBackupYarat.Size = new Size(200, 50);
            btnBackupYarat.TabIndex = 0;
            btnBackupYarat.Text = "Backup Yarat";
            btnBackupYarat.Type = MaterialButton.MaterialButtonType.Contained;
            btnBackupYarat.UseAccentColor = false;
            btnBackupYarat.UseVisualStyleBackColor = false;
            btnBackupYarat.Click += btnBackupYarat_Click;
            // 
            // btnRestoreEt
            // 
            btnRestoreEt.AutoSize = false;
            btnRestoreEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRestoreEt.BackColor = Color.FromArgb(242, 242, 242);
            btnRestoreEt.Density = MaterialButton.MaterialButtonDensity.Default;
            btnRestoreEt.Depth = 0;
            btnRestoreEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnRestoreEt.HighEmphasis = true;
            btnRestoreEt.Icon = null;
            btnRestoreEt.Location = new Point(240, 35);
            btnRestoreEt.Margin = new Padding(4, 6, 4, 6);
            btnRestoreEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnRestoreEt.Name = "btnRestoreEt";
            btnRestoreEt.NoAccentTextColor = Color.Empty;
            btnRestoreEt.Size = new Size(200, 50);
            btnRestoreEt.TabIndex = 1;
            btnRestoreEt.Text = "Restore Et (Bərpa)";
            btnRestoreEt.Type = MaterialButton.MaterialButtonType.Contained;
            btnRestoreEt.UseAccentColor = false;
            btnRestoreEt.UseVisualStyleBackColor = false;
            btnRestoreEt.Click += btnRestoreEt_Click;
            // 
            // btnQovluguAc
            // 
            btnQovluguAc.AutoSize = false;
            btnQovluguAc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQovluguAc.BackColor = Color.FromArgb(242, 242, 242);
            btnQovluguAc.Density = MaterialButton.MaterialButtonDensity.Default;
            btnQovluguAc.Depth = 0;
            btnQovluguAc.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnQovluguAc.HighEmphasis = true;
            btnQovluguAc.Icon = null;
            btnQovluguAc.Location = new Point(460, 35);
            btnQovluguAc.Margin = new Padding(4, 6, 4, 6);
            btnQovluguAc.MouseState = MaterialSkin.MouseState.HOVER;
            btnQovluguAc.Name = "btnQovluguAc";
            btnQovluguAc.NoAccentTextColor = Color.Empty;
            btnQovluguAc.Size = new Size(200, 50);
            btnQovluguAc.TabIndex = 2;
            btnQovluguAc.Text = "Backup Qovluğu";
            btnQovluguAc.Type = MaterialButton.MaterialButtonType.Outlined;
            btnQovluguAc.UseAccentColor = false;
            btnQovluguAc.UseVisualStyleBackColor = false;
            btnQovluguAc.Click += btnQovluguAc_Click;
            // 
            // btnBackupSil
            // 
            btnBackupSil.AutoSize = false;
            btnBackupSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackupSil.BackColor = Color.FromArgb(242, 242, 242);
            btnBackupSil.Density = MaterialButton.MaterialButtonDensity.Default;
            btnBackupSil.Depth = 0;
            btnBackupSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBackupSil.HighEmphasis = true;
            btnBackupSil.Icon = null;
            btnBackupSil.Location = new Point(680, 35);
            btnBackupSil.Margin = new Padding(4, 6, 4, 6);
            btnBackupSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackupSil.Name = "btnBackupSil";
            btnBackupSil.NoAccentTextColor = Color.Empty;
            btnBackupSil.Size = new Size(200, 50);
            btnBackupSil.TabIndex = 3;
            btnBackupSil.Text = "Seçilmişi Sil";
            btnBackupSil.Type = MaterialButton.MaterialButtonType.Text;
            btnBackupSil.UseAccentColor = false;
            btnBackupSil.UseVisualStyleBackColor = false;
            btnBackupSil.Click += btnBackupSil_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = Color.FromArgb(242, 242, 242);
            groupBox3.Controls.Add(lstBackuplar);
            groupBox3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            groupBox3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            groupBox3.Location = new Point(12, 300);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(960, 350);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Mövcud Backup Faylları";
            // 
            // lstBackuplar
            // 
            lstBackuplar.BackColor = Color.FromArgb(242, 242, 242);
            lstBackuplar.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lstBackuplar.Dock = DockStyle.Fill;
            lstBackuplar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lstBackuplar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lstBackuplar.FullRowSelect = true;
            lstBackuplar.GridLines = true;
            lstBackuplar.Location = new Point(3, 20);
            lstBackuplar.Name = "lstBackuplar";
            lstBackuplar.Size = new Size(954, 327);
            lstBackuplar.TabIndex = 0;
            lstBackuplar.UseCompatibleStateImageBehavior = false;
            lstBackuplar.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Fayl Adı";
            columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ölçü";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Yaradılma Tarixi";
            columnHeader3.Width = 200;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(12, 75);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(313, 29);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Verilənlər Bazası İdarəetməsi";
            // 
            // BazaIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(materialLabel1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "BazaIdareetmeFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Verilənlər Bazası İdarəetməsi";
            Load += BazaIdareetmeFormu_Load;
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(groupBox3, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialLabel lblBazaOlcusu;
        private MaterialLabel lblSonBackup;
        private MaterialButton btnYenile;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialButton btnBackupYarat;
        private MaterialButton btnRestoreEt;
        private MaterialButton btnQovluguAc;
        private MaterialButton btnBackupSil;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstBackuplar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialLabel materialLabel1;
    }
}
