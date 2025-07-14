namespace AzAgroPOS.PL.Forms
{
    partial class BorcPaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUmumiBorc = new System.Windows.Forms.Label();
            this.lblUmumiBorcLabel = new System.Windows.Forms.Label();
            this.lblFaizMeblegi = new System.Windows.Forms.Label();
            this.lblFaizMeblegLabel = new System.Windows.Forms.Label();
            this.lblQalanBorc = new System.Windows.Forms.Label();
            this.lblQalanBorcLabel = new System.Windows.Forms.Label();
            this.lblOdenilmisMebleg = new System.Windows.Forms.Label();
            this.lblOdenilmisMeblegLabel = new System.Windows.Forms.Label();
            this.lblBorcMeblegi = new System.Windows.Forms.Label();
            this.lblBorcMeblegLabel = new System.Windows.Forms.Label();
            this.lblMusteriAdi = new System.Windows.Forms.Label();
            this.lblMusteriAdiLabel = new System.Windows.Forms.Label();
            this.lblBorcNomresi = new System.Windows.Forms.Label();
            this.lblBorcNomresiLabel = new System.Windows.Forms.Label();
            this.lblBorcBilgileri = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numKomissiya = new System.Windows.Forms.NumericUpDown();
            this.lblKomissiya = new System.Windows.Forms.Label();
            this.txtOdenisDetali = new System.Windows.Forms.TextBox();
            this.lblOdenisDetali = new System.Windows.Forms.Label();
            this.cmbOdenisTipi = new System.Windows.Forms.ComboBox();
            this.lblOdenisTipi = new System.Windows.Forms.Label();
            this.numOdenisMeblegi = new System.Windows.Forms.NumericUpDown();
            this.lblOdenisMeblegi = new System.Windows.Forms.Label();
            this.dtpOdenisTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblOdenisTarixi = new System.Windows.Forms.Label();
            this.lblOdenisBilgileri = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.lblEsasBorcOdenisi = new System.Windows.Forms.Label();
            this.lblEsasBorcOdenisiLabel = new System.Windows.Forms.Label();
            this.lblFaizOdenisi = new System.Windows.Forms.Label();
            this.lblFaizOdenisiLabel = new System.Windows.Forms.Label();
            this.lblOdenisBreakdown = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKomissiya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOdenisMeblegi)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💰 Borc Ödənişi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblUmumiBorc);
            this.panel2.Controls.Add(this.lblUmumiBorcLabel);
            this.panel2.Controls.Add(this.lblFaizMeblegi);
            this.panel2.Controls.Add(this.lblFaizMeblegLabel);
            this.panel2.Controls.Add(this.lblQalanBorc);
            this.panel2.Controls.Add(this.lblQalanBorcLabel);
            this.panel2.Controls.Add(this.lblOdenilmisMebleg);
            this.panel2.Controls.Add(this.lblOdenilmisMeblegLabel);
            this.panel2.Controls.Add(this.lblBorcMeblegi);
            this.panel2.Controls.Add(this.lblBorcMeblegLabel);
            this.panel2.Controls.Add(this.lblMusteriAdi);
            this.panel2.Controls.Add(this.lblMusteriAdiLabel);
            this.panel2.Controls.Add(this.lblBorcNomresi);
            this.panel2.Controls.Add(this.lblBorcNomresiLabel);
            this.panel2.Controls.Add(this.lblBorcBilgileri);
            this.panel2.Location = new System.Drawing.Point(20, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 180);
            this.panel2.TabIndex = 1;
            // 
            // lblUmumiBorc
            // 
            this.lblUmumiBorc.AutoSize = true;
            this.lblUmumiBorc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUmumiBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblUmumiBorc.Location = new System.Drawing.Point(450, 113);
            this.lblUmumiBorc.Name = "lblUmumiBorc";
            this.lblUmumiBorc.Size = new System.Drawing.Size(36, 21);
            this.lblUmumiBorc.TabIndex = 14;
            this.lblUmumiBorc.Text = "0 ₼";
            // 
            // lblUmumiBorcLabel
            // 
            this.lblUmumiBorcLabel.AutoSize = true;
            this.lblUmumiBorcLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUmumiBorcLabel.Location = new System.Drawing.Point(350, 115);
            this.lblUmumiBorcLabel.Name = "lblUmumiBorcLabel";
            this.lblUmumiBorcLabel.Size = new System.Drawing.Size(88, 19);
            this.lblUmumiBorcLabel.TabIndex = 13;
            this.lblUmumiBorcLabel.Text = "Ümumi Borc:";
            // 
            // lblFaizMeblegi
            // 
            this.lblFaizMeblegi.AutoSize = true;
            this.lblFaizMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizMeblegi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblFaizMeblegi.Location = new System.Drawing.Point(450, 85);
            this.lblFaizMeblegi.Name = "lblFaizMeblegi";
            this.lblFaizMeblegi.Size = new System.Drawing.Size(33, 19);
            this.lblFaizMeblegi.TabIndex = 12;
            this.lblFaizMeblegi.Text = "0 ₼";
            // 
            // lblFaizMeblegLabel
            // 
            this.lblFaizMeblegLabel.AutoSize = true;
            this.lblFaizMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFaizMeblegLabel.Location = new System.Drawing.Point(350, 85);
            this.lblFaizMeblegLabel.Name = "lblFaizMeblegLabel";
            this.lblFaizMeblegLabel.Size = new System.Drawing.Size(88, 19);
            this.lblFaizMeblegLabel.TabIndex = 11;
            this.lblFaizMeblegLabel.Text = "Faiz Məbləği:";
            // 
            // lblQalanBorc
            // 
            this.lblQalanBorc.AutoSize = true;
            this.lblQalanBorc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQalanBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblQalanBorc.Location = new System.Drawing.Point(110, 145);
            this.lblQalanBorc.Name = "lblQalanBorc";
            this.lblQalanBorc.Size = new System.Drawing.Size(33, 19);
            this.lblQalanBorc.TabIndex = 10;
            this.lblQalanBorc.Text = "0 ₼";
            // 
            // lblQalanBorcLabel
            // 
            this.lblQalanBorcLabel.AutoSize = true;
            this.lblQalanBorcLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQalanBorcLabel.Location = new System.Drawing.Point(20, 145);
            this.lblQalanBorcLabel.Name = "lblQalanBorcLabel";
            this.lblQalanBorcLabel.Size = new System.Drawing.Size(79, 19);
            this.lblQalanBorcLabel.TabIndex = 9;
            this.lblQalanBorcLabel.Text = "Qalan Borc:";
            // 
            // lblOdenilmisMebleg
            // 
            this.lblOdenilmisMebleg.AutoSize = true;
            this.lblOdenilmisMebleg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOdenilmisMebleg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblOdenilmisMebleg.Location = new System.Drawing.Point(160, 115);
            this.lblOdenilmisMebleg.Name = "lblOdenilmisMebleg";
            this.lblOdenilmisMebleg.Size = new System.Drawing.Size(33, 19);
            this.lblOdenilmisMebleg.TabIndex = 8;
            this.lblOdenilmisMebleg.Text = "0 ₼";
            // 
            // lblOdenilmisMeblegLabel
            // 
            this.lblOdenilmisMeblegLabel.AutoSize = true;
            this.lblOdenilmisMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOdenilmisMeblegLabel.Location = new System.Drawing.Point(20, 115);
            this.lblOdenilmisMeblegLabel.Name = "lblOdenilmisMeblegLabel";
            this.lblOdenilmisMeblegLabel.Size = new System.Drawing.Size(123, 19);
            this.lblOdenilmisMeblegLabel.TabIndex = 7;
            this.lblOdenilmisMeblegLabel.Text = "Ödənilmiş Məbləğ:";
            // 
            // lblBorcMeblegi
            // 
            this.lblBorcMeblegi.AutoSize = true;
            this.lblBorcMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcMeblegi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblBorcMeblegi.Location = new System.Drawing.Point(130, 85);
            this.lblBorcMeblegi.Name = "lblBorcMeblegi";
            this.lblBorcMeblegi.Size = new System.Drawing.Size(33, 19);
            this.lblBorcMeblegi.TabIndex = 6;
            this.lblBorcMeblegi.Text = "0 ₼";
            // 
            // lblBorcMeblegLabel
            // 
            this.lblBorcMeblegLabel.AutoSize = true;
            this.lblBorcMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcMeblegLabel.Location = new System.Drawing.Point(20, 85);
            this.lblBorcMeblegLabel.Name = "lblBorcMeblegLabel";
            this.lblBorcMeblegLabel.Size = new System.Drawing.Size(92, 19);
            this.lblBorcMeblegLabel.TabIndex = 5;
            this.lblBorcMeblegLabel.Text = "Borc Məbləği:";
            // 
            // lblMusteriAdi
            // 
            this.lblMusteriAdi.AutoSize = true;
            this.lblMusteriAdi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriAdi.Location = new System.Drawing.Point(320, 55);
            this.lblMusteriAdi.Name = "lblMusteriAdi";
            this.lblMusteriAdi.Size = new System.Drawing.Size(15, 19);
            this.lblMusteriAdi.TabIndex = 4;
            this.lblMusteriAdi.Text = "-";
            // 
            // lblMusteriAdiLabel
            // 
            this.lblMusteriAdiLabel.AutoSize = true;
            this.lblMusteriAdiLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMusteriAdiLabel.Location = new System.Drawing.Point(250, 55);
            this.lblMusteriAdiLabel.Name = "lblMusteriAdiLabel";
            this.lblMusteriAdiLabel.Size = new System.Drawing.Size(59, 19);
            this.lblMusteriAdiLabel.TabIndex = 3;
            this.lblMusteriAdiLabel.Text = "Müştəri:";
            // 
            // lblBorcNomresi
            // 
            this.lblBorcNomresi.AutoSize = true;
            this.lblBorcNomresi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcNomresi.Location = new System.Drawing.Point(130, 55);
            this.lblBorcNomresi.Name = "lblBorcNomresi";
            this.lblBorcNomresi.Size = new System.Drawing.Size(15, 19);
            this.lblBorcNomresi.TabIndex = 2;
            this.lblBorcNomresi.Text = "-";
            // 
            // lblBorcNomresiLabel
            // 
            this.lblBorcNomresiLabel.AutoSize = true;
            this.lblBorcNomresiLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcNomresiLabel.Location = new System.Drawing.Point(20, 55);
            this.lblBorcNomresiLabel.Name = "lblBorcNomresiLabel";
            this.lblBorcNomresiLabel.Size = new System.Drawing.Size(94, 19);
            this.lblBorcNomresiLabel.TabIndex = 1;
            this.lblBorcNomresiLabel.Text = "Borc Nömrəsi:";
            // 
            // lblBorcBilgileri
            // 
            this.lblBorcBilgileri.AutoSize = true;
            this.lblBorcBilgileri.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBorcBilgileri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcBilgileri.Location = new System.Drawing.Point(15, 15);
            this.lblBorcBilgileri.Name = "lblBorcBilgileri";
            this.lblBorcBilgileri.Size = new System.Drawing.Size(125, 25);
            this.lblBorcBilgileri.TabIndex = 0;
            this.lblBorcBilgileri.Text = "Borc Bilgiləri";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.numKomissiya);
            this.panel3.Controls.Add(this.lblKomissiya);
            this.panel3.Controls.Add(this.txtOdenisDetali);
            this.panel3.Controls.Add(this.lblOdenisDetali);
            this.panel3.Controls.Add(this.cmbOdenisTipi);
            this.panel3.Controls.Add(this.lblOdenisTipi);
            this.panel3.Controls.Add(this.numOdenisMeblegi);
            this.panel3.Controls.Add(this.lblOdenisMeblegi);
            this.panel3.Controls.Add(this.dtpOdenisTarixi);
            this.panel3.Controls.Add(this.lblOdenisTarixi);
            this.panel3.Controls.Add(this.lblOdenisBilgileri);
            this.panel3.Location = new System.Drawing.Point(20, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 160);
            this.panel3.TabIndex = 2;
            // 
            // numKomissiya
            // 
            this.numKomissiya.DecimalPlaces = 2;
            this.numKomissiya.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numKomissiya.Location = new System.Drawing.Point(430, 82);
            this.numKomissiya.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numKomissiya.Name = "numKomissiya";
            this.numKomissiya.Size = new System.Drawing.Size(100, 25);
            this.numKomissiya.TabIndex = 10;
            // 
            // lblKomissiya
            // 
            this.lblKomissiya.AutoSize = true;
            this.lblKomissiya.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKomissiya.Location = new System.Drawing.Point(350, 85);
            this.lblKomissiya.Name = "lblKomissiya";
            this.lblKomissiya.Size = new System.Drawing.Size(72, 19);
            this.lblKomissiya.TabIndex = 9;
            this.lblKomissiya.Text = "Komissiya:";
            // 
            // txtOdenisDetali
            // 
            this.txtOdenisDetali.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOdenisDetali.Location = new System.Drawing.Point(450, 52);
            this.txtOdenisDetali.Name = "txtOdenisDetali";
            this.txtOdenisDetali.Size = new System.Drawing.Size(180, 25);
            this.txtOdenisDetali.TabIndex = 8;
            // 
            // lblOdenisDetali
            // 
            this.lblOdenisDetali.AutoSize = true;
            this.lblOdenisDetali.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOdenisDetali.Location = new System.Drawing.Point(350, 55);
            this.lblOdenisDetali.Name = "lblOdenisDetali";
            this.lblOdenisDetali.Size = new System.Drawing.Size(89, 19);
            this.lblOdenisDetali.TabIndex = 7;
            this.lblOdenisDetali.Text = "Ödəniş Təlali:";
            // 
            // cmbOdenisTipi
            // 
            this.cmbOdenisTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdenisTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbOdenisTipi.FormattingEnabled = true;
            this.cmbOdenisTipi.Location = new System.Drawing.Point(110, 112);
            this.cmbOdenisTipi.Name = "cmbOdenisTipi";
            this.cmbOdenisTipi.Size = new System.Drawing.Size(160, 25);
            this.cmbOdenisTipi.TabIndex = 6;
            // 
            // lblOdenisTipi
            // 
            this.lblOdenisTipi.AutoSize = true;
            this.lblOdenisTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOdenisTipi.Location = new System.Drawing.Point(20, 115);
            this.lblOdenisTipi.Name = "lblOdenisTipi";
            this.lblOdenisTipi.Size = new System.Drawing.Size(80, 19);
            this.lblOdenisTipi.TabIndex = 5;
            this.lblOdenisTipi.Text = "Ödəniş Tipi:";
            // 
            // numOdenisMeblegi
            // 
            this.numOdenisMeblegi.DecimalPlaces = 2;
            this.numOdenisMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numOdenisMeblegi.Location = new System.Drawing.Point(140, 82);
            this.numOdenisMeblegi.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numOdenisMeblegi.Name = "numOdenisMeblegi";
            this.numOdenisMeblegi.Size = new System.Drawing.Size(130, 25);
            this.numOdenisMeblegi.TabIndex = 4;
            this.numOdenisMeblegi.ValueChanged += new System.EventHandler(this.numOdenisMeblegi_ValueChanged);
            // 
            // lblOdenisMeblegi
            // 
            this.lblOdenisMeblegi.AutoSize = true;
            this.lblOdenisMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOdenisMeblegi.Location = new System.Drawing.Point(20, 85);
            this.lblOdenisMeblegi.Name = "lblOdenisMeblegi";
            this.lblOdenisMeblegi.Size = new System.Drawing.Size(108, 19);
            this.lblOdenisMeblegi.TabIndex = 3;
            this.lblOdenisMeblegi.Text = "Ödəniş Məbləği:";
            // 
            // dtpOdenisTarixi
            // 
            this.dtpOdenisTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpOdenisTarixi.Location = new System.Drawing.Point(120, 52);
            this.dtpOdenisTarixi.Name = "dtpOdenisTarixi";
            this.dtpOdenisTarixi.Size = new System.Drawing.Size(150, 25);
            this.dtpOdenisTarixi.TabIndex = 2;
            // 
            // lblOdenisTarixi
            // 
            this.lblOdenisTarixi.AutoSize = true;
            this.lblOdenisTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOdenisTarixi.Location = new System.Drawing.Point(20, 55);
            this.lblOdenisTarixi.Name = "lblOdenisTarixi";
            this.lblOdenisTarixi.Size = new System.Drawing.Size(88, 19);
            this.lblOdenisTarixi.TabIndex = 1;
            this.lblOdenisTarixi.Text = "Ödəniş Tarixi:";
            // 
            // lblOdenisBilgileri
            // 
            this.lblOdenisBilgileri.AutoSize = true;
            this.lblOdenisBilgileri.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOdenisBilgileri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOdenisBilgileri.Location = new System.Drawing.Point(15, 15);
            this.lblOdenisBilgileri.Name = "lblOdenisBilgileri";
            this.lblOdenisBilgileri.Size = new System.Drawing.Size(145, 25);
            this.lblOdenisBilgileri.TabIndex = 0;
            this.lblOdenisBilgileri.Text = "Ödəniş Bilgiləri";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtAciklama);
            this.panel4.Controls.Add(this.lblAciklama);
            this.panel4.Controls.Add(this.lblEsasBorcOdenisi);
            this.panel4.Controls.Add(this.lblEsasBorcOdenisiLabel);
            this.panel4.Controls.Add(this.lblFaizOdenisi);
            this.panel4.Controls.Add(this.lblFaizOdenisiLabel);
            this.panel4.Controls.Add(this.lblOdenisBreakdown);
            this.panel4.Location = new System.Drawing.Point(20, 460);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(660, 120);
            this.panel4.TabIndex = 3;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAciklama.Location = new System.Drawing.Point(100, 82);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(530, 25);
            this.txtAciklama.TabIndex = 6;
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAciklama.Location = new System.Drawing.Point(20, 85);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(67, 19);
            this.lblAciklama.TabIndex = 5;
            this.lblAciklama.Text = "Açıqlama:";
            // 
            // lblEsasBorcOdenisi
            // 
            this.lblEsasBorcOdenisi.AutoSize = true;
            this.lblEsasBorcOdenisi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEsasBorcOdenisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblEsasBorcOdenisi.Location = new System.Drawing.Point(330, 55);
            this.lblEsasBorcOdenisi.Name = "lblEsasBorcOdenisi";
            this.lblEsasBorcOdenisi.Size = new System.Drawing.Size(33, 19);
            this.lblEsasBorcOdenisi.TabIndex = 4;
            this.lblEsasBorcOdenisi.Text = "0 ₼";
            // 
            // lblEsasBorcOdenisiLabel
            // 
            this.lblEsasBorcOdenisiLabel.AutoSize = true;
            this.lblEsasBorcOdenisiLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEsasBorcOdenisiLabel.Location = new System.Drawing.Point(200, 55);
            this.lblEsasBorcOdenisiLabel.Name = "lblEsasBorcOdenisiLabel";
            this.lblEsasBorcOdenisiLabel.Size = new System.Drawing.Size(119, 19);
            this.lblEsasBorcOdenisiLabel.TabIndex = 3;
            this.lblEsasBorcOdenisiLabel.Text = "Əsas Borc Ödəniş:";
            // 
            // lblFaizOdenisi
            // 
            this.lblFaizOdenisi.AutoSize = true;
            this.lblFaizOdenisi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizOdenisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblFaizOdenisi.Location = new System.Drawing.Point(120, 55);
            this.lblFaizOdenisi.Name = "lblFaizOdenisi";
            this.lblFaizOdenisi.Size = new System.Drawing.Size(33, 19);
            this.lblFaizOdenisi.TabIndex = 2;
            this.lblFaizOdenisi.Text = "0 ₼";
            // 
            // lblFaizOdenisiLabel
            // 
            this.lblFaizOdenisiLabel.AutoSize = true;
            this.lblFaizOdenisiLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFaizOdenisiLabel.Location = new System.Drawing.Point(20, 55);
            this.lblFaizOdenisiLabel.Name = "lblFaizOdenisiLabel";
            this.lblFaizOdenisiLabel.Size = new System.Drawing.Size(85, 19);
            this.lblFaizOdenisiLabel.TabIndex = 1;
            this.lblFaizOdenisiLabel.Text = "Faiz Ödənişi:";
            // 
            // lblOdenisBreakdown
            // 
            this.lblOdenisBreakdown.AutoSize = true;
            this.lblOdenisBreakdown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOdenisBreakdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOdenisBreakdown.Location = new System.Drawing.Point(15, 15);
            this.lblOdenisBreakdown.Name = "lblOdenisBreakdown";
            this.lblOdenisBreakdown.Size = new System.Drawing.Size(151, 25);
            this.lblOdenisBreakdown.TabIndex = 0;
            this.lblOdenisBreakdown.Text = "Ödəniş Bölgüsü";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(401, 600);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "💾 Yadda Saxla";
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
            this.btnCancel.Location = new System.Drawing.Point(573, 600);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "❌ Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BorcPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(700, 660);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorcPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Borc Ödənişi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKomissiya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOdenisMeblegi)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUmumiBorc;
        private System.Windows.Forms.Label lblUmumiBorcLabel;
        private System.Windows.Forms.Label lblFaizMeblegi;
        private System.Windows.Forms.Label lblFaizMeblegLabel;
        private System.Windows.Forms.Label lblQalanBorc;
        private System.Windows.Forms.Label lblQalanBorcLabel;
        private System.Windows.Forms.Label lblOdenilmisMebleg;
        private System.Windows.Forms.Label lblOdenilmisMeblegLabel;
        private System.Windows.Forms.Label lblBorcMeblegi;
        private System.Windows.Forms.Label lblBorcMeblegLabel;
        private System.Windows.Forms.Label lblMusteriAdi;
        private System.Windows.Forms.Label lblMusteriAdiLabel;
        private System.Windows.Forms.Label lblBorcNomresi;
        private System.Windows.Forms.Label lblBorcNomresiLabel;
        private System.Windows.Forms.Label lblBorcBilgileri;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numKomissiya;
        private System.Windows.Forms.Label lblKomissiya;
        private System.Windows.Forms.TextBox txtOdenisDetali;
        private System.Windows.Forms.Label lblOdenisDetali;
        private System.Windows.Forms.ComboBox cmbOdenisTipi;
        private System.Windows.Forms.Label lblOdenisTipi;
        private System.Windows.Forms.NumericUpDown numOdenisMeblegi;
        private System.Windows.Forms.Label lblOdenisMeblegi;
        private System.Windows.Forms.DateTimePicker dtpOdenisTarixi;
        private System.Windows.Forms.Label lblOdenisTarixi;
        private System.Windows.Forms.Label lblOdenisBilgileri;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.Label lblEsasBorcOdenisi;
        private System.Windows.Forms.Label lblEsasBorcOdenisiLabel;
        private System.Windows.Forms.Label lblFaizOdenisi;
        private System.Windows.Forms.Label lblFaizOdenisiLabel;
        private System.Windows.Forms.Label lblOdenisBreakdown;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}