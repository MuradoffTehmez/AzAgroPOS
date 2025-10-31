// Fayl: AzAgroPOS.Teqdimat/IsciIzniFormu.Designer.cs
namespace AzAgroPOS.Teqdimat;

partial class IsciIzniFormu
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
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        groupIzinMelumatlari = new GroupBox();
        lblIsciIzinMelumati = new Label();
        txtQeydler = new TextBox();
        lblQeydler = new Label();
        txtSebeb = new TextBox();
        lblSebeb = new Label();
        numIzinGunu = new NumericUpDown();
        lblIzinGunu = new Label();
        dtpBitmeTarixi = new DateTimePicker();
        lblBitmeTarixi = new Label();
        dtpBaslamaTarixi = new DateTimePicker();
        lblBaslamaTarixi = new Label();
        cmbIzinNovu = new ComboBox();
        lblIzinNovu = new Label();
        cmbIsci = new ComboBox();
        lblIsci = new Label();
        groupEmeliyyatlar = new GroupBox();
        btnTemizle = new Button();
        btnLegvEt = new Button();
        btnReddEt = new Button();
        btnTesdiqle = new Button();
        btnSil = new Button();
        btnYenile = new Button();
        btnYarat = new Button();
        groupIzinSiyahisi = new GroupBox();
        dgvIzinler = new DataGridView();
        groupFiltre = new GroupBox();
        cmbStatusFiltre = new ComboBox();
        lblStatusFiltre = new Label();
        lblStatusMelumat = new Label();
        btnYenileHamisi = new Button();
        groupIzinMelumatlari.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numIzinGunu).BeginInit();
        groupEmeliyyatlar.SuspendLayout();
        groupIzinSiyahisi.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvIzinler).BeginInit();
        groupFiltre.SuspendLayout();
        SuspendLayout();
        // 
        // groupIzinMelumatlari
        // 
        groupIzinMelumatlari.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupIzinMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
        groupIzinMelumatlari.Controls.Add(lblIsciIzinMelumati);
        groupIzinMelumatlari.Controls.Add(txtQeydler);
        groupIzinMelumatlari.Controls.Add(lblQeydler);
        groupIzinMelumatlari.Controls.Add(txtSebeb);
        groupIzinMelumatlari.Controls.Add(lblSebeb);
        groupIzinMelumatlari.Controls.Add(numIzinGunu);
        groupIzinMelumatlari.Controls.Add(lblIzinGunu);
        groupIzinMelumatlari.Controls.Add(dtpBitmeTarixi);
        groupIzinMelumatlari.Controls.Add(lblBitmeTarixi);
        groupIzinMelumatlari.Controls.Add(dtpBaslamaTarixi);
        groupIzinMelumatlari.Controls.Add(lblBaslamaTarixi);
        groupIzinMelumatlari.Controls.Add(cmbIzinNovu);
        groupIzinMelumatlari.Controls.Add(lblIzinNovu);
        groupIzinMelumatlari.Controls.Add(cmbIsci);
        groupIzinMelumatlari.Controls.Add(lblIsci);
        groupIzinMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupIzinMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupIzinMelumatlari.Location = new Point(10, 70);
        groupIzinMelumatlari.Margin = new Padding(3, 2, 3, 2);
        groupIzinMelumatlari.Name = "groupIzinMelumatlari";
        groupIzinMelumatlari.Padding = new Padding(3, 2, 3, 2);
        groupIzinMelumatlari.Size = new Size(1121, 135);
        groupIzinMelumatlari.TabIndex = 0;
        groupIzinMelumatlari.TabStop = false;
        groupIzinMelumatlari.Text = "İzin Məlumatları";
        // 
        // lblIsciIzinMelumati
        // 
        lblIsciIzinMelumati.AutoSize = true;
        lblIsciIzinMelumati.BackColor = Color.FromArgb(242, 242, 242);
        lblIsciIzinMelumati.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblIsciIzinMelumati.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblIsciIzinMelumati.Location = new Point(630, 25);
        lblIsciIzinMelumati.Name = "lblIsciIzinMelumati";
        lblIsciIzinMelumati.Size = new Size(109, 17);
        lblIsciIzinMelumati.TabIndex = 14;
        lblIsciIzinMelumati.Text = "İzin məlumatı: ---";
        // 
        // txtQeydler
        // 
        txtQeydler.BackColor = Color.FromArgb(242, 242, 242);
        txtQeydler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtQeydler.ForeColor = Color.FromArgb(222, 0, 0, 0);
        txtQeydler.Location = new Point(630, 90);
        txtQeydler.Margin = new Padding(3, 2, 3, 2);
        txtQeydler.Multiline = true;
        txtQeydler.Name = "txtQeydler";
        txtQeydler.Size = new Size(350, 35);
        txtQeydler.TabIndex = 13;
        // 
        // lblQeydler
        // 
        lblQeydler.AutoSize = true;
        lblQeydler.BackColor = Color.FromArgb(242, 242, 242);
        lblQeydler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblQeydler.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblQeydler.Location = new Point(560, 92);
        lblQeydler.Name = "lblQeydler";
        lblQeydler.Size = new Size(58, 17);
        lblQeydler.TabIndex = 12;
        lblQeydler.Text = "Qeydlər:";
        // 
        // txtSebeb
        // 
        txtSebeb.BackColor = Color.FromArgb(242, 242, 242);
        txtSebeb.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtSebeb.ForeColor = Color.FromArgb(222, 0, 0, 0);
        txtSebeb.Location = new Point(630, 50);
        txtSebeb.Margin = new Padding(3, 2, 3, 2);
        txtSebeb.Multiline = true;
        txtSebeb.Name = "txtSebeb";
        txtSebeb.Size = new Size(350, 35);
        txtSebeb.TabIndex = 11;
        // 
        // lblSebeb
        // 
        lblSebeb.AutoSize = true;
        lblSebeb.BackColor = Color.FromArgb(242, 242, 242);
        lblSebeb.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblSebeb.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblSebeb.Location = new Point(560, 52);
        lblSebeb.Name = "lblSebeb";
        lblSebeb.Size = new Size(49, 17);
        lblSebeb.TabIndex = 10;
        lblSebeb.Text = "Səbəb:";
        // 
        // numIzinGunu
        // 
        numIzinGunu.BackColor = Color.FromArgb(242, 242, 242);
        numIzinGunu.Enabled = false;
        numIzinGunu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        numIzinGunu.ForeColor = Color.FromArgb(222, 0, 0, 0);
        numIzinGunu.Location = new Point(158, 105);
        numIzinGunu.Margin = new Padding(3, 2, 3, 2);
        numIzinGunu.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
        numIzinGunu.Name = "numIzinGunu";
        numIzinGunu.ReadOnly = true;
        numIzinGunu.Size = new Size(131, 24);
        numIzinGunu.TabIndex = 9;
        // 
        // lblIzinGunu
        // 
        lblIzinGunu.AutoSize = true;
        lblIzinGunu.BackColor = Color.FromArgb(242, 242, 242);
        lblIzinGunu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblIzinGunu.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblIzinGunu.Location = new Point(18, 107);
        lblIzinGunu.Name = "lblIzinGunu";
        lblIzinGunu.Size = new Size(70, 17);
        lblIzinGunu.TabIndex = 8;
        lblIzinGunu.Text = "İzin Günü:";
        // 
        // dtpBitmeTarixi
        // 
        dtpBitmeTarixi.BackColor = Color.FromArgb(242, 242, 242);
        dtpBitmeTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpBitmeTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpBitmeTarixi.Format = DateTimePickerFormat.Short;
        dtpBitmeTarixi.Location = new Point(385, 77);
        dtpBitmeTarixi.Margin = new Padding(3, 2, 3, 2);
        dtpBitmeTarixi.Name = "dtpBitmeTarixi";
        dtpBitmeTarixi.Size = new Size(158, 24);
        dtpBitmeTarixi.TabIndex = 7;
        dtpBitmeTarixi.ValueChanged += dtpBitmeTarixi_ValueChanged;
        // 
        // lblBitmeTarixi
        // 
        lblBitmeTarixi.AutoSize = true;
        lblBitmeTarixi.BackColor = Color.FromArgb(242, 242, 242);
        lblBitmeTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblBitmeTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblBitmeTarixi.Location = new Point(298, 80);
        lblBitmeTarixi.Name = "lblBitmeTarixi";
        lblBitmeTarixi.Size = new Size(83, 17);
        lblBitmeTarixi.TabIndex = 6;
        lblBitmeTarixi.Text = "Bitmə Tarixi:";
        // 
        // dtpBaslamaTarixi
        // 
        dtpBaslamaTarixi.BackColor = Color.FromArgb(242, 242, 242);
        dtpBaslamaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dtpBaslamaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dtpBaslamaTarixi.Format = DateTimePickerFormat.Short;
        dtpBaslamaTarixi.Location = new Point(158, 77);
        dtpBaslamaTarixi.Margin = new Padding(3, 2, 3, 2);
        dtpBaslamaTarixi.Name = "dtpBaslamaTarixi";
        dtpBaslamaTarixi.Size = new Size(132, 24);
        dtpBaslamaTarixi.TabIndex = 5;
        dtpBaslamaTarixi.ValueChanged += dtpBaslamaTarixi_ValueChanged;
        // 
        // lblBaslamaTarixi
        // 
        lblBaslamaTarixi.AutoSize = true;
        lblBaslamaTarixi.BackColor = Color.FromArgb(242, 242, 242);
        lblBaslamaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblBaslamaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblBaslamaTarixi.Location = new Point(18, 80);
        lblBaslamaTarixi.Name = "lblBaslamaTarixi";
        lblBaslamaTarixi.Size = new Size(102, 17);
        lblBaslamaTarixi.TabIndex = 4;
        lblBaslamaTarixi.Text = "Başlama Tarixi:";
        // 
        // cmbIzinNovu
        // 
        cmbIzinNovu.BackColor = Color.FromArgb(242, 242, 242);
        cmbIzinNovu.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbIzinNovu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        cmbIzinNovu.ForeColor = Color.FromArgb(222, 0, 0, 0);
        cmbIzinNovu.FormattingEnabled = true;
        cmbIzinNovu.Location = new Point(158, 50);
        cmbIzinNovu.Margin = new Padding(3, 2, 3, 2);
        cmbIzinNovu.Name = "cmbIzinNovu";
        cmbIzinNovu.Size = new Size(386, 25);
        cmbIzinNovu.TabIndex = 3;
        // 
        // lblIzinNovu
        // 
        lblIzinNovu.AutoSize = true;
        lblIzinNovu.BackColor = Color.FromArgb(242, 242, 242);
        lblIzinNovu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblIzinNovu.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblIzinNovu.Location = new Point(18, 52);
        lblIzinNovu.Name = "lblIzinNovu";
        lblIzinNovu.Size = new Size(69, 17);
        lblIzinNovu.TabIndex = 2;
        lblIzinNovu.Text = "İzin Növü:";
        // 
        // cmbIsci
        // 
        cmbIsci.BackColor = Color.FromArgb(242, 242, 242);
        cmbIsci.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbIsci.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        cmbIsci.ForeColor = Color.FromArgb(222, 0, 0, 0);
        cmbIsci.FormattingEnabled = true;
        cmbIsci.Location = new Point(158, 22);
        cmbIsci.Margin = new Padding(3, 2, 3, 2);
        cmbIsci.Name = "cmbIsci";
        cmbIsci.Size = new Size(386, 25);
        cmbIsci.TabIndex = 1;
        cmbIsci.SelectedIndexChanged += cmbIsci_SelectedIndexChanged;
        // 
        // lblIsci
        // 
        lblIsci.AutoSize = true;
        lblIsci.BackColor = Color.FromArgb(242, 242, 242);
        lblIsci.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblIsci.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblIsci.Location = new Point(18, 25);
        lblIsci.Name = "lblIsci";
        lblIsci.Size = new Size(32, 17);
        lblIsci.TabIndex = 0;
        lblIsci.Text = "İşçi:";
        // 
        // groupEmeliyyatlar
        // 
        groupEmeliyyatlar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupEmeliyyatlar.BackColor = Color.FromArgb(242, 242, 242);
        groupEmeliyyatlar.Controls.Add(btnTemizle);
        groupEmeliyyatlar.Controls.Add(btnLegvEt);
        groupEmeliyyatlar.Controls.Add(btnReddEt);
        groupEmeliyyatlar.Controls.Add(btnTesdiqle);
        groupEmeliyyatlar.Controls.Add(btnSil);
        groupEmeliyyatlar.Controls.Add(btnYenile);
        groupEmeliyyatlar.Controls.Add(btnYarat);
        groupEmeliyyatlar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupEmeliyyatlar.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupEmeliyyatlar.Location = new Point(10, 209);
        groupEmeliyyatlar.Margin = new Padding(3, 2, 3, 2);
        groupEmeliyyatlar.Name = "groupEmeliyyatlar";
        groupEmeliyyatlar.Padding = new Padding(3, 2, 3, 2);
        groupEmeliyyatlar.Size = new Size(1121, 60);
        groupEmeliyyatlar.TabIndex = 1;
        groupEmeliyyatlar.TabStop = false;
        groupEmeliyyatlar.Text = "Əməliyyatlar";
        // 
        // btnTemizle
        // 
        btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
        btnTemizle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnTemizle.Location = new Point(892, 22);
        btnTemizle.Margin = new Padding(3, 2, 3, 2);
        btnTemizle.Name = "btnTemizle";
        btnTemizle.Size = new Size(105, 26);
        btnTemizle.TabIndex = 6;
        btnTemizle.Text = "Təmizlə";
        btnTemizle.UseVisualStyleBackColor = false;
        btnTemizle.Click += btnTemizle_Click;
        // 
        // btnLegvEt
        // 
        btnLegvEt.BackColor = Color.FromArgb(242, 242, 242);
        btnLegvEt.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnLegvEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnLegvEt.Location = new Point(752, 22);
        btnLegvEt.Margin = new Padding(3, 2, 3, 2);
        btnLegvEt.Name = "btnLegvEt";
        btnLegvEt.Size = new Size(105, 26);
        btnLegvEt.TabIndex = 5;
        btnLegvEt.Text = "Ləğv Et";
        btnLegvEt.UseVisualStyleBackColor = false;
        btnLegvEt.Click += btnLegvEt_Click;
        // 
        // btnReddEt
        // 
        btnReddEt.BackColor = Color.FromArgb(242, 242, 242);
        btnReddEt.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnReddEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnReddEt.Location = new Point(612, 22);
        btnReddEt.Margin = new Padding(3, 2, 3, 2);
        btnReddEt.Name = "btnReddEt";
        btnReddEt.Size = new Size(105, 26);
        btnReddEt.TabIndex = 4;
        btnReddEt.Text = "Rədd Et";
        btnReddEt.UseVisualStyleBackColor = false;
        btnReddEt.Click += btnReddEt_Click;
        // 
        // btnTesdiqle
        // 
        btnTesdiqle.BackColor = Color.FromArgb(242, 242, 242);
        btnTesdiqle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnTesdiqle.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnTesdiqle.Location = new Point(472, 22);
        btnTesdiqle.Margin = new Padding(3, 2, 3, 2);
        btnTesdiqle.Name = "btnTesdiqle";
        btnTesdiqle.Size = new Size(105, 26);
        btnTesdiqle.TabIndex = 3;
        btnTesdiqle.Text = "Təsdiqlə";
        btnTesdiqle.UseVisualStyleBackColor = false;
        btnTesdiqle.Click += btnTesdiqle_Click;
        // 
        // btnSil
        // 
        btnSil.BackColor = Color.FromArgb(242, 242, 242);
        btnSil.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnSil.Location = new Point(332, 22);
        btnSil.Margin = new Padding(3, 2, 3, 2);
        btnSil.Name = "btnSil";
        btnSil.Size = new Size(105, 26);
        btnSil.TabIndex = 2;
        btnSil.Text = "Sil";
        btnSil.UseVisualStyleBackColor = false;
        btnSil.Click += btnSil_Click;
        // 
        // btnYenile
        // 
        btnYenile.BackColor = Color.FromArgb(242, 242, 242);
        btnYenile.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnYenile.Location = new Point(192, 22);
        btnYenile.Margin = new Padding(3, 2, 3, 2);
        btnYenile.Name = "btnYenile";
        btnYenile.Size = new Size(105, 26);
        btnYenile.TabIndex = 1;
        btnYenile.Text = "Yenilə";
        btnYenile.UseVisualStyleBackColor = false;
        btnYenile.Click += btnYenile_Click;
        // 
        // btnYarat
        // 
        btnYarat.BackColor = Color.FromArgb(242, 242, 242);
        btnYarat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnYarat.Location = new Point(52, 22);
        btnYarat.Margin = new Padding(3, 2, 3, 2);
        btnYarat.Name = "btnYarat";
        btnYarat.Size = new Size(105, 26);
        btnYarat.TabIndex = 0;
        btnYarat.Text = "Yarat";
        btnYarat.UseVisualStyleBackColor = false;
        btnYarat.Click += btnYarat_Click;
        // 
        // groupIzinSiyahisi
        // 
        groupIzinSiyahisi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupIzinSiyahisi.BackColor = Color.FromArgb(242, 242, 242);
        groupIzinSiyahisi.Controls.Add(dgvIzinler);
        groupIzinSiyahisi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupIzinSiyahisi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupIzinSiyahisi.Location = new Point(10, 343);
        groupIzinSiyahisi.Margin = new Padding(3, 2, 3, 2);
        groupIzinSiyahisi.Name = "groupIzinSiyahisi";
        groupIzinSiyahisi.Padding = new Padding(3, 2, 3, 2);
        groupIzinSiyahisi.Size = new Size(1121, 368);
        groupIzinSiyahisi.TabIndex = 2;
        groupIzinSiyahisi.TabStop = false;
        groupIzinSiyahisi.Text = "İzin Siyahısı";
        // 
        // dgvIzinler
        // 
        dgvIzinler.AllowUserToAddRows = false;
        dgvIzinler.AllowUserToDeleteRows = false;
        dgvIzinler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = SystemColors.Control;
        dataGridViewCellStyle3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
        dgvIzinler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dgvIzinler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = SystemColors.Window;
        dataGridViewCellStyle4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
        dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
        dgvIzinler.DefaultCellStyle = dataGridViewCellStyle4;
        dgvIzinler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        dgvIzinler.Location = new Point(5, 21);
        dgvIzinler.Margin = new Padding(3, 2, 3, 2);
        dgvIzinler.Name = "dgvIzinler";
        dgvIzinler.ReadOnly = true;
        dgvIzinler.RowHeadersWidth = 51;
        dgvIzinler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvIzinler.Size = new Size(1110, 343);
        dgvIzinler.TabIndex = 0;
        dgvIzinler.SelectionChanged += dgvIzinler_SelectionChanged;
        // 
        // groupFiltre
        // 
        groupFiltre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupFiltre.BackColor = Color.FromArgb(242, 242, 242);
        groupFiltre.Controls.Add(cmbStatusFiltre);
        groupFiltre.Controls.Add(lblStatusFiltre);
        groupFiltre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        groupFiltre.ForeColor = Color.FromArgb(222, 0, 0, 0);
        groupFiltre.Location = new Point(10, 274);
        groupFiltre.Margin = new Padding(3, 2, 3, 2);
        groupFiltre.Name = "groupFiltre";
        groupFiltre.Padding = new Padding(3, 2, 3, 2);
        groupFiltre.Size = new Size(806, 56);
        groupFiltre.TabIndex = 3;
        groupFiltre.TabStop = false;
        groupFiltre.Text = "Filtrələmə";
        // 
        // cmbStatusFiltre
        // 
        cmbStatusFiltre.BackColor = Color.FromArgb(242, 242, 242);
        cmbStatusFiltre.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStatusFiltre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        cmbStatusFiltre.ForeColor = Color.FromArgb(222, 0, 0, 0);
        cmbStatusFiltre.FormattingEnabled = true;
        cmbStatusFiltre.Location = new Point(158, 22);
        cmbStatusFiltre.Margin = new Padding(3, 2, 3, 2);
        cmbStatusFiltre.Name = "cmbStatusFiltre";
        cmbStatusFiltre.Size = new Size(263, 25);
        cmbStatusFiltre.TabIndex = 1;
        cmbStatusFiltre.SelectedIndexChanged += cmbStatusFiltre_SelectedIndexChanged;
        // 
        // lblStatusFiltre
        // 
        lblStatusFiltre.AutoSize = true;
        lblStatusFiltre.BackColor = Color.FromArgb(242, 242, 242);
        lblStatusFiltre.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblStatusFiltre.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblStatusFiltre.Location = new Point(18, 25);
        lblStatusFiltre.Name = "lblStatusFiltre";
        lblStatusFiltre.Size = new Size(82, 17);
        lblStatusFiltre.TabIndex = 0;
        lblStatusFiltre.Text = "Status Filtri:";
        // 
        // lblStatusMelumat
        // 
        lblStatusMelumat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblStatusMelumat.AutoSize = true;
        lblStatusMelumat.BackColor = Color.FromArgb(242, 242, 242);
        lblStatusMelumat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        lblStatusMelumat.ForeColor = Color.FromArgb(222, 0, 0, 0);
        lblStatusMelumat.Location = new Point(832, 297);
        lblStatusMelumat.Name = "lblStatusMelumat";
        lblStatusMelumat.Size = new Size(67, 17);
        lblStatusMelumat.TabIndex = 4;
        lblStatusMelumat.Text = "Status: ---";
        // 
        // btnYenileHamisi
        // 
        btnYenileHamisi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnYenileHamisi.BackColor = Color.FromArgb(242, 242, 242);
        btnYenileHamisi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        btnYenileHamisi.ForeColor = Color.FromArgb(222, 0, 0, 0);
        btnYenileHamisi.Location = new Point(1026, 715);
        btnYenileHamisi.Margin = new Padding(3, 2, 3, 2);
        btnYenileHamisi.Name = "btnYenileHamisi";
        btnYenileHamisi.Size = new Size(105, 26);
        btnYenileHamisi.TabIndex = 5;
        btnYenileHamisi.Text = "Yenilə";
        btnYenileHamisi.UseVisualStyleBackColor = false;
        btnYenileHamisi.Click += btnYenileHamisi_Click;
        // 
        // IsciIzniFormu
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1142, 750);
        Controls.Add(btnYenileHamisi);
        Controls.Add(lblStatusMelumat);
        Controls.Add(groupFiltre);
        Controls.Add(groupIzinSiyahisi);
        Controls.Add(groupEmeliyyatlar);
        Controls.Add(groupIzinMelumatlari);
        Margin = new Padding(3, 2, 3, 2);
        Name = "IsciIzniFormu";
        Padding = new Padding(3, 48, 3, 2);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "İşçi İzni İdarəetməsi";
        Controls.SetChildIndex(groupIzinMelumatlari, 0);
        Controls.SetChildIndex(groupEmeliyyatlar, 0);
        Controls.SetChildIndex(groupIzinSiyahisi, 0);
        Controls.SetChildIndex(groupFiltre, 0);
        Controls.SetChildIndex(lblStatusMelumat, 0);
        Controls.SetChildIndex(btnYenileHamisi, 0);
        groupIzinMelumatlari.ResumeLayout(false);
        groupIzinMelumatlari.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numIzinGunu).EndInit();
        groupEmeliyyatlar.ResumeLayout(false);
        groupIzinSiyahisi.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvIzinler).EndInit();
        groupFiltre.ResumeLayout(false);
        groupFiltre.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupIzinMelumatlari;
    private System.Windows.Forms.ComboBox cmbIsci;
    private System.Windows.Forms.Label lblIsci;
    private System.Windows.Forms.ComboBox cmbIzinNovu;
    private System.Windows.Forms.Label lblIzinNovu;
    private System.Windows.Forms.DateTimePicker dtpBaslamaTarixi;
    private System.Windows.Forms.Label lblBaslamaTarixi;
    private System.Windows.Forms.DateTimePicker dtpBitmeTarixi;
    private System.Windows.Forms.Label lblBitmeTarixi;
    private System.Windows.Forms.NumericUpDown numIzinGunu;
    private System.Windows.Forms.Label lblIzinGunu;
    private System.Windows.Forms.TextBox txtSebeb;
    private System.Windows.Forms.Label lblSebeb;
    private System.Windows.Forms.TextBox txtQeydler;
    private System.Windows.Forms.Label lblQeydler;
    private System.Windows.Forms.Label lblIsciIzinMelumati;
    private System.Windows.Forms.GroupBox groupEmeliyyatlar;
    private System.Windows.Forms.Button btnYarat;
    private System.Windows.Forms.Button btnYenile;
    private System.Windows.Forms.Button btnSil;
    private System.Windows.Forms.Button btnTesdiqle;
    private System.Windows.Forms.Button btnReddEt;
    private System.Windows.Forms.Button btnLegvEt;
    private System.Windows.Forms.Button btnTemizle;
    private System.Windows.Forms.GroupBox groupIzinSiyahisi;
    private System.Windows.Forms.DataGridView dgvIzinler;
    private System.Windows.Forms.GroupBox groupFiltre;
    private System.Windows.Forms.ComboBox cmbStatusFiltre;
    private System.Windows.Forms.Label lblStatusFiltre;
    private System.Windows.Forms.Label lblStatusMelumat;
    private System.Windows.Forms.Button btnYenileHamisi;
}
