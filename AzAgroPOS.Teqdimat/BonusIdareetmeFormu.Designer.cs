namespace AzAgroPOS.Teqdimat
{
    partial class BonusIdareetmeFormu
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
            tabControl = new TabControl();
            tabMusteriBonus = new TabPage();
            grpBonusTarixcesi = new GroupBox();
            dgvBonusTarixcesi = new DataGridView();
            grpBonusEmeliyyatlari = new GroupBox();
            btnManualElaveEt = new MaterialSkin.Controls.MaterialButton();
            btnBalLegvEt = new MaterialSkin.Controls.MaterialButton();
            btnBalIstifadeEt = new MaterialSkin.Controls.MaterialButton();
            btnBalElaveEt = new MaterialSkin.Controls.MaterialButton();
            txtAciklama = new TextBox();
            lblAciklama = new Label();
            numBalMiqdari = new NumericUpDown();
            lblBalMiqdari = new Label();
            grpMusteriBonusMelumatlari = new GroupBox();
            lblSeviyye = new Label();
            lblMovcudBalDeyer = new Label();
            lblIstifadeBalDeyer = new Label();
            lblToplamBalDeyer = new Label();
            lblSeviyyeBasliq = new Label();
            lblMovcudBalBasliq = new Label();
            lblIstifadeBalBasliq = new Label();
            lblToplamBalBasliq = new Label();
            grpMusteriSecim = new GroupBox();
            cmbMusteri = new ComboBox();
            lblMusteri = new Label();
            tabButunBonuslar = new TabPage();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            dgvButunBonuslar = new DataGridView();
            tabControl.SuspendLayout();
            tabMusteriBonus.SuspendLayout();
            grpBonusTarixcesi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBonusTarixcesi).BeginInit();
            grpBonusEmeliyyatlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBalMiqdari).BeginInit();
            grpMusteriBonusMelumatlari.SuspendLayout();
            grpMusteriSecim.SuspendLayout();
            tabButunBonuslar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvButunBonuslar).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabMusteriBonus);
            tabControl.Controls.Add(tabButunBonuslar);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tabControl.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tabControl.Location = new Point(3, 64);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1394, 711);
            tabControl.TabIndex = 0;
            // 
            // tabMusteriBonus
            // 
            tabMusteriBonus.BackColor = Color.FromArgb(242, 242, 242);
            tabMusteriBonus.Controls.Add(grpBonusTarixcesi);
            tabMusteriBonus.Controls.Add(grpBonusEmeliyyatlari);
            tabMusteriBonus.Controls.Add(grpMusteriBonusMelumatlari);
            tabMusteriBonus.Controls.Add(grpMusteriSecim);
            tabMusteriBonus.Location = new Point(4, 26);
            tabMusteriBonus.Name = "tabMusteriBonus";
            tabMusteriBonus.Padding = new Padding(3);
            tabMusteriBonus.Size = new Size(1386, 681);
            tabMusteriBonus.TabIndex = 0;
            tabMusteriBonus.Text = "Müştəri Bonus İdarəetməsi";
            // 
            // grpBonusTarixcesi
            // 
            grpBonusTarixcesi.BackColor = Color.FromArgb(242, 242, 242);
            grpBonusTarixcesi.Controls.Add(dgvBonusTarixcesi);
            grpBonusTarixcesi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpBonusTarixcesi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpBonusTarixcesi.Location = new Point(20, 310);
            grpBonusTarixcesi.Name = "grpBonusTarixcesi";
            grpBonusTarixcesi.Size = new Size(1340, 370);
            grpBonusTarixcesi.TabIndex = 3;
            grpBonusTarixcesi.TabStop = false;
            grpBonusTarixcesi.Text = "Bonus Tarixçəsi";
            // 
            // dgvBonusTarixcesi
            // 
            dgvBonusTarixcesi.AllowUserToAddRows = false;
            dgvBonusTarixcesi.AllowUserToDeleteRows = false;
            dgvBonusTarixcesi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBonusTarixcesi.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBonusTarixcesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBonusTarixcesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBonusTarixcesi.Dock = DockStyle.Fill;
            dgvBonusTarixcesi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvBonusTarixcesi.Location = new Point(3, 20);
            dgvBonusTarixcesi.MultiSelect = false;
            dgvBonusTarixcesi.Name = "dgvBonusTarixcesi";
            dgvBonusTarixcesi.ReadOnly = true;
            dgvBonusTarixcesi.RowHeadersVisible = false;
            dgvBonusTarixcesi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBonusTarixcesi.Size = new Size(1334, 347);
            dgvBonusTarixcesi.TabIndex = 0;
            // 
            // grpBonusEmeliyyatlari
            // 
            grpBonusEmeliyyatlari.BackColor = Color.FromArgb(242, 242, 242);
            grpBonusEmeliyyatlari.Controls.Add(btnManualElaveEt);
            grpBonusEmeliyyatlari.Controls.Add(btnBalLegvEt);
            grpBonusEmeliyyatlari.Controls.Add(btnBalIstifadeEt);
            grpBonusEmeliyyatlari.Controls.Add(btnBalElaveEt);
            grpBonusEmeliyyatlari.Controls.Add(txtAciklama);
            grpBonusEmeliyyatlari.Controls.Add(lblAciklama);
            grpBonusEmeliyyatlari.Controls.Add(numBalMiqdari);
            grpBonusEmeliyyatlari.Controls.Add(lblBalMiqdari);
            grpBonusEmeliyyatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpBonusEmeliyyatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpBonusEmeliyyatlari.Location = new Point(520, 20);
            grpBonusEmeliyyatlari.Name = "grpBonusEmeliyyatlari";
            grpBonusEmeliyyatlari.Size = new Size(840, 270);
            grpBonusEmeliyyatlari.TabIndex = 2;
            grpBonusEmeliyyatlari.TabStop = false;
            grpBonusEmeliyyatlari.Text = "Bonus Əməliyyatları";
            // 
            // btnManualElaveEt
            // 
            btnManualElaveEt.AutoSize = false;
            btnManualElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnManualElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnManualElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnManualElaveEt.Depth = 0;
            btnManualElaveEt.Enabled = false;
            btnManualElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnManualElaveEt.HighEmphasis = true;
            btnManualElaveEt.Icon = null;
            btnManualElaveEt.Location = new Point(630, 200);
            btnManualElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnManualElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnManualElaveEt.Name = "btnManualElaveEt";
            btnManualElaveEt.NoAccentTextColor = Color.Empty;
            btnManualElaveEt.Size = new Size(180, 40);
            btnManualElaveEt.TabIndex = 7;
            btnManualElaveEt.Text = "MANUAL ƏLAVƏ ET";
            btnManualElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnManualElaveEt.UseAccentColor = false;
            btnManualElaveEt.UseVisualStyleBackColor = false;
            btnManualElaveEt.Click += btnManualElaveEt_Click;
            // 
            // btnBalLegvEt
            // 
            btnBalLegvEt.AutoSize = false;
            btnBalLegvEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBalLegvEt.BackColor = Color.FromArgb(242, 242, 242);
            btnBalLegvEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBalLegvEt.Depth = 0;
            btnBalLegvEt.Enabled = false;
            btnBalLegvEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBalLegvEt.HighEmphasis = true;
            btnBalLegvEt.Icon = null;
            btnBalLegvEt.Location = new Point(420, 200);
            btnBalLegvEt.Margin = new Padding(4, 6, 4, 6);
            btnBalLegvEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnBalLegvEt.Name = "btnBalLegvEt";
            btnBalLegvEt.NoAccentTextColor = Color.Empty;
            btnBalLegvEt.Size = new Size(180, 40);
            btnBalLegvEt.TabIndex = 6;
            btnBalLegvEt.Text = "BAL LƏĞV ET";
            btnBalLegvEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBalLegvEt.UseAccentColor = false;
            btnBalLegvEt.UseVisualStyleBackColor = false;
            btnBalLegvEt.Click += btnBalLegvEt_Click;
            // 
            // btnBalIstifadeEt
            // 
            btnBalIstifadeEt.AutoSize = false;
            btnBalIstifadeEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBalIstifadeEt.BackColor = Color.FromArgb(242, 242, 242);
            btnBalIstifadeEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBalIstifadeEt.Depth = 0;
            btnBalIstifadeEt.Enabled = false;
            btnBalIstifadeEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBalIstifadeEt.HighEmphasis = true;
            btnBalIstifadeEt.Icon = null;
            btnBalIstifadeEt.Location = new Point(210, 200);
            btnBalIstifadeEt.Margin = new Padding(4, 6, 4, 6);
            btnBalIstifadeEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnBalIstifadeEt.Name = "btnBalIstifadeEt";
            btnBalIstifadeEt.NoAccentTextColor = Color.Empty;
            btnBalIstifadeEt.Size = new Size(180, 40);
            btnBalIstifadeEt.TabIndex = 5;
            btnBalIstifadeEt.Text = "BAL İSTİFADƏ ET";
            btnBalIstifadeEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBalIstifadeEt.UseAccentColor = false;
            btnBalIstifadeEt.UseVisualStyleBackColor = false;
            btnBalIstifadeEt.Click += btnBalIstifadeEt_Click;
            // 
            // btnBalElaveEt
            // 
            btnBalElaveEt.AutoSize = false;
            btnBalElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBalElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnBalElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBalElaveEt.Depth = 0;
            btnBalElaveEt.Enabled = false;
            btnBalElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBalElaveEt.HighEmphasis = true;
            btnBalElaveEt.Icon = null;
            btnBalElaveEt.Location = new Point(20, 200);
            btnBalElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnBalElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnBalElaveEt.Name = "btnBalElaveEt";
            btnBalElaveEt.NoAccentTextColor = Color.Empty;
            btnBalElaveEt.Size = new Size(180, 40);
            btnBalElaveEt.TabIndex = 4;
            btnBalElaveEt.Text = "BAL ƏLAVƏ ET";
            btnBalElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBalElaveEt.UseAccentColor = false;
            btnBalElaveEt.UseVisualStyleBackColor = false;
            btnBalElaveEt.Click += btnBalElaveEt_Click;
            // 
            // txtAciklama
            // 
            txtAciklama.BackColor = Color.FromArgb(242, 242, 242);
            txtAciklama.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAciklama.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtAciklama.Location = new Point(130, 85);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(680, 90);
            txtAciklama.TabIndex = 3;
            // 
            // lblAciklama
            // 
            lblAciklama.AutoSize = true;
            lblAciklama.BackColor = Color.FromArgb(242, 242, 242);
            lblAciklama.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAciklama.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblAciklama.Location = new Point(20, 88);
            lblAciklama.Name = "lblAciklama";
            lblAciklama.Size = new Size(69, 17);
            lblAciklama.TabIndex = 2;
            lblAciklama.Text = "Açıqlama:";
            // 
            // numBalMiqdari
            // 
            numBalMiqdari.BackColor = Color.FromArgb(242, 242, 242);
            numBalMiqdari.DecimalPlaces = 2;
            numBalMiqdari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numBalMiqdari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numBalMiqdari.Location = new Point(130, 40);
            numBalMiqdari.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numBalMiqdari.Name = "numBalMiqdari";
            numBalMiqdari.Size = new Size(200, 24);
            numBalMiqdari.TabIndex = 1;
            numBalMiqdari.TextAlign = HorizontalAlignment.Right;
            // 
            // lblBalMiqdari
            // 
            lblBalMiqdari.AutoSize = true;
            lblBalMiqdari.BackColor = Color.FromArgb(242, 242, 242);
            lblBalMiqdari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBalMiqdari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBalMiqdari.Location = new Point(20, 42);
            lblBalMiqdari.Name = "lblBalMiqdari";
            lblBalMiqdari.Size = new Size(81, 17);
            lblBalMiqdari.TabIndex = 0;
            lblBalMiqdari.Text = "Bal Miqdarı:";
            // 
            // grpMusteriBonusMelumatlari
            // 
            grpMusteriBonusMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            grpMusteriBonusMelumatlari.Controls.Add(lblSeviyye);
            grpMusteriBonusMelumatlari.Controls.Add(lblMovcudBalDeyer);
            grpMusteriBonusMelumatlari.Controls.Add(lblIstifadeBalDeyer);
            grpMusteriBonusMelumatlari.Controls.Add(lblToplamBalDeyer);
            grpMusteriBonusMelumatlari.Controls.Add(lblSeviyyeBasliq);
            grpMusteriBonusMelumatlari.Controls.Add(lblMovcudBalBasliq);
            grpMusteriBonusMelumatlari.Controls.Add(lblIstifadeBalBasliq);
            grpMusteriBonusMelumatlari.Controls.Add(lblToplamBalBasliq);
            grpMusteriBonusMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpMusteriBonusMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpMusteriBonusMelumatlari.Location = new Point(20, 110);
            grpMusteriBonusMelumatlari.Name = "grpMusteriBonusMelumatlari";
            grpMusteriBonusMelumatlari.Size = new Size(480, 180);
            grpMusteriBonusMelumatlari.TabIndex = 1;
            grpMusteriBonusMelumatlari.TabStop = false;
            grpMusteriBonusMelumatlari.Text = "Bonus Məlumatları";
            // 
            // lblSeviyye
            // 
            lblSeviyye.AutoSize = true;
            lblSeviyye.BackColor = Color.FromArgb(242, 242, 242);
            lblSeviyye.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSeviyye.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSeviyye.Location = new Point(200, 135);
            lblSeviyye.Name = "lblSeviyye";
            lblSeviyye.Size = new Size(12, 17);
            lblSeviyye.TabIndex = 7;
            lblSeviyye.Text = "-";
            // 
            // lblMovcudBalDeyer
            // 
            lblMovcudBalDeyer.AutoSize = true;
            lblMovcudBalDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblMovcudBalDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMovcudBalDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMovcudBalDeyer.Location = new Point(200, 95);
            lblMovcudBalDeyer.Name = "lblMovcudBalDeyer";
            lblMovcudBalDeyer.Size = new Size(36, 17);
            lblMovcudBalDeyer.TabIndex = 6;
            lblMovcudBalDeyer.Text = "0.00";
            // 
            // lblIstifadeBalDeyer
            // 
            lblIstifadeBalDeyer.AutoSize = true;
            lblIstifadeBalDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblIstifadeBalDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblIstifadeBalDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblIstifadeBalDeyer.Location = new Point(200, 65);
            lblIstifadeBalDeyer.Name = "lblIstifadeBalDeyer";
            lblIstifadeBalDeyer.Size = new Size(36, 17);
            lblIstifadeBalDeyer.TabIndex = 5;
            lblIstifadeBalDeyer.Text = "0.00";
            // 
            // lblToplamBalDeyer
            // 
            lblToplamBalDeyer.AutoSize = true;
            lblToplamBalDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblToplamBalDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblToplamBalDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblToplamBalDeyer.Location = new Point(200, 35);
            lblToplamBalDeyer.Name = "lblToplamBalDeyer";
            lblToplamBalDeyer.Size = new Size(36, 17);
            lblToplamBalDeyer.TabIndex = 4;
            lblToplamBalDeyer.Text = "0.00";
            // 
            // lblSeviyyeBasliq
            // 
            lblSeviyyeBasliq.AutoSize = true;
            lblSeviyyeBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblSeviyyeBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSeviyyeBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSeviyyeBasliq.Location = new Point(20, 137);
            lblSeviyyeBasliq.Name = "lblSeviyyeBasliq";
            lblSeviyyeBasliq.Size = new Size(107, 17);
            lblSeviyyeBasliq.TabIndex = 3;
            lblSeviyyeBasliq.Text = "Müştəri Səviyyə:";
            // 
            // lblMovcudBalBasliq
            // 
            lblMovcudBalBasliq.AutoSize = true;
            lblMovcudBalBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblMovcudBalBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMovcudBalBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMovcudBalBasliq.Location = new Point(20, 99);
            lblMovcudBalBasliq.Name = "lblMovcudBalBasliq";
            lblMovcudBalBasliq.Size = new Size(84, 17);
            lblMovcudBalBasliq.TabIndex = 2;
            lblMovcudBalBasliq.Text = "Mövcud Bal:";
            // 
            // lblIstifadeBalBasliq
            // 
            lblIstifadeBalBasliq.AutoSize = true;
            lblIstifadeBalBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblIstifadeBalBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblIstifadeBalBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblIstifadeBalBasliq.Location = new Point(20, 67);
            lblIstifadeBalBasliq.Name = "lblIstifadeBalBasliq";
            lblIstifadeBalBasliq.Size = new Size(128, 17);
            lblIstifadeBalBasliq.TabIndex = 1;
            lblIstifadeBalBasliq.Text = "İstifadə Edilmiş Bal:";
            // 
            // lblToplamBalBasliq
            // 
            lblToplamBalBasliq.AutoSize = true;
            lblToplamBalBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblToplamBalBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblToplamBalBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblToplamBalBasliq.Location = new Point(20, 37);
            lblToplamBalBasliq.Name = "lblToplamBalBasliq";
            lblToplamBalBasliq.Size = new Size(80, 17);
            lblToplamBalBasliq.TabIndex = 0;
            lblToplamBalBasliq.Text = "Toplam Bal:";
            // 
            // grpMusteriSecim
            // 
            grpMusteriSecim.BackColor = Color.FromArgb(242, 242, 242);
            grpMusteriSecim.Controls.Add(cmbMusteri);
            grpMusteriSecim.Controls.Add(lblMusteri);
            grpMusteriSecim.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpMusteriSecim.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpMusteriSecim.Location = new Point(20, 20);
            grpMusteriSecim.Name = "grpMusteriSecim";
            grpMusteriSecim.Size = new Size(480, 80);
            grpMusteriSecim.TabIndex = 0;
            grpMusteriSecim.TabStop = false;
            grpMusteriSecim.Text = "Müştəri Seçimi";
            // 
            // cmbMusteri
            // 
            cmbMusteri.BackColor = Color.FromArgb(242, 242, 242);
            cmbMusteri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbMusteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Location = new Point(110, 35);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(350, 25);
            cmbMusteri.TabIndex = 1;
            cmbMusteri.SelectedIndexChanged += cmbMusteri_SelectedIndexChanged;
            // 
            // lblMusteri
            // 
            lblMusteri.AutoSize = true;
            lblMusteri.BackColor = Color.FromArgb(242, 242, 242);
            lblMusteri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMusteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMusteri.Location = new Point(20, 38);
            lblMusteri.Name = "lblMusteri";
            lblMusteri.Size = new Size(58, 17);
            lblMusteri.TabIndex = 0;
            lblMusteri.Text = "Müştəri:";
            // 
            // tabButunBonuslar
            // 
            tabButunBonuslar.BackColor = Color.FromArgb(242, 242, 242);
            tabButunBonuslar.Controls.Add(btnYenile);
            tabButunBonuslar.Controls.Add(dgvButunBonuslar);
            tabButunBonuslar.Location = new Point(4, 26);
            tabButunBonuslar.Name = "tabButunBonuslar";
            tabButunBonuslar.Padding = new Padding(3);
            tabButunBonuslar.Size = new Size(1386, 681);
            tabButunBonuslar.TabIndex = 1;
            tabButunBonuslar.Text = "Bütün Müştəri Bonusları";
            // 
            // btnYenile
            // 
            btnYenile.AutoSize = false;
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(1229, 9);
            btnYenile.Margin = new Padding(4, 6, 4, 6);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(150, 40);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "YENİLƏ";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // dgvButunBonuslar
            // 
            dgvButunBonuslar.AllowUserToAddRows = false;
            dgvButunBonuslar.AllowUserToDeleteRows = false;
            dgvButunBonuslar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvButunBonuslar.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvButunBonuslar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvButunBonuslar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvButunBonuslar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvButunBonuslar.Location = new Point(3, 3);
            dgvButunBonuslar.MultiSelect = false;
            dgvButunBonuslar.Name = "dgvButunBonuslar";
            dgvButunBonuslar.ReadOnly = true;
            dgvButunBonuslar.RowHeadersVisible = false;
            dgvButunBonuslar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvButunBonuslar.Size = new Size(1219, 697);
            dgvButunBonuslar.TabIndex = 0;
            // 
            // BonusIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 800);
            Controls.Add(tabControl);
            Name = "BonusIdareetmeFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bonus İdarəetməsi";
            Controls.SetChildIndex(tabControl, 0);
            tabControl.ResumeLayout(false);
            tabMusteriBonus.ResumeLayout(false);
            grpBonusTarixcesi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBonusTarixcesi).EndInit();
            grpBonusEmeliyyatlari.ResumeLayout(false);
            grpBonusEmeliyyatlari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBalMiqdari).EndInit();
            grpMusteriBonusMelumatlari.ResumeLayout(false);
            grpMusteriBonusMelumatlari.PerformLayout();
            grpMusteriSecim.ResumeLayout(false);
            grpMusteriSecim.PerformLayout();
            tabButunBonuslar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvButunBonuslar).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMusteriBonus;
        private System.Windows.Forms.TabPage tabButunBonuslar;
        private System.Windows.Forms.GroupBox grpMusteriSecim;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.GroupBox grpMusteriBonusMelumatlari;
        private System.Windows.Forms.Label lblToplamBalBasliq;
        private System.Windows.Forms.Label lblIstifadeBalBasliq;
        private System.Windows.Forms.Label lblMovcudBalBasliq;
        private System.Windows.Forms.Label lblSeviyyeBasliq;
        private System.Windows.Forms.Label lblToplamBalDeyer;
        private System.Windows.Forms.Label lblIstifadeBalDeyer;
        private System.Windows.Forms.Label lblMovcudBalDeyer;
        private System.Windows.Forms.Label lblSeviyye;
        private System.Windows.Forms.GroupBox grpBonusEmeliyyatlari;
        private System.Windows.Forms.Label lblBalMiqdari;
        private System.Windows.Forms.NumericUpDown numBalMiqdari;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.TextBox txtAciklama;
        private MaterialSkin.Controls.MaterialButton btnBalElaveEt;
        private MaterialSkin.Controls.MaterialButton btnBalIstifadeEt;
        private MaterialSkin.Controls.MaterialButton btnBalLegvEt;
        private MaterialSkin.Controls.MaterialButton btnManualElaveEt;
        private System.Windows.Forms.GroupBox grpBonusTarixcesi;
        private System.Windows.Forms.DataGridView dgvBonusTarixcesi;
        private System.Windows.Forms.DataGridView dgvButunBonuslar;
        private MaterialSkin.Controls.MaterialButton btnYenile;
    }
}
