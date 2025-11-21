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
            dgvSenetler = new DataGridView();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
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
            dgvSenedSetirleri = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            btnSetirSil = new MaterialSkin.Controls.MaterialButton();
            btnMehsulElaveEt = new MaterialSkin.Controls.MaterialButton();
            txtQiymet = new MaterialSkin.Controls.MaterialTextBox2();
            txtMiqdar = new MaterialSkin.Controls.MaterialTextBox2();
            cmbMehsul = new ComboBox();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSenetler).BeginInit();
            materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSenedSetirleri).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Location = new Point(3, 64);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel1.Controls.Add(dgvSenetler);
            splitContainer1.Panel1.Controls.Add(txtAxtaris);
            splitContainer1.Panel1.Controls.Add(materialCard2);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(dgvSenedSetirleri);
            splitContainer1.Panel2.Controls.Add(materialCard1);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(1194, 661);
            splitContainer1.SplitterDistance = 330;
            splitContainer1.TabIndex = 0;
            //
            // dgvSenetler
            //
            dgvSenetler.AllowUserToAddRows = false;
            dgvSenetler.AllowUserToDeleteRows = false;
            dgvSenetler.AutoGenerateColumns = false;
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
            dgvSenetler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSenetler.Location = new Point(10, 58);
            dgvSenetler.MultiSelect = false;
            dgvSenetler.Name = "dgvSenetler";
            dgvSenetler.ReadOnly = true;
            dgvSenetler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSenetler.Size = new Size(794, 260);
            dgvSenetler.TabIndex = 0;
            dgvSenetler.SelectionChanged += dgvSenetler_SelectionChanged;
            // 
            // txtAxtaris
            // 
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Alış sənədi axtar...";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(10, 4);
            txtAxtaris.MaxLength = 32767;
            txtAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            txtAxtaris.Name = "txtAxtaris";
            txtAxtaris.PasswordChar = '\0';
            txtAxtaris.PrefixSuffixText = null;
            txtAxtaris.ReadOnly = false;
            txtAxtaris.RightToLeft = RightToLeft.No;
            txtAxtaris.SelectedText = "";
            txtAxtaris.SelectionLength = 0;
            txtAxtaris.SelectionStart = 0;
            txtAxtaris.ShortcutsEnabled = true;
            txtAxtaris.Size = new Size(794, 48);
            txtAxtaris.TabIndex = 1;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
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
            materialCard2.Location = new Point(814, 4);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(370, 314);
            materialCard2.TabIndex = 2;
            // 
            // btnSil
            // 
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(250, 245);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(100, 36);
            btnSil.TabIndex = 10;
            btnSil.Text = "Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = false;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYaddaSaxla
            // 
            btnYaddaSaxla.AutoSize = false;
            btnYaddaSaxla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYaddaSaxla.BackColor = Color.FromArgb(242, 242, 242);
            btnYaddaSaxla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYaddaSaxla.Depth = 0;
            btnYaddaSaxla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYaddaSaxla.HighEmphasis = true;
            btnYaddaSaxla.Icon = null;
            btnYaddaSaxla.Location = new Point(130, 245);
            btnYaddaSaxla.Margin = new Padding(4, 6, 4, 6);
            btnYaddaSaxla.MouseState = MaterialSkin.MouseState.HOVER;
            btnYaddaSaxla.Name = "btnYaddaSaxla";
            btnYaddaSaxla.NoAccentTextColor = Color.Empty;
            btnYaddaSaxla.Size = new Size(110, 36);
            btnYaddaSaxla.TabIndex = 9;
            btnYaddaSaxla.Text = "Yadda Saxla";
            btnYaddaSaxla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYaddaSaxla.UseAccentColor = false;
            btnYaddaSaxla.UseVisualStyleBackColor = false;
            btnYaddaSaxla.Click += btnYaddaSaxla_Click;
            // 
            // btnYeni
            // 
            btnYeni.AutoSize = false;
            btnYeni.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeni.BackColor = Color.FromArgb(242, 242, 242);
            btnYeni.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeni.Depth = 0;
            btnYeni.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYeni.HighEmphasis = true;
            btnYeni.Icon = null;
            btnYeni.Location = new Point(20, 245);
            btnYeni.Margin = new Padding(4, 6, 4, 6);
            btnYeni.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeni.Name = "btnYeni";
            btnYeni.NoAccentTextColor = Color.Empty;
            btnYeni.Size = new Size(100, 36);
            btnYeni.TabIndex = 8;
            btnYeni.Text = "Yeni";
            btnYeni.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnYeni.UseAccentColor = false;
            btnYeni.UseVisualStyleBackColor = false;
            btnYeni.Click += btnYeni_Click;
            // 
            // txtQeydler
            // 
            txtQeydler.AnimateReadOnly = false;
            txtQeydler.BackColor = Color.FromArgb(255, 255, 255);
            txtQeydler.BackgroundImageLayout = ImageLayout.None;
            txtQeydler.CharacterCasing = CharacterCasing.Normal;
            txtQeydler.Depth = 0;
            txtQeydler.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeydler.HideSelection = true;
            txtQeydler.Hint = "Qeydlər";
            txtQeydler.LeadingIcon = null;
            txtQeydler.Location = new Point(17, 195);
            txtQeydler.MaxLength = 500;
            txtQeydler.MouseState = MaterialSkin.MouseState.OUT;
            txtQeydler.Name = "txtQeydler";
            txtQeydler.PasswordChar = '\0';
            txtQeydler.PrefixSuffixText = null;
            txtQeydler.ReadOnly = false;
            txtQeydler.RightToLeft = RightToLeft.No;
            txtQeydler.SelectedText = "";
            txtQeydler.SelectionLength = 0;
            txtQeydler.SelectionStart = 0;
            txtQeydler.ShortcutsEnabled = true;
            txtQeydler.Size = new Size(336, 48);
            txtQeydler.TabIndex = 7;
            txtQeydler.TabStop = false;
            txtQeydler.TextAlign = HorizontalAlignment.Left;
            txtQeydler.TrailingIcon = null;
            txtQeydler.UseSystemPasswordChar = false;
            // 
            // dtpTehvilTarixi
            // 
            dtpTehvilTarixi.BackColor = Color.FromArgb(255, 255, 255);
            dtpTehvilTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpTehvilTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpTehvilTarixi.Format = DateTimePickerFormat.Short;
            dtpTehvilTarixi.Location = new Point(130, 158);
            dtpTehvilTarixi.Name = "dtpTehvilTarixi";
            dtpTehvilTarixi.Size = new Size(223, 24);
            dtpTehvilTarixi.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(255, 255, 255);
            label3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label3.Location = new Point(17, 162);
            label3.Name = "label3";
            label3.Size = new Size(83, 17);
            label3.TabIndex = 5;
            label3.Text = "Təhvil Tarixi:";
            // 
            // dtpYaradilmaTarixi
            // 
            dtpYaradilmaTarixi.BackColor = Color.FromArgb(255, 255, 255);
            dtpYaradilmaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpYaradilmaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpYaradilmaTarixi.Format = DateTimePickerFormat.Short;
            dtpYaradilmaTarixi.Location = new Point(130, 122);
            dtpYaradilmaTarixi.Name = "dtpYaradilmaTarixi";
            dtpYaradilmaTarixi.Size = new Size(223, 24);
            dtpYaradilmaTarixi.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 255, 255);
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label2.Location = new Point(17, 126);
            label2.Name = "label2";
            label2.Size = new Size(110, 17);
            label2.TabIndex = 3;
            label2.Text = "Yaradılma Tarixi:";
            // 
            // cmbTedarukcu
            // 
            cmbTedarukcu.BackColor = Color.FromArgb(255, 255, 255);
            cmbTedarukcu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTedarukcu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTedarukcu.FormattingEnabled = true;
            cmbTedarukcu.Location = new Point(130, 86);
            cmbTedarukcu.Name = "cmbTedarukcu";
            cmbTedarukcu.Size = new Size(223, 25);
            cmbTedarukcu.TabIndex = 2;
            // 
            // labelTedarukcu
            // 
            labelTedarukcu.AutoSize = true;
            labelTedarukcu.BackColor = Color.FromArgb(255, 255, 255);
            labelTedarukcu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelTedarukcu.Location = new Point(17, 89);
            labelTedarukcu.Name = "labelTedarukcu";
            labelTedarukcu.Size = new Size(77, 17);
            labelTedarukcu.TabIndex = 1;
            labelTedarukcu.Text = "Tədarükçü:";
            // 
            // txtSenedNomresi
            // 
            txtSenedNomresi.AnimateReadOnly = false;
            txtSenedNomresi.BackColor = Color.FromArgb(255, 255, 255);
            txtSenedNomresi.BackgroundImageLayout = ImageLayout.None;
            txtSenedNomresi.CharacterCasing = CharacterCasing.Normal;
            txtSenedNomresi.Depth = 0;
            txtSenedNomresi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSenedNomresi.HideSelection = true;
            txtSenedNomresi.Hint = "Sənəd Nömrəsi";
            txtSenedNomresi.LeadingIcon = null;
            txtSenedNomresi.Location = new Point(17, 14);
            txtSenedNomresi.MaxLength = 50;
            txtSenedNomresi.MouseState = MaterialSkin.MouseState.OUT;
            txtSenedNomresi.Name = "txtSenedNomresi";
            txtSenedNomresi.PasswordChar = '\0';
            txtSenedNomresi.PrefixSuffixText = null;
            txtSenedNomresi.ReadOnly = false;
            txtSenedNomresi.RightToLeft = RightToLeft.No;
            txtSenedNomresi.SelectedText = "";
            txtSenedNomresi.SelectionLength = 0;
            txtSenedNomresi.SelectionStart = 0;
            txtSenedNomresi.ShortcutsEnabled = true;
            txtSenedNomresi.Size = new Size(336, 48);
            txtSenedNomresi.TabIndex = 0;
            txtSenedNomresi.TabStop = false;
            txtSenedNomresi.TextAlign = HorizontalAlignment.Left;
            txtSenedNomresi.TrailingIcon = null;
            txtSenedNomresi.UseSystemPasswordChar = false;
            //
            // dgvSenedSetirleri
            //
            dgvSenedSetirleri.AllowUserToAddRows = false;
            dgvSenedSetirleri.AllowUserToDeleteRows = false;
            dgvSenedSetirleri.AutoGenerateColumns = false;
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
            dgvSenedSetirleri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSenedSetirleri.Location = new Point(10, 10);
            dgvSenedSetirleri.MultiSelect = false;
            dgvSenedSetirleri.Name = "dgvSenedSetirleri";
            dgvSenedSetirleri.ReadOnly = true;
            dgvSenedSetirleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSenedSetirleri.Size = new Size(794, 307);
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
            materialCard1.Location = new Point(814, 10);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(370, 384);
            materialCard1.TabIndex = 1;
            // 
            // lblUmumiMebleg
            // 
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUmumiMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiMebleg.Location = new Point(20, 240);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(126, 19);
            lblUmumiMebleg.TabIndex = 6;
            lblUmumiMebleg.Text = "Ümumi: 0.00 AZN";
            // 
            // btnSetirSil
            // 
            btnSetirSil.AutoSize = false;
            btnSetirSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSetirSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSetirSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSetirSil.Depth = 0;
            btnSetirSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSetirSil.HighEmphasis = true;
            btnSetirSil.Icon = null;
            btnSetirSil.Location = new Point(210, 192);
            btnSetirSil.Margin = new Padding(4, 6, 4, 6);
            btnSetirSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSetirSil.Name = "btnSetirSil";
            btnSetirSil.NoAccentTextColor = Color.Empty;
            btnSetirSil.Size = new Size(143, 36);
            btnSetirSil.TabIndex = 5;
            btnSetirSil.Text = "Sətir Sil";
            btnSetirSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSetirSil.UseAccentColor = false;
            btnSetirSil.UseVisualStyleBackColor = false;
            btnSetirSil.Click += btnSetirSil_Click;
            // 
            // btnMehsulElaveEt
            // 
            btnMehsulElaveEt.AutoSize = false;
            btnMehsulElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnMehsulElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulElaveEt.Depth = 0;
            btnMehsulElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnMehsulElaveEt.HighEmphasis = true;
            btnMehsulElaveEt.Icon = null;
            btnMehsulElaveEt.Location = new Point(20, 192);
            btnMehsulElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnMehsulElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulElaveEt.Name = "btnMehsulElaveEt";
            btnMehsulElaveEt.NoAccentTextColor = Color.Empty;
            btnMehsulElaveEt.Size = new Size(180, 36);
            btnMehsulElaveEt.TabIndex = 4;
            btnMehsulElaveEt.Text = "Məhsul Əlavə Et";
            btnMehsulElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMehsulElaveEt.UseAccentColor = false;
            btnMehsulElaveEt.UseVisualStyleBackColor = false;
            btnMehsulElaveEt.Click += btnMehsulElaveEt_Click;
            // 
            // txtQiymet
            // 
            txtQiymet.AnimateReadOnly = false;
            txtQiymet.BackColor = Color.FromArgb(255, 255, 255);
            txtQiymet.BackgroundImageLayout = ImageLayout.None;
            txtQiymet.CharacterCasing = CharacterCasing.Normal;
            txtQiymet.Depth = 0;
            txtQiymet.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQiymet.HideSelection = true;
            txtQiymet.Hint = "Qiymət";
            txtQiymet.LeadingIcon = null;
            txtQiymet.Location = new Point(17, 130);
            txtQiymet.MaxLength = 32767;
            txtQiymet.MouseState = MaterialSkin.MouseState.OUT;
            txtQiymet.Name = "txtQiymet";
            txtQiymet.PasswordChar = '\0';
            txtQiymet.PrefixSuffixText = null;
            txtQiymet.ReadOnly = false;
            txtQiymet.RightToLeft = RightToLeft.No;
            txtQiymet.SelectedText = "";
            txtQiymet.SelectionLength = 0;
            txtQiymet.SelectionStart = 0;
            txtQiymet.ShortcutsEnabled = true;
            txtQiymet.Size = new Size(336, 48);
            txtQiymet.TabIndex = 3;
            txtQiymet.TabStop = false;
            txtQiymet.TextAlign = HorizontalAlignment.Left;
            txtQiymet.TrailingIcon = null;
            txtQiymet.UseSystemPasswordChar = false;
            // 
            // txtMiqdar
            // 
            txtMiqdar.AnimateReadOnly = false;
            txtMiqdar.BackColor = Color.FromArgb(255, 255, 255);
            txtMiqdar.BackgroundImageLayout = ImageLayout.None;
            txtMiqdar.CharacterCasing = CharacterCasing.Normal;
            txtMiqdar.Depth = 0;
            txtMiqdar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMiqdar.HideSelection = true;
            txtMiqdar.Hint = "Miqdar";
            txtMiqdar.LeadingIcon = null;
            txtMiqdar.Location = new Point(17, 68);
            txtMiqdar.MaxLength = 32767;
            txtMiqdar.MouseState = MaterialSkin.MouseState.OUT;
            txtMiqdar.Name = "txtMiqdar";
            txtMiqdar.PasswordChar = '\0';
            txtMiqdar.PrefixSuffixText = null;
            txtMiqdar.ReadOnly = false;
            txtMiqdar.RightToLeft = RightToLeft.No;
            txtMiqdar.SelectedText = "";
            txtMiqdar.SelectionLength = 0;
            txtMiqdar.SelectionStart = 0;
            txtMiqdar.ShortcutsEnabled = true;
            txtMiqdar.Size = new Size(336, 48);
            txtMiqdar.TabIndex = 2;
            txtMiqdar.TabStop = false;
            txtMiqdar.TextAlign = HorizontalAlignment.Left;
            txtMiqdar.TrailingIcon = null;
            txtMiqdar.UseSystemPasswordChar = false;
            // 
            // cmbMehsul
            // 
            cmbMehsul.BackColor = Color.FromArgb(255, 255, 255);
            cmbMehsul.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMehsul.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbMehsul.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMehsul.FormattingEnabled = true;
            cmbMehsul.Location = new Point(100, 29);
            cmbMehsul.Name = "cmbMehsul";
            cmbMehsul.Size = new Size(253, 25);
            cmbMehsul.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(255, 255, 255);
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            label1.Location = new Point(17, 32);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "Məhsul:";
            // 
            // AlisSenedFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 728);
            Controls.Add(splitContainer1);
            Name = "AlisSenedFormu";
            Text = "Alış Sənəd İdarəetməsi";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSenetler).EndInit();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSenedSetirleri).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
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
