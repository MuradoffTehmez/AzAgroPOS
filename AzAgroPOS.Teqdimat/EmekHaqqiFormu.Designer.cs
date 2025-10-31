// Fayl: AzAgroPOS.Teqdimat/EmekHaqqiFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class EmekHaqqiFormu
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBasliq = new MaterialSkin.Controls.MaterialLabel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.lblIsci = new MaterialSkin.Controls.MaterialLabel();
            this.cmbIsci = new System.Windows.Forms.ComboBox();
            this.lblDovr = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDovr = new System.Windows.Forms.DateTimePicker();
            this.lblElaveOdenisler = new MaterialSkin.Controls.MaterialLabel();
            this.numElaveOdenisler = new System.Windows.Forms.NumericUpDown();
            this.lblDigerTutulmalar = new MaterialSkin.Controls.MaterialLabel();
            this.numDigerTutulmalar = new System.Windows.Forms.NumericUpDown();
            this.lblQeyd = new MaterialSkin.Controls.MaterialLabel();
            this.txtQeyd = new MaterialSkin.Controls.MaterialTextBox();
            this.lblSonMaas = new MaterialSkin.Controls.MaterialLabel();
            this.btnHesabla = new MaterialSkin.Controls.MaterialButton();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvEmekHaqqlari = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnOde = new MaterialSkin.Controls.MaterialButton();
            this.btnLegvEt = new MaterialSkin.Controls.MaterialButton();
            this.btnYenile = new MaterialSkin.Controls.MaterialButton();
            this.panelTop.SuspendLayout();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numElaveOdenisler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigerTutulmalar)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmekHaqqlari)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelTop.Controls.Add(this.lblBasliq);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 60);
            this.panelTop.TabIndex = 0;
            //
            // lblBasliq
            //
            this.lblBasliq.AutoSize = true;
            this.lblBasliq.Depth = 0;
            this.lblBasliq.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblBasliq.ForeColor = System.Drawing.Color.White;
            this.lblBasliq.Location = new System.Drawing.Point(20, 15);
            this.lblBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBasliq.Name = "lblBasliq";
            this.lblBasliq.Size = new System.Drawing.Size(297, 29);
            this.lblBasliq.TabIndex = 0;
            this.lblBasliq.Text = "Əmək Haqqı İdarəetməsi";
            //
            // panelForm
            //
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.lblIsci);
            this.panelForm.Controls.Add(this.cmbIsci);
            this.panelForm.Controls.Add(this.lblDovr);
            this.panelForm.Controls.Add(this.dtpDovr);
            this.panelForm.Controls.Add(this.lblElaveOdenisler);
            this.panelForm.Controls.Add(this.numElaveOdenisler);
            this.panelForm.Controls.Add(this.lblDigerTutulmalar);
            this.panelForm.Controls.Add(this.numDigerTutulmalar);
            this.panelForm.Controls.Add(this.lblQeyd);
            this.panelForm.Controls.Add(this.txtQeyd);
            this.panelForm.Controls.Add(this.lblSonMaas);
            this.panelForm.Controls.Add(this.btnHesabla);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(20);
            this.panelForm.Size = new System.Drawing.Size(1200, 250);
            this.panelForm.TabIndex = 1;
            //
            // lblIsci
            //
            this.lblIsci.AutoSize = true;
            this.lblIsci.Depth = 0;
            this.lblIsci.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIsci.Location = new System.Drawing.Point(20, 20);
            this.lblIsci.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIsci.Name = "lblIsci";
            this.lblIsci.Size = new System.Drawing.Size(33, 19);
            this.lblIsci.TabIndex = 0;
            this.lblIsci.Text = "İşçi:";
            //
            // cmbIsci
            //
            this.cmbIsci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsci.Font = new System.Drawing.Font("Roboto", 11F);
            this.cmbIsci.FormattingEnabled = true;
            this.cmbIsci.Location = new System.Drawing.Point(20, 45);
            this.cmbIsci.Name = "cmbIsci";
            this.cmbIsci.Size = new System.Drawing.Size(300, 26);
            this.cmbIsci.TabIndex = 1;
            this.cmbIsci.SelectedIndexChanged += new System.EventHandler(this.cmbIsci_SelectedIndexChanged);
            //
            // lblDovr
            //
            this.lblDovr.AutoSize = true;
            this.lblDovr.Depth = 0;
            this.lblDovr.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDovr.Location = new System.Drawing.Point(340, 20);
            this.lblDovr.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDovr.Name = "lblDovr";
            this.lblDovr.Size = new System.Drawing.Size(40, 19);
            this.lblDovr.TabIndex = 2;
            this.lblDovr.Text = "Dövr:";
            //
            // dtpDovr
            //
            this.dtpDovr.CustomFormat = "MMMM yyyy";
            this.dtpDovr.Font = new System.Drawing.Font("Roboto", 11F);
            this.dtpDovr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDovr.Location = new System.Drawing.Point(340, 45);
            this.dtpDovr.Name = "dtpDovr";
            this.dtpDovr.Size = new System.Drawing.Size(200, 25);
            this.dtpDovr.TabIndex = 3;
            //
            // lblElaveOdenisler
            //
            this.lblElaveOdenisler.AutoSize = true;
            this.lblElaveOdenisler.Depth = 0;
            this.lblElaveOdenisler.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblElaveOdenisler.Location = new System.Drawing.Point(560, 20);
            this.lblElaveOdenisler.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblElaveOdenisler.Name = "lblElaveOdenisler";
            this.lblElaveOdenisler.Size = new System.Drawing.Size(123, 19);
            this.lblElaveOdenisler.TabIndex = 4;
            this.lblElaveOdenisler.Text = "Əlavə Ödənişlər:";
            //
            // numElaveOdenisler
            //
            this.numElaveOdenisler.DecimalPlaces = 2;
            this.numElaveOdenisler.Font = new System.Drawing.Font("Roboto", 11F);
            this.numElaveOdenisler.Location = new System.Drawing.Point(560, 45);
            this.numElaveOdenisler.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numElaveOdenisler.Name = "numElaveOdenisler";
            this.numElaveOdenisler.Size = new System.Drawing.Size(150, 25);
            this.numElaveOdenisler.TabIndex = 5;
            //
            // lblDigerTutulmalar
            //
            this.lblDigerTutulmalar.AutoSize = true;
            this.lblDigerTutulmalar.Depth = 0;
            this.lblDigerTutulmalar.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDigerTutulmalar.Location = new System.Drawing.Point(730, 20);
            this.lblDigerTutulmalar.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDigerTutulmalar.Name = "lblDigerTutulmalar";
            this.lblDigerTutulmalar.Size = new System.Drawing.Size(127, 19);
            this.lblDigerTutulmalar.TabIndex = 6;
            this.lblDigerTutulmalar.Text = "Digər Tutulmalar:";
            //
            // numDigerTutulmalar
            //
            this.numDigerTutulmalar.DecimalPlaces = 2;
            this.numDigerTutulmalar.Font = new System.Drawing.Font("Roboto", 11F);
            this.numDigerTutulmalar.Location = new System.Drawing.Point(730, 45);
            this.numDigerTutulmalar.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numDigerTutulmalar.Name = "numDigerTutulmalar";
            this.numDigerTutulmalar.Size = new System.Drawing.Size(150, 25);
            this.numDigerTutulmalar.TabIndex = 7;
            //
            // lblQeyd
            //
            this.lblQeyd.AutoSize = true;
            this.lblQeyd.Depth = 0;
            this.lblQeyd.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblQeyd.Location = new System.Drawing.Point(20, 90);
            this.lblQeyd.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblQeyd.Name = "lblQeyd";
            this.lblQeyd.Size = new System.Drawing.Size(41, 19);
            this.lblQeyd.TabIndex = 8;
            this.lblQeyd.Text = "Qeyd:";
            //
            // txtQeyd
            //
            this.txtQeyd.AnimateReadOnly = false;
            this.txtQeyd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQeyd.Depth = 0;
            this.txtQeyd.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtQeyd.Hint = "Əmək haqqı ilə bağlı əlavə qeydlər...";
            this.txtQeyd.LeadingIcon = null;
            this.txtQeyd.Location = new System.Drawing.Point(20, 115);
            this.txtQeyd.MaxLength = 500;
            this.txtQeyd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtQeyd.Multiline = false;
            this.txtQeyd.Name = "txtQeyd";
            this.txtQeyd.Size = new System.Drawing.Size(860, 50);
            this.txtQeyd.TabIndex = 9;
            this.txtQeyd.Text = "";
            this.txtQeyd.TrailingIcon = null;
            //
            // lblSonMaas
            //
            this.lblSonMaas.AutoSize = true;
            this.lblSonMaas.Depth = 0;
            this.lblSonMaas.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSonMaas.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblSonMaas.Location = new System.Drawing.Point(20, 180);
            this.lblSonMaas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSonMaas.Name = "lblSonMaas";
            this.lblSonMaas.Size = new System.Drawing.Size(92, 17);
            this.lblSonMaas.TabIndex = 10;
            this.lblSonMaas.Text = "Son Maaş: ---";
            //
            // btnHesabla
            //
            this.btnHesabla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHesabla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHesabla.Depth = 0;
            this.btnHesabla.HighEmphasis = true;
            this.btnHesabla.Icon = null;
            this.btnHesabla.Location = new System.Drawing.Point(900, 115);
            this.btnHesabla.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHesabla.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHesabla.Name = "btnHesabla";
            this.btnHesabla.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHesabla.Size = new System.Drawing.Size(150, 36);
            this.btnHesabla.TabIndex = 11;
            this.btnHesabla.Text = "HESABLA";
            this.btnHesabla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHesabla.UseAccentColor = false;
            this.btnHesabla.UseVisualStyleBackColor = true;
            this.btnHesabla.Click += new System.EventHandler(this.btnHesabla_Click);
            //
            // panelGrid
            //
            this.panelGrid.Controls.Add(this.dgvEmekHaqqlari);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 310);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelGrid.Size = new System.Drawing.Size(1200, 340);
            this.panelGrid.TabIndex = 2;
            //
            // dgvEmekHaqqlari
            //
            this.dgvEmekHaqqlari.AllowUserToAddRows = false;
            this.dgvEmekHaqqlari.AllowUserToDeleteRows = false;
            this.dgvEmekHaqqlari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmekHaqqlari.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmekHaqqlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmekHaqqlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmekHaqqlari.Location = new System.Drawing.Point(20, 10);
            this.dgvEmekHaqqlari.MultiSelect = false;
            this.dgvEmekHaqqlari.Name = "dgvEmekHaqqlari";
            this.dgvEmekHaqqlari.ReadOnly = true;
            this.dgvEmekHaqqlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmekHaqqlari.Size = new System.Drawing.Size(1160, 320);
            this.dgvEmekHaqqlari.TabIndex = 0;
            //
            // panelButtons
            //
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.btnOde);
            this.panelButtons.Controls.Add(this.btnLegvEt);
            this.panelButtons.Controls.Add(this.btnYenile);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 650);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelButtons.Size = new System.Drawing.Size(1200, 60);
            this.panelButtons.TabIndex = 3;
            //
            // btnOde
            //
            this.btnOde.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOde.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOde.Depth = 0;
            this.btnOde.HighEmphasis = true;
            this.btnOde.Icon = null;
            this.btnOde.Location = new System.Drawing.Point(20, 12);
            this.btnOde.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOde.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOde.Name = "btnOde";
            this.btnOde.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOde.Size = new System.Drawing.Size(120, 36);
            this.btnOde.TabIndex = 0;
            this.btnOde.Text = "ÖDƏ";
            this.btnOde.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOde.UseAccentColor = true;
            this.btnOde.UseVisualStyleBackColor = true;
            this.btnOde.Click += new System.EventHandler(this.btnOde_Click);
            //
            // btnLegvEt
            //
            this.btnLegvEt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLegvEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLegvEt.Depth = 0;
            this.btnLegvEt.HighEmphasis = false;
            this.btnLegvEt.Icon = null;
            this.btnLegvEt.Location = new System.Drawing.Point(160, 12);
            this.btnLegvEt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLegvEt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLegvEt.Name = "btnLegvEt";
            this.btnLegvEt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLegvEt.Size = new System.Drawing.Size(120, 36);
            this.btnLegvEt.TabIndex = 1;
            this.btnLegvEt.Text = "LƏĞV ET";
            this.btnLegvEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnLegvEt.UseAccentColor = false;
            this.btnLegvEt.UseVisualStyleBackColor = true;
            this.btnLegvEt.Click += new System.EventHandler(this.btnLegvEt_Click);
            //
            // btnYenile
            //
            this.btnYenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYenile.Depth = 0;
            this.btnYenile.HighEmphasis = false;
            this.btnYenile.Icon = null;
            this.btnYenile.Location = new System.Drawing.Point(1060, 12);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYenile.Size = new System.Drawing.Size(120, 36);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "YENİLƏ";
            this.btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnYenile.UseAccentColor = false;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            //
            // EmekHaqqiFormu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 710);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelTop);
            this.Name = "EmekHaqqiFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Əmək Haqqı İdarəetməsi";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numElaveOdenisler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigerTutulmalar)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmekHaqqlari)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private MaterialSkin.Controls.MaterialLabel lblBasliq;
        private System.Windows.Forms.Panel panelForm;
        private MaterialSkin.Controls.MaterialLabel lblIsci;
        private System.Windows.Forms.ComboBox cmbIsci;
        private MaterialSkin.Controls.MaterialLabel lblDovr;
        private System.Windows.Forms.DateTimePicker dtpDovr;
        private MaterialSkin.Controls.MaterialLabel lblElaveOdenisler;
        private System.Windows.Forms.NumericUpDown numElaveOdenisler;
        private MaterialSkin.Controls.MaterialLabel lblDigerTutulmalar;
        private System.Windows.Forms.NumericUpDown numDigerTutulmalar;
        private MaterialSkin.Controls.MaterialLabel lblQeyd;
        private MaterialSkin.Controls.MaterialTextBox txtQeyd;
        private MaterialSkin.Controls.MaterialLabel lblSonMaas;
        private MaterialSkin.Controls.MaterialButton btnHesabla;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvEmekHaqqlari;
        private System.Windows.Forms.Panel panelButtons;
        private MaterialSkin.Controls.MaterialButton btnOde;
        private MaterialSkin.Controls.MaterialButton btnLegvEt;
        private MaterialSkin.Controls.MaterialButton btnYenile;
    }
}
