namespace AzAgroPOS.Teqdimat
{
    partial class XercIdareetmeFormu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblXercNovu = new MaterialSkin.Controls.MaterialLabel();
            cmbXercNovu = new MaterialSkin.Controls.MaterialComboBox();
            lblXercAdi = new MaterialSkin.Controls.MaterialLabel();
            txtXercAdi = new MaterialSkin.Controls.MaterialTextBox();
            lblXercMeblegi = new MaterialSkin.Controls.MaterialLabel();
            nudXercMeblegi = new NumericUpDown();
            lblXercTarixi = new MaterialSkin.Controls.MaterialLabel();
            dtpXercTarixi = new DateTimePicker();
            lblSenedNomresi = new MaterialSkin.Controls.MaterialLabel();
            txtSenedNomresi = new MaterialSkin.Controls.MaterialTextBox();
            lblQeyd = new MaterialSkin.Controls.MaterialLabel();
            txtQeyd = new TextBox();
            btnXercElaveEt = new MaterialSkin.Controls.MaterialButton();
            btnXercYenile = new MaterialSkin.Controls.MaterialButton();
            btnXercSil = new MaterialSkin.Controls.MaterialButton();
            dgvXercler = new DataGridView();
            btnYenidenYukle = new MaterialSkin.Controls.MaterialButton();
            btnFormuSifirla = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvXercler).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblXercNovu
            // 
            lblXercNovu.AutoSize = true;
            lblXercNovu.Depth = 0;
            lblXercNovu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblXercNovu.Location = new Point(3, 0);
            lblXercNovu.MouseState = MaterialSkin.MouseState.HOVER;
            lblXercNovu.Name = "lblXercNovu";
            lblXercNovu.Size = new Size(77, 19);
            lblXercNovu.TabIndex = 0;
            lblXercNovu.Text = "Xərc Növü:";
            // 
            // cmbXercNovu
            // 
            cmbXercNovu.AutoResize = false;
            cmbXercNovu.BackColor = Color.FromArgb(255, 255, 255);
            cmbXercNovu.Depth = 0;
            cmbXercNovu.Dock = DockStyle.Fill;
            cmbXercNovu.DrawMode = DrawMode.OwnerDrawVariable;
            cmbXercNovu.DropDownHeight = 174;
            cmbXercNovu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbXercNovu.DropDownWidth = 121;
            cmbXercNovu.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbXercNovu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbXercNovu.FormattingEnabled = true;
            cmbXercNovu.IntegralHeight = false;
            cmbXercNovu.ItemHeight = 43;
            cmbXercNovu.Location = new Point(3, 22);
            cmbXercNovu.MaxDropDownItems = 4;
            cmbXercNovu.MouseState = MaterialSkin.MouseState.OUT;
            cmbXercNovu.Name = "cmbXercNovu";
            cmbXercNovu.Size = new Size(200, 49);
            cmbXercNovu.StartIndex = 0;
            cmbXercNovu.TabIndex = 1;
            // 
            // lblXercAdi
            // 
            lblXercAdi.AutoSize = true;
            lblXercAdi.Depth = 0;
            lblXercAdi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblXercAdi.Location = new Point(209, 0);
            lblXercAdi.MouseState = MaterialSkin.MouseState.HOVER;
            lblXercAdi.Name = "lblXercAdi";
            lblXercAdi.Size = new Size(65, 19);
            lblXercAdi.TabIndex = 2;
            lblXercAdi.Text = "Xərc Adı:";
            // 
            // txtXercAdi
            // 
            txtXercAdi.AnimateReadOnly = false;
            txtXercAdi.BorderStyle = BorderStyle.None;
            txtXercAdi.Depth = 0;
            txtXercAdi.Dock = DockStyle.Fill;
            txtXercAdi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtXercAdi.LeadingIcon = null;
            txtXercAdi.Location = new Point(209, 22);
            txtXercAdi.MaxLength = 50;
            txtXercAdi.MouseState = MaterialSkin.MouseState.OUT;
            txtXercAdi.Multiline = false;
            txtXercAdi.Name = "txtXercAdi";
            txtXercAdi.Size = new Size(200, 50);
            txtXercAdi.TabIndex = 3;
            txtXercAdi.Text = "";
            txtXercAdi.TrailingIcon = null;
            // 
            // lblXercMeblegi
            // 
            lblXercMeblegi.AutoSize = true;
            lblXercMeblegi.Depth = 0;
            lblXercMeblegi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblXercMeblegi.Location = new Point(415, 0);
            lblXercMeblegi.MouseState = MaterialSkin.MouseState.HOVER;
            lblXercMeblegi.Name = "lblXercMeblegi";
            lblXercMeblegi.Size = new Size(94, 19);
            lblXercMeblegi.TabIndex = 4;
            lblXercMeblegi.Text = "Xərc Məbləği:";
            // 
            // nudXercMeblegi
            // 
            nudXercMeblegi.DecimalPlaces = 2;
            nudXercMeblegi.Dock = DockStyle.Fill;
            nudXercMeblegi.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudXercMeblegi.Location = new Point(415, 22);
            nudXercMeblegi.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudXercMeblegi.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudXercMeblegi.Name = "nudXercMeblegi";
            nudXercMeblegi.Size = new Size(120, 23);
            nudXercMeblegi.TabIndex = 5;
            nudXercMeblegi.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // lblXercTarixi
            // 
            lblXercTarixi.AutoSize = true;
            lblXercTarixi.Depth = 0;
            lblXercTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblXercTarixi.Location = new Point(541, 0);
            lblXercTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            lblXercTarixi.Name = "lblXercTarixi";
            lblXercTarixi.Size = new Size(75, 19);
            lblXercTarixi.TabIndex = 6;
            lblXercTarixi.Text = "Xərc Tarixi:";
            // 
            // dtpXercTarixi
            // 
            dtpXercTarixi.Dock = DockStyle.Fill;
            dtpXercTarixi.Location = new Point(541, 22);
            dtpXercTarixi.MinimumSize = new Size(0, 29);
            dtpXercTarixi.Name = "dtpXercTarixi";
            dtpXercTarixi.Size = new Size(200, 29);
            dtpXercTarixi.TabIndex = 7;
            // 
            // lblSenedNomresi
            // 
            lblSenedNomresi.AutoSize = true;
            lblSenedNomresi.Depth = 0;
            lblSenedNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSenedNomresi.Location = new Point(3, 57);
            lblSenedNomresi.MouseState = MaterialSkin.MouseState.HOVER;
            lblSenedNomresi.Name = "lblSenedNomresi";
            lblSenedNomresi.Size = new Size(98, 19);
            lblSenedNomresi.TabIndex = 8;
            lblSenedNomresi.Text = "Sənəd Nömrəsi:";
            // 
            // txtSenedNomresi
            // 
            txtSenedNomresi.AnimateReadOnly = false;
            txtSenedNomresi.BorderStyle = BorderStyle.None;
            txtSenedNomresi.Depth = 0;
            txtSenedNomresi.Dock = DockStyle.Fill;
            txtSenedNomresi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSenedNomresi.LeadingIcon = null;
            txtSenedNomresi.Location = new Point(3, 79);
            txtSenedNomresi.MaxLength = 50;
            txtSenedNomresi.MouseState = MaterialSkin.MouseState.OUT;
            txtSenedNomresi.Multiline = false;
            txtSenedNomresi.Name = "txtSenedNomresi";
            txtSenedNomresi.Size = new Size(200, 50);
            txtSenedNomresi.TabIndex = 9;
            txtSenedNomresi.Text = "";
            txtSenedNomresi.TrailingIcon = null;
            // 
            // lblQeyd
            // 
            lblQeyd.AutoSize = true;
            lblQeyd.Depth = 0;
            lblQeyd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQeyd.Location = new Point(209, 57);
            lblQeyd.MouseState = MaterialSkin.MouseState.HOVER;
            lblQeyd.Name = "lblQeyd";
            lblQeyd.Size = new Size(46, 19);
            lblQeyd.TabIndex = 10;
            lblQeyd.Text = "Qeyd:";
            // 
            // txtQeyd
            // 
            txtQeyd.Dock = DockStyle.Fill;
            txtQeyd.Location = new Point(209, 79);
            txtQeyd.MaxLength = 32767;
            txtQeyd.Multiline = true;
            txtQeyd.Name = "txtQeyd";
            txtQeyd.ScrollBars = ScrollBars.Vertical;
            txtQeyd.Size = new Size(326, 100);
            txtQeyd.TabIndex = 11;
            // 
            // btnXercElaveEt
            // 
            btnXercElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnXercElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnXercElaveEt.Depth = 0;
            btnXercElaveEt.Dock = DockStyle.Fill;
            btnXercElaveEt.HighEmphasis = true;
            btnXercElaveEt.Icon = null;
            btnXercElaveEt.Location = new Point(541, 79);
            btnXercElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnXercElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnXercElaveEt.Name = "btnXercElaveEt";
            btnXercElaveEt.NoAccentTextColor = Color.Empty;
            btnXercElaveEt.Size = new Size(118, 36);
            btnXercElaveEt.TabIndex = 12;
            btnXercElaveEt.Text = "Əlavə Et";
            btnXercElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnXercElaveEt.UseAccentColor = false;
            btnXercElaveEt.UseVisualStyleBackColor = true;
            btnXercElaveEt.Click += btnXercElaveEt_Click;
            // 
            // btnXercYenile
            // 
            btnXercYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnXercYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnXercYenile.Depth = 0;
            btnXercYenile.Dock = DockStyle.Fill;
            btnXercYenile.Enabled = false;
            btnXercYenile.HighEmphasis = true;
            btnXercYenile.Icon = null;
            btnXercYenile.Location = new Point(667, 79);
            btnXercYenile.Margin = new Padding(4, 6, 4, 6);
            btnXercYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnXercYenile.Name = "btnXercYenile";
            btnXercYenile.NoAccentTextColor = Color.Empty;
            btnXercYenile.Size = new Size(78, 36);
            btnXercYenile.TabIndex = 13;
            btnXercYenile.Text = "Yenilə";
            btnXercYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnXercYenile.UseAccentColor = false;
            btnXercYenile.UseVisualStyleBackColor = true;
            btnXercYenile.Click += btnXercYenile_Click;
            // 
            // btnXercSil
            // 
            btnXercSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnXercSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnXercSil.Depth = 0;
            btnXercSil.Dock = DockStyle.Fill;
            btnXercSil.Enabled = false;
            btnXercSil.HighEmphasis = true;
            btnXercSil.Icon = null;
            btnXercSil.Location = new Point(753, 79);
            btnXercSil.Margin = new Padding(4, 6, 4, 6);
            btnXercSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnXercSil.Name = "btnXercSil";
            btnXercSil.NoAccentTextColor = Color.Empty;
            btnXercSil.Size = new Size(55, 36);
            btnXercSil.TabIndex = 14;
            btnXercSil.Text = "Sil";
            btnXercSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnXercSil.UseAccentColor = false;
            btnXercSil.UseVisualStyleBackColor = true;
            btnXercSil.Click += btnXercSil_Click;
            // 
            // dgvXercler
            // 
            dgvXercler.AllowUserToAddRows = false;
            dgvXercler.AllowUserToDeleteRows = false;
            dgvXercler.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(238, 239, 249);
            dgvXercler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvXercler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvXercler.BackgroundColor = Color.White;
            dgvXercler.BorderStyle = BorderStyle.None;
            dgvXercler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvXercler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvXercler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvXercler.DefaultCellStyle = dataGridViewCellStyle3;
            dgvXercler.Dock = DockStyle.Fill;
            dgvXercler.EnableHeadersVisualStyles = false;
            dgvXercler.Font = new Font("Segoe UI", 11F);
            dgvXercler.GridColor = Color.FromArgb(238, 239, 249);
            dgvXercler.Location = new Point(3, 188);
            dgvXercler.Name = "dgvXercler";
            dgvXercler.ReadOnly = true;
            dgvXercler.RowHeadersWidth = 51;
            dgvXercler.RowTemplate.Height = 24;
            dgvXercler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXercler.Size = new Size(1078, 359);
            dgvXercler.TabIndex = 15;
            dgvXercler.SelectionChanged += dgvXercler_SelectionChanged;
            // 
            // btnYenidenYukle
            // 
            btnYenidenYukle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenidenYukle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenidenYukle.Depth = 0;
            btnYenidenYukle.Dock = DockStyle.Right;
            btnYenidenYukle.HighEmphasis = true;
            btnYenidenYukle.Icon = null;
            btnYenidenYukle.Location = new Point(972, 146);
            btnYenidenYukle.Margin = new Padding(4, 6, 4, 6);
            btnYenidenYukle.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenidenYukle.Name = "btnYenidenYukle";
            btnYenidenYukle.NoAccentTextColor = Color.Empty;
            btnYenidenYukle.Size = new Size(109, 36);
            btnYenidenYukle.TabIndex = 16;
            btnYenidenYukle.Text = "Yenidən Yüklə";
            btnYenidenYukle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenidenYukle.UseAccentColor = false;
            btnYenidenYukle.UseVisualStyleBackColor = true;
            btnYenidenYukle.Click += btnYenidenYukle_Click;
            // 
            // btnFormuSifirla
            // 
            btnFormuSifirla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormuSifirla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFormuSifirla.Depth = 0;
            btnFormuSifirla.Dock = DockStyle.Right;
            btnFormuSifirla.HighEmphasis = true;
            btnFormuSifirla.Icon = null;
            btnFormuSifirla.Location = new Point(855, 146);
            btnFormuSifirla.Margin = new Padding(4, 6, 4, 6);
            btnFormuSifirla.MouseState = MaterialSkin.MouseState.HOVER;
            btnFormuSifirla.Name = "btnFormuSifirla";
            btnFormuSifirla.NoAccentTextColor = Color.Empty;
            btnFormuSifirla.Size = new Size(109, 36);
            btnFormuSifirla.TabIndex = 17;
            btnFormuSifirla.Text = "Formu Sıfırla";
            btnFormuSifirla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFormuSifirla.UseAccentColor = false;
            btnFormuSifirla.UseVisualStyleBackColor = true;
            btnFormuSifirla.Click += btnFormuSifirla_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(btnYenidenYukle, 0, 1);
            tableLayoutPanel1.Controls.Add(btnFormuSifirla, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvXercler, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 64);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 185F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1084, 550);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 206F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 206F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 206F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
            tableLayoutPanel2.Controls.Add(lblXercNovu, 0, 0);
            tableLayoutPanel2.Controls.Add(cmbXercNovu, 0, 1);
            tableLayoutPanel2.Controls.Add(lblXercAdi, 1, 0);
            tableLayoutPanel2.Controls.Add(txtXercAdi, 1, 1);
            tableLayoutPanel2.Controls.Add(lblXercMeblegi, 2, 0);
            tableLayoutPanel2.Controls.Add(nudXercMeblegi, 2, 1);
            tableLayoutPanel2.Controls.Add(lblXercTarixi, 3, 0);
            tableLayoutPanel2.Controls.Add(dtpXercTarixi, 3, 1);
            tableLayoutPanel2.Controls.Add(lblSenedNomresi, 0, 2);
            tableLayoutPanel2.Controls.Add(txtSenedNomresi, 0, 3);
            tableLayoutPanel2.Controls.Add(lblQeyd, 1, 2);
            tableLayoutPanel2.Controls.Add(txtQeyd, 1, 3);
            tableLayoutPanel2.Controls.Add(btnXercElaveEt, 4, 3);
            tableLayoutPanel2.Controls.Add(btnXercYenile, 5, 3);
            tableLayoutPanel2.Controls.Add(btnXercSil, 6, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.Size = new Size(1078, 179);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // XercIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 617);
            Controls.Add(tableLayoutPanel1);
            Name = "XercIdareetmeFormu";
            Text = "Xərc İdarəetməsi";
            Load += XercIdareetmeFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvXercler).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblXercNovu;
        private MaterialSkin.Controls.MaterialComboBox cmbXercNovu;
        private MaterialSkin.Controls.MaterialLabel lblXercAdi;
        private MaterialSkin.Controls.MaterialTextBox txtXercAdi;
        private MaterialSkin.Controls.MaterialLabel lblXercMeblegi;
        private NumericUpDown nudXercMeblegi;
        private MaterialSkin.Controls.MaterialLabel lblXercTarixi;
        private DateTimePicker dtpXercTarixi;
        private MaterialSkin.Controls.MaterialLabel lblSenedNomresi;
        private MaterialSkin.Controls.MaterialTextBox txtSenedNomresi;
        private MaterialSkin.Controls.MaterialLabel lblQeyd;
        private TextBox txtQeyd;
        private MaterialSkin.Controls.MaterialButton btnXercElaveEt;
        private MaterialSkin.Controls.MaterialButton btnXercYenile;
        private MaterialSkin.Controls.MaterialButton btnXercSil;
        private DataGridView dgvXercler;
        private MaterialSkin.Controls.MaterialButton btnYenidenYukle;
        private MaterialSkin.Controls.MaterialButton btnFormuSifirla;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
