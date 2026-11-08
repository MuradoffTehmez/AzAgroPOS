// Fayl: AzAgroPOS.Teqdimat/NisyeIdareetmeFormu.cs

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat;

public partial class NisyeIdareetmeFormu : BazaForm, INisyeView
{
    private readonly NisyePresenter _presenter;
    private readonly MaterialSkin.Controls.MaterialButton _btnEvvelkiBorc;
    private decimal _evvelkiBorcMeblegi;
    private string _evvelkiBorcQeydi = string.Empty;
    private DateTime _evvelkiBorcTarixi = DateTime.Today;
    private readonly ComboBox _odenisMetodu;

    public NisyeIdareetmeFormu(NisyeManager nisyeManager, MusteriManager musteriManager)
    {
        InitializeComponent();
        _presenter = new NisyePresenter(this, nisyeManager, musteriManager);
        StilVerDataGridView(dgvMusteriler);
        StilVerDataGridView(dgvNisyeHereketleri);
        _btnEvvelkiBorc = new MaterialSkin.Controls.MaterialButton
        {
            Name = "btnEvvelkiBorc",
            Text = "ƏVVƏLKİ BORCU ƏLAVƏ ET",
            AutoSize = false,
            Size = new Size(215, 42),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined
        };
        materialCard1.Controls.Add(_btnEvvelkiBorc);
        _odenisMetodu = new ComboBox
        {
            Name = "cmbOdenisMetodu",
            DropDownStyle = ComboBoxStyle.DropDownList,
            Location = new Point(390, 52),
            Size = new Size(145, 32),
            Anchor = AnchorStyles.Top | AnchorStyles.Left
        };
        _odenisMetodu.Items.AddRange(new object[] { OdenisMetodu.Nağd, OdenisMetodu.Kart });
        _odenisMetodu.SelectedIndex = 0;
        materialCard1.Controls.Add(_odenisMetodu);
        materialCard1.Resize += (_, _) =>
        {
            btnOdenisEt.Left = materialCard1.ClientSize.Width - btnOdenisEt.Width - 24;
            _btnEvvelkiBorc.Location = new Point(btnOdenisEt.Left - _btnEvvelkiBorc.Width - 12, btnOdenisEt.Top);
        };
        btnOdenisEt.Left = materialCard1.ClientSize.Width - btnOdenisEt.Width - 24;
        _btnEvvelkiBorc.Location = new Point(btnOdenisEt.Left - _btnEvvelkiBorc.Width - 12, btnOdenisEt.Top);
        _btnEvvelkiBorc.Click += BtnEvvelkiBorc_Click;
    }

    public int? SecilmisMusteriId => dgvMusteriler.CurrentRow != null && dgvMusteriler.CurrentRow.DataBoundItem is MusteriDto musteri ? musteri.Id : null;
    public OdenisMetodu OdenisMetodu => (OdenisMetodu)_odenisMetodu.SelectedItem!;
    public DateTime EvvelkiBorcTarixi => _evvelkiBorcTarixi;

    public decimal OdenisMeblegi => decimal.TryParse(txtOdenisMeblegi.Text, out decimal mebleg) ? mebleg : 0;
    public decimal EvvelkiBorcMeblegi => _evvelkiBorcMeblegi;
    public string EvvelkiBorcQeydi => _evvelkiBorcQeydi;

