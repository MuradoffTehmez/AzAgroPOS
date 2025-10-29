namespace AzAgroPOS.Teqdimat
{
    partial class AlisSenedFormu
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();

            splitContainer1 = new SplitContainer();
            toolTip1 = new ToolTip(components);
            dgvSenetler = new DataGridView();
            dgvSenedSetirleri = new DataGridView();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            btnSetirSil = new MaterialSkin.Controls.MaterialButton();
            btnMehsulElaveEt = new MaterialSkin.Controls.MaterialButton();
            txtQiymet = new MaterialSkin.Controls.MaterialTextBox2();
            txtMiqdar = new MaterialSkin.Controls.MaterialTextBox2();
            cmbMehsul = new ComboBox();
            label1 = new Label();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnYaddaSaxla = new MaterialSkin.Controls.MaterialButton();
            btnYeni = new MaterialSkin.Controls.MaterialButton();
            txtQeydler = new MaterialSkin.Controls.MaterialTextBox2();
            dtpTehvilTarixi = new DateTimePicker();
            label3 = new Label();
            dtpYaradilmaTarixi = new DateTimePicker();
            label2 = new Label();
            cmbTedarukcu = new ComboBox();
            labelTedarukcu = new Label();
            txtSenedNomresi = new MaterialSkin.Controls.MaterialTextBox2();

            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSenetler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSenedSetirleri).BeginInit();
            materialCard1.SuspendLayout();
            materialCard2.SuspendLayout();
            SuspendLayout();
            //
            // splitContainer1
            //
            splitContainer1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 64);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            splitContainer1.Panel1.Controls.Add(dgvSenetler);
            splitContainer1.Panel1.Controls.Add(txtAxtaris);
            splitContainer1.Panel1.Controls.Add(materialCard2);
            //
            // splitContainer1.Panel2
            //
            splitContainer1.Panel2.Controls.Add(dgvSenedSetirleri);
            splitContainer1.Panel2.Controls.Add(materialCard1);
            splitContainer1.Size = new Size(1200, 700);
            splitContainer1.SplitterDistance = 350;
            splitContainer1.TabIndex = 0;
            //
            // dgvSenetler
            //
            dgvSenetler.AllowUserToAddRows = false;
            dgvSenetler.AllowUserToDeleteRows = false;
            dgvSenetler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSenetler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSenetler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSenetler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSenetler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSenetler.Location = new Point(10, 58);
            dgvSenetler.MultiSelect = false;
            dgvSenetler.Name = "dgvSenetler";
            dgvSenetler.ReadOnly = true;
            dgvSenetler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSenetler.Size = new Size(800, 280);
            dgvSenetler.TabIndex = 0;
            dgvSenetler.SelectionChanged += dgvSenetler_SelectionChanged;
            //
            // txtAxtaris
            //
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.Hint = "Alış sənədi axtar...";
            txtAxtaris.Location = new Point(10, 4);
            txtAxtaris.MaxLength = 32767;
            txtAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            txtAxtaris.Name = "txtAxtaris";
            txtAxtaris.PasswordChar = '\0';
            txtAxtaris.ReadOnly = false;
            txtAxtaris.SelectedText = "";
            txtAxtaris.SelectionLength = 0;
            txtAxtaris.SelectionStart = 0;
            txtAxtaris.ShortcutsEnabled = true;
            txtAxtaris.Size = new Size(800, 48);
            txtAxtaris.TabIndex = 1;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.TextChanged += txtAxtaris_TextChanged;
            //
            // materialCard2
            //
            materialCard2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(btnSil);
            materialCard2.Controls.Add(btnYaddaSaxla);
            materialCard2.Controls.Add(btnYeni);
            materialCard2.Controls.Add(txtQeydler);
            materialCard2.Controls.Add(dtpTehvilTarixi);
            materialCard2.Controls.Add(label3);
            materialCard2.Controls.Add(dtpYaradilmaTarixi);
            materialCard2.Controls.Add(label2);
            materialCard2.Controls.Add(cmbTedarukcu);
            materialCard2.Controls.Add(labelTedarukcu);
            materialCard2.Controls.Add(txtSenedNomresi);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(820, 4);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(370, 334);
            materialCard2.TabIndex = 2;
            //
            // btnSil
            //
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(250, 285);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(100, 36);
            btnSil.TabIndex = 10;
            btnSil.Text = "Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = false;
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            //
            // btnYaddaSaxla
            //
            btnYaddaSaxla.AutoSize = false;
            btnYaddaSaxla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYaddaSaxla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYaddaSaxla.Depth = 0;
            btnYaddaSaxla.HighEmphasis = true;
            btnYaddaSaxla.Icon = null;
            btnYaddaSaxla.Location = new Point(130, 285);
            btnYaddaSaxla.Margin = new Padding(4, 6, 4, 6);
            btnYaddaSaxla.MouseState = MaterialSkin.MouseState.HOVER;
            btnYaddaSaxla.Name = "btnYaddaSaxla";
            btnYaddaSaxla.NoAccentTextColor = Color.Empty;
            btnYaddaSaxla.Size = new Size(110, 36);
            btnYaddaSaxla.TabIndex = 9;
            btnYaddaSaxla.Text = "Yadda Saxla";
            btnYaddaSaxla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYaddaSaxla.UseAccentColor = false;
            btnYaddaSaxla.UseVisualStyleBackColor = true;
            btnYaddaSaxla.Click += btnYaddaSaxla_Click;
            //
            // btnYeni
            //
            btnYeni.AutoSize = false;
            btnYeni.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeni.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeni.Depth = 0;
            btnYeni.HighEmphasis = true;
            btnYeni.Icon = null;
            btnYeni.Location = new Point(20, 285);
            btnYeni.Margin = new Padding(4, 6, 4, 6);
            btnYeni.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeni.Name = "btnYeni";
            btnYeni.NoAccentTextColor = Color.Empty;
            btnYeni.Size = new Size(100, 36);
            btnYeni.TabIndex = 8;
            btnYeni.Text = "Yeni";
            btnYeni.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnYeni.UseAccentColor = false;
            btnYeni.UseVisualStyleBackColor = true;
            btnYeni.Click += btnYeni_Click;
            //
            // txtQeydler
            //
            txtQeydler.AnimateReadOnly = false;
            txtQeydler.BackColor = Color.FromArgb(255, 255, 255);
            txtQeydler.CharacterCasing = CharacterCasing.Normal;
            txtQeydler.Depth = 0;
            txtQeydler.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeydler.Hint = "Qeydlər";
            txtQeydler.Location = new Point(17, 220);
            txtQeydler.MaxLength = 500;
            txtQeydler.MouseState = MaterialSkin.MouseState.OUT;
            txtQeydler.Name = "txtQeydler";
            txtQeydler.PasswordChar = '\0';
            txtQeydler.ReadOnly = false;
            txtQeydler.SelectedText = "";
            txtQeydler.SelectionLength = 0;
            txtQeydler.SelectionStart = 0;
            txtQeydler.ShortcutsEnabled = true;
            txtQeydler.Size = new Size(336, 48);
            txtQeydler.TabIndex = 7;
            txtQeydler.TabStop = false;
            txtQeydler.TextAlign = HorizontalAlignment.Left;
            txtQeydler.UseSystemPasswordChar = false;
            //
            // dtpTehvilTarixi
            //
            dtpTehvilTarixi.Format = DateTimePickerFormat.Short;
            dtpTehvilTarixi.Location = new Point(120, 183);
            dtpTehvilTarixi.Name = "dtpTehvilTarixi";
            dtpTehvilTarixi.Size = new Size(233, 23);
            dtpTehvilTarixi.TabIndex = 6;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(17, 187);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Təhvil Tarixi:";
            //
            // dtpYaradilmaTarixi
            //
            dtpYaradilmaTarixi.Format = DateTimePickerFormat.Short;
            dtpYaradilmaTarixi.Location = new Point(120, 147);
            dtpYaradilmaTarixi.Name = "dtpYaradilmaTarixi";
            dtpYaradilmaTarixi.Size = new Size(233, 23);
            dtpYaradilmaTarixi.TabIndex = 4;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(17, 151);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 3;
            label2.Text = "Yaradılma Tarixi:";
            //
            // cmbTedarukcu
            //
            cmbTedarukcu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTedarukcu.FormattingEnabled = true;
            cmbTedarukcu.Location = new Point(100, 111);
            cmbTedarukcu.Name = "cmbTedarukcu";
            cmbTedarukcu.Size = new Size(253, 23);
            cmbTedarukcu.TabIndex = 2;
            //
            // labelTedarukcu
            //
            labelTedarukcu.AutoSize = true;
            labelTedarukcu.Location = new Point(17, 114);
            labelTedarukcu.Name = "labelTedarukcu";
            labelTedarukcu.Size = new Size(67, 15);
            labelTedarukcu.TabIndex = 1;
            labelTedarukcu.Text = "Tədarükçü:";
            //
            // txtSenedNomresi
            //
            txtSenedNomresi.AnimateReadOnly = false;
            txtSenedNomresi.BackColor = Color.FromArgb(255, 255, 255);
            txtSenedNomresi.CharacterCasing = CharacterCasing.Normal;
            txtSenedNomresi.Depth = 0;
            txtSenedNomresi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSenedNomresi.Hint = "Sənəd Nömrəsi";
            txtSenedNomresi.Location = new Point(17, 14);
            txtSenedNomresi.MaxLength = 50;
            txtSenedNomresi.MouseState = MaterialSkin.MouseState.OUT;
            txtSenedNomresi.Name = "txtSenedNomresi";
            txtSenedNomresi.PasswordChar = '\0';
            txtSenedNomresi.ReadOnly = false;
            txtSenedNomresi.SelectedText = "";
            txtSenedNomresi.SelectionLength = 0;
            txtSenedNomresi.SelectionStart = 0;
            txtSenedNomresi.ShortcutsEnabled = true;
            txtSenedNomresi.Size = new Size(336, 48);
            txtSenedNomresi.TabIndex = 0;
            txtSenedNomresi.TabStop = false;
            txtSenedNomresi.TextAlign = HorizontalAlignment.Left;
            txtSenedNomresi.UseSystemPasswordChar = false;
            //
            // dgvSenedSetirleri
            //
            dgvSenedSetirleri.AllowUserToAddRows = false;
            dgvSenedSetirleri.AllowUserToDeleteRows = false;
            dgvSenedSetirleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSenedSetirleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSenedSetirleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSenedSetirleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSenedSetirleri.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSenedSetirleri.Location = new Point(10, 10);
            dgvSenedSetirleri.MultiSelect = false;
            dgvSenedSetirleri.Name = "dgvSenedSetirleri";
            dgvSenedSetirleri.ReadOnly = true;
            dgvSenedSetirleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSenedSetirleri.Size = new Size(800, 326);
            dgvSenedSetirleri.TabIndex = 0;
            //
            // materialCard1
            //
            materialCard1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(lblUmumiMebleg);
            materialCard1.Controls.Add(btnSetirSil);
            materialCard1.Controls.Add(btnMehsulElaveEt);
            materialCard1.Controls.Add(txtQiymet);
            materialCard1.Controls.Add(txtMiqdar);
            materialCard1.Controls.Add(cmbMehsul);
            materialCard1.Controls.Add(label1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(820, 10);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(370, 326);
            materialCard1.TabIndex = 1;
            //
            // lblUmumiMebleg
            //
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiMebleg.Location = new Point(20, 290);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(138, 19);
            lblUmumiMebleg.TabIndex = 6;
            lblUmumiMebleg.Text = "Ümumi: 0.00 AZN";
            //
            // btnSetirSil
            //
            btnSetirSil.AutoSize = false;
            btnSetirSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSetirSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSetirSil.Depth = 0;
            btnSetirSil.HighEmphasis = true;
            btnSetirSil.Icon = null;
            btnSetirSil.Location = new Point(210, 242);
            btnSetirSil.Margin = new Padding(4, 6, 4, 6);
            btnSetirSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSetirSil.Name = "btnSetirSil";
            btnSetirSil.NoAccentTextColor = Color.Empty;
            btnSetirSil.Size = new Size(143, 36);
            btnSetirSil.TabIndex = 5;
            btnSetirSil.Text = "Sətir Sil";
            btnSetirSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSetirSil.UseAccentColor = false;
            btnSetirSil.UseVisualStyleBackColor = true;
            btnSetirSil.Click += btnSetirSil_Click;
            //
            // btnMehsulElaveEt
            //
            btnMehsulElaveEt.AutoSize = false;
            btnMehsulElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulElaveEt.Depth = 0;
            btnMehsulElaveEt.HighEmphasis = true;
            btnMehsulElaveEt.Icon = null;
            btnMehsulElaveEt.Location = new Point(20, 242);
            btnMehsulElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnMehsulElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulElaveEt.Name = "btnMehsulElaveEt";
            btnMehsulElaveEt.NoAccentTextColor = Color.Empty;
            btnMehsulElaveEt.Size = new Size(180, 36);
            btnMehsulElaveEt.TabIndex = 4;
            btnMehsulElaveEt.Text = "Məhsul Əlavə Et";
            btnMehsulElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMehsulElaveEt.UseAccentColor = false;
            btnMehsulElaveEt.UseVisualStyleBackColor = true;
            btnMehsulElaveEt.Click += btnMehsulElaveEt_Click;
            //
            // txtQiymet
            //
            txtQiymet.AnimateReadOnly = false;
            txtQiymet.BackColor = Color.FromArgb(255, 255, 255);
            txtQiymet.CharacterCasing = CharacterCasing.Normal;
            txtQiymet.Depth = 0;
            txtQiymet.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQiymet.Hint = "Qiymət";
            txtQiymet.Location = new Point(17, 180);
            txtQiymet.MaxLength = 32767;
            txtQiymet.MouseState = MaterialSkin.MouseState.OUT;
            txtQiymet.Name = "txtQiymet";
            txtQiymet.PasswordChar = '\0';
            txtQiymet.ReadOnly = false;
            txtQiymet.SelectedText = "";
            txtQiymet.SelectionLength = 0;
            txtQiymet.SelectionStart = 0;
            txtQiymet.ShortcutsEnabled = true;
            txtQiymet.Size = new Size(336, 48);
            txtQiymet.TabIndex = 3;
            txtQiymet.TabStop = false;
            txtQiymet.TextAlign = HorizontalAlignment.Left;
            txtQiymet.UseSystemPasswordChar = false;
            //
            // txtMiqdar
            //
            txtMiqdar.AnimateReadOnly = false;
            txtMiqdar.BackColor = Color.FromArgb(255, 255, 255);
            txtMiqdar.CharacterCasing = CharacterCasing.Normal;
            txtMiqdar.Depth = 0;
            txtMiqdar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMiqdar.Hint = "Miqdar";
            txtMiqdar.Location = new Point(17, 118);
            txtMiqdar.MaxLength = 32767;
            txtMiqdar.MouseState = MaterialSkin.MouseState.OUT;
            txtMiqdar.Name = "txtMiqdar";
            txtMiqdar.PasswordChar = '\0';
            txtMiqdar.ReadOnly = false;
            txtMiqdar.SelectedText = "";
            txtMiqdar.SelectionLength = 0;
            txtMiqdar.SelectionStart = 0;
            txtMiqdar.ShortcutsEnabled = true;
            txtMiqdar.Size = new Size(336, 48);
            txtMiqdar.TabIndex = 2;
            txtMiqdar.TabStop = false;
            txtMiqdar.TextAlign = HorizontalAlignment.Left;
            txtMiqdar.UseSystemPasswordChar = false;
            //
            // cmbMehsul
            //
            cmbMehsul.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMehsul.FormattingEnabled = true;
            cmbMehsul.Location = new Point(100, 79);
            cmbMehsul.Name = "cmbMehsul";
            cmbMehsul.Size = new Size(253, 23);
            cmbMehsul.TabIndex = 1;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(17, 82);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Məhsul:";
            //
            // AlisSenedFormu
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Name = "AlisSenedFormu";
            Text = "Alış Sənəd İdarəetməsi";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSenetler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSenedSetirleri).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected System.Windows.Forms.SplitContainer splitContainer1;
        private ToolTip toolTip1;
        private DataGridView dgvSenetler;
        private DataGridView dgvSenedSetirleri;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialTextBox2 txtSenedNomresi;
        private ComboBox cmbTedarukcu;
        private Label labelTedarukcu;
        private DateTimePicker dtpYaradilmaTarixi;
        private Label label2;
        private DateTimePicker dtpTehvilTarixi;
        private Label label3;
        private MaterialSkin.Controls.MaterialTextBox2 txtQeydler;
        private MaterialSkin.Controls.MaterialButton btnYeni;
        private MaterialSkin.Controls.MaterialButton btnYaddaSaxla;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private ComboBox cmbMehsul;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox2 txtMiqdar;
        private MaterialSkin.Controls.MaterialTextBox2 txtQiymet;
        private MaterialSkin.Controls.MaterialButton btnMehsulElaveEt;
        private MaterialSkin.Controls.MaterialButton btnSetirSil;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
    }
}
