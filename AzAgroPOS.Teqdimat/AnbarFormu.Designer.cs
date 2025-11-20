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

            // Axtarış Paneli
            grpAxtaris = new GroupBox();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            btnAxtar = new MaterialSkin.Controls.MaterialButton();

            // Məhsul Məlumat Paneli
            pnlMehsulMelumat = new Panel();
            lblMehsulAdi = new MaterialSkin.Controls.MaterialLabel();
            lblStokKodu = new MaterialSkin.Controls.MaterialLabel();
            lblMovcudStok = new MaterialSkin.Controls.MaterialLabel();
            lblOlcuVahidi = new MaterialSkin.Controls.MaterialLabel();
            lblMehsulId = new Label();

            // Əməliyyat Paneli
            grpEmeliyyat = new GroupBox();
            txtSay = new MaterialSkin.Controls.MaterialTextBox2();
            txtQeyd = new MaterialSkin.Controls.MaterialTextBox2();
            btnStokArtir = new MaterialSkin.Controls.MaterialButton();
            btnStokAzalt = new MaterialSkin.Controls.MaterialButton();
            btnStokDuzelis = new MaterialSkin.Controls.MaterialButton();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();

            // Tarixçə Paneli
            grpTarixce = new GroupBox();
            dgvTarixce = new DataGridView();
            colTarix = new DataGridViewTextBoxColumn();
            colIstifadeci = new DataGridViewTextBoxColumn();
            colEmeliyyatNovu = new DataGridViewTextBoxColumn();
            colKohneStok = new DataGridViewTextBoxColumn();
            colDeyisiklik = new DataGridViewTextBoxColumn();
            colYeniStok = new DataGridViewTextBoxColumn();
            colQeyd = new DataGridViewTextBoxColumn();
            btnTarixceYenile = new MaterialSkin.Controls.MaterialButton();

            // Yardımçılar
            errorProvider1 = new ErrorProvider(components);
            toolTip1 = new ToolTip(components);

            grpAxtaris.SuspendLayout();
            pnlMehsulMelumat.SuspendLayout();
            grpEmeliyyat.SuspendLayout();
            grpTarixce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarixce).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            //
            // grpAxtaris
            //
            grpAxtaris.Controls.Add(txtAxtaris);
            grpAxtaris.Controls.Add(btnAxtar);
            grpAxtaris.Font = new Font("Roboto", 10F, FontStyle.Bold);
            grpAxtaris.Location = new Point(20, 85);
            grpAxtaris.Name = "grpAxtaris";
            grpAxtaris.Size = new Size(1160, 80);
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
            txtAxtaris.Size = new Size(960, 48);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            toolTip1.SetToolTip(txtAxtaris, "Məhsulun barkod və ya stok kodunu daxil edib Enter basın (F3)");

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
            btnAxtar.Location = new Point(995, 31);
            btnAxtar.Margin = new Padding(4, 6, 4, 6);
            btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAxtar.Name = "btnAxtar";
            btnAxtar.NoAccentTextColor = Color.Empty;
            btnAxtar.Size = new Size(150, 36);
            btnAxtar.TabIndex = 1;
            btnAxtar.Text = "🔍 Axtar (F3)";
            btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAxtar.UseAccentColor = false;
            btnAxtar.UseVisualStyleBackColor = false;
            toolTip1.SetToolTip(btnAxtar, "Məhsulu axtar (F3)");

            //
            // pnlMehsulMelumat
            //
            pnlMehsulMelumat.BackColor = Color.FromArgb(245, 248, 250);
            pnlMehsulMelumat.BorderStyle = BorderStyle.FixedSingle;
            pnlMehsulMelumat.Controls.Add(lblMehsulAdi);
            pnlMehsulMelumat.Controls.Add(lblStokKodu);
            pnlMehsulMelumat.Controls.Add(lblMovcudStok);
            pnlMehsulMelumat.Controls.Add(lblOlcuVahidi);
            pnlMehsulMelumat.Controls.Add(lblMehsulId);
            pnlMehsulMelumat.Location = new Point(20, 175);
            pnlMehsulMelumat.Name = "pnlMehsulMelumat";
            pnlMehsulMelumat.Size = new Size(1160, 120);
            pnlMehsulMelumat.TabIndex = 1;
            pnlMehsulMelumat.Visible = false;

            //
            // lblMehsulAdi
            //
            lblMehsulAdi.BackColor = Color.FromArgb(245, 248, 250);
            lblMehsulAdi.Depth = 0;
            lblMehsulAdi.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMehsulAdi.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblMehsulAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulAdi.Location = new Point(15, 10);
            lblMehsulAdi.MouseState = MaterialSkin.MouseState.HOVER;
            lblMehsulAdi.Name = "lblMehsulAdi";
            lblMehsulAdi.Size = new Size(1130, 30);
            lblMehsulAdi.TabIndex = 0;
            lblMehsulAdi.Text = "Məhsul Adı";

            //
            // lblStokKodu
            //
            lblStokKodu.BackColor = Color.FromArgb(245, 248, 250);
            lblStokKodu.Depth = 0;
            lblStokKodu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStokKodu.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblStokKodu.ForeColor = Color.FromArgb(180, 0, 0, 0);
            lblStokKodu.Location = new Point(15, 45);
            lblStokKodu.MouseState = MaterialSkin.MouseState.HOVER;
            lblStokKodu.Name = "lblStokKodu";
            lblStokKodu.Size = new Size(400, 20);
            lblStokKodu.TabIndex = 1;
            lblStokKodu.Text = "Stok Kodu: -";

            //
            // lblMovcudStok
            //
            lblMovcudStok.BackColor = Color.FromArgb(245, 248, 250);
            lblMovcudStok.Depth = 0;
            lblMovcudStok.Font = new Font("Roboto", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMovcudStok.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lblMovcudStok.ForeColor = Color.FromArgb(33, 150, 243);
            lblMovcudStok.Location = new Point(15, 75);
            lblMovcudStok.MouseState = MaterialSkin.MouseState.HOVER;
            lblMovcudStok.Name = "lblMovcudStok";
            lblMovcudStok.Size = new Size(300, 30);
            lblMovcudStok.TabIndex = 2;
            lblMovcudStok.Text = "Mövcud Stok: 0";

            //
            // lblOlcuVahidi
            //
            lblOlcuVahidi.BackColor = Color.FromArgb(245, 248, 250);
            lblOlcuVahidi.Depth = 0;
            lblOlcuVahidi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOlcuVahidi.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblOlcuVahidi.ForeColor = Color.FromArgb(180, 0, 0, 0);
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
            lblMehsulId.Location = new Point(1000, 10);
            lblMehsulId.Name = "lblMehsulId";
            lblMehsulId.Size = new Size(0, 15);
            lblMehsulId.TabIndex = 4;
            lblMehsulId.Visible = false;

            //
            // grpEmeliyyat
            //
            grpEmeliyyat.Controls.Add(txtSay);
            grpEmeliyyat.Controls.Add(txtQeyd);
            grpEmeliyyat.Controls.Add(btnStokArtir);
            grpEmeliyyat.Controls.Add(btnStokAzalt);
            grpEmeliyyat.Controls.Add(btnStokDuzelis);
            grpEmeliyyat.Controls.Add(btnTemizle);
            grpEmeliyyat.Enabled = false;
            grpEmeliyyat.Font = new Font("Roboto", 10F, FontStyle.Bold);
            grpEmeliyyat.Location = new Point(20, 305);
            grpEmeliyyat.Name = "grpEmeliyyat";
            grpEmeliyyat.Size = new Size(1160, 200);
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
            txtSay.TrailingIcon = null;
            txtSay.UseSystemPasswordChar = false;
            toolTip1.SetToolTip(txtSay, "Əlavə ediləcək və ya azaldılacaq sayı daxil edin");

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
            txtQeyd.Size = new Size(1120, 48);
            txtQeyd.TabIndex = 1;
            txtQeyd.TabStop = false;
            txtQeyd.TextAlign = HorizontalAlignment.Left;
            txtQeyd.TrailingIcon = null;
            txtQeyd.UseSystemPasswordChar = false;
            toolTip1.SetToolTip(txtQeyd, "Əməliyyat üçün qeyd və ya səbəb (məs: inventarizasiya, satış iadəsi və s.)");

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
            btnStokArtir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokArtir.UseAccentColor = false;
            btnStokArtir.UseVisualStyleBackColor = false;
            toolTip1.SetToolTip(btnStokArtir, "Stok artır (məhsul alışı, iadə və s.)");

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
            btnStokAzalt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokAzalt.UseAccentColor = false;
            btnStokAzalt.UseVisualStyleBackColor = false;
            toolTip1.SetToolTip(btnStokAzalt, "Stok azalt (zərər, istifadə və s.)");

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
            btnStokDuzelis.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokDuzelis.UseAccentColor = true;
            btnStokDuzelis.UseVisualStyleBackColor = false;
            toolTip1.SetToolTip(btnStokDuzelis, "Stok düzəliş (inventarizasiya, düzəltmə)");

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
            btnTemizle.Location = new Point(940, 150);
            btnTemizle.Margin = new Padding(4, 6, 4, 6);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(200, 40);
            btnTemizle.TabIndex = 5;
            btnTemizle.Text = "🗑️ Təmizlə (F5)";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            toolTip1.SetToolTip(btnTemizle, "Formu təmizlə (F5)");

            //
            // grpTarixce
            //
            grpTarixce.Controls.Add(dgvTarixce);
            grpTarixce.Controls.Add(btnTarixceYenile);
            grpTarixce.Font = new Font("Roboto", 10F, FontStyle.Bold);
            grpTarixce.Location = new Point(20, 515);
            grpTarixce.Name = "grpTarixce";
            grpTarixce.Size = new Size(1160, 285);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.Font = new Font("Roboto", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTarixce.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTarixce.ColumnHeadersHeight = 35;
            dgvTarixce.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTarixce.Columns.AddRange(new DataGridViewColumn[] {
                colTarix,
                colIstifadeci,
                colEmeliyyatNovu,
                colKohneStok,
                colDeyisiklik,
                colYeniStok,
                colQeyd
            });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Roboto", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTarixce.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTarixce.EnableHeadersVisualStyles = false;
            dgvTarixce.GridColor = Color.FromArgb(224, 224, 224);
            dgvTarixce.Location = new Point(20, 30);
            dgvTarixce.MultiSelect = false;
            dgvTarixce.Name = "dgvTarixce";
            dgvTarixce.ReadOnly = true;
            dgvTarixce.RowHeadersVisible = false;
            dgvTarixce.RowTemplate.Height = 30;
            dgvTarixce.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTarixce.Size = new Size(1120, 200);
            dgvTarixce.TabIndex = 0;

            //
            // colTarix
            //
            colTarix.DataPropertyName = "Tarix";
            colTarix.HeaderText = "Tarix";
            colTarix.Name = "colTarix";
            colTarix.ReadOnly = true;
            colTarix.FillWeight = 15;

            //
            // colIstifadeci
            //
            colIstifadeci.DataPropertyName = "IstifadeciAdi";
            colIstifadeci.HeaderText = "İstifadəçi";
            colIstifadeci.Name = "colIstifadeci";
            colIstifadeci.ReadOnly = true;
            colIstifadeci.FillWeight = 12;

            //
            // colEmeliyyatNovu
            //
            colEmeliyyatNovu.DataPropertyName = "EmeliyyatNovu";
            colEmeliyyatNovu.HeaderText = "Əməliyyat";
            colEmeliyyatNovu.Name = "colEmeliyyatNovu";
            colEmeliyyatNovu.ReadOnly = true;
            colEmeliyyatNovu.FillWeight = 12;

            //
            // colKohneStok
            //
            colKohneStok.DataPropertyName = "KohneStok";
            colKohneStok.HeaderText = "Köhnə Stok";
            colKohneStok.Name = "colKohneStok";
            colKohneStok.ReadOnly = true;
            colKohneStok.FillWeight = 10;

            //
            // colDeyisiklik
            //
            colDeyisiklik.DataPropertyName = "DeyisiklikMiqdari";
            colDeyisiklik.HeaderText = "Dəyişiklik";
            colDeyisiklik.Name = "colDeyisiklik";
            colDeyisiklik.ReadOnly = true;
            colDeyisiklik.FillWeight = 10;

            //
            // colYeniStok
            //
            colYeniStok.DataPropertyName = "YeniStok";
            colYeniStok.HeaderText = "Yeni Stok";
            colYeniStok.Name = "colYeniStok";
            colYeniStok.ReadOnly = true;
            colYeniStok.FillWeight = 10;

            //
            // colQeyd
            //
            colQeyd.DataPropertyName = "Qeyd";
            colQeyd.HeaderText = "Qeyd";
            colQeyd.Name = "colQeyd";
            colQeyd.ReadOnly = true;
            colQeyd.FillWeight = 31;

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
            btnTarixceYenile.Location = new Point(960, 240);
            btnTarixceYenile.Margin = new Padding(4, 6, 4, 6);
            btnTarixceYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnTarixceYenile.Name = "btnTarixceYenile";
            btnTarixceYenile.NoAccentTextColor = Color.Empty;
            btnTarixceYenile.Size = new Size(180, 36);
            btnTarixceYenile.TabIndex = 1;
            btnTarixceYenile.Text = "🔄 Yenilə (F12)";
            btnTarixceYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTarixceYenile.UseAccentColor = false;
            btnTarixceYenile.UseVisualStyleBackColor = false;
            toolTip1.SetToolTip(btnTarixceYenile, "Tarixçəni yenilə (F12)");

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
            ClientSize = new Size(1200, 820);
            Controls.Add(grpTarixce);
            Controls.Add(grpEmeliyyat);
            Controls.Add(pnlMehsulMelumat);
            Controls.Add(grpAxtaris);
            Name = "AnbarFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anbar İdarəetməsi";
            Controls.SetChildIndex(grpAxtaris, 0);
            Controls.SetChildIndex(pnlMehsulMelumat, 0);
            Controls.SetChildIndex(grpEmeliyyat, 0);
            Controls.SetChildIndex(grpTarixce, 0);
            grpAxtaris.ResumeLayout(false);
            pnlMehsulMelumat.ResumeLayout(false);
            pnlMehsulMelumat.PerformLayout();
            grpEmeliyyat.ResumeLayout(false);
            grpTarixce.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTarixce).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
        private DataGridViewTextBoxColumn colKohneStok;
        private DataGridViewTextBoxColumn colDeyisiklik;
        private DataGridViewTextBoxColumn colYeniStok;
        private DataGridViewTextBoxColumn colQeyd;
        private MaterialSkin.Controls.MaterialButton btnTarixceYenile;

        // Yardımçılar
        private ErrorProvider errorProvider1;
        private ToolTip toolTip1;
    }
}
