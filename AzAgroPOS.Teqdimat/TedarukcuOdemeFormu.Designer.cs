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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblBasliq = new MaterialSkin.Controls.MaterialLabel();
            panelForm = new Panel();
            txtBankMelumatlari = new MaterialSkin.Controls.MaterialTextBox();
            lblBankMelumatlari = new MaterialSkin.Controls.MaterialLabel();
            txtQeydler = new MaterialSkin.Controls.MaterialTextBox();
            lblQeydler = new MaterialSkin.Controls.MaterialLabel();
            cmbStatus = new ComboBox();
            lblStatus = new MaterialSkin.Controls.MaterialLabel();
            cmbOdemeUsulu = new ComboBox();
            lblOdemeUsulu = new MaterialSkin.Controls.MaterialLabel();
            numMebleg = new NumericUpDown();
            lblMebleg = new MaterialSkin.Controls.MaterialLabel();
            dtpOdemeTarixi = new DateTimePicker();
            lblOdemeTarixi = new MaterialSkin.Controls.MaterialLabel();
            cmbAlisSened = new ComboBox();
            lblAlisSened = new MaterialSkin.Controls.MaterialLabel();
            cmbTedarukcu = new ComboBox();
            lblTedarukcu = new MaterialSkin.Controls.MaterialLabel();
            dtpYaradilmaTarixi = new DateTimePicker();
            lblYaradilmaTarixi = new MaterialSkin.Controls.MaterialLabel();
            txtOdemeNomresi = new MaterialSkin.Controls.MaterialTextBox();
            lblOdemeNomresi = new MaterialSkin.Controls.MaterialLabel();
            panelGrid = new Panel();
            dgvOdemeler = new DataGridView();
            panelButtons = new Panel();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            btnYarat = new MaterialSkin.Controls.MaterialButton();
            panelTop.SuspendLayout();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMebleg).BeginInit();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOdemeler).BeginInit();
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
            lblBasliq.Location = new Point(18, 17);
            lblBasliq.Margin = new Padding(4, 0, 4, 0);
            lblBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblBasliq.Name = "lblBasliq";
            lblBasliq.Size = new Size(228, 29);
            lblBasliq.TabIndex = 0;
            lblBasliq.Text = "Tədarükçü Ödənişləri";
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.FromArgb(242, 242, 242);
            panelForm.Controls.Add(txtBankMelumatlari);
            panelForm.Controls.Add(lblBankMelumatlari);
            panelForm.Controls.Add(txtQeydler);
            panelForm.Controls.Add(lblQeydler);
            panelForm.Controls.Add(cmbStatus);
            panelForm.Controls.Add(lblStatus);
            panelForm.Controls.Add(cmbOdemeUsulu);
            panelForm.Controls.Add(lblOdemeUsulu);
            panelForm.Controls.Add(numMebleg);
            panelForm.Controls.Add(lblMebleg);
            panelForm.Controls.Add(dtpOdemeTarixi);
            panelForm.Controls.Add(lblOdemeTarixi);
            panelForm.Controls.Add(cmbAlisSened);
            panelForm.Controls.Add(lblAlisSened);
            panelForm.Controls.Add(cmbTedarukcu);
            panelForm.Controls.Add(lblTedarukcu);
            panelForm.Controls.Add(dtpYaradilmaTarixi);
            panelForm.Controls.Add(lblYaradilmaTarixi);
            panelForm.Controls.Add(txtOdemeNomresi);
            panelForm.Controls.Add(lblOdemeNomresi);
            panelForm.Dock = DockStyle.Top;
            panelForm.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelForm.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelForm.Location = new Point(4, 143);
            panelForm.Margin = new Padding(4, 3, 4, 3);
            panelForm.Name = "panelForm";
            panelForm.Padding = new Padding(12, 12, 12, 12);
            panelForm.Size = new Size(1392, 323);
            panelForm.TabIndex = 1;
            // 
            // txtBankMelumatlari
            // 
            txtBankMelumatlari.AnimateReadOnly = false;
            txtBankMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            txtBankMelumatlari.BorderStyle = BorderStyle.None;
            txtBankMelumatlari.Depth = 0;
            txtBankMelumatlari.Enabled = false;
            txtBankMelumatlari.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBankMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBankMelumatlari.LeadingIcon = null;
            txtBankMelumatlari.Location = new Point(735, 254);
            txtBankMelumatlari.Margin = new Padding(4, 3, 4, 3);
            txtBankMelumatlari.MaxLength = 500;
            txtBankMelumatlari.MouseState = MaterialSkin.MouseState.OUT;
            txtBankMelumatlari.Multiline = false;
            txtBankMelumatlari.Name = "txtBankMelumatlari";
            txtBankMelumatlari.Size = new Size(642, 50);
            txtBankMelumatlari.TabIndex = 19;
            txtBankMelumatlari.Text = "";
            txtBankMelumatlari.TrailingIcon = null;
            // 
            // lblBankMelumatlari
            // 
            lblBankMelumatlari.AutoSize = true;
            lblBankMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            lblBankMelumatlari.Depth = 0;
            lblBankMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBankMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBankMelumatlari.Location = new Point(735, 225);
            lblBankMelumatlari.Margin = new Padding(4, 0, 4, 0);
            lblBankMelumatlari.MouseState = MaterialSkin.MouseState.HOVER;
            lblBankMelumatlari.Name = "lblBankMelumatlari";
            lblBankMelumatlari.Size = new Size(130, 19);
            lblBankMelumatlari.TabIndex = 18;
            lblBankMelumatlari.Text = "Bank Məlumatları:";
            // 
            // txtQeydler
            // 
            txtQeydler.AnimateReadOnly = false;
            txtQeydler.BackColor = Color.FromArgb(242, 242, 242);
            txtQeydler.BorderStyle = BorderStyle.None;
            txtQeydler.Depth = 0;
            txtQeydler.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeydler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtQeydler.LeadingIcon = null;
            txtQeydler.Location = new Point(18, 254);
            txtQeydler.Margin = new Padding(4, 3, 4, 3);
            txtQeydler.MaxLength = 500;
            txtQeydler.MouseState = MaterialSkin.MouseState.OUT;
            txtQeydler.Multiline = false;
            txtQeydler.Name = "txtQeydler";
            txtQeydler.Size = new Size(700, 50);
            txtQeydler.TabIndex = 17;
            txtQeydler.Text = "";
            txtQeydler.TrailingIcon = null;
            // 
            // lblQeydler
            // 
            lblQeydler.AutoSize = true;
            lblQeydler.BackColor = Color.FromArgb(242, 242, 242);
            lblQeydler.Depth = 0;
            lblQeydler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQeydler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblQeydler.Location = new Point(18, 225);
            lblQeydler.Margin = new Padding(4, 0, 4, 0);
            lblQeydler.MouseState = MaterialSkin.MouseState.HOVER;
            lblQeydler.Name = "lblQeydler";
            lblQeydler.Size = new Size(58, 19);
            lblQeydler.TabIndex = 16;
            lblQeydler.Text = "Qeydlər:";
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.FromArgb(242, 242, 242);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(1027, 173);
            cmbStatus.Margin = new Padding(4, 3, 4, 3);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(349, 25);
            cmbStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.FromArgb(242, 242, 242);
            lblStatus.Depth = 0;
            lblStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblStatus.Location = new Point(1027, 144);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(51, 19);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "Status:";
            // 
            // cmbOdemeUsulu
            // 
            cmbOdemeUsulu.BackColor = Color.FromArgb(242, 242, 242);
            cmbOdemeUsulu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOdemeUsulu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbOdemeUsulu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbOdemeUsulu.FormattingEnabled = true;
            cmbOdemeUsulu.Location = new Point(519, 173);
            cmbOdemeUsulu.Margin = new Padding(4, 3, 4, 3);
            cmbOdemeUsulu.Name = "cmbOdemeUsulu";
            cmbOdemeUsulu.Size = new Size(489, 25);
            cmbOdemeUsulu.TabIndex = 13;
            cmbOdemeUsulu.SelectedIndexChanged += cmbOdemeUsulu_SelectedIndexChanged;
            // 
            // lblOdemeUsulu
            // 
            lblOdemeUsulu.AutoSize = true;
            lblOdemeUsulu.BackColor = Color.FromArgb(242, 242, 242);
            lblOdemeUsulu.Depth = 0;
            lblOdemeUsulu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOdemeUsulu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblOdemeUsulu.Location = new Point(519, 144);
            lblOdemeUsulu.Margin = new Padding(4, 0, 4, 0);
            lblOdemeUsulu.MouseState = MaterialSkin.MouseState.HOVER;
            lblOdemeUsulu.Name = "lblOdemeUsulu";
            lblOdemeUsulu.Size = new Size(98, 19);
            lblOdemeUsulu.TabIndex = 12;
            lblOdemeUsulu.Text = "Ödəniş Üsulu:";
            // 
            // numMebleg
            // 
            numMebleg.BackColor = Color.FromArgb(242, 242, 242);
            numMebleg.DecimalPlaces = 2;
            numMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numMebleg.Location = new Point(18, 173);
            numMebleg.Margin = new Padding(4, 3, 4, 3);
            numMebleg.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMebleg.Name = "numMebleg";
            numMebleg.Size = new Size(484, 24);
            numMebleg.TabIndex = 11;
            numMebleg.ThousandsSeparator = true;
            // 
            // lblMebleg
            // 
            lblMebleg.AutoSize = true;
            lblMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblMebleg.Depth = 0;
            lblMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMebleg.Location = new Point(18, 144);
            lblMebleg.Margin = new Padding(4, 0, 4, 0);
            lblMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblMebleg.Name = "lblMebleg";
            lblMebleg.Size = new Size(57, 19);
            lblMebleg.TabIndex = 10;
            lblMebleg.Text = "Məbləğ:";
            // 
            // dtpOdemeTarixi
            // 
            dtpOdemeTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpOdemeTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpOdemeTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpOdemeTarixi.Format = DateTimePickerFormat.Short;
            dtpOdemeTarixi.Location = new Point(1027, 92);
            dtpOdemeTarixi.Margin = new Padding(4, 3, 4, 3);
            dtpOdemeTarixi.Name = "dtpOdemeTarixi";
            dtpOdemeTarixi.Size = new Size(349, 24);
            dtpOdemeTarixi.TabIndex = 9;
            // 
            // lblOdemeTarixi
            // 
            lblOdemeTarixi.AutoSize = true;
            lblOdemeTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblOdemeTarixi.Depth = 0;
            lblOdemeTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOdemeTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblOdemeTarixi.Location = new Point(1027, 63);
            lblOdemeTarixi.Margin = new Padding(4, 0, 4, 0);
            lblOdemeTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            lblOdemeTarixi.Name = "lblOdemeTarixi";
            lblOdemeTarixi.Size = new Size(98, 19);
            lblOdemeTarixi.TabIndex = 8;
            lblOdemeTarixi.Text = "Ödəniş Tarixi:";
            // 
            // cmbAlisSened
            // 
            cmbAlisSened.BackColor = Color.FromArgb(242, 242, 242);
            cmbAlisSened.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlisSened.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbAlisSened.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbAlisSened.FormattingEnabled = true;
            cmbAlisSened.Location = new Point(519, 92);
            cmbAlisSened.Margin = new Padding(4, 3, 4, 3);
            cmbAlisSened.Name = "cmbAlisSened";
            cmbAlisSened.Size = new Size(489, 25);
            cmbAlisSened.TabIndex = 7;
            // 
            // lblAlisSened
            // 
            lblAlisSened.AutoSize = true;
            lblAlisSened.BackColor = Color.FromArgb(242, 242, 242);
            lblAlisSened.Depth = 0;
            lblAlisSened.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAlisSened.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblAlisSened.Location = new Point(519, 63);
            lblAlisSened.Margin = new Padding(4, 0, 4, 0);
            lblAlisSened.MouseState = MaterialSkin.MouseState.HOVER;
            lblAlisSened.Name = "lblAlisSened";
            lblAlisSened.Size = new Size(145, 19);
            lblAlisSened.TabIndex = 6;
            lblAlisSened.Text = "Alış Sənədi (İxtiyari):";
            // 
            // cmbTedarukcu
            // 
            cmbTedarukcu.BackColor = Color.FromArgb(242, 242, 242);
            cmbTedarukcu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTedarukcu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTedarukcu.FormattingEnabled = true;
            cmbTedarukcu.Location = new Point(18, 92);
            cmbTedarukcu.Margin = new Padding(4, 3, 4, 3);
            cmbTedarukcu.Name = "cmbTedarukcu";
            cmbTedarukcu.Size = new Size(483, 25);
            cmbTedarukcu.TabIndex = 5;
            // 
            // lblTedarukcu
            // 
            lblTedarukcu.AutoSize = true;
            lblTedarukcu.BackColor = Color.FromArgb(242, 242, 242);
            lblTedarukcu.Depth = 0;
            lblTedarukcu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTedarukcu.Location = new Point(18, 63);
            lblTedarukcu.Margin = new Padding(4, 0, 4, 0);
            lblTedarukcu.MouseState = MaterialSkin.MouseState.HOVER;
            lblTedarukcu.Name = "lblTedarukcu";
            lblTedarukcu.Size = new Size(80, 19);
            lblTedarukcu.TabIndex = 4;
            lblTedarukcu.Text = "Tədarükçü:";
            // 
            // dtpYaradilmaTarixi
            // 
            dtpYaradilmaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpYaradilmaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpYaradilmaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpYaradilmaTarixi.Format = DateTimePickerFormat.Short;
            dtpYaradilmaTarixi.Location = new Point(735, 17);
            dtpYaradilmaTarixi.Margin = new Padding(4, 3, 4, 3);
            dtpYaradilmaTarixi.Name = "dtpYaradilmaTarixi";
            dtpYaradilmaTarixi.Size = new Size(641, 24);
            dtpYaradilmaTarixi.TabIndex = 3;
            // 
            // lblYaradilmaTarixi
            // 
            lblYaradilmaTarixi.AutoSize = true;
            lblYaradilmaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblYaradilmaTarixi.Depth = 0;
            lblYaradilmaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblYaradilmaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblYaradilmaTarixi.Location = new Point(572, 23);
            lblYaradilmaTarixi.Margin = new Padding(4, 0, 4, 0);
            lblYaradilmaTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            lblYaradilmaTarixi.Name = "lblYaradilmaTarixi";
            lblYaradilmaTarixi.Size = new Size(122, 19);
            lblYaradilmaTarixi.TabIndex = 2;
            lblYaradilmaTarixi.Text = "Yaradılma Tarixi:";
            // 
            // txtOdemeNomresi
            // 
            txtOdemeNomresi.AnimateReadOnly = false;
            txtOdemeNomresi.BackColor = Color.FromArgb(242, 242, 242);
            txtOdemeNomresi.BorderStyle = BorderStyle.None;
            txtOdemeNomresi.Depth = 0;
            txtOdemeNomresi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtOdemeNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtOdemeNomresi.LeadingIcon = null;
            txtOdemeNomresi.Location = new Point(18, 17);
            txtOdemeNomresi.Margin = new Padding(4, 3, 4, 3);
            txtOdemeNomresi.MaxLength = 50;
            txtOdemeNomresi.MouseState = MaterialSkin.MouseState.OUT;
            txtOdemeNomresi.Multiline = false;
            txtOdemeNomresi.Name = "txtOdemeNomresi";
            txtOdemeNomresi.Size = new Size(484, 50);
            txtOdemeNomresi.TabIndex = 1;
            txtOdemeNomresi.Text = "";
            txtOdemeNomresi.TrailingIcon = null;
            // 
            // lblOdemeNomresi
            // 
            lblOdemeNomresi.AutoSize = true;
            lblOdemeNomresi.BackColor = Color.FromArgb(242, 242, 242);
            lblOdemeNomresi.Depth = 0;
            lblOdemeNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOdemeNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblOdemeNomresi.Location = new Point(18, -6);
            lblOdemeNomresi.Margin = new Padding(4, 0, 4, 0);
            lblOdemeNomresi.MouseState = MaterialSkin.MouseState.HOVER;
            lblOdemeNomresi.Name = "lblOdemeNomresi";
            lblOdemeNomresi.Size = new Size(117, 19);
            lblOdemeNomresi.TabIndex = 0;
            lblOdemeNomresi.Text = "Ödəniş Nömrəsi:";
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.FromArgb(242, 242, 242);
            panelGrid.Controls.Add(dgvOdemeler);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelGrid.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelGrid.Location = new Point(4, 466);
            panelGrid.Margin = new Padding(4, 3, 4, 3);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(12, 12, 12, 12);
            panelGrid.Size = new Size(1392, 327);
            panelGrid.TabIndex = 2;
            // 
            // dgvOdemeler
            // 
            dgvOdemeler.AllowUserToAddRows = false;
            dgvOdemeler.AllowUserToDeleteRows = false;
            dgvOdemeler.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOdemeler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOdemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOdemeler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOdemeler.Dock = DockStyle.Fill;
            dgvOdemeler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvOdemeler.Location = new Point(12, 12);
            dgvOdemeler.Margin = new Padding(4, 3, 4, 3);
            dgvOdemeler.MultiSelect = false;
            dgvOdemeler.Name = "dgvOdemeler";
            dgvOdemeler.ReadOnly = true;
            dgvOdemeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOdemeler.Size = new Size(1368, 303);
            dgvOdemeler.TabIndex = 0;
            dgvOdemeler.SelectionChanged += dgvOdemeler_SelectionChanged;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(242, 242, 242);
            panelButtons.Controls.Add(btnTemizle);
            panelButtons.Controls.Add(btnSil);
            panelButtons.Controls.Add(btnYenile);
            panelButtons.Controls.Add(btnYarat);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelButtons.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelButtons.Location = new Point(4, 793);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(12, 12, 12, 12);
            panelButtons.Size = new Size(1392, 69);
            panelButtons.TabIndex = 3;
            // 
            // btnTemizle
            // 
            btnTemizle.AutoSize = false;
            btnTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemizle.Depth = 0;
            btnTemizle.Dock = DockStyle.Right;
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.HighEmphasis = true;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(1211, 12);
            btnTemizle.Margin = new Padding(5, 7, 5, 7);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(169, 45);
            btnTemizle.TabIndex = 3;
            btnTemizle.Text = "TƏMİZLƏ";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.Dock = DockStyle.Left;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(362, 12);
            btnSil.Margin = new Padding(5, 7, 5, 7);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(175, 45);
            btnSil.TabIndex = 2;
            btnSil.Text = "SİL";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = false;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.AutoSize = false;
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.Dock = DockStyle.Left;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(187, 12);
            btnYenile.Margin = new Padding(5, 7, 5, 7);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(175, 45);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "YENİLƏ";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnYarat
            // 
            btnYarat.AutoSize = false;
            btnYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYarat.Depth = 0;
            btnYarat.Dock = DockStyle.Left;
            btnYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYarat.HighEmphasis = true;
            btnYarat.Icon = null;
            btnYarat.Location = new Point(12, 12);
            btnYarat.Margin = new Padding(5, 7, 5, 7);
            btnYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnYarat.Name = "btnYarat";
            btnYarat.NoAccentTextColor = Color.Empty;
            btnYarat.Size = new Size(175, 45);
            btnYarat.TabIndex = 0;
            btnYarat.Text = "YARAT";
            btnYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYarat.UseAccentColor = false;
            btnYarat.UseVisualStyleBackColor = false;
            btnYarat.Click += btnYarat_Click;
            // 
            // TedarukcuOdemeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 865);
            Controls.Add(panelGrid);
            Controls.Add(panelButtons);
            Controls.Add(panelForm);
            Controls.Add(panelTop);
            Margin = new Padding(4, 3, 4, 3);
            Name = "TedarukcuOdemeFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tədarükçü Ödənişləri";
            Controls.SetChildIndex(panelTop, 0);
            Controls.SetChildIndex(panelForm, 0);
            Controls.SetChildIndex(panelButtons, 0);
            Controls.SetChildIndex(panelGrid, 0);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMebleg).EndInit();
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOdemeler).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

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
