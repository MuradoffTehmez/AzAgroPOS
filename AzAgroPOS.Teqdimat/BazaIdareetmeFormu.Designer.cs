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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBazaOlcusu = new MaterialLabel();
            this.lblSonBackup = new MaterialLabel();
            this.btnYenile = new MaterialButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBackupYarat = new MaterialButton();
            this.btnRestoreEt = new MaterialButton();
            this.btnQovluguAc = new MaterialButton();
            this.btnBackupSil = new MaterialButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstBackuplar = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.materialLabel1 = new MaterialLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblBazaOlcusu);
            this.groupBox1.Controls.Add(this.lblSonBackup);
            this.groupBox1.Controls.Add(this.btnYenile);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verilənlər Bazası Məlumatı";
            //
            // lblBazaOlcusu
            //
            this.lblBazaOlcusu.AutoSize = true;
            this.lblBazaOlcusu.Depth = 0;
            this.lblBazaOlcusu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBazaOlcusu.Location = new System.Drawing.Point(20, 30);
            this.lblBazaOlcusu.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBazaOlcusu.Name = "lblBazaOlcusu";
            this.lblBazaOlcusu.Size = new System.Drawing.Size(200, 19);
            this.lblBazaOlcusu.TabIndex = 0;
            this.lblBazaOlcusu.Text = "Verilənlər Bazası Ölçüsü: --- MB";
            //
            // lblSonBackup
            //
            this.lblSonBackup.AutoSize = true;
            this.lblSonBackup.Depth = 0;
            this.lblSonBackup.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSonBackup.Location = new System.Drawing.Point(20, 60);
            this.lblSonBackup.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSonBackup.Name = "lblSonBackup";
            this.lblSonBackup.Size = new System.Drawing.Size(180, 19);
            this.lblSonBackup.TabIndex = 1;
            this.lblSonBackup.Text = "Son Backup: ---";
            //
            // btnYenile
            //
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.AutoSize = false;
            this.btnYenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYenile.Depth = 0;
            this.btnYenile.HighEmphasis = true;
            this.btnYenile.Icon = null;
            this.btnYenile.Location = new System.Drawing.Point(820, 30);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYenile.Size = new System.Drawing.Size(120, 50);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "Yenilə";
            this.btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYenile.UseAccentColor = false;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            //
            // groupBox2
            //
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnBackupYarat);
            this.groupBox2.Controls.Add(this.btnRestoreEt);
            this.groupBox2.Controls.Add(this.btnQovluguAc);
            this.groupBox2.Controls.Add(this.btnBackupSil);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Əməliyyatlar";
            //
            // btnBackupYarat
            //
            this.btnBackupYarat.AutoSize = false;
            this.btnBackupYarat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackupYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackupYarat.Depth = 0;
            this.btnBackupYarat.HighEmphasis = true;
            this.btnBackupYarat.Icon = null;
            this.btnBackupYarat.Location = new System.Drawing.Point(20, 35);
            this.btnBackupYarat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackupYarat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackupYarat.Name = "btnBackupYarat";
            this.btnBackupYarat.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackupYarat.Size = new System.Drawing.Size(200, 50);
            this.btnBackupYarat.TabIndex = 0;
            this.btnBackupYarat.Text = "Backup Yarat";
            this.btnBackupYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBackupYarat.UseAccentColor = false;
            this.btnBackupYarat.UseVisualStyleBackColor = true;
            this.btnBackupYarat.Click += new System.EventHandler(this.btnBackupYarat_Click);
            //
            // btnRestoreEt
            //
            this.btnRestoreEt.AutoSize = false;
            this.btnRestoreEt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestoreEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRestoreEt.Depth = 0;
            this.btnRestoreEt.HighEmphasis = true;
            this.btnRestoreEt.Icon = null;
            this.btnRestoreEt.Location = new System.Drawing.Point(240, 35);
            this.btnRestoreEt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRestoreEt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRestoreEt.Name = "btnRestoreEt";
            this.btnRestoreEt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRestoreEt.Size = new System.Drawing.Size(200, 50);
            this.btnRestoreEt.TabIndex = 1;
            this.btnRestoreEt.Text = "Restore Et (Bərpa)";
            this.btnRestoreEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRestoreEt.UseAccentColor = false;
            this.btnRestoreEt.UseVisualStyleBackColor = true;
            this.btnRestoreEt.Click += new System.EventHandler(this.btnRestoreEt_Click);
            //
            // btnQovluguAc
            //
            this.btnQovluguAc.AutoSize = false;
            this.btnQovluguAc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQovluguAc.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnQovluguAc.Depth = 0;
            this.btnQovluguAc.HighEmphasis = true;
            this.btnQovluguAc.Icon = null;
            this.btnQovluguAc.Location = new System.Drawing.Point(460, 35);
            this.btnQovluguAc.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnQovluguAc.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQovluguAc.Name = "btnQovluguAc";
            this.btnQovluguAc.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnQovluguAc.Size = new System.Drawing.Size(200, 50);
            this.btnQovluguAc.TabIndex = 2;
            this.btnQovluguAc.Text = "Backup Qovluğu";
            this.btnQovluguAc.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnQovluguAc.UseAccentColor = false;
            this.btnQovluguAc.UseVisualStyleBackColor = true;
            this.btnQovluguAc.Click += new System.EventHandler(this.btnQovluguAc_Click);
            //
            // btnBackupSil
            //
            this.btnBackupSil.AutoSize = false;
            this.btnBackupSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackupSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackupSil.Depth = 0;
            this.btnBackupSil.HighEmphasis = true;
            this.btnBackupSil.Icon = null;
            this.btnBackupSil.Location = new System.Drawing.Point(680, 35);
            this.btnBackupSil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackupSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackupSil.Name = "btnBackupSil";
            this.btnBackupSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackupSil.Size = new System.Drawing.Size(200, 50);
            this.btnBackupSil.TabIndex = 3;
            this.btnBackupSil.Text = "Seçilmişi Sil";
            this.btnBackupSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnBackupSil.UseAccentColor = false;
            this.btnBackupSil.UseVisualStyleBackColor = true;
            this.btnBackupSil.Click += new System.EventHandler(this.btnBackupSil_Click);
            //
            // groupBox3
            //
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lstBackuplar);
            this.groupBox3.Font = new System.Drawing.Font("Roboto", 12F);
            this.groupBox3.Location = new System.Drawing.Point(12, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(960, 350);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mövcud Backup Faylları";
            //
            // lstBackuplar
            //
            this.lstBackuplar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstBackuplar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBackuplar.FullRowSelect = true;
            this.lstBackuplar.GridLines = true;
            this.lstBackuplar.Location = new System.Drawing.Point(3, 22);
            this.lstBackuplar.Name = "lstBackuplar";
            this.lstBackuplar.Size = new System.Drawing.Size(954, 325);
            this.lstBackuplar.TabIndex = 0;
            this.lstBackuplar.UseCompatibleStateImageBehavior = false;
            this.lstBackuplar.View = System.Windows.Forms.View.Details;
            //
            // columnHeader1
            //
            this.columnHeader1.Text = "Fayl Adı";
            this.columnHeader1.Width = 400;
            //
            // columnHeader2
            //
            this.columnHeader2.Text = "Ölçü";
            this.columnHeader2.Width = 150;
            //
            // columnHeader3
            //
            this.columnHeader3.Text = "Yaradılma Tarixi";
            this.columnHeader3.Width = 200;
            //
            // materialLabel1
            //
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(12, 75);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(348, 29);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Verilənlər Bazası İdarəetməsi";
            //
            // BazaIdareetmeFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BazaIdareetmeFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verilənlər Bazası İdarəetməsi";
            this.Load += new System.EventHandler(this.BazaIdareetmeFormu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
