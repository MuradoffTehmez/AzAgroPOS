namespace AzAgroPOS.PL.Forms
{
    partial class MusteriDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpPersonalInfo;
        private System.Windows.Forms.Label lblMusteriKodu;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox grpFinancialInfo;
        private System.Windows.Forms.Label lblCariBorc;
        private System.Windows.Forms.Label lblKreditLimiti;
        private System.Windows.Forms.Label lblUmumiAlis;
        private System.Windows.Forms.Label lblSonZiyaret;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpPersonalInfo = new System.Windows.Forms.GroupBox();
            this.lblMusteriKodu = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.grpFinancialInfo = new System.Windows.Forms.GroupBox();
            this.lblCariBorc = new System.Windows.Forms.Label();
            this.lblKreditLimiti = new System.Windows.Forms.Label();
            this.lblUmumiAlis = new System.Windows.Forms.Label();
            this.lblSonZiyaret = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpPersonalInfo.SuspendLayout();
            this.grpFinancialInfo.SuspendLayout();
            this.SuspendLayout();
            
            // panel1
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 60);
            this.panel1.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Müştəri Detalları";
            
            // panel2
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 60);
            this.panel2.TabIndex = 1;
            
            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(500, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✗ Bağla";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // grpPersonalInfo
            this.grpPersonalInfo.BackColor = System.Drawing.Color.White;
            this.grpPersonalInfo.Controls.Add(this.lblMusteriKodu);
            this.grpPersonalInfo.Controls.Add(this.lblAd);
            this.grpPersonalInfo.Controls.Add(this.lblSoyad);
            this.grpPersonalInfo.Controls.Add(this.lblTelefon);
            this.grpPersonalInfo.Controls.Add(this.lblEmail);
            this.grpPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpPersonalInfo.Location = new System.Drawing.Point(20, 80);
            this.grpPersonalInfo.Name = "grpPersonalInfo";
            this.grpPersonalInfo.Size = new System.Drawing.Size(270, 200);
            this.grpPersonalInfo.TabIndex = 2;
            this.grpPersonalInfo.TabStop = false;
            this.grpPersonalInfo.Text = "📝 Şəxsi Məlumatlar";
            
            // lblMusteriKodu
            this.lblMusteriKodu.AutoSize = true;
            this.lblMusteriKodu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMusteriKodu.Location = new System.Drawing.Point(15, 30);
            this.lblMusteriKodu.Name = "lblMusteriKodu";
            this.lblMusteriKodu.Size = new System.Drawing.Size(100, 19);
            this.lblMusteriKodu.TabIndex = 0;
            this.lblMusteriKodu.Text = "Müştəri Kodu: ";
            
            // lblAd
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAd.Location = new System.Drawing.Point(15, 60);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(30, 19);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "Ad: ";
            
            // lblSoyad
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoyad.Location = new System.Drawing.Point(15, 90);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(55, 19);
            this.lblSoyad.TabIndex = 2;
            this.lblSoyad.Text = "Soyad: ";
            
            // lblTelefon
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTelefon.Location = new System.Drawing.Point(15, 120);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(65, 19);
            this.lblTelefon.TabIndex = 3;
            this.lblTelefon.Text = "Telefon: ";
            
            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(15, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 19);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email: ";
            
            // grpFinancialInfo
            this.grpFinancialInfo.BackColor = System.Drawing.Color.White;
            this.grpFinancialInfo.Controls.Add(this.lblCariBorc);
            this.grpFinancialInfo.Controls.Add(this.lblKreditLimiti);
            this.grpFinancialInfo.Controls.Add(this.lblUmumiAlis);
            this.grpFinancialInfo.Controls.Add(this.lblSonZiyaret);
            this.grpFinancialInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpFinancialInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.grpFinancialInfo.Location = new System.Drawing.Point(310, 80);
            this.grpFinancialInfo.Name = "grpFinancialInfo";
            this.grpFinancialInfo.Size = new System.Drawing.Size(270, 200);
            this.grpFinancialInfo.TabIndex = 3;
            this.grpFinancialInfo.TabStop = false;
            this.grpFinancialInfo.Text = "💰 Maliyyə Məlumatları";
            
            // lblCariBorc
            this.lblCariBorc.AutoSize = true;
            this.lblCariBorc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCariBorc.Location = new System.Drawing.Point(15, 30);
            this.lblCariBorc.Name = "lblCariBorc";
            this.lblCariBorc.Size = new System.Drawing.Size(80, 19);
            this.lblCariBorc.TabIndex = 0;
            this.lblCariBorc.Text = "Cari Borc: ";
            
            // lblKreditLimiti
            this.lblKreditLimiti.AutoSize = true;
            this.lblKreditLimiti.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKreditLimiti.Location = new System.Drawing.Point(15, 60);
            this.lblKreditLimiti.Name = "lblKreditLimiti";
            this.lblKreditLimiti.Size = new System.Drawing.Size(95, 19);
            this.lblKreditLimiti.TabIndex = 1;
            this.lblKreditLimiti.Text = "Kredit Limiti: ";
            
            // lblUmumiAlis
            this.lblUmumiAlis.AutoSize = true;
            this.lblUmumiAlis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUmumiAlis.Location = new System.Drawing.Point(15, 90);
            this.lblUmumiAlis.Name = "lblUmumiAlis";
            this.lblUmumiAlis.Size = new System.Drawing.Size(90, 19);
            this.lblUmumiAlis.TabIndex = 2;
            this.lblUmumiAlis.Text = "Ümumi Alış: ";
            
            // lblSonZiyaret
            this.lblSonZiyaret.AutoSize = true;
            this.lblSonZiyaret.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSonZiyaret.Location = new System.Drawing.Point(15, 120);
            this.lblSonZiyaret.Name = "lblSonZiyaret";
            this.lblSonZiyaret.Size = new System.Drawing.Size(90, 19);
            this.lblSonZiyaret.TabIndex = 3;
            this.lblSonZiyaret.Text = "Son Ziyarət: ";
            
            // MusteriDetailsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.grpFinancialInfo);
            this.Controls.Add(this.grpPersonalInfo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MusteriDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müştəri Detalları";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grpPersonalInfo.ResumeLayout(false);
            this.grpPersonalInfo.PerformLayout();
            this.grpFinancialInfo.ResumeLayout(false);
            this.grpFinancialInfo.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}