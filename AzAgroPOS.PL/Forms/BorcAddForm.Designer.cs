namespace AzAgroPOS.PL.Forms
{
    partial class BorcAddForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.lblBorcTipi = new System.Windows.Forms.Label();
            this.cmbBorcTipi = new System.Windows.Forms.ComboBox();
            this.lblSatis = new System.Windows.Forms.Label();
            this.cmbSatis = new System.Windows.Forms.ComboBox();
            this.lblBorcMeblegi = new System.Windows.Forms.Label();
            this.numBorcMeblegi = new System.Windows.Forms.NumericUpDown();
            this.lblBorcTarixi = new System.Windows.Forms.Label();
            this.dtpBorcTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblSonOdemeTarixi = new System.Windows.Forms.Label();
            this.dtpSonOdemeTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblFaizDerecesi = new System.Windows.Forms.Label();
            this.numFaizDerecesi = new System.Windows.Forms.NumericUpDown();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBorcMeblegi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFaizDerecesi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(237, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💳 Yeni Borc Əlavə Et";
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMusteri.Location = new System.Drawing.Point(30, 80);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(59, 19);
            this.lblMusteri.TabIndex = 1;
            this.lblMusteri.Text = "Müştəri:";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(180, 77);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(250, 25);
            this.cmbMusteri.TabIndex = 2;
            // 
            // lblBorcTipi
            // 
            this.lblBorcTipi.AutoSize = true;
            this.lblBorcTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcTipi.Location = new System.Drawing.Point(30, 120);
            this.lblBorcTipi.Name = "lblBorcTipi";
            this.lblBorcTipi.Size = new System.Drawing.Size(64, 19);
            this.lblBorcTipi.TabIndex = 3;
            this.lblBorcTipi.Text = "Borc Tipi:";
            // 
            // cmbBorcTipi
            // 
            this.cmbBorcTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBorcTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBorcTipi.FormattingEnabled = true;
            this.cmbBorcTipi.Items.AddRange(new object[] {
            "Satış",
            "Nisyə",
            "Faiz",
            "Cərimə"});
            this.cmbBorcTipi.Location = new System.Drawing.Point(180, 117);
            this.cmbBorcTipi.Name = "cmbBorcTipi";
            this.cmbBorcTipi.Size = new System.Drawing.Size(250, 25);
            this.cmbBorcTipi.TabIndex = 4;
            // 
            // lblSatis
            // 
            this.lblSatis.AutoSize = true;
            this.lblSatis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSatis.Location = new System.Drawing.Point(30, 160);
            this.lblSatis.Name = "lblSatis";
            this.lblSatis.Size = new System.Drawing.Size(84, 19);
            this.lblSatis.TabIndex = 5;
            this.lblSatis.Text = "Satış Sənədi:";
            // 
            // cmbSatis
            // 
            this.cmbSatis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSatis.FormattingEnabled = true;
            this.cmbSatis.Location = new System.Drawing.Point(180, 157);
            this.cmbSatis.Name = "cmbSatis";
            this.cmbSatis.Size = new System.Drawing.Size(250, 25);
            this.cmbSatis.TabIndex = 6;
            // 
            // lblBorcMeblegi
            // 
            this.lblBorcMeblegi.AutoSize = true;
            this.lblBorcMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcMeblegi.Location = new System.Drawing.Point(30, 200);
            this.lblBorcMeblegi.Name = "lblBorcMeblegi";
            this.lblBorcMeblegi.Size = new System.Drawing.Size(92, 19);
            this.lblBorcMeblegi.TabIndex = 7;
            this.lblBorcMeblegi.Text = "Borc Məbləği:";
            // 
            // numBorcMeblegi
            // 
            this.numBorcMeblegi.DecimalPlaces = 2;
            this.numBorcMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numBorcMeblegi.Location = new System.Drawing.Point(180, 197);
            this.numBorcMeblegi.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numBorcMeblegi.Name = "numBorcMeblegi";
            this.numBorcMeblegi.Size = new System.Drawing.Size(150, 25);
            this.numBorcMeblegi.TabIndex = 8;
            // 
            // lblBorcTarixi
            // 
            this.lblBorcTarixi.AutoSize = true;
            this.lblBorcTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcTarixi.Location = new System.Drawing.Point(30, 240);
            this.lblBorcTarixi.Name = "lblBorcTarixi";
            this.lblBorcTarixi.Size = new System.Drawing.Size(72, 19);
            this.lblBorcTarixi.TabIndex = 9;
            this.lblBorcTarixi.Text = "Borc Tarixi:";
            // 
            // dtpBorcTarixi
            // 
            this.dtpBorcTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpBorcTarixi.Location = new System.Drawing.Point(180, 237);
            this.dtpBorcTarixi.Name = "dtpBorcTarixi";
            this.dtpBorcTarixi.Size = new System.Drawing.Size(200, 25);
            this.dtpBorcTarixi.TabIndex = 10;
            // 
            // lblSonOdemeTarixi
            // 
            this.lblSonOdemeTarixi.AutoSize = true;
            this.lblSonOdemeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSonOdemeTarixi.Location = new System.Drawing.Point(30, 280);
            this.lblSonOdemeTarixi.Name = "lblSonOdemeTarixi";
            this.lblSonOdemeTarixi.Size = new System.Drawing.Size(117, 19);
            this.lblSonOdemeTarixi.TabIndex = 11;
            this.lblSonOdemeTarixi.Text = "Son Ödəmə Tarixi:";
            // 
            // dtpSonOdemeTarixi
            // 
            this.dtpSonOdemeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpSonOdemeTarixi.Location = new System.Drawing.Point(180, 277);
            this.dtpSonOdemeTarixi.Name = "dtpSonOdemeTarixi";
            this.dtpSonOdemeTarixi.Size = new System.Drawing.Size(200, 25);
            this.dtpSonOdemeTarixi.TabIndex = 12;
            // 
            // lblFaizDerecesi
            // 
            this.lblFaizDerecesi.AutoSize = true;
            this.lblFaizDerecesi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFaizDerecesi.Location = new System.Drawing.Point(30, 320);
            this.lblFaizDerecesi.Name = "lblFaizDerecesi";
            this.lblFaizDerecesi.Size = new System.Drawing.Size(113, 19);
            this.lblFaizDerecesi.TabIndex = 13;
            this.lblFaizDerecesi.Text = "Faiz Dərəcəsi (%):";
            // 
            // numFaizDerecesi
            // 
            this.numFaizDerecesi.DecimalPlaces = 2;
            this.numFaizDerecesi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFaizDerecesi.Location = new System.Drawing.Point(180, 317);
            this.numFaizDerecesi.Name = "numFaizDerecesi";
            this.numFaizDerecesi.Size = new System.Drawing.Size(100, 25);
            this.numFaizDerecesi.TabIndex = 14;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAciklama.Location = new System.Drawing.Point(30, 360);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(67, 19);
            this.lblAciklama.TabIndex = 15;
            this.lblAciklama.Text = "Açıqlama:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(180, 357);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(300, 80);
            this.txtAciklama.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(400, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BorcAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(550, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.numFaizDerecesi);
            this.Controls.Add(this.lblFaizDerecesi);
            this.Controls.Add(this.dtpSonOdemeTarixi);
            this.Controls.Add(this.lblSonOdemeTarixi);
            this.Controls.Add(this.dtpBorcTarixi);
            this.Controls.Add(this.lblBorcTarixi);
            this.Controls.Add(this.numBorcMeblegi);
            this.Controls.Add(this.lblBorcMeblegi);
            this.Controls.Add(this.cmbSatis);
            this.Controls.Add(this.lblSatis);
            this.Controls.Add(this.cmbBorcTipi);
            this.Controls.Add(this.lblBorcTipi);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.lblMusteri);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorcAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Borc Əlavə Et";
            ((System.ComponentModel.ISupportInitialize)(this.numBorcMeblegi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFaizDerecesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.Label lblBorcTipi;
        private System.Windows.Forms.ComboBox cmbBorcTipi;
        private System.Windows.Forms.Label lblSatis;
        private System.Windows.Forms.ComboBox cmbSatis;
        private System.Windows.Forms.Label lblBorcMeblegi;
        private System.Windows.Forms.NumericUpDown numBorcMeblegi;
        private System.Windows.Forms.Label lblBorcTarixi;
        private System.Windows.Forms.DateTimePicker dtpBorcTarixi;
        private System.Windows.Forms.Label lblSonOdemeTarixi;
        private System.Windows.Forms.DateTimePicker dtpSonOdemeTarixi;
        private System.Windows.Forms.Label lblFaizDerecesi;
        private System.Windows.Forms.NumericUpDown numFaizDerecesi;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}