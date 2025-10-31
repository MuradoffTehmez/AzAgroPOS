// Fayl: AzAgroPOS.Teqdimat/TedarukcuOdemeFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class TedarukcuOdemeFormu
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBasliq = new MaterialSkin.Controls.MaterialLabel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.txtBankMelumatlari = new MaterialSkin.Controls.MaterialTextBox();
            this.lblBankMelumatlari = new MaterialSkin.Controls.MaterialLabel();
            this.txtQeydler = new MaterialSkin.Controls.MaterialTextBox();
            this.lblQeydler = new MaterialSkin.Controls.MaterialLabel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new MaterialSkin.Controls.MaterialLabel();
            this.cmbOdemeUsulu = new System.Windows.Forms.ComboBox();
            this.lblOdemeUsulu = new MaterialSkin.Controls.MaterialLabel();
            this.numMebleg = new System.Windows.Forms.NumericUpDown();
            this.lblMebleg = new MaterialSkin.Controls.MaterialLabel();
            this.dtpOdemeTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblOdemeTarixi = new MaterialSkin.Controls.MaterialLabel();
            this.cmbAlisSened = new System.Windows.Forms.ComboBox();
            this.lblAlisSened = new MaterialSkin.Controls.MaterialLabel();
            this.cmbTedarukcu = new System.Windows.Forms.ComboBox();
            this.lblTedarukcu = new MaterialSkin.Controls.MaterialLabel();
            this.dtpYaradilmaTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblYaradilmaTarixi = new MaterialSkin.Controls.MaterialLabel();
            this.txtOdemeNomresi = new MaterialSkin.Controls.MaterialTextBox();
            this.lblOdemeNomresi = new MaterialSkin.Controls.MaterialLabel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvOdemeler = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnTemizle = new MaterialSkin.Controls.MaterialButton();
            this.btnSil = new MaterialSkin.Controls.MaterialButton();
            this.btnYenile = new MaterialSkin.Controls.MaterialButton();
            this.btnYarat = new MaterialSkin.Controls.MaterialButton();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMebleg)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdemeler)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelTop.Controls.Add(this.lblBasliq);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 64);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1194, 60);
            this.panelTop.TabIndex = 0;
            //
            // lblBasliq
            //
            this.lblBasliq.AutoSize = true;
            this.lblBasliq.Depth = 0;
            this.lblBasliq.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblBasliq.ForeColor = System.Drawing.Color.White;
            this.lblBasliq.Location = new System.Drawing.Point(15, 15);
            this.lblBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBasliq.Name = "lblBasliq";
            this.lblBasliq.Size = new System.Drawing.Size(275, 29);
            this.lblBasliq.TabIndex = 0;
            this.lblBasliq.Text = "Tədarükçü Ödənişləri";
            //
            // panelForm
            //
            this.panelForm.Controls.Add(this.txtBankMelumatlari);
            this.panelForm.Controls.Add(this.lblBankMelumatlari);
            this.panelForm.Controls.Add(this.txtQeydler);
            this.panelForm.Controls.Add(this.lblQeydler);
            this.panelForm.Controls.Add(this.cmbStatus);
            this.panelForm.Controls.Add(this.lblStatus);
            this.panelForm.Controls.Add(this.cmbOdemeUsulu);
            this.panelForm.Controls.Add(this.lblOdemeUsulu);
            this.panelForm.Controls.Add(this.numMebleg);
            this.panelForm.Controls.Add(this.lblMebleg);
            this.panelForm.Controls.Add(this.dtpOdemeTarixi);
            this.panelForm.Controls.Add(this.lblOdemeTarixi);
            this.panelForm.Controls.Add(this.cmbAlisSened);
            this.panelForm.Controls.Add(this.lblAlisSened);
            this.panelForm.Controls.Add(this.cmbTedarukcu);
            this.panelForm.Controls.Add(this.lblTedarukcu);
            this.panelForm.Controls.Add(this.dtpYaradilmaTarixi);
            this.panelForm.Controls.Add(this.lblYaradilmaTarixi);
            this.panelForm.Controls.Add(this.txtOdemeNomresi);
            this.panelForm.Controls.Add(this.lblOdemeNomresi);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(3, 124);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(10);
            this.panelForm.Size = new System.Drawing.Size(1194, 280);
            this.panelForm.TabIndex = 1;
            //
            // txtBankMelumatlari
            //
            this.txtBankMelumatlari.AnimateReadOnly = false;
            this.txtBankMelumatlari.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBankMelumatlari.Depth = 0;
            this.txtBankMelumatlari.Enabled = false;
            this.txtBankMelumatlari.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBankMelumatlari.LeadingIcon = null;
            this.txtBankMelumatlari.Location = new System.Drawing.Point(630, 220);
            this.txtBankMelumatlari.MaxLength = 500;
            this.txtBankMelumatlari.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBankMelumatlari.Multiline = false;
            this.txtBankMelumatlari.Name = "txtBankMelumatlari";
            this.txtBankMelumatlari.Size = new System.Drawing.Size(550, 50);
            this.txtBankMelumatlari.TabIndex = 19;
            this.txtBankMelumatlari.Text = "";
            this.txtBankMelumatlari.TrailingIcon = null;
            //
            // lblBankMelumatlari
            //
            this.lblBankMelumatlari.AutoSize = true;
            this.lblBankMelumatlari.Depth = 0;
            this.lblBankMelumatlari.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBankMelumatlari.Location = new System.Drawing.Point(630, 195);
            this.lblBankMelumatlari.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBankMelumatlari.Name = "lblBankMelumatlari";
            this.lblBankMelumatlari.Size = new System.Drawing.Size(132, 19);
            this.lblBankMelumatlari.TabIndex = 18;
            this.lblBankMelumatlari.Text = "Bank Məlumatları:";
            //
            // txtQeydler
            //
            this.txtQeydler.AnimateReadOnly = false;
            this.txtQeydler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQeydler.Depth = 0;
            this.txtQeydler.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtQeydler.LeadingIcon = null;
            this.txtQeydler.Location = new System.Drawing.Point(15, 220);
            this.txtQeydler.MaxLength = 500;
            this.txtQeydler.MouseState = MaterialSkin.MouseState.OUT;
            this.txtQeydler.Multiline = false;
            this.txtQeydler.Name = "txtQeydler";
            this.txtQeydler.Size = new System.Drawing.Size(600, 50);
            this.txtQeydler.TabIndex = 17;
            this.txtQeydler.Text = "";
            this.txtQeydler.TrailingIcon = null;
            //
            // lblQeydler
            //
            this.lblQeydler.AutoSize = true;
            this.lblQeydler.Depth = 0;
            this.lblQeydler.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblQeydler.Location = new System.Drawing.Point(15, 195);
            this.lblQeydler.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblQeydler.Name = "lblQeydler";
            this.lblQeydler.Size = new System.Drawing.Size(67, 19);
            this.lblQeydler.TabIndex = 16;
            this.lblQeydler.Text = "Qeydlər:";
            //
            // cmbStatus
            //
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(880, 150);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 29);
            this.cmbStatus.TabIndex = 15;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.Location = new System.Drawing.Point(880, 125);
            this.lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 19);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status:";
            //
            // cmbOdemeUsulu
            //
            this.cmbOdemeUsulu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeUsulu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbOdemeUsulu.FormattingEnabled = true;
            this.cmbOdemeUsulu.Location = new System.Drawing.Point(445, 150);
            this.cmbOdemeUsulu.Name = "cmbOdemeUsulu";
            this.cmbOdemeUsulu.Size = new System.Drawing.Size(420, 29);
            this.cmbOdemeUsulu.TabIndex = 13;
            this.cmbOdemeUsulu.SelectedIndexChanged += new System.EventHandler(this.cmbOdemeUsulu_SelectedIndexChanged);
            //
            // lblOdemeUsulu
            //
            this.lblOdemeUsulu.AutoSize = true;
            this.lblOdemeUsulu.Depth = 0;
            this.lblOdemeUsulu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOdemeUsulu.Location = new System.Drawing.Point(445, 125);
            this.lblOdemeUsulu.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOdemeUsulu.Name = "lblOdemeUsulu";
            this.lblOdemeUsulu.Size = new System.Drawing.Size(112, 19);
            this.lblOdemeUsulu.TabIndex = 12;
            this.lblOdemeUsulu.Text = "Ödəniş Üsulu:";
            //
            // numMebleg
            //
            this.numMebleg.DecimalPlaces = 2;
            this.numMebleg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numMebleg.Location = new System.Drawing.Point(15, 150);
            this.numMebleg.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMebleg.Name = "numMebleg";
            this.numMebleg.Size = new System.Drawing.Size(415, 29);
            this.numMebleg.TabIndex = 11;
            this.numMebleg.ThousandsSeparator = true;
            //
            // lblMebleg
            //
            this.lblMebleg.AutoSize = true;
            this.lblMebleg.Depth = 0;
            this.lblMebleg.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMebleg.Location = new System.Drawing.Point(15, 125);
            this.lblMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMebleg.Name = "lblMebleg";
            this.lblMebleg.Size = new System.Drawing.Size(64, 19);
            this.lblMebleg.TabIndex = 10;
            this.lblMebleg.Text = "Məbləğ:";
            //
            // dtpOdemeTarixi
            //
            this.dtpOdemeTarixi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpOdemeTarixi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOdemeTarixi.Location = new System.Drawing.Point(880, 80);
            this.dtpOdemeTarixi.Name = "dtpOdemeTarixi";
            this.dtpOdemeTarixi.Size = new System.Drawing.Size(300, 29);
            this.dtpOdemeTarixi.TabIndex = 9;
            //
            // lblOdemeTarixi
            //
            this.lblOdemeTarixi.AutoSize = true;
            this.lblOdemeTarixi.Depth = 0;
            this.lblOdemeTarixi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOdemeTarixi.Location = new System.Drawing.Point(880, 55);
            this.lblOdemeTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOdemeTarixi.Name = "lblOdemeTarixi";
            this.lblOdemeTarixi.Size = new System.Drawing.Size(116, 19);
            this.lblOdemeTarixi.TabIndex = 8;
            this.lblOdemeTarixi.Text = "Ödəniş Tarixi:";
            //
            // cmbAlisSened
            //
            this.cmbAlisSened.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlisSened.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbAlisSened.FormattingEnabled = true;
            this.cmbAlisSened.Location = new System.Drawing.Point(445, 80);
            this.cmbAlisSened.Name = "cmbAlisSened";
            this.cmbAlisSened.Size = new System.Drawing.Size(420, 29);
            this.cmbAlisSened.TabIndex = 7;
            //
            // lblAlisSened
            //
            this.lblAlisSened.AutoSize = true;
            this.lblAlisSened.Depth = 0;
            this.lblAlisSened.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAlisSened.Location = new System.Drawing.Point(445, 55);
            this.lblAlisSened.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAlisSened.Name = "lblAlisSened";
            this.lblAlisSened.Size = new System.Drawing.Size(142, 19);
            this.lblAlisSened.TabIndex = 6;
            this.lblAlisSened.Text = "Alış Sənədi (İxtiyari):";
            //
            // cmbTedarukcu
            //
            this.cmbTedarukcu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTedarukcu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbTedarukcu.FormattingEnabled = true;
            this.cmbTedarukcu.Location = new System.Drawing.Point(15, 80);
            this.cmbTedarukcu.Name = "cmbTedarukcu";
            this.cmbTedarukcu.Size = new System.Drawing.Size(415, 29);
            this.cmbTedarukcu.TabIndex = 5;
            //
            // lblTedarukcu
            //
            this.lblTedarukcu.AutoSize = true;
            this.lblTedarukcu.Depth = 0;
            this.lblTedarukcu.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTedarukcu.Location = new System.Drawing.Point(15, 55);
            this.lblTedarukcu.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTedarukcu.Name = "lblTedarukcu";
            this.lblTedarukcu.Size = new System.Drawing.Size(85, 19);
            this.lblTedarukcu.TabIndex = 4;
            this.lblTedarukcu.Text = "Tədarükçü:";
            //
            // dtpYaradilmaTarixi
            //
            this.dtpYaradilmaTarixi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpYaradilmaTarixi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpYaradilmaTarixi.Location = new System.Drawing.Point(630, 15);
            this.dtpYaradilmaTarixi.Name = "dtpYaradilmaTarixi";
            this.dtpYaradilmaTarixi.Size = new System.Drawing.Size(550, 29);
            this.dtpYaradilmaTarixi.TabIndex = 3;
            //
            // lblYaradilmaTarixi
            //
            this.lblYaradilmaTarixi.AutoSize = true;
            this.lblYaradilmaTarixi.Depth = 0;
            this.lblYaradilmaTarixi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblYaradilmaTarixi.Location = new System.Drawing.Point(490, 20);
            this.lblYaradilmaTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblYaradilmaTarixi.Name = "lblYaradilmaTarixi";
            this.lblYaradilmaTarixi.Size = new System.Drawing.Size(133, 19);
            this.lblYaradilmaTarixi.TabIndex = 2;
            this.lblYaradilmaTarixi.Text = "Yaradılma Tarixi:";
            //
            // txtOdemeNomresi
            //
            this.txtOdemeNomresi.AnimateReadOnly = false;
            this.txtOdemeNomresi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOdemeNomresi.Depth = 0;
            this.txtOdemeNomresi.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOdemeNomresi.LeadingIcon = null;
            this.txtOdemeNomresi.Location = new System.Drawing.Point(15, 15);
            this.txtOdemeNomresi.MaxLength = 50;
            this.txtOdemeNomresi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOdemeNomresi.Multiline = false;
            this.txtOdemeNomresi.Name = "txtOdemeNomresi";
            this.txtOdemeNomresi.Size = new System.Drawing.Size(415, 36);
            this.txtOdemeNomresi.TabIndex = 1;
            this.txtOdemeNomresi.Text = "";
            this.txtOdemeNomresi.TrailingIcon = null;
            //
            // lblOdemeNomresi
            //
            this.lblOdemeNomresi.AutoSize = true;
            this.lblOdemeNomresi.Depth = 0;
            this.lblOdemeNomresi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOdemeNomresi.Location = new System.Drawing.Point(15, -5);
            this.lblOdemeNomresi.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOdemeNomresi.Name = "lblOdemeNomresi";
            this.lblOdemeNomresi.Size = new System.Drawing.Size(123, 19);
            this.lblOdemeNomresi.TabIndex = 0;
            this.lblOdemeNomresi.Text = "Ödəniş Nömrəsi:";
            //
            // panelGrid
            //
            this.panelGrid.Controls.Add(this.dgvOdemeler);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(3, 404);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(10);
            this.panelGrid.Size = new System.Drawing.Size(1194, 283);
            this.panelGrid.TabIndex = 2;
            //
            // dgvOdemeler
            //
            this.dgvOdemeler.AllowUserToAddRows = false;
            this.dgvOdemeler.AllowUserToDeleteRows = false;
            this.dgvOdemeler.BackgroundColor = System.Drawing.Color.White;
            this.dgvOdemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOdemeler.Location = new System.Drawing.Point(10, 10);
            this.dgvOdemeler.MultiSelect = false;
            this.dgvOdemeler.Name = "dgvOdemeler";
            this.dgvOdemeler.ReadOnly = true;
            this.dgvOdemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOdemeler.Size = new System.Drawing.Size(1174, 263);
            this.dgvOdemeler.TabIndex = 0;
            this.dgvOdemeler.SelectionChanged += new System.EventHandler(this.dgvOdemeler_SelectionChanged);
            //
            // panelButtons
            //
            this.panelButtons.Controls.Add(this.btnTemizle);
            this.panelButtons.Controls.Add(this.btnSil);
            this.panelButtons.Controls.Add(this.btnYenile);
            this.panelButtons.Controls.Add(this.btnYarat);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(3, 687);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(1194, 60);
            this.panelButtons.TabIndex = 3;
            //
            // btnTemizle
            //
            this.btnTemizle.AutoSize = false;
            this.btnTemizle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTemizle.Depth = 0;
            this.btnTemizle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTemizle.HighEmphasis = true;
            this.btnTemizle.Icon = null;
            this.btnTemizle.Location = new System.Drawing.Point(1039, 10);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTemizle.Size = new System.Drawing.Size(145, 40);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "TƏMİZLƏ";
            this.btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTemizle.UseAccentColor = false;
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            //
            // btnSil
            //
            this.btnSil.AutoSize = false;
            this.btnSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSil.Depth = 0;
            this.btnSil.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSil.HighEmphasis = true;
            this.btnSil.Icon = null;
            this.btnSil.Location = new System.Drawing.Point(310, 10);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSil.Name = "btnSil";
            this.btnSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSil.Size = new System.Drawing.Size(150, 40);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "SİL";
            this.btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSil.UseAccentColor = false;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            //
            // btnYenile
            //
            this.btnYenile.AutoSize = false;
            this.btnYenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYenile.Depth = 0;
            this.btnYenile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYenile.HighEmphasis = true;
            this.btnYenile.Icon = null;
            this.btnYenile.Location = new System.Drawing.Point(160, 10);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYenile.Size = new System.Drawing.Size(150, 40);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "YENİLƏ";
            this.btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYenile.UseAccentColor = false;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            //
            // btnYarat
            //
            this.btnYarat.AutoSize = false;
            this.btnYarat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYarat.Depth = 0;
            this.btnYarat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYarat.HighEmphasis = true;
            this.btnYarat.Icon = null;
            this.btnYarat.Location = new System.Drawing.Point(10, 10);
            this.btnYarat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYarat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYarat.Name = "btnYarat";
            this.btnYarat.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYarat.Size = new System.Drawing.Size(150, 40);
            this.btnYarat.TabIndex = 0;
            this.btnYarat.Text = "YARAT";
            this.btnYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYarat.UseAccentColor = false;
            this.btnYarat.UseVisualStyleBackColor = true;
            this.btnYarat.Click += new System.EventHandler(this.btnYarat_Click);
            //
            // TedarukcuOdemeFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Name = "TedarukcuOdemeFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tədarükçü Ödənişləri";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMebleg)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdemeler)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private MaterialSkin.Controls.MaterialLabel lblBasliq;
        private System.Windows.Forms.Panel panelForm;
        private MaterialSkin.Controls.MaterialTextBox txtOdemeNomresi;
        private MaterialSkin.Controls.MaterialLabel lblOdemeNomresi;
        private System.Windows.Forms.DateTimePicker dtpYaradilmaTarixi;
        private MaterialSkin.Controls.MaterialLabel lblYaradilmaTarixi;
        private System.Windows.Forms.ComboBox cmbTedarukcu;
        private MaterialSkin.Controls.MaterialLabel lblTedarukcu;
        private System.Windows.Forms.ComboBox cmbAlisSened;
        private MaterialSkin.Controls.MaterialLabel lblAlisSened;
        private System.Windows.Forms.DateTimePicker dtpOdemeTarixi;
        private MaterialSkin.Controls.MaterialLabel lblOdemeTarixi;
        private System.Windows.Forms.NumericUpDown numMebleg;
        private MaterialSkin.Controls.MaterialLabel lblMebleg;
        private System.Windows.Forms.ComboBox cmbOdemeUsulu;
        private MaterialSkin.Controls.MaterialLabel lblOdemeUsulu;
        private System.Windows.Forms.ComboBox cmbStatus;
        private MaterialSkin.Controls.MaterialLabel lblStatus;
        private MaterialSkin.Controls.MaterialTextBox txtQeydler;
        private MaterialSkin.Controls.MaterialLabel lblQeydler;
        private MaterialSkin.Controls.MaterialTextBox txtBankMelumatlari;
        private MaterialSkin.Controls.MaterialLabel lblBankMelumatlari;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvOdemeler;
        private System.Windows.Forms.Panel panelButtons;
        private MaterialSkin.Controls.MaterialButton btnYarat;
        private MaterialSkin.Controls.MaterialButton btnYenile;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnTemizle;
    }
}
