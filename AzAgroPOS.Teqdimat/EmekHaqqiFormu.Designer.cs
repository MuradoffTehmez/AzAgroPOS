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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblBasliq = new MaterialSkin.Controls.MaterialLabel();
            panelForm = new Panel();
            lblIsci = new MaterialSkin.Controls.MaterialLabel();
            cmbIsci = new ComboBox();
            lblDovr = new MaterialSkin.Controls.MaterialLabel();
            dtpDovr = new DateTimePicker();
            lblElaveOdenisler = new MaterialSkin.Controls.MaterialLabel();
            numElaveOdenisler = new NumericUpDown();
            lblDigerTutulmalar = new MaterialSkin.Controls.MaterialLabel();
            numDigerTutulmalar = new NumericUpDown();
            lblQeyd = new MaterialSkin.Controls.MaterialLabel();
            txtQeyd = new MaterialSkin.Controls.MaterialTextBox();
            lblSonMaas = new MaterialSkin.Controls.MaterialLabel();
            btnHesabla = new MaterialSkin.Controls.MaterialButton();
            panelGrid = new Panel();
            dgvEmekHaqqlari = new DataGridView();
            panelButtons = new Panel();
            btnOde = new MaterialSkin.Controls.MaterialButton();
            btnLegvEt = new MaterialSkin.Controls.MaterialButton();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            panelTop.SuspendLayout();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numElaveOdenisler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDigerTutulmalar).BeginInit();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmekHaqqlari).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(242, 242, 242);
            panelTop.Controls.Add(lblBasliq);
            panelTop.Dock = DockStyle.Top;
            panelTop.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelTop.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelTop.Location = new Point(4, 74);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1392, 69);
            panelTop.TabIndex = 0;
            // 
            // lblBasliq
            // 
            lblBasliq.AutoSize = true;
            lblBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblBasliq.Depth = 0;
            lblBasliq.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBasliq.Location = new Point(23, 17);
            lblBasliq.Margin = new Padding(4, 0, 4, 0);
            lblBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblBasliq.Name = "lblBasliq";
            lblBasliq.Size = new Size(268, 29);
            lblBasliq.TabIndex = 0;
            lblBasliq.Text = "Əmək Haqqı İdarəetməsi";
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.FromArgb(242, 242, 242);
            panelForm.Controls.Add(lblIsci);
            panelForm.Controls.Add(cmbIsci);
            panelForm.Controls.Add(lblDovr);
            panelForm.Controls.Add(dtpDovr);
            panelForm.Controls.Add(lblElaveOdenisler);
            panelForm.Controls.Add(numElaveOdenisler);
            panelForm.Controls.Add(lblDigerTutulmalar);
            panelForm.Controls.Add(numDigerTutulmalar);
            panelForm.Controls.Add(lblQeyd);
            panelForm.Controls.Add(txtQeyd);
            panelForm.Controls.Add(lblSonMaas);
            panelForm.Controls.Add(btnHesabla);
            panelForm.Dock = DockStyle.Top;
            panelForm.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelForm.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelForm.Location = new Point(4, 143);
            panelForm.Margin = new Padding(4, 3, 4, 3);
            panelForm.Name = "panelForm";
            panelForm.Padding = new Padding(23);
            panelForm.Size = new Size(1392, 288);
            panelForm.TabIndex = 1;
            // 
            // lblIsci
            // 
            lblIsci.AutoSize = true;
            lblIsci.BackColor = Color.FromArgb(242, 242, 242);
            lblIsci.Depth = 0;
            lblIsci.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblIsci.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblIsci.Location = new Point(23, 23);
            lblIsci.Margin = new Padding(4, 0, 4, 0);
            lblIsci.MouseState = MaterialSkin.MouseState.HOVER;
            lblIsci.Name = "lblIsci";
            lblIsci.Size = new Size(29, 19);
            lblIsci.TabIndex = 0;
            lblIsci.Text = "İşçi:";
            // 
            // cmbIsci
            // 
            cmbIsci.BackColor = Color.FromArgb(242, 242, 242);
            cmbIsci.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIsci.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbIsci.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbIsci.FormattingEnabled = true;
            cmbIsci.Location = new Point(23, 52);
            cmbIsci.Margin = new Padding(4, 3, 4, 3);
            cmbIsci.Name = "cmbIsci";
            cmbIsci.Size = new Size(349, 25);
            cmbIsci.TabIndex = 1;
            cmbIsci.SelectedIndexChanged += cmbIsci_SelectedIndexChanged;
            // 
            // lblDovr
            // 
            lblDovr.AutoSize = true;
            lblDovr.BackColor = Color.FromArgb(242, 242, 242);
            lblDovr.Depth = 0;
            lblDovr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDovr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDovr.Location = new Point(397, 23);
            lblDovr.Margin = new Padding(4, 0, 4, 0);
            lblDovr.MouseState = MaterialSkin.MouseState.HOVER;
            lblDovr.Name = "lblDovr";
            lblDovr.Size = new Size(38, 19);
            lblDovr.TabIndex = 2;
            lblDovr.Text = "Dövr:";
            // 
            // dtpDovr
            // 
            dtpDovr.BackColor = Color.FromArgb(242, 242, 242);
            dtpDovr.CustomFormat = "MMMM yyyy";
            dtpDovr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpDovr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpDovr.Format = DateTimePickerFormat.Custom;
            dtpDovr.Location = new Point(397, 52);
            dtpDovr.Margin = new Padding(4, 3, 4, 3);
            dtpDovr.Name = "dtpDovr";
            dtpDovr.Size = new Size(233, 24);
            dtpDovr.TabIndex = 3;
            // 
            // lblElaveOdenisler
            // 
            lblElaveOdenisler.AutoSize = true;
            lblElaveOdenisler.BackColor = Color.FromArgb(242, 242, 242);
            lblElaveOdenisler.Depth = 0;
            lblElaveOdenisler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblElaveOdenisler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblElaveOdenisler.Location = new Point(653, 23);
            lblElaveOdenisler.Margin = new Padding(4, 0, 4, 0);
            lblElaveOdenisler.MouseState = MaterialSkin.MouseState.HOVER;
            lblElaveOdenisler.Name = "lblElaveOdenisler";
            lblElaveOdenisler.Size = new Size(115, 19);
            lblElaveOdenisler.TabIndex = 4;
            lblElaveOdenisler.Text = "Əlavə Ödənişlər:";
            // 
            // numElaveOdenisler
            // 
            numElaveOdenisler.BackColor = Color.FromArgb(242, 242, 242);
            numElaveOdenisler.DecimalPlaces = 2;
            numElaveOdenisler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numElaveOdenisler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numElaveOdenisler.Location = new Point(653, 52);
            numElaveOdenisler.Margin = new Padding(4, 3, 4, 3);
            numElaveOdenisler.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numElaveOdenisler.Name = "numElaveOdenisler";
            numElaveOdenisler.Size = new Size(175, 24);
            numElaveOdenisler.TabIndex = 5;
            // 
            // lblDigerTutulmalar
            // 
            lblDigerTutulmalar.AutoSize = true;
            lblDigerTutulmalar.BackColor = Color.FromArgb(242, 242, 242);
            lblDigerTutulmalar.Depth = 0;
            lblDigerTutulmalar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDigerTutulmalar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDigerTutulmalar.Location = new Point(852, 23);
            lblDigerTutulmalar.Margin = new Padding(4, 0, 4, 0);
            lblDigerTutulmalar.MouseState = MaterialSkin.MouseState.HOVER;
            lblDigerTutulmalar.Name = "lblDigerTutulmalar";
            lblDigerTutulmalar.Size = new Size(124, 19);
            lblDigerTutulmalar.TabIndex = 6;
            lblDigerTutulmalar.Text = "Digər Tutulmalar:";
            // 
            // numDigerTutulmalar
            // 
            numDigerTutulmalar.BackColor = Color.FromArgb(242, 242, 242);
            numDigerTutulmalar.DecimalPlaces = 2;
            numDigerTutulmalar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numDigerTutulmalar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numDigerTutulmalar.Location = new Point(852, 52);
            numDigerTutulmalar.Margin = new Padding(4, 3, 4, 3);
            numDigerTutulmalar.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numDigerTutulmalar.Name = "numDigerTutulmalar";
            numDigerTutulmalar.Size = new Size(175, 24);
            numDigerTutulmalar.TabIndex = 7;
            // 
            // lblQeyd
            // 
            lblQeyd.AutoSize = true;
            lblQeyd.BackColor = Color.FromArgb(242, 242, 242);
            lblQeyd.Depth = 0;
            lblQeyd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQeyd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblQeyd.Location = new Point(23, 104);
            lblQeyd.Margin = new Padding(4, 0, 4, 0);
            lblQeyd.MouseState = MaterialSkin.MouseState.HOVER;
            lblQeyd.Name = "lblQeyd";
            lblQeyd.Size = new Size(41, 19);
            lblQeyd.TabIndex = 8;
            lblQeyd.Text = "Qeyd:";
            // 
            // txtQeyd
            // 
            txtQeyd.AnimateReadOnly = false;
            txtQeyd.BackColor = Color.FromArgb(242, 242, 242);
            txtQeyd.BorderStyle = BorderStyle.FixedSingle;
            txtQeyd.Depth = 0;
            txtQeyd.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeyd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtQeyd.Hint = "Əmək haqqı ilə bağlı əlavə qeydlər...";
            txtQeyd.LeadingIcon = null;
            txtQeyd.Location = new Point(23, 133);
            txtQeyd.Margin = new Padding(4, 3, 4, 3);
            txtQeyd.MaxLength = 500;
            txtQeyd.MouseState = MaterialSkin.MouseState.OUT;
            txtQeyd.Multiline = false;
            txtQeyd.Name = "txtQeyd";
            txtQeyd.Size = new Size(1003, 50);
            txtQeyd.TabIndex = 9;
            txtQeyd.Text = "";
            txtQeyd.TrailingIcon = null;
            // 
            // lblSonMaas
            // 
            lblSonMaas.AutoSize = true;
            lblSonMaas.BackColor = Color.FromArgb(242, 242, 242);
            lblSonMaas.Depth = 0;
            lblSonMaas.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSonMaas.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            lblSonMaas.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSonMaas.Location = new Point(23, 208);
            lblSonMaas.Margin = new Padding(4, 0, 4, 0);
            lblSonMaas.MouseState = MaterialSkin.MouseState.HOVER;
            lblSonMaas.Name = "lblSonMaas";
            lblSonMaas.Size = new Size(85, 17);
            lblSonMaas.TabIndex = 10;
            lblSonMaas.Text = "Son Maaş: ---";
            // 
            // btnHesabla
            // 
            btnHesabla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHesabla.BackColor = Color.FromArgb(242, 242, 242);
            btnHesabla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnHesabla.Depth = 0;
            btnHesabla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnHesabla.HighEmphasis = true;
            btnHesabla.Icon = null;
            btnHesabla.Location = new Point(1050, 133);
            btnHesabla.Margin = new Padding(5, 7, 5, 7);
            btnHesabla.MouseState = MaterialSkin.MouseState.HOVER;
            btnHesabla.Name = "btnHesabla";
            btnHesabla.NoAccentTextColor = Color.Empty;
            btnHesabla.Size = new Size(86, 36);
            btnHesabla.TabIndex = 11;
            btnHesabla.Text = "HESABLA";
            btnHesabla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnHesabla.UseAccentColor = false;
            btnHesabla.UseVisualStyleBackColor = false;
            btnHesabla.Click += btnHesabla_Click;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.FromArgb(242, 242, 242);
            panelGrid.Controls.Add(dgvEmekHaqqlari);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelGrid.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelGrid.Location = new Point(4, 431);
            panelGrid.Margin = new Padding(4, 3, 4, 3);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(23, 12, 23, 12);
            panelGrid.Size = new Size(1392, 294);
            panelGrid.TabIndex = 2;
            // 
            // dgvEmekHaqqlari
            // 
            dgvEmekHaqqlari.AllowUserToAddRows = false;
            dgvEmekHaqqlari.AllowUserToDeleteRows = false;
            dgvEmekHaqqlari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmekHaqqlari.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmekHaqqlari.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmekHaqqlari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmekHaqqlari.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmekHaqqlari.Dock = DockStyle.Fill;
            dgvEmekHaqqlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvEmekHaqqlari.Location = new Point(23, 12);
            dgvEmekHaqqlari.Margin = new Padding(4, 3, 4, 3);
            dgvEmekHaqqlari.MultiSelect = false;
            dgvEmekHaqqlari.Name = "dgvEmekHaqqlari";
            dgvEmekHaqqlari.ReadOnly = true;
            dgvEmekHaqqlari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmekHaqqlari.Size = new Size(1346, 270);
            dgvEmekHaqqlari.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(242, 242, 242);
            panelButtons.Controls.Add(btnOde);
            panelButtons.Controls.Add(btnLegvEt);
            panelButtons.Controls.Add(btnYenile);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelButtons.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelButtons.Location = new Point(4, 725);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(23, 12, 23, 12);
            panelButtons.Size = new Size(1392, 69);
            panelButtons.TabIndex = 3;
            // 
            // btnOde
            // 
            btnOde.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOde.BackColor = Color.FromArgb(242, 242, 242);
            btnOde.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOde.Depth = 0;
            btnOde.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnOde.HighEmphasis = true;
            btnOde.Icon = null;
            btnOde.Location = new Point(23, 14);
            btnOde.Margin = new Padding(5, 7, 5, 7);
            btnOde.MouseState = MaterialSkin.MouseState.HOVER;
            btnOde.Name = "btnOde";
            btnOde.NoAccentTextColor = Color.Empty;
            btnOde.Size = new Size(64, 36);
            btnOde.TabIndex = 0;
            btnOde.Text = "ÖDƏ";
            btnOde.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOde.UseAccentColor = true;
            btnOde.UseVisualStyleBackColor = false;
            btnOde.Click += btnOde_Click;
            // 
            // btnLegvEt
            // 
            btnLegvEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLegvEt.BackColor = Color.FromArgb(242, 242, 242);
            btnLegvEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLegvEt.Depth = 0;
            btnLegvEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnLegvEt.HighEmphasis = false;
            btnLegvEt.Icon = null;
            btnLegvEt.Location = new Point(187, 14);
            btnLegvEt.Margin = new Padding(5, 7, 5, 7);
            btnLegvEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnLegvEt.Name = "btnLegvEt";
            btnLegvEt.NoAccentTextColor = Color.Empty;
            btnLegvEt.Size = new Size(80, 36);
            btnLegvEt.TabIndex = 1;
            btnLegvEt.Text = "LƏĞV ET";
            btnLegvEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnLegvEt.UseAccentColor = false;
            btnLegvEt.UseVisualStyleBackColor = false;
            btnLegvEt.Click += btnLegvEt_Click;
            // 
            // btnYenile
            // 
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = false;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(1237, 14);
            btnYenile.Margin = new Padding(5, 7, 5, 7);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(72, 36);
            btnYenile.TabIndex = 2;
            btnYenile.Text = "YENİLƏ";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // EmekHaqqiFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 819);
            Controls.Add(panelGrid);
            Controls.Add(panelButtons);
            Controls.Add(panelForm);
            Controls.Add(panelTop);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EmekHaqqiFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Əmək Haqqı İdarəetməsi";
            Controls.SetChildIndex(panelTop, 0);
            Controls.SetChildIndex(panelForm, 0);
            Controls.SetChildIndex(panelButtons, 0);
            Controls.SetChildIndex(panelGrid, 0);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numElaveOdenisler).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDigerTutulmalar).EndInit();
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmekHaqqlari).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
