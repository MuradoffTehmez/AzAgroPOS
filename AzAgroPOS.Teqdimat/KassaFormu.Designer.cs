// Fayl: AzAgroPOS.Teqdimat/KassaFormu.Designer.cs
namespace AzAgroPOS.Teqdimat;

partial class KassaFormu
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
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        tabControl = new TabControl();
        tabXercler = new TabPage();
        groupXercForm = new GroupBox();
        btnXercTemizle = new Button();
        btnXercSil = new Button();
        btnXercYenile = new Button();
        btnXercYarat = new Button();
        txtXercQeyd = new TextBox();
        lblXercQeyd = new Label();
        txtSenedNomresi = new TextBox();
        lblSenedNomresi = new Label();
        dtpXercTarix = new DateTimePicker();
        lblXercTarix = new Label();
        numXercMebleg = new NumericUpDown();
        lblXercMebleg = new Label();
        txtXercAd = new TextBox();
        lblXercAd = new Label();
        cmbXercNovu = new ComboBox();
        lblXercNovu = new Label();
        dgvXercler = new DataGridView();
        tabKassaHareketleri = new TabPage();
        groupFiltre = new GroupBox();
        btnFiltrele = new Button();
        dtpBitis = new DateTimePicker();
        lblBitis = new Label();
        dtpBaslangic = new DateTimePicker();
        lblBaslangic = new Label();
        dgvKassaHareketleri = new DataGridView();
        tabMaliyyeXulasesi = new TabPage();
        groupXulase = new GroupBox();
        lblCariBalans = new Label();
        lblMenfeetZerere = new Label();
        lblUmumiXerc = new Label();
        lblUmumiGelir = new Label();
        groupHesabatFiltre = new GroupBox();
        btnHesabatGoster = new Button();
        dtpXesabatBitis = new DateTimePicker();
        lblXesabatBitis = new Label();
        dtpXesabatBaslangic = new DateTimePicker();
        lblXesabatBaslangic = new Label();
        btnYenile = new Button();
        tabControl.SuspendLayout();
        tabXercler.SuspendLayout();
        groupXercForm.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numXercMebleg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvXercler).BeginInit();
        tabKassaHareketleri.SuspendLayout();
        groupFiltre.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKassaHareketleri).BeginInit();
        tabMaliyyeXulasesi.SuspendLayout();
        groupXulase.SuspendLayout();
        groupHesabatFiltre.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabControl.Controls.Add(tabXercler);
        tabControl.Controls.Add(tabKassaHareketleri);
        tabControl.Controls.Add(tabMaliyyeXulasesi);
        tabControl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        tabControl.ForeColor = Color.FromArgb(222, 0, 0, 0);
        tabControl.Location = new Point(6, 73);
        tabControl.Margin = new Padding(3, 2, 3, 2);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1349, 627);
        tabControl.TabIndex = 0;
        // 
        // tabXercler
        // 
        tabXercler.BackColor = Color.FromArgb(242, 242, 242);
        tabXercler.Controls.Add(groupXercForm);
        tabXercler.Controls.Add(dgvXercler);
        tabXercler.Location = new Point(4, 26);
        tabXercler.Margin = new Padding(3, 2, 3, 2);
        tabXercler.Name = "tabXercler";
        tabXercler.Padding = new Padding(3, 2, 3, 2);
        tabXercler.Size = new Size(1341, 597);
        tabXercler.TabIndex = 0;
        tabXercler.Text = "Xərc İdarəetməsi";
        // 
        // groupXercForm
        // 
        groupXercForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupXercForm.BackColor = Color.FromArgb(242, 242, 242);
        groupXercForm.Controls.Add(btnXercTemizle);
        groupXercForm.Controls.Add(btnXercSil);
        groupXercForm.Controls.Add(btnXercYenile);
        groupXercForm.Controls.Add(btnXercYarat);
        groupXercForm.Controls.Add(txtXercQeyd);
        groupXercForm.Controls.Add(lblXercQeyd);
        groupXercForm.Controls.Add(txtSenedNomresi);
        groupXercForm.Controls.Add(lblSenedNomresi);
        groupXercForm.Controls.Add(dtpXercTarix);
        groupXercForm.Controls.Add(lblXercTarix);
        groupXercForm.Controls.Add(numXercMebleg);
        groupXercForm.Controls.Add(lblXercMebleg);
        groupXercForm.Controls.Add(txtXercAd);
        groupXercForm.Controls.Add(lblXercAd);
        groupXercForm.Controls.Add(cmbXercNovu);
        groupXercForm.Controls.Add(lblXercNovu);
        groupXercForm.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupXercForm.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupXercForm.Location = new Point(5, 4);
        groupXercForm.Margin = new Padding(3, 2, 3, 2);
        groupXercForm.Name = "groupXercForm";
        groupXercForm.Padding = new Padding(3, 2, 3, 2);
        groupXercForm.Size = new Size(1332, 135);
        groupXercForm.TabIndex = 1;
        groupXercForm.TabStop = false;
        groupXercForm.Text = "Xərc Məlumatları";
        // 
        // btnXercTemizle
        // 
        btnXercTemizle.BackColor = Color.FromArgb(242, 242, 242);
        btnXercTemizle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnXercTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnXercTemizle.Location = new Point(770, 104);
        btnXercTemizle.Margin = new Padding(3, 2, 3, 2);
        btnXercTemizle.Name = "btnXercTemizle";
        btnXercTemizle.Size = new Size(105, 22);
        btnXercTemizle.TabIndex = 15;
        btnXercTemizle.Text = "Təmizlə";
        btnXercTemizle.UseVisualStyleBackColor = false;
        btnXercTemizle.Click += btnXercTemizle_Click;
        // 
        // btnXercSil
        // 
        btnXercSil.BackColor = Color.FromArgb(242, 242, 242);
        btnXercSil.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnXercSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnXercSil.Location = new Point(542, 104);
        btnXercSil.Margin = new Padding(3, 2, 3, 2);
        btnXercSil.Name = "btnXercSil";
        btnXercSil.Size = new Size(105, 22);
        btnXercSil.TabIndex = 14;
        btnXercSil.Text = "Sil";
        btnXercSil.UseVisualStyleBackColor = false;
        btnXercSil.Click += btnXercSil_Click;
        // 
        // btnXercYenile
        // 
        btnXercYenile.BackColor = Color.FromArgb(242, 242, 242);
        btnXercYenile.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnXercYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnXercYenile.Location = new Point(315, 104);
        btnXercYenile.Margin = new Padding(3, 2, 3, 2);
        btnXercYenile.Name = "btnXercYenile";
        btnXercYenile.Size = new Size(105, 22);
        btnXercYenile.TabIndex = 13;
        btnXercYenile.Text = "Yenilə";
        btnXercYenile.UseVisualStyleBackColor = false;
        btnXercYenile.Click += btnXercYenile_Click;
        // 
        // btnXercYarat
        // 
        btnXercYarat.BackColor = Color.FromArgb(242, 242, 242);
        btnXercYarat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnXercYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnXercYarat.Location = new Point(88, 104);
        btnXercYarat.Margin = new Padding(3, 2, 3, 2);
        btnXercYarat.Name = "btnXercYarat";
        btnXercYarat.Size = new Size(105, 22);
        btnXercYarat.TabIndex = 12;
        btnXercYarat.Text = "Yarat";
        btnXercYarat.UseVisualStyleBackColor = false;
        btnXercYarat.Click += btnXercYarat_Click;
        // 
        // txtXercQeyd
        // 
        txtXercQeyd.BackColor = Color.FromArgb(242, 242, 242);
        txtXercQeyd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtXercQeyd.ForeColor = Color.FromArgb(222, 0, 0, 0);
        txtXercQeyd.Location = new Point(612, 68);
        txtXercQeyd.Margin = new Padding(3, 2, 3, 2);
        txtXercQeyd.Multiline = true;
        txtXercQeyd.Name = "txtXercQeyd";
        txtXercQeyd.Size = new Size(350, 27);
        txtXercQeyd.TabIndex = 11;
        // 
        // lblXercQeyd
        // 
        lblXercQeyd.AutoSize = true;
        lblXercQeyd.BackColor = Color.FromArgb(242, 242, 242);
        lblXercQeyd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXercQeyd.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXercQeyd.Location = new Point(542, 70);
        lblXercQeyd.Name = "lblXercQeyd";
        lblXercQeyd.Size = new Size(43, 17);
        lblXercQeyd.TabIndex = 10;
        lblXercQeyd.Text = "Qeyd:";
        // 
        // txtSenedNomresi
        // 
        txtSenedNomresi.BackColor = Color.FromArgb(242, 242, 242);
        txtSenedNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtSenedNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        txtSenedNomresi.Location = new Point(158, 68);
        txtSenedNomresi.Margin = new Padding(3, 2, 3, 2);
        txtSenedNomresi.Name = "txtSenedNomresi";
        txtSenedNomresi.Size = new Size(350, 24);
        txtSenedNomresi.TabIndex = 9;
        // 
        // lblSenedNomresi
        // 
        lblSenedNomresi.AutoSize = true;
        lblSenedNomresi.BackColor = Color.FromArgb(242, 242, 242);
        lblSenedNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblSenedNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblSenedNomresi.Location = new Point(18, 70);
        lblSenedNomresi.Name = "lblSenedNomresi";
        lblSenedNomresi.Size = new Size(66, 17);
        lblSenedNomresi.TabIndex = 8;
        lblSenedNomresi.Text = "Sənəd №:";
        // 
        // dtpXercTarix
        // 
        dtpXercTarix.BackColor = Color.FromArgb(242, 242, 242);
        dtpXercTarix.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpXercTarix.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpXercTarix.Format = DateTimePickerFormat.Short;
        dtpXercTarix.Location = new Point(788, 22);
        dtpXercTarix.Margin = new Padding(3, 2, 3, 2);
        dtpXercTarix.Name = "dtpXercTarix";
        dtpXercTarix.Size = new Size(176, 24);
        dtpXercTarix.TabIndex = 7;
        // 
        // lblXercTarix
        // 
        lblXercTarix.AutoSize = true;
        lblXercTarix.BackColor = Color.FromArgb(242, 242, 242);
        lblXercTarix.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXercTarix.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXercTarix.Location = new Point(718, 25);
        lblXercTarix.Name = "lblXercTarix";
        lblXercTarix.Size = new Size(41, 17);
        lblXercTarix.TabIndex = 6;
        lblXercTarix.Text = "Tarix:";
        // 
        // numXercMebleg
        // 
        numXercMebleg.BackColor = Color.FromArgb(242, 242, 242);
        numXercMebleg.DecimalPlaces = 2;
        numXercMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        numXercMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
        numXercMebleg.Location = new Point(578, 22);
        numXercMebleg.Margin = new Padding(3, 2, 3, 2);
        numXercMebleg.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
        numXercMebleg.Name = "numXercMebleg";
        numXercMebleg.Size = new Size(131, 24);
        numXercMebleg.TabIndex = 5;
        // 
        // lblXercMebleg
        // 
        lblXercMebleg.AutoSize = true;
        lblXercMebleg.BackColor = Color.FromArgb(242, 242, 242);
        lblXercMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXercMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXercMebleg.Location = new Point(508, 25);
        lblXercMebleg.Name = "lblXercMebleg";
        lblXercMebleg.Size = new Size(56, 17);
        lblXercMebleg.TabIndex = 4;
        lblXercMebleg.Text = "Məbləğ:";
        // 
        // txtXercAd
        // 
        txtXercAd.BackColor = Color.FromArgb(242, 242, 242);
        txtXercAd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtXercAd.ForeColor = Color.FromArgb(222, 0, 0, 0);
        txtXercAd.Location = new Point(289, 22);
        txtXercAd.Margin = new Padding(3, 2, 3, 2);
        txtXercAd.Name = "txtXercAd";
        txtXercAd.Size = new Size(210, 24);
        txtXercAd.TabIndex = 3;
        // 
        // lblXercAd
        // 
        lblXercAd.AutoSize = true;
        lblXercAd.BackColor = Color.FromArgb(242, 242, 242);
        lblXercAd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXercAd.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXercAd.Location = new Point(245, 25);
        lblXercAd.Name = "lblXercAd";
        lblXercAd.Size = new Size(28, 17);
        lblXercAd.TabIndex = 2;
        lblXercAd.Text = "Ad:";
        // 
        // cmbXercNovu
        // 
        cmbXercNovu.BackColor = Color.FromArgb(242, 242, 242);
        cmbXercNovu.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbXercNovu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        cmbXercNovu.ForeColor = Color.FromArgb(222, 0, 0, 0);
        cmbXercNovu.FormattingEnabled = true;
        cmbXercNovu.Location = new Point(70, 22);
        cmbXercNovu.Margin = new Padding(3, 2, 3, 2);
        cmbXercNovu.Name = "cmbXercNovu";
        cmbXercNovu.Size = new Size(158, 25);
        cmbXercNovu.TabIndex = 1;
        // 
        // lblXercNovu
        // 
        lblXercNovu.AutoSize = true;
        lblXercNovu.BackColor = Color.FromArgb(242, 242, 242);
        lblXercNovu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXercNovu.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXercNovu.Location = new Point(18, 25);
        lblXercNovu.Name = "lblXercNovu";
        lblXercNovu.Size = new Size(36, 17);
        lblXercNovu.TabIndex = 0;
        lblXercNovu.Text = "Növ:";
        // 
        // dgvXercler
        // 
        dgvXercler.AllowUserToAddRows = false;
        dgvXercler.AllowUserToDeleteRows = false;
        dgvXercler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvXercler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvXercler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvXercler.DefaultCellStyle = dataGridViewCellStyle2;
        dgvXercler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dgvXercler.Location = new Point(5, 144);
        dgvXercler.Margin = new Padding(3, 2, 3, 2);
        dgvXercler.Name = "dgvXercler";
        dgvXercler.ReadOnly = true;
        dgvXercler.RowHeadersWidth = 51;
        dgvXercler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvXercler.Size = new Size(1332, 453);
        dgvXercler.TabIndex = 0;
        dgvXercler.SelectionChanged += dgvXercler_SelectionChanged;
        // 
        // tabKassaHareketleri
        // 
        tabKassaHareketleri.BackColor = Color.FromArgb(242, 242, 242);
        tabKassaHareketleri.Controls.Add(groupFiltre);
        tabKassaHareketleri.Controls.Add(dgvKassaHareketleri);
        tabKassaHareketleri.Location = new Point(4, 26);
        tabKassaHareketleri.Margin = new Padding(3, 2, 3, 2);
        tabKassaHareketleri.Name = "tabKassaHareketleri";
        tabKassaHareketleri.Padding = new Padding(3, 2, 3, 2);
        tabKassaHareketleri.Size = new Size(1341, 597);
        tabKassaHareketleri.TabIndex = 1;
        tabKassaHareketleri.Text = "Kassa Hərəkətləri";
        // 
        // groupFiltre
        // 
        groupFiltre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupFiltre.BackColor = Color.FromArgb(242, 242, 242);
        groupFiltre.Controls.Add(btnFiltrele);
        groupFiltre.Controls.Add(dtpBitis);
        groupFiltre.Controls.Add(lblBitis);
        groupFiltre.Controls.Add(dtpBaslangic);
        groupFiltre.Controls.Add(lblBaslangic);
        groupFiltre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupFiltre.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupFiltre.Location = new Point(5, 4);
        groupFiltre.Margin = new Padding(3, 2, 3, 2);
        groupFiltre.Name = "groupFiltre";
        groupFiltre.Padding = new Padding(3, 2, 3, 2);
        groupFiltre.Size = new Size(1332, 60);
        groupFiltre.TabIndex = 1;
        groupFiltre.TabStop = false;
        groupFiltre.Text = "Tarix Filtri";
        // 
        // btnFiltrele
        // 
        btnFiltrele.BackColor = Color.FromArgb(242, 242, 242);
        btnFiltrele.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnFiltrele.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnFiltrele.Location = new Point(612, 22);
        btnFiltrele.Margin = new Padding(3, 2, 3, 2);
        btnFiltrele.Name = "btnFiltrele";
        btnFiltrele.Size = new Size(105, 22);
        btnFiltrele.TabIndex = 4;
        btnFiltrele.Text = "Filtrələ";
        btnFiltrele.UseVisualStyleBackColor = false;
        btnFiltrele.Click += btnFiltrele_Click;
        // 
        // dtpBitis
        // 
        dtpBitis.BackColor = Color.FromArgb(242, 242, 242);
        dtpBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpBitis.Format = DateTimePickerFormat.Short;
        dtpBitis.Location = new Point(411, 22);
        dtpBitis.Margin = new Padding(3, 2, 3, 2);
        dtpBitis.Name = "dtpBitis";
        dtpBitis.Size = new Size(176, 24);
        dtpBitis.TabIndex = 3;
        // 
        // lblBitis
        // 
        lblBitis.AutoSize = true;
        lblBitis.BackColor = Color.FromArgb(242, 242, 242);
        lblBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblBitis.Location = new Point(332, 25);
        lblBitis.Name = "lblBitis";
        lblBitis.Size = new Size(74, 17);
        lblBitis.TabIndex = 2;
        lblBitis.Text = "Bitis Tarixi:";
        // 
        // dtpBaslangic
        // 
        dtpBaslangic.BackColor = Color.FromArgb(242, 242, 242);
        dtpBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpBaslangic.Format = DateTimePickerFormat.Short;
        dtpBaslangic.Location = new Point(131, 22);
        dtpBaslangic.Margin = new Padding(3, 2, 3, 2);
        dtpBaslangic.Name = "dtpBaslangic";
        dtpBaslangic.Size = new Size(176, 24);
        dtpBaslangic.TabIndex = 1;
        // 
        // lblBaslangic
        // 
        lblBaslangic.AutoSize = true;
        lblBaslangic.BackColor = Color.FromArgb(242, 242, 242);
        lblBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblBaslangic.Location = new Point(18, 25);
        lblBaslangic.Name = "lblBaslangic";
        lblBaslangic.Size = new Size(108, 17);
        lblBaslangic.TabIndex = 0;
        lblBaslangic.Text = "Başlanğıc Tarixi:";
        // 
        // dgvKassaHareketleri
        // 
        dgvKassaHareketleri.AllowUserToAddRows = false;
        dgvKassaHareketleri.AllowUserToDeleteRows = false;
        dgvKassaHareketleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = SystemColors.Control;
        dataGridViewCellStyle3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
        dgvKassaHareketleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dgvKassaHareketleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = SystemColors.Window;
        dataGridViewCellStyle4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
        dgvKassaHareketleri.DefaultCellStyle = dataGridViewCellStyle4;
        dgvKassaHareketleri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dgvKassaHareketleri.Location = new Point(5, 69);
        dgvKassaHareketleri.Margin = new Padding(3, 2, 3, 2);
        dgvKassaHareketleri.Name = "dgvKassaHareketleri";
        dgvKassaHareketleri.ReadOnly = true;
        dgvKassaHareketleri.RowHeadersWidth = 51;
        dgvKassaHareketleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvKassaHareketleri.Size = new Size(1332, 529);
        dgvKassaHareketleri.TabIndex = 0;
        // 
        // tabMaliyyeXulasesi
        // 
        tabMaliyyeXulasesi.BackColor = Color.FromArgb(242, 242, 242);
        tabMaliyyeXulasesi.Controls.Add(groupXulase);
        tabMaliyyeXulasesi.Controls.Add(groupHesabatFiltre);
        tabMaliyyeXulasesi.Location = new Point(4, 26);
        tabMaliyyeXulasesi.Margin = new Padding(3, 2, 3, 2);
        tabMaliyyeXulasesi.Name = "tabMaliyyeXulasesi";
        tabMaliyyeXulasesi.Padding = new Padding(3, 2, 3, 2);
        tabMaliyyeXulasesi.Size = new Size(1341, 597);
        tabMaliyyeXulasesi.TabIndex = 2;
        tabMaliyyeXulasesi.Text = "Maliyyə Xülasəsi";
        // 
        // groupXulase
        // 
        groupXulase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupXulase.BackColor = Color.FromArgb(242, 242, 242);
        groupXulase.Controls.Add(lblCariBalans);
        groupXulase.Controls.Add(lblMenfeetZerere);
        groupXulase.Controls.Add(lblUmumiXerc);
        groupXulase.Controls.Add(lblUmumiGelir);
        groupXulase.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupXulase.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupXulase.Location = new Point(5, 69);
        groupXulase.Margin = new Padding(3, 2, 3, 2);
        groupXulase.Name = "groupXulase";
        groupXulase.Padding = new Padding(3, 2, 3, 2);
        groupXulase.Size = new Size(1332, 529);
        groupXulase.TabIndex = 1;
        groupXulase.TabStop = false;
        groupXulase.Text = "Maliyyə Göstəriciləri";
        // 
        // lblCariBalans
        // 
        lblCariBalans.AutoSize = true;
        lblCariBalans.BackColor = Color.FromArgb(242, 242, 242);
        lblCariBalans.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblCariBalans.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblCariBalans.Location = new Point(35, 165);
        lblCariBalans.Name = "lblCariBalans";
        lblCariBalans.Size = new Size(143, 17);
        lblCariBalans.TabIndex = 3;
        lblCariBalans.Text = "Cari Balans: 0.00 AZN";
        // 
        // lblMenfeetZerere
        // 
        lblMenfeetZerere.AutoSize = true;
        lblMenfeetZerere.BackColor = Color.FromArgb(242, 242, 242);
        lblMenfeetZerere.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblMenfeetZerere.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblMenfeetZerere.Location = new Point(35, 120);
        lblMenfeetZerere.Name = "lblMenfeetZerere";
        lblMenfeetZerere.Size = new Size(123, 17);
        lblMenfeetZerere.TabIndex = 2;
        lblMenfeetZerere.Text = "Mənfəət: 0.00 AZN";
        // 
        // lblUmumiXerc
        // 
        lblUmumiXerc.AutoSize = true;
        lblUmumiXerc.BackColor = Color.FromArgb(242, 242, 242);
        lblUmumiXerc.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblUmumiXerc.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblUmumiXerc.Location = new Point(35, 75);
        lblUmumiXerc.Name = "lblUmumiXerc";
        lblUmumiXerc.Size = new Size(147, 17);
        lblUmumiXerc.TabIndex = 1;
        lblUmumiXerc.Text = "Ümumi Xərc: 0.00 AZN";
        // 
        // lblUmumiGelir
        // 
        lblUmumiGelir.AutoSize = true;
        lblUmumiGelir.BackColor = Color.FromArgb(242, 242, 242);
        lblUmumiGelir.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblUmumiGelir.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblUmumiGelir.Location = new Point(35, 30);
        lblUmumiGelir.Name = "lblUmumiGelir";
        lblUmumiGelir.Size = new Size(147, 17);
        lblUmumiGelir.TabIndex = 0;
        lblUmumiGelir.Text = "Ümumi Gəlir: 0.00 AZN";
        // 
        // groupHesabatFiltre
        // 
        groupHesabatFiltre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupHesabatFiltre.BackColor = Color.FromArgb(242, 242, 242);
        groupHesabatFiltre.Controls.Add(btnHesabatGoster);
        groupHesabatFiltre.Controls.Add(dtpXesabatBitis);
        groupHesabatFiltre.Controls.Add(lblXesabatBitis);
        groupHesabatFiltre.Controls.Add(dtpXesabatBaslangic);
        groupHesabatFiltre.Controls.Add(lblXesabatBaslangic);
        groupHesabatFiltre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupHesabatFiltre.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupHesabatFiltre.Location = new Point(5, 4);
        groupHesabatFiltre.Margin = new Padding(3, 2, 3, 2);
        groupHesabatFiltre.Name = "groupHesabatFiltre";
        groupHesabatFiltre.Padding = new Padding(3, 2, 3, 2);
        groupHesabatFiltre.Size = new Size(1332, 60);
        groupHesabatFiltre.TabIndex = 0;
        groupHesabatFiltre.TabStop = false;
        groupHesabatFiltre.Text = "Hesabat Dövrü";
        // 
        // btnHesabatGoster
        // 
        btnHesabatGoster.BackColor = Color.FromArgb(242, 242, 242);
        btnHesabatGoster.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnHesabatGoster.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnHesabatGoster.Location = new Point(612, 22);
        btnHesabatGoster.Margin = new Padding(3, 2, 3, 2);
        btnHesabatGoster.Name = "btnHesabatGoster";
        btnHesabatGoster.Size = new Size(105, 22);
        btnHesabatGoster.TabIndex = 4;
        btnHesabatGoster.Text = "Göstər";
        btnHesabatGoster.UseVisualStyleBackColor = false;
        btnHesabatGoster.Click += btnHesabatGoster_Click;
        // 
        // dtpXesabatBitis
        // 
        dtpXesabatBitis.BackColor = Color.FromArgb(242, 242, 242);
        dtpXesabatBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpXesabatBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpXesabatBitis.Format = DateTimePickerFormat.Short;
        dtpXesabatBitis.Location = new Point(411, 22);
        dtpXesabatBitis.Margin = new Padding(3, 2, 3, 2);
        dtpXesabatBitis.Name = "dtpXesabatBitis";
        dtpXesabatBitis.Size = new Size(176, 24);
        dtpXesabatBitis.TabIndex = 3;
        // 
        // lblXesabatBitis
        // 
        lblXesabatBitis.AutoSize = true;
        lblXesabatBitis.BackColor = Color.FromArgb(242, 242, 242);
        lblXesabatBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXesabatBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXesabatBitis.Location = new Point(332, 25);
        lblXesabatBitis.Name = "lblXesabatBitis";
        lblXesabatBitis.Size = new Size(74, 17);
        lblXesabatBitis.TabIndex = 2;
        lblXesabatBitis.Text = "Bitis Tarixi:";
        // 
        // dtpXesabatBaslangic
        // 
        dtpXesabatBaslangic.BackColor = Color.FromArgb(242, 242, 242);
        dtpXesabatBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpXesabatBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpXesabatBaslangic.Format = DateTimePickerFormat.Short;
        dtpXesabatBaslangic.Location = new Point(131, 22);
        dtpXesabatBaslangic.Margin = new Padding(3, 2, 3, 2);
        dtpXesabatBaslangic.Name = "dtpXesabatBaslangic";
        dtpXesabatBaslangic.Size = new Size(176, 24);
        dtpXesabatBaslangic.TabIndex = 1;
        // 
        // lblXesabatBaslangic
        // 
        lblXesabatBaslangic.AutoSize = true;
        lblXesabatBaslangic.BackColor = Color.FromArgb(242, 242, 242);
        lblXesabatBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblXesabatBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblXesabatBaslangic.Location = new Point(18, 25);
        lblXesabatBaslangic.Name = "lblXesabatBaslangic";
        lblXesabatBaslangic.Size = new Size(108, 17);
        lblXesabatBaslangic.TabIndex = 0;
        lblXesabatBaslangic.Text = "Başlanğıc Tarixi:";
        // 
        // btnYenile
        // 
        btnYenile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnYenile.BackColor = Color.FromArgb(242, 242, 242);
        btnYenile.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnYenile.Location = new Point(1241, 715);
        btnYenile.Margin = new Padding(3, 2, 3, 2);
        btnYenile.Name = "btnYenile";
        btnYenile.Size = new Size(105, 26);
        btnYenile.TabIndex = 1;
        btnYenile.Text = "Yenilə";
        btnYenile.UseVisualStyleBackColor = false;
        btnYenile.Click += btnYenile_Click;
        // 
        // KassaFormu
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1365, 754);
        Controls.Add(tabControl);
        Controls.Add(btnYenile);
        Margin = new Padding(3, 2, 3, 2);
        Name = "KassaFormu";
        Padding = new Padding(3, 48, 3, 2);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Kassa və Maliyyə İdarəetməsi";
        Controls.SetChildIndex(btnYenile, 0);
        Controls.SetChildIndex(tabControl, 0);
        tabControl.ResumeLayout(false);
        tabXercler.ResumeLayout(false);
        groupXercForm.ResumeLayout(false);
        groupXercForm.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numXercMebleg).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvXercler).EndInit();
        tabKassaHareketleri.ResumeLayout(false);
        groupFiltre.ResumeLayout(false);
        groupFiltre.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKassaHareketleri).EndInit();
        tabMaliyyeXulasesi.ResumeLayout(false);
        groupXulase.ResumeLayout(false);
        groupXulase.PerformLayout();
        groupHesabatFiltre.ResumeLayout(false);
        groupHesabatFiltre.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabXercler;
    private System.Windows.Forms.TabPage tabKassaHareketleri;
    private System.Windows.Forms.TabPage tabMaliyyeXulasesi;
    private System.Windows.Forms.DataGridView dgvXercler;
    private System.Windows.Forms.GroupBox groupXercForm;
    private System.Windows.Forms.Label lblXercNovu;
    private System.Windows.Forms.ComboBox cmbXercNovu;
    private System.Windows.Forms.TextBox txtXercAd;
    private System.Windows.Forms.Label lblXercAd;
    private System.Windows.Forms.NumericUpDown numXercMebleg;
    private System.Windows.Forms.Label lblXercMebleg;
    private System.Windows.Forms.DateTimePicker dtpXercTarix;
    private System.Windows.Forms.Label lblXercTarix;
    private System.Windows.Forms.TextBox txtSenedNomresi;
    private System.Windows.Forms.Label lblSenedNomresi;
    private System.Windows.Forms.TextBox txtXercQeyd;
    private System.Windows.Forms.Label lblXercQeyd;
    private System.Windows.Forms.Button btnXercYarat;
    private System.Windows.Forms.Button btnXercYenile;
    private System.Windows.Forms.Button btnXercSil;
    private System.Windows.Forms.Button btnXercTemizle;
    private System.Windows.Forms.DataGridView dgvKassaHareketleri;
    private System.Windows.Forms.GroupBox groupFiltre;
    private System.Windows.Forms.DateTimePicker dtpBaslangic;
    private System.Windows.Forms.Label lblBaslangic;
    private System.Windows.Forms.DateTimePicker dtpBitis;
    private System.Windows.Forms.Label lblBitis;
    private System.Windows.Forms.Button btnFiltrele;
    private System.Windows.Forms.GroupBox groupHesabatFiltre;
    private System.Windows.Forms.DateTimePicker dtpXesabatBaslangic;
    private System.Windows.Forms.Label lblXesabatBaslangic;
    private System.Windows.Forms.DateTimePicker dtpXesabatBitis;
    private System.Windows.Forms.Label lblXesabatBitis;
    private System.Windows.Forms.Button btnHesabatGoster;
    private System.Windows.Forms.GroupBox groupXulase;
    private System.Windows.Forms.Label lblUmumiGelir;
    private System.Windows.Forms.Label lblUmumiXerc;
    private System.Windows.Forms.Label lblMenfeetZerere;
    private System.Windows.Forms.Label lblCariBalans;
    private System.Windows.Forms.Button btnYenile;
}
