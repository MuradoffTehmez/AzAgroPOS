// Fayl: AzAgroPOS.Teqdimat/AnbarFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnbarFormu
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
            grpMehsullar = new GroupBox();
            dgvMehsullar = new DataGridView();
            pnlSag = new Panel();
            grpTarixce = new GroupBox();
            dgvTarixce = new DataGridView();
            btnTarixceYenile = new MaterialSkin.Controls.MaterialButton();
            grpEmeliyyat = new GroupBox();
            txtSay = new MaterialSkin.Controls.MaterialTextBox2();
            txtQeyd = new MaterialSkin.Controls.MaterialTextBox2();
            btnStokArtir = new MaterialSkin.Controls.MaterialButton();
            btnStokAzalt = new MaterialSkin.Controls.MaterialButton();
            btnStokDuzelis = new MaterialSkin.Controls.MaterialButton();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();
            pnlMehsulMelumat = new Panel();
            lblMehsulAdi = new MaterialSkin.Controls.MaterialLabel();
            lblStokKodu = new MaterialSkin.Controls.MaterialLabel();
            lblMovcudStok = new MaterialSkin.Controls.MaterialLabel();
            lblOlcuVahidi = new MaterialSkin.Controls.MaterialLabel();
            lblMehsulId = new Label();
            grpAxtaris = new GroupBox();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            btnAxtar = new MaterialSkin.Controls.MaterialButton();
            errorProvider1 = new ErrorProvider(components);
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpMehsullar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).BeginInit();
            pnlSag.SuspendLayout();
            grpTarixce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarixce).BeginInit();
            grpEmeliyyat.SuspendLayout();
            pnlMehsulMelumat.SuspendLayout();
            grpAxtaris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
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
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel1.Controls.Add(grpMehsullar);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(pnlSag);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(1594, 811);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 0;
            // 
            // grpMehsullar
            // 
            grpMehsullar.BackColor = Color.FromArgb(242, 242, 242);
            grpMehsullar.Controls.Add(dgvMehsullar);
            grpMehsullar.Dock = DockStyle.Fill;
            grpMehsullar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpMehsullar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpMehsullar.Location = new Point(0, 0);
            grpMehsullar.Name = "grpMehsullar";
            grpMehsullar.Size = new Size(400, 811);
            grpMehsullar.TabIndex = 0;
            grpMehsullar.TabStop = false;
            grpMehsullar.Text = "Bütün Məhsullar";
            // 
            // dgvMehsullar
            // 
            dgvMehsullar.AllowUserToAddRows = false;
            dgvMehsullar.AllowUserToDeleteRows = false;
            dgvMehsullar.AllowUserToResizeRows = false;
            dgvMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMehsullar.BackgroundColor = Color.White;
            dgvMehsullar.BorderStyle = BorderStyle.None;
            dgvMehsullar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMehsullar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMehsullar.ColumnHeadersHeight = 30;
            dgvMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMehsullar.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMehsullar.Dock = DockStyle.Fill;
            dgvMehsullar.EnableHeadersVisualStyles = false;
            dgvMehsullar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMehsullar.GridColor = Color.FromArgb(224, 224, 224);
            dgvMehsullar.Location = new Point(3, 20);
            dgvMehsullar.MultiSelect = false;
            dgvMehsullar.Name = "dgvMehsullar";
            dgvMehsullar.ReadOnly = true;
            dgvMehsullar.RowHeadersVisible = false;
            dgvMehsullar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMehsullar.Size = new Size(394, 788);
            dgvMehsullar.TabIndex = 0;
            // 
            // pnlSag
            // 
            pnlSag.BackColor = Color.FromArgb(242, 242, 242);
            pnlSag.Controls.Add(grpTarixce);
            pnlSag.Controls.Add(grpEmeliyyat);
            pnlSag.Controls.Add(pnlMehsulMelumat);
            pnlSag.Controls.Add(grpAxtaris);
            pnlSag.Dock = DockStyle.Fill;
            pnlSag.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlSag.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlSag.Location = new Point(0, 0);
            pnlSag.Name = "pnlSag";
            pnlSag.Size = new Size(1190, 811);
            pnlSag.TabIndex = 0;
            // 
            // grpTarixce
            // 
            grpTarixce.BackColor = Color.FromArgb(242, 242, 242);
            grpTarixce.Controls.Add(dgvTarixce);
            grpTarixce.Controls.Add(btnTarixceYenile);
            grpTarixce.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpTarixce.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpTarixce.Location = new Point(10, 440);
            grpTarixce.Name = "grpTarixce";
            grpTarixce.Size = new Size(1170, 320);
            grpTarixce.TabIndex = 3;
            grpTarixce.TabStop = false;
            grpTarixce.Text = "Son Əməliyyatlar";
            // 
            // dgvTarixce
            // 
            dgvTarixce.AllowUserToAddRows = false;
            dgvTarixce.AllowUserToDeleteRows = false;
            dgvTarixce.AllowUserToResizeRows = false;
            dgvTarixce.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTarixce.BackgroundColor = Color.White;
            dgvTarixce.BorderStyle = BorderStyle.None;
            dgvTarixce.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTarixce.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTarixce.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTarixce.ColumnHeadersHeight = 35;
            dgvTarixce.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTarixce.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTarixce.EnableHeadersVisualStyles = false;
            dgvTarixce.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvTarixce.GridColor = Color.FromArgb(224, 224, 224);
            dgvTarixce.Location = new Point(20, 30);
            dgvTarixce.MultiSelect = false;
            dgvTarixce.Name = "dgvTarixce";
            dgvTarixce.ReadOnly = true;
            dgvTarixce.RowHeadersVisible = false;
            dgvTarixce.RowTemplate.Height = 30;
            dgvTarixce.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTarixce.Size = new Size(1130, 230);
            dgvTarixce.TabIndex = 0;
            // 
            // btnTarixceYenile
            // 
            btnTarixceYenile.AutoSize = false;
            btnTarixceYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTarixceYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnTarixceYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTarixceYenile.Depth = 0;
            btnTarixceYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTarixceYenile.HighEmphasis = false;
            btnTarixceYenile.Icon = null;
            btnTarixceYenile.Location = new Point(970, 270);
            btnTarixceYenile.Margin = new Padding(4, 6, 4, 6);
            btnTarixceYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnTarixceYenile.Name = "btnTarixceYenile";
            btnTarixceYenile.NoAccentTextColor = Color.Empty;
            btnTarixceYenile.Size = new Size(180, 36);
            btnTarixceYenile.TabIndex = 1;
            btnTarixceYenile.Text = "🔄 Yenilə (F12)";
            toolTip1.SetToolTip(btnTarixceYenile, "Tarixçəni yenilə (F12)");
            btnTarixceYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTarixceYenile.UseAccentColor = false;
            btnTarixceYenile.UseVisualStyleBackColor = false;
            // 
            // grpEmeliyyat
            // 
            grpEmeliyyat.BackColor = Color.FromArgb(242, 242, 242);
            grpEmeliyyat.Controls.Add(txtSay);
            grpEmeliyyat.Controls.Add(txtQeyd);
            grpEmeliyyat.Controls.Add(btnStokArtir);
            grpEmeliyyat.Controls.Add(btnStokAzalt);
            grpEmeliyyat.Controls.Add(btnStokDuzelis);
            grpEmeliyyat.Controls.Add(btnTemizle);
            grpEmeliyyat.Enabled = false;
            grpEmeliyyat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpEmeliyyat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpEmeliyyat.Location = new Point(10, 230);
            grpEmeliyyat.Name = "grpEmeliyyat";
            grpEmeliyyat.Size = new Size(1170, 200);
            grpEmeliyyat.TabIndex = 2;
            grpEmeliyyat.TabStop = false;
            grpEmeliyyat.Text = "Stok Əməliyyatları";
            // 
            // txtSay
            // 
            txtSay.AnimateReadOnly = false;
            txtSay.BackColor = Color.FromArgb(242, 242, 242);
            txtSay.BackgroundImageLayout = ImageLayout.None;
            txtSay.CharacterCasing = CharacterCasing.Normal;
            txtSay.Depth = 0;
            txtSay.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSay.HideSelection = true;
            txtSay.Hint = "Say (məs: 10 və ya 10.50)";
            txtSay.LeadingIcon = null;
            txtSay.Location = new Point(20, 30);
            txtSay.MaxLength = 10;
            txtSay.MouseState = MaterialSkin.MouseState.OUT;
            txtSay.Name = "txtSay";
            txtSay.PasswordChar = '\0';
            txtSay.PrefixSuffixText = null;
            txtSay.ReadOnly = false;
            txtSay.RightToLeft = RightToLeft.No;
            txtSay.SelectedText = "";
            txtSay.SelectionLength = 0;
            txtSay.SelectionStart = 0;
            txtSay.ShortcutsEnabled = true;
            txtSay.Size = new Size(250, 48);
            txtSay.TabIndex = 0;
            txtSay.TabStop = false;
            txtSay.TextAlign = HorizontalAlignment.Left;
            toolTip1.SetToolTip(txtSay, "Əlavə ediləcək və ya azaldılacaq sayı daxil edin");
            txtSay.TrailingIcon = null;
            txtSay.UseSystemPasswordChar = false;
            // 
            // txtQeyd
            // 
            txtQeyd.AnimateReadOnly = false;
            txtQeyd.BackColor = Color.FromArgb(242, 242, 242);
            txtQeyd.BackgroundImageLayout = ImageLayout.None;
            txtQeyd.CharacterCasing = CharacterCasing.Normal;
            txtQeyd.Depth = 0;
            txtQeyd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeyd.HideSelection = true;
            txtQeyd.Hint = "Qeyd/Səbəb (opsional - düzəliş üçün mütləqdir)";
            txtQeyd.LeadingIcon = null;
            txtQeyd.Location = new Point(20, 90);
            txtQeyd.MaxLength = 500;
            txtQeyd.MouseState = MaterialSkin.MouseState.OUT;
            txtQeyd.Name = "txtQeyd";
            txtQeyd.PasswordChar = '\0';
            txtQeyd.PrefixSuffixText = null;
            txtQeyd.ReadOnly = false;
            txtQeyd.RightToLeft = RightToLeft.No;
            txtQeyd.SelectedText = "";
            txtQeyd.SelectionLength = 0;
            txtQeyd.SelectionStart = 0;
            txtQeyd.ShortcutsEnabled = true;
            txtQeyd.Size = new Size(1130, 48);
            txtQeyd.TabIndex = 1;
            txtQeyd.TabStop = false;
            txtQeyd.TextAlign = HorizontalAlignment.Left;
            toolTip1.SetToolTip(txtQeyd, "Əməliyyat üçün qeyd və ya səbəb (məs: inventarizasiya, satış iadəsi və s.)");
            txtQeyd.TrailingIcon = null;
            txtQeyd.UseSystemPasswordChar = false;
            // 
            // btnStokArtir
            // 
            btnStokArtir.AutoSize = false;
            btnStokArtir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStokArtir.BackColor = Color.FromArgb(242, 242, 242);
            btnStokArtir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStokArtir.Depth = 0;
            btnStokArtir.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnStokArtir.HighEmphasis = true;
            btnStokArtir.Icon = null;
            btnStokArtir.Location = new Point(20, 150);
            btnStokArtir.Margin = new Padding(4, 6, 4, 6);
            btnStokArtir.MouseState = MaterialSkin.MouseState.HOVER;
            btnStokArtir.Name = "btnStokArtir";
            btnStokArtir.NoAccentTextColor = Color.Empty;
            btnStokArtir.Size = new Size(200, 40);
            btnStokArtir.TabIndex = 2;
            btnStokArtir.Text = "➕ Stok Artır";
            toolTip1.SetToolTip(btnStokArtir, "Stok artır (məhsul alışı, iadə və s.)");
            btnStokArtir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokArtir.UseAccentColor = false;
            btnStokArtir.UseVisualStyleBackColor = false;
            // 
            // btnStokAzalt
            // 
            btnStokAzalt.AutoSize = false;
            btnStokAzalt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStokAzalt.BackColor = Color.FromArgb(242, 242, 242);
            btnStokAzalt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStokAzalt.Depth = 0;
            btnStokAzalt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnStokAzalt.HighEmphasis = true;
            btnStokAzalt.Icon = null;
            btnStokAzalt.Location = new Point(240, 150);
            btnStokAzalt.Margin = new Padding(4, 6, 4, 6);
            btnStokAzalt.MouseState = MaterialSkin.MouseState.HOVER;
            btnStokAzalt.Name = "btnStokAzalt";
            btnStokAzalt.NoAccentTextColor = Color.Empty;
            btnStokAzalt.Size = new Size(200, 40);
            btnStokAzalt.TabIndex = 3;
            btnStokAzalt.Text = "➖ Stok Azalt";
            toolTip1.SetToolTip(btnStokAzalt, "Stok azalt (zərər, istifadə və s.)");
            btnStokAzalt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokAzalt.UseAccentColor = false;
            btnStokAzalt.UseVisualStyleBackColor = false;
            // 
            // btnStokDuzelis
            // 
            btnStokDuzelis.AutoSize = false;
            btnStokDuzelis.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStokDuzelis.BackColor = Color.FromArgb(242, 242, 242);
            btnStokDuzelis.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStokDuzelis.Depth = 0;
            btnStokDuzelis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnStokDuzelis.HighEmphasis = true;
            btnStokDuzelis.Icon = null;
            btnStokDuzelis.Location = new Point(460, 150);
            btnStokDuzelis.Margin = new Padding(4, 6, 4, 6);
            btnStokDuzelis.MouseState = MaterialSkin.MouseState.HOVER;
            btnStokDuzelis.Name = "btnStokDuzelis";
            btnStokDuzelis.NoAccentTextColor = Color.Empty;
            btnStokDuzelis.Size = new Size(200, 40);
            btnStokDuzelis.TabIndex = 4;
            btnStokDuzelis.Text = "🔧 Düzəliş";
            toolTip1.SetToolTip(btnStokDuzelis, "Stok düzəliş (inventarizasiya, düzəltmə)");
            btnStokDuzelis.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokDuzelis.UseAccentColor = true;
            btnStokDuzelis.UseVisualStyleBackColor = false;
            // 
            // btnTemizle
            // 
            btnTemizle.AutoSize = false;
            btnTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemizle.Depth = 0;
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.HighEmphasis = false;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(950, 150);
            btnTemizle.Margin = new Padding(4, 6, 4, 6);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(200, 40);
            btnTemizle.TabIndex = 5;
            btnTemizle.Text = "🗑️ Təmizlə (F5)";
            toolTip1.SetToolTip(btnTemizle, "Formu təmizlə (F5)");
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            // 
            // pnlMehsulMelumat
            // 
            pnlMehsulMelumat.BackColor = Color.FromArgb(242, 242, 242);
            pnlMehsulMelumat.BorderStyle = BorderStyle.FixedSingle;
            pnlMehsulMelumat.Controls.Add(lblMehsulAdi);
            pnlMehsulMelumat.Controls.Add(lblStokKodu);
            pnlMehsulMelumat.Controls.Add(lblMovcudStok);
            pnlMehsulMelumat.Controls.Add(lblOlcuVahidi);
            pnlMehsulMelumat.Controls.Add(lblMehsulId);
            pnlMehsulMelumat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMehsulMelumat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMehsulMelumat.Location = new Point(10, 100);
            pnlMehsulMelumat.Name = "pnlMehsulMelumat";
            pnlMehsulMelumat.Size = new Size(1170, 120);
            pnlMehsulMelumat.TabIndex = 1;
            pnlMehsulMelumat.Visible = false;
            // 
            // lblMehsulAdi
            // 
            lblMehsulAdi.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulAdi.Depth = 0;
            lblMehsulAdi.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMehsulAdi.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblMehsulAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulAdi.Location = new Point(15, 10);
            lblMehsulAdi.MouseState = MaterialSkin.MouseState.HOVER;
            lblMehsulAdi.Name = "lblMehsulAdi";
            lblMehsulAdi.Size = new Size(1140, 30);
            lblMehsulAdi.TabIndex = 0;
            lblMehsulAdi.Text = "Məhsul Adı";
            // 
            // lblStokKodu
            // 
            lblStokKodu.BackColor = Color.FromArgb(242, 242, 242);
            lblStokKodu.Depth = 0;
            lblStokKodu.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStokKodu.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblStokKodu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblStokKodu.Location = new Point(15, 45);
            lblStokKodu.MouseState = MaterialSkin.MouseState.HOVER;
            lblStokKodu.Name = "lblStokKodu";
            lblStokKodu.Size = new Size(400, 20);
            lblStokKodu.TabIndex = 1;
            lblStokKodu.Text = "Stok Kodu: -";
            // 
            // lblMovcudStok
            // 
            lblMovcudStok.BackColor = Color.FromArgb(242, 242, 242);
            lblMovcudStok.Depth = 0;
            lblMovcudStok.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMovcudStok.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblMovcudStok.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMovcudStok.Location = new Point(15, 75);
            lblMovcudStok.MouseState = MaterialSkin.MouseState.HOVER;
            lblMovcudStok.Name = "lblMovcudStok";
            lblMovcudStok.Size = new Size(300, 30);
            lblMovcudStok.TabIndex = 2;
            lblMovcudStok.Text = "Mövcud Stok: 0";
            // 
            // lblOlcuVahidi
            // 
            lblOlcuVahidi.BackColor = Color.FromArgb(242, 242, 242);
            lblOlcuVahidi.Depth = 0;
            lblOlcuVahidi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOlcuVahidi.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblOlcuVahidi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblOlcuVahidi.Location = new Point(320, 80);
            lblOlcuVahidi.MouseState = MaterialSkin.MouseState.HOVER;
            lblOlcuVahidi.Name = "lblOlcuVahidi";
            lblOlcuVahidi.Size = new Size(200, 20);
            lblOlcuVahidi.TabIndex = 3;
            lblOlcuVahidi.Text = "ədəd";
            // 
            // lblMehsulId
            // 
            lblMehsulId.AutoSize = true;
            lblMehsulId.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulId.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMehsulId.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulId.Location = new Point(1000, 10);
            lblMehsulId.Name = "lblMehsulId";
            lblMehsulId.Size = new Size(0, 17);
            lblMehsulId.TabIndex = 4;
            lblMehsulId.Visible = false;
            // 
            // grpAxtaris
            // 
            grpAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            grpAxtaris.Controls.Add(txtAxtaris);
            grpAxtaris.Controls.Add(btnAxtar);
            grpAxtaris.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpAxtaris.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpAxtaris.Location = new Point(10, 10);
            grpAxtaris.Name = "grpAxtaris";
            grpAxtaris.Size = new Size(1170, 80);
            grpAxtaris.TabIndex = 0;
            grpAxtaris.TabStop = false;
            grpAxtaris.Text = "Məhsul Axtarışı";
            // 
            // txtAxtaris
            // 
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Upper;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Barkod və ya Stok Kodu daxil edin...";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(20, 25);
            txtAxtaris.MaxLength = 50;
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
            txtAxtaris.Size = new Size(970, 48);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            toolTip1.SetToolTip(txtAxtaris, "Məhsulun barkod və ya stok kodunu daxil edib Enter basın (F3)");
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            // 
            // btnAxtar
            // 
            btnAxtar.AutoSize = false;
            btnAxtar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAxtar.BackColor = Color.FromArgb(242, 242, 242);
            btnAxtar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAxtar.Depth = 0;
            btnAxtar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAxtar.HighEmphasis = true;
            btnAxtar.Icon = null;
            btnAxtar.Location = new Point(1005, 31);
            btnAxtar.Margin = new Padding(4, 6, 4, 6);
            btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAxtar.Name = "btnAxtar";
            btnAxtar.NoAccentTextColor = Color.Empty;
            btnAxtar.Size = new Size(150, 36);
            btnAxtar.TabIndex = 1;
            btnAxtar.Text = "🔍 Axtar (F3)";
            toolTip1.SetToolTip(btnAxtar, "Məhsulu axtar (F3)");
            btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAxtar.UseAccentColor = false;
            btnAxtar.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // AnbarFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 900);
            Controls.Add(splitContainer1);
            Name = "AnbarFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anbar İdarəetməsi";
            Controls.SetChildIndex(splitContainer1, 0);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpMehsullar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).EndInit();
            pnlSag.ResumeLayout(false);
            grpTarixce.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTarixce).EndInit();
            grpEmeliyyat.ResumeLayout(false);
            pnlMehsulMelumat.ResumeLayout(false);
            pnlMehsulMelumat.PerformLayout();
            grpAxtaris.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Main Container
        private SplitContainer splitContainer1;

        // Sol Tərəf - Məhsullar
        private GroupBox grpMehsullar;
        private DataGridView dgvMehsullar;
        private DataGridViewTextBoxColumn colMehsulId;
        private DataGridViewTextBoxColumn colMehsulAdi;
        private DataGridViewTextBoxColumn colStokKodu;
        private DataGridViewTextBoxColumn colBarkod;
        private DataGridViewTextBoxColumn colMovcudSay;

        // Sağ Tərəf
        private Panel pnlSag;

        // Axtarış
        private GroupBox grpAxtaris;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private MaterialSkin.Controls.MaterialButton btnAxtar;

        // Məhsul Məlumatı
        private Panel pnlMehsulMelumat;
        private MaterialSkin.Controls.MaterialLabel lblMehsulAdi;
        private MaterialSkin.Controls.MaterialLabel lblStokKodu;
        private MaterialSkin.Controls.MaterialLabel lblMovcudStok;
        private MaterialSkin.Controls.MaterialLabel lblOlcuVahidi;
        private Label lblMehsulId;

        // Əməliyyatlar
        private GroupBox grpEmeliyyat;
        private MaterialSkin.Controls.MaterialTextBox2 txtSay;
        private MaterialSkin.Controls.MaterialTextBox2 txtQeyd;
        private MaterialSkin.Controls.MaterialButton btnStokArtir;
        private MaterialSkin.Controls.MaterialButton btnStokAzalt;
        private MaterialSkin.Controls.MaterialButton btnStokDuzelis;
        private MaterialSkin.Controls.MaterialButton btnTemizle;

        // Tarixçə
        private GroupBox grpTarixce;
        private DataGridView dgvTarixce;
        private DataGridViewTextBoxColumn colTarix;
        private DataGridViewTextBoxColumn colIstifadeci;
        private DataGridViewTextBoxColumn colEmeliyyatNovu;
        private DataGridViewTextBoxColumn colMehsul;
        private DataGridViewTextBoxColumn colDeyisiklik;
        private DataGridViewTextBoxColumn colQeyd;
        private MaterialSkin.Controls.MaterialButton btnTarixceYenile;

        // Yardımçılar
        private ErrorProvider errorProvider1;
        private ToolTip toolTip1;
    }
}
