namespace AzAgroPOS.PL.Forms
{
    partial class BorcEditForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblAciklamaLabel = new System.Windows.Forms.Label();
            this.numFaizDerecesi = new System.Windows.Forms.NumericUpDown();
            this.lblFaizDerecesiLabel = new System.Windows.Forms.Label();
            this.dtpSonOdemeTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblSonOdemeTarixiLabel = new System.Windows.Forms.Label();
            this.dtpBorcTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblBorcTarixiLabel = new System.Windows.Forms.Label();
            this.numBorcMeblegi = new System.Windows.Forms.NumericUpDown();
            this.lblBorcMeblegLabel = new System.Windows.Forms.Label();
            this.cmbSatis = new System.Windows.Forms.ComboBox();
            this.lblSatisLabel = new System.Windows.Forms.Label();
            this.cmbBorcTipi = new System.Windows.Forms.ComboBox();
            this.lblBorcTipiLabel = new System.Windows.Forms.Label();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.lblMusteriLabel = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFaizDerecesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorcMeblegi)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Borcu Düzəlt";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtAciklama);
            this.panel2.Controls.Add(this.lblAciklamaLabel);
            this.panel2.Controls.Add(this.numFaizDerecesi);
            this.panel2.Controls.Add(this.lblFaizDerecesiLabel);
            this.panel2.Controls.Add(this.dtpSonOdemeTarixi);
            this.panel2.Controls.Add(this.lblSonOdemeTarixiLabel);
            this.panel2.Controls.Add(this.dtpBorcTarixi);
            this.panel2.Controls.Add(this.lblBorcTarixiLabel);
            this.panel2.Controls.Add(this.numBorcMeblegi);
            this.panel2.Controls.Add(this.lblBorcMeblegLabel);
            this.panel2.Controls.Add(this.cmbSatis);
            this.panel2.Controls.Add(this.lblSatisLabel);
            this.panel2.Controls.Add(this.cmbBorcTipi);
            this.panel2.Controls.Add(this.lblBorcTipiLabel);
            this.panel2.Controls.Add(this.cmbMusteri);
            this.panel2.Controls.Add(this.lblMusteriLabel);
            this.panel2.Controls.Add(this.lblFormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(600, 460);
            this.panel2.TabIndex = 1;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(200, 360);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(350, 60);
            this.txtAciklama.TabIndex = 16;
            // 
            // lblAciklamaLabel
            // 
            this.lblAciklamaLabel.AutoSize = true;
            this.lblAciklamaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAciklamaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAciklamaLabel.Location = new System.Drawing.Point(30, 360);
            this.lblAciklamaLabel.Name = "lblAciklamaLabel";
            this.lblAciklamaLabel.Size = new System.Drawing.Size(69, 19);
            this.lblAciklamaLabel.TabIndex = 15;
            this.lblAciklamaLabel.Text = "Açıqlama:";
            // 
            // numFaizDerecesi
            // 
            this.numFaizDerecesi.DecimalPlaces = 2;
            this.numFaizDerecesi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFaizDerecesi.Location = new System.Drawing.Point(200, 320);
            this.numFaizDerecesi.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numFaizDerecesi.Name = "numFaizDerecesi";
            this.numFaizDerecesi.Size = new System.Drawing.Size(150, 25);
            this.numFaizDerecesi.TabIndex = 14;
            // 
            // lblFaizDerecesiLabel
            // 
            this.lblFaizDerecesiLabel.AutoSize = true;
            this.lblFaizDerecesiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizDerecesiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFaizDerecesiLabel.Location = new System.Drawing.Point(30, 320);
            this.lblFaizDerecesiLabel.Name = "lblFaizDerecesiLabel";
            this.lblFaizDerecesiLabel.Size = new System.Drawing.Size(95, 19);
            this.lblFaizDerecesiLabel.TabIndex = 13;
            this.lblFaizDerecesiLabel.Text = "Faiz Dərəcəsi:";
            // 
            // dtpSonOdemeTarixi
            // 
            this.dtpSonOdemeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpSonOdemeTarixi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSonOdemeTarixi.Location = new System.Drawing.Point(200, 280);
            this.dtpSonOdemeTarixi.Name = "dtpSonOdemeTarixi";
            this.dtpSonOdemeTarixi.Size = new System.Drawing.Size(200, 25);
            this.dtpSonOdemeTarixi.TabIndex = 12;
            // 
            // lblSonOdemeTarixiLabel
            // 
            this.lblSonOdemeTarixiLabel.AutoSize = true;
            this.lblSonOdemeTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSonOdemeTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSonOdemeTarixiLabel.Location = new System.Drawing.Point(30, 280);
            this.lblSonOdemeTarixiLabel.Name = "lblSonOdemeTarixiLabel";
            this.lblSonOdemeTarixiLabel.Size = new System.Drawing.Size(130, 19);
            this.lblSonOdemeTarixiLabel.TabIndex = 11;
            this.lblSonOdemeTarixiLabel.Text = "Son Ödəmə Tarixi:";
            // 
            // dtpBorcTarixi
            // 
            this.dtpBorcTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpBorcTarixi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorcTarixi.Location = new System.Drawing.Point(200, 240);
            this.dtpBorcTarixi.Name = "dtpBorcTarixi";
            this.dtpBorcTarixi.Size = new System.Drawing.Size(200, 25);
            this.dtpBorcTarixi.TabIndex = 10;
            // 
            // lblBorcTarixiLabel
            // 
            this.lblBorcTarixiLabel.AutoSize = true;
            this.lblBorcTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcTarixiLabel.Location = new System.Drawing.Point(30, 240);
            this.lblBorcTarixiLabel.Name = "lblBorcTarixiLabel";
            this.lblBorcTarixiLabel.Size = new System.Drawing.Size(84, 19);
            this.lblBorcTarixiLabel.TabIndex = 9;
            this.lblBorcTarixiLabel.Text = "Borc Tarixi:";
            // 
            // numBorcMeblegi
            // 
            this.numBorcMeblegi.DecimalPlaces = 2;
            this.numBorcMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numBorcMeblegi.Location = new System.Drawing.Point(200, 200);
            this.numBorcMeblegi.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numBorcMeblegi.Name = "numBorcMeblegi";
            this.numBorcMeblegi.Size = new System.Drawing.Size(200, 25);
            this.numBorcMeblegi.TabIndex = 8;
            // 
            // lblBorcMeblegLabel
            // 
            this.lblBorcMeblegLabel.AutoSize = true;
            this.lblBorcMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcMeblegLabel.Location = new System.Drawing.Point(30, 200);
            this.lblBorcMeblegLabel.Name = "lblBorcMeblegLabel";
            this.lblBorcMeblegLabel.Size = new System.Drawing.Size(96, 19);
            this.lblBorcMeblegLabel.TabIndex = 7;
            this.lblBorcMeblegLabel.Text = "Borc Məbləği:";
            // 
            // cmbSatis
            // 
            this.cmbSatis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSatis.FormattingEnabled = true;
            this.cmbSatis.Location = new System.Drawing.Point(200, 160);
            this.cmbSatis.Name = "cmbSatis";
            this.cmbSatis.Size = new System.Drawing.Size(350, 25);
            this.cmbSatis.TabIndex = 6;
            // 
            // lblSatisLabel
            // 
            this.lblSatisLabel.AutoSize = true;
            this.lblSatisLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSatisLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSatisLabel.Location = new System.Drawing.Point(30, 160);
            this.lblSatisLabel.Name = "lblSatisLabel";
            this.lblSatisLabel.Size = new System.Drawing.Size(91, 19);
            this.lblSatisLabel.TabIndex = 5;
            this.lblSatisLabel.Text = "Satış Sənədi:";
            // 
            // cmbBorcTipi
            // 
            this.cmbBorcTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBorcTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBorcTipi.FormattingEnabled = true;
            this.cmbBorcTipi.Items.AddRange(new object[] {
            "Mal Satışı",
            "Xidmət",
            "Kredit",
            "Avans",
            "Digər"});
            this.cmbBorcTipi.Location = new System.Drawing.Point(200, 120);
            this.cmbBorcTipi.Name = "cmbBorcTipi";
            this.cmbBorcTipi.Size = new System.Drawing.Size(200, 25);
            this.cmbBorcTipi.TabIndex = 4;
            // 
            // lblBorcTipiLabel
            // 
            this.lblBorcTipiLabel.AutoSize = true;
            this.lblBorcTipiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcTipiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcTipiLabel.Location = new System.Drawing.Point(30, 120);
            this.lblBorcTipiLabel.Name = "lblBorcTipiLabel";
            this.lblBorcTipiLabel.Size = new System.Drawing.Size(73, 19);
            this.lblBorcTipiLabel.TabIndex = 3;
            this.lblBorcTipiLabel.Text = "Borc Tipi:";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(200, 80);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(350, 25);
            this.cmbMusteri.TabIndex = 2;
            // 
            // lblMusteriLabel
            // 
            this.lblMusteriLabel.AutoSize = true;
            this.lblMusteriLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMusteriLabel.Location = new System.Drawing.Point(30, 80);
            this.lblMusteriLabel.Name = "lblMusteriLabel";
            this.lblMusteriLabel.Size = new System.Drawing.Size(65, 19);
            this.lblMusteriLabel.TabIndex = 1;
            this.lblMusteriLabel.Text = "Müştəri:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFormTitle.Location = new System.Drawing.Point(25, 30);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(192, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Borc Məlumatları";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 70);
            this.panel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(420, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BorcEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorcEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Borcu Düzəlt";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFaizDerecesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorcMeblegi)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.Label lblMusteriLabel;
        private System.Windows.Forms.ComboBox cmbBorcTipi;
        private System.Windows.Forms.Label lblBorcTipiLabel;
        private System.Windows.Forms.ComboBox cmbSatis;
        private System.Windows.Forms.Label lblSatisLabel;
        private System.Windows.Forms.NumericUpDown numBorcMeblegi;
        private System.Windows.Forms.Label lblBorcMeblegLabel;
        private System.Windows.Forms.DateTimePicker dtpBorcTarixi;
        private System.Windows.Forms.Label lblBorcTarixiLabel;
        private System.Windows.Forms.DateTimePicker dtpSonOdemeTarixi;
        private System.Windows.Forms.Label lblSonOdemeTarixiLabel;
        private System.Windows.Forms.NumericUpDown numFaizDerecesi;
        private System.Windows.Forms.Label lblFaizDerecesiLabel;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lblAciklamaLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}