    /// <summary>
    /// Ödəniş düyməsinin aktiv/deaktiv olma vəziyyəti
    /// </summary>
    public bool OdenisButtonAktivdir
    {
        get => btnOdenisEt.Enabled;
        set
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => btnOdenisEt.Enabled = value));
            }
            else
            {
                btnOdenisEt.Enabled = value;
            }
        }
    }

    public event EventHandler FormYuklendi;
    public event EventHandler MusteriSecildi;
    public event EventHandler OdenisEdildi;
    public event EventHandler EvvelkiBorcElaveEdildi;

    public void MusterileriGoster(List<MusteriDto> musteriler)
    {
        int? secilmisId = SecilmisMusteriId;
        dgvMusteriler.SelectionChanged -= dgvMusteriler_SelectionChanged;
        dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvMusteriler.AllowUserToResizeColumns = true;
        dgvMusteriler.ScrollBars = ScrollBars.Both;
        if (dgvMusteriler.Columns.Count == 0)
        {
            dgvMusteriler.AutoGenerateColumns = false;

            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unvan", DataPropertyName = "Unvan", Visible = false });
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TamAd", DataPropertyName = "TamAd", HeaderText = "Tam Ad", Width = 240 });
            dgvMusteriler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TelefonNomresi", DataPropertyName = "TelefonNomresi", HeaderText = "Telefon", Width = 150 });

            var debtCol = new DataGridViewTextBoxColumn { Name = "UmumiBorc", DataPropertyName = "UmumiBorc", HeaderText = "Ümumi Borc" };
            debtCol.DefaultCellStyle.Format = "N2";
            debtCol.Width = 140;
            dgvMusteriler.Columns.Add(debtCol);

            var limitCol = new DataGridViewTextBoxColumn { Name = "KreditLimiti", DataPropertyName = "KreditLimiti", HeaderText = "Kredit Limiti" };
            limitCol.DefaultCellStyle.Format = "N2";
            limitCol.Width = 140;
            dgvMusteriler.Columns.Add(limitCol);
        }

        dgvMusteriler.DataSource = new System.ComponentModel.BindingList<MusteriDto>(musteriler);
        if (secilmisId.HasValue)
        {
            foreach (DataGridViewRow row in dgvMusteriler.Rows)
            {
                if (row.DataBoundItem is MusteriDto m && m.Id == secilmisId.Value)
                {
                    dgvMusteriler.CurrentCell = row.Cells["TamAd"];
                    break;
                }
            }
        }
        dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
        MusteriSecildi?.Invoke(this, EventArgs.Empty);
    }

    public void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler)
    {
        dgvNisyeHereketleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvNisyeHereketleri.AllowUserToResizeColumns = true;
        dgvNisyeHereketleri.ScrollBars = ScrollBars.Both;
        if (dgvNisyeHereketleri.Columns.Count == 0)
        {
            dgvNisyeHereketleri.AutoGenerateColumns = false;

            var dateCol = new DataGridViewTextBoxColumn { Name = "Tarix", DataPropertyName = "Tarix", HeaderText = "Tarix", Width = 155 };
            dateCol.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dgvNisyeHereketleri.Columns.Add(dateCol);

            var sumCol = new DataGridViewTextBoxColumn { Name = "Mebleg", DataPropertyName = "Mebleg", HeaderText = "Məbləğ", Width = 120 };
            sumCol.DefaultCellStyle.Format = "N2";
            dgvNisyeHereketleri.Columns.Add(sumCol);

            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmeliyyatNovu", DataPropertyName = "EmeliyyatNovu", HeaderText = "Növü", Width = 145 });
            dgvNisyeHereketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeyd", DataPropertyName = "Qeyd", HeaderText = "Qeyd", Width = 420 });
        }

        dgvNisyeHereketleri.DataSource = new System.ComponentModel.BindingList<NisyeHereketiDto>(hereketler);
    }

    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
    }

    /// <summary>
    /// MessageBox göstərir və istifadəçi cavabını qaytarır
    /// </summary>
    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        return MessageBox.Show(mesaj, basliq, buttons, icon);
    }

    /// <summary>
    /// Shows a validation error on a control
    /// </summary>
    /// <param name="control">Control to show error on</param>
    /// <param name="message">Error message</param>
    public void XetaGoster(Control control, string message)
    {
        errorProvider1.SetError(control, message);
        errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        errorProvider1.SetIconPadding(control, 2);
    }

    /// <summary>
    /// Clears validation error from a control
    /// </summary>
    /// <param name="control">Control to clear error from</param>
    public void XetaniTemizle(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
    }

    /// <summary>
    /// Clears all validation errors
    /// </summary>
    public void ButunXetalariTemizle()
    {
        // Clear errors from all controls
        foreach (Control control in Controls)
        {
            ClearErrorsRecursive(control);
        }
    }

    /// <summary>
    /// Recursively clears errors from all controls
    /// </summary>
    /// <param name="control">Control to clear errors from</param>
    private void ClearErrorsRecursive(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
        foreach (Control child in control.Controls)
        {
            ClearErrorsRecursive(child);
        }
    }

    public void FormuTemizle()
    {
        txtOdenisMeblegi.Clear();
        ButunXetalariTemizle();
        txtOdenisMeblegi.Focus();
    }

    private void NisyeIdareetmeFormu_Load(object sender, EventArgs e)
    {
        // Numeric input validation üçün KeyPress event-i əlavə et
        txtOdenisMeblegi.KeyPress += TxtOdenisMeblegi_KeyPress;
        txtOdenisMeblegi.TextChanged += TxtOdenisMeblegi_TextChanged;

        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Yalnız rəqəm və ondalık nöqtə daxil edilməsinə icazə verir
    /// </summary>
    private void TxtOdenisMeblegi_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Backspace, Delete və Ctrl+V icazə verilir
        if (char.IsControl(e.KeyChar))
        {
            return;
        }

        // Yalnız rəqəmlər və ondalık separator
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
        {
            e.Handled = true;
            return;
        }

        // Yalnız bir dəfə ondalık separator
        if ((e.KeyChar == '.' || e.KeyChar == ',') &&
            (txtOdenisMeblegi.Text.Contains(".") || txtOdenisMeblegi.Text.Contains(",")))
        {
            e.Handled = true;
        }
    }

    /// <summary>
    /// Məbləğ dəyişdikdə validation error-ları təmizləyir
    /// </summary>
    private void TxtOdenisMeblegi_TextChanged(object sender, EventArgs e)
    {
        XetaniTemizle(txtOdenisMeblegi);
    }

    private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
    {
        MusteriSecildi?.Invoke(this, EventArgs.Empty);
    }

    private void btnOdenisEt_Click(object sender, EventArgs e)
    {
        OdenisEdildi?.Invoke(this, EventArgs.Empty);
    }

    private void BtnEvvelkiBorc_Click(object? sender, EventArgs e)
    {
        if (!IcazeVarmiMesajla(SistemIcazeleri.NisyeVer))
        {
            return;
        }

        if (!SecilmisMusteriId.HasValue)
        {
            MesajGoster("Əvvəlcə müştəri seçin.", "Xəbərdarlıq");
            return;
        }

        using Form dialog = new()
        {
            Text = "Proqramdan əvvəlki borc",
            ClientSize = new Size(420, 275),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            StartPosition = FormStartPosition.CenterParent
        };
        Label lblMebleg = new() { Text = "Əvvəlki borc (AZN)", Location = new Point(20, 18), AutoSize = true };
        NumericUpDown mebleg = new()
        {
            Location = new Point(20, 45),
            Size = new Size(380, 30),
            DecimalPlaces = 2,
            Minimum = 0.01m,
            Maximum = 999999999m,
            ThousandsSeparator = true
        };
        Label lblQeyd = new() { Text = "Qeyd / borcun mənbəyi", Location = new Point(20, 90), AutoSize = true };
        TextBox qeyd = new() { Location = new Point(20, 116), Size = new Size(380, 30), MaxLength = 300 };
        Label lblTarix = new() { Text = "Borcun yarandığı tarix", Location = new Point(20, 157), AutoSize = true };
        DateTimePicker tarix = new() { Location = new Point(20, 181), Size = new Size(380, 30), MaxDate = DateTime.Today };
        Button tesdiq = new() { Text = "Əlavə et", Location = new Point(220, 225), Size = new Size(85, 32), DialogResult = DialogResult.OK };
        Button imtina = new() { Text = "İmtina", Location = new Point(315, 225), Size = new Size(85, 32), DialogResult = DialogResult.Cancel };
        dialog.Controls.AddRange(new Control[] { lblMebleg, mebleg, lblQeyd, qeyd, lblTarix, tarix, tesdiq, imtina });
        dialog.AcceptButton = tesdiq;
        dialog.CancelButton = imtina;
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _evvelkiBorcMeblegi = mebleg.Value;
            _evvelkiBorcQeydi = qeyd.Text;
            _evvelkiBorcTarixi = tarix.Value.Date;
            EvvelkiBorcElaveEdildi?.Invoke(this, EventArgs.Empty);
        }
    }
}
