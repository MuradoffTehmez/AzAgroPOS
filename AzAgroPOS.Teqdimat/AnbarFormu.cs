// Fayl: AzAgroPOS.Teqdimat/AnbarFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Sabitler;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Anbar idarəetmə formu - Stok artırma, azaltma, düzəliş əməliyyatları
/// </summary>
public partial class AnbarFormu : BazaForm, IAnbarView
{
    #region Fields

    private readonly AnbarPresenter _presenter;
    private bool _isLoading;
    private bool _suppressEvents = false;

    #endregion

    #region Constructor

    public AnbarFormu(
        AnbarManager anbarManager,
        StokHareketiManager stokHareketiManager)
    {
        InitializeComponent();

        _presenter = new AnbarPresenter(this, anbarManager, stokHareketiManager);

        ConfigureForm();
        WireUpEventHandlers();
    }

    #endregion

    #region IAnbarView Properties - Input Data

    public string AxtarisMetni => txtAxtaris.Text?.Trim() ?? string.Empty;

    public string ElaveOlunanSay => txtSay.Text?.Trim() ?? string.Empty;

    public int? SecilmisMehsulId
    {
        get
        {
            if (int.TryParse(lblMehsulId.Text, out int id) && id > 0)
                return id;
            return null;
        }
    }

    public string Qeyd => txtQeyd.Text?.Trim() ?? string.Empty;

    public string EmeliyyatNovu { get; private set; } = AnbarSabitleri.EmeliyyatNovu.StokArtirma;

    #endregion

    #region IAnbarView Properties - State

    public bool IsLoading => _isLoading;

    public bool MehsulSecilmisdir => SecilmisMehsulId.HasValue && SecilmisMehsulId.Value > 0;

    #endregion

    #region IAnbarView Events

    public event EventHandler AxtarIstek;
    public event EventHandler StokArtirIstek;
    public event EventHandler StokAzaltIstek;
    public event EventHandler StokDuzelisIstek;
    public event EventHandler TemizleIstek;
    public event EventHandler TarixceGosterIstek;
    public event EventHandler FormYuklendi;

    #endregion

    #region Form Configuration

    private void ConfigureForm()
    {
        // Form ayarları
        this.Text = AnbarSabitleri.UIMetinler.FormBasligi;
        this.KeyPreview = true; // Klaviatura qısayolları üçün

        // ErrorProvider ayarları
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider1.Icon = SystemIcons.Error;

        // Initial state
        pnlMehsulMelumat.Visible = false;
        grpEmeliyyat.Enabled = false;

        // DataGrid formatlaması
        FormatDataGrid();
    }

    private void FormatDataGrid()
    {
        // Tarix sütunu formatı
        dgvTarixce.Columns["colTarix"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

        // Say sütunları formatı (sağa hizala)
        dgvTarixce.Columns["colKohneStok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvTarixce.Columns["colDeyisiklik"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvTarixce.Columns["colYeniStok"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        dgvTarixce.Columns["colKohneStok"].DefaultCellStyle.Format = "N2";
        dgvTarixce.Columns["colDeyisiklik"].DefaultCellStyle.Format = "N2";
        dgvTarixce.Columns["colYeniStok"].DefaultCellStyle.Format = "N2";
    }

    private void WireUpEventHandlers()
    {
        // Form events
        this.Load += AnbarFormu_Load;
        this.KeyDown += AnbarFormu_KeyDown;

        // Search events
        txtAxtaris.KeyDown += TxtAxtaris_KeyDown;
        btnAxtar.Click += BtnAxtar_Click;

        // Operation button events
        btnStokArtir.Click += BtnStokArtir_Click;
        btnStokAzalt.Click += BtnStokAzalt_Click;
        btnStokDuzelis.Click += BtnStokDuzelis_Click;
        btnTemizle.Click += BtnTemizle_Click;

        // History events
        btnTarixceYenile.Click += BtnTarixceYenile_Click;

        // Input validation events
        txtSay.TextChanged += TxtSay_TextChanged;
    }

    #endregion

    #region Event Handlers - Form

    private void AnbarFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
        txtAxtaris.Focus();
    }

    private void AnbarFormu_KeyDown(object sender, KeyEventArgs e)
    {
        // Klaviatura qısayolları
        switch (e.KeyCode)
        {
            case Keys.F3:
                if (!_isLoading)
                {
                    AxtarIstek?.Invoke(this, EventArgs.Empty);
                    e.Handled = true;
                }
                break;

            case Keys.F5:
                if (!_isLoading && grpEmeliyyat.Enabled)
                {
                    TemizleIstek?.Invoke(this, EventArgs.Empty);
                    e.Handled = true;
                }
                break;

            case Keys.F12:
                if (!_isLoading && MehsulSecilmisdir)
                {
                    TarixceGosterIstek?.Invoke(this, EventArgs.Empty);
                    e.Handled = true;
                }
                break;

            case Keys.Escape:
                if (!_isLoading)
                {
                    FormuTemizle();
                    e.Handled = true;
                }
                break;
        }
    }

    #endregion

    #region Event Handlers - Search

    private void TxtAxtaris_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && !_isLoading)
        {
            AxtarIstek?.Invoke(this, EventArgs.Empty);
            e.SuppressKeyPress = true; // "ding" səsini blokla
        }
    }

    private void BtnAxtar_Click(object sender, EventArgs e)
    {
        if (!_isLoading)
        {
            AxtarIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion

    #region Event Handlers - Operations

    private void BtnStokArtir_Click(object sender, EventArgs e)
    {
        if (!_isLoading)
        {
            EmeliyyatNovu = AnbarSabitleri.EmeliyyatNovu.StokArtirma;
            StokArtirIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void BtnStokAzalt_Click(object sender, EventArgs e)
    {
        if (!_isLoading)
        {
            EmeliyyatNovu = AnbarSabitleri.EmeliyyatNovu.StokAzaltma;
            StokAzaltIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void BtnStokDuzelis_Click(object sender, EventArgs e)
    {
        if (!_isLoading)
        {
            EmeliyyatNovu = AnbarSabitleri.EmeliyyatNovu.StokDuzelis;
            StokDuzelisIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void BtnTemizle_Click(object sender, EventArgs e)
    {
        if (!_isLoading)
        {
            TemizleIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion

    #region Event Handlers - History

    private void BtnTarixceYenile_Click(object sender, EventArgs e)
    {
        if (!_isLoading && MehsulSecilmisdir)
        {
            TarixceGosterIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion

    #region Event Handlers - Validation

    private void TxtSay_TextChanged(object sender, EventArgs e)
    {
        // Real-time input cleaning
        if (!_suppressEvents)
        {
            string cleaned = Yardimcilar.AnbarValidasiyasi.SayInputuTemizle(txtSay.Text);
            if (cleaned != txtSay.Text)
            {
                _suppressEvents = true;
                int cursorPosition = txtSay.SelectionStart;
                txtSay.Text = cleaned;
                txtSay.SelectionStart = Math.Min(cursorPosition, cleaned.Length);
                _suppressEvents = false;
            }
        }
    }

    #endregion

    #region IAnbarView Methods - Display Data

    public void MehsulMelumatlariniGoster(MehsulDto mehsul)
    {
        if (mehsul == null)
        {
            MehsulPaneliniGoster(false);
            return;
        }

        _suppressEvents = true;
        try
        {
            // Məhsul ID-ni saxla
            lblMehsulId.Text = mehsul.Id.ToString();

            // Məhsul adı
            lblMehsulAdi.Text = mehsul.Ad ?? "N/A";

            // Stok kodu
            lblStokKodu.Text = $"Stok Kodu: {mehsul.StokKodu ?? "N/A"}";

            // Mövcud stok
            lblMovcudStok.Text = $"Mövcud Stok: {mehsul.MovcudSay:N2}";

            // Ölçü vahidi
            lblOlcuVahidi.Text = mehsul.OlcuVahidiAdi ?? AnbarSabitleri.VarsayilanDeyerler.VarsayilanOlcuVahidi;

            // Stok rəngi (qırmızı əgər bitibsə, sarı əgər minimum səviyyədədirsə)
            if (mehsul.MovcudSay <= 0)
            {
                lblMovcudStok.ForeColor = Color.FromArgb(244, 67, 54); // Qırmızı
            }
            else if (mehsul.MinimumStok > 0 && mehsul.MovcudSay <= mehsul.MinimumStok)
            {
                lblMovcudStok.ForeColor = Color.FromArgb(255, 152, 0); // Narıncı
            }
            else
            {
                lblMovcudStok.ForeColor = Color.FromArgb(76, 175, 80); // Yaşıl
            }

            // Paneli göstər
            MehsulPaneliniGoster(true);
        }
        finally
        {
            _suppressEvents = false;
        }
    }

    public void StokTarixcesiniGoster(List<StokHareketiDto> tarixce)
    {
        if (tarixce == null)
        {
            dgvTarixce.DataSource = null;
            return;
        }

        dgvTarixce.DataSource = tarixce;

        // Rəng kodlaması
        foreach (DataGridViewRow row in dgvTarixce.Rows)
        {
            if (row.DataBoundItem is StokHareketiDto hareket)
            {
                // Əməliyyat növünə görə rəng
                switch (hareket.EmeliyyatNovu?.ToUpper())
                {
                    case "ARTIRMA":
                        row.Cells["colEmeliyyatNovu"].Style.ForeColor = Color.FromArgb(76, 175, 80); // Yaşıl
                        break;
                    case "AZALTMA":
                        row.Cells["colEmeliyyatNovu"].Style.ForeColor = Color.FromArgb(244, 67, 54); // Qırmızı
                        break;
                    case "DUZELIS":
                        row.Cells["colEmeliyyatNovu"].Style.ForeColor = Color.FromArgb(33, 150, 243); // Mavi
                        break;
                }

                // Dəyişiklik rəngi (+ yaşıl, - qırmızı)
                if (hareket.DeyisiklikMiqdari > 0)
                {
                    row.Cells["colDeyisiklik"].Style.ForeColor = Color.FromArgb(76, 175, 80);
                }
                else if (hareket.DeyisiklikMiqdari < 0)
                {
                    row.Cells["colDeyisiklik"].Style.ForeColor = Color.FromArgb(244, 67, 54);
                }
            }
        }
    }

    #endregion

    #region IAnbarView Methods - UI Control

    public void FormuTemizle(bool axtarisQutusuQalsin = false)
    {
        _suppressEvents = true;
        try
        {
            ButunXetalariTemizle();

            if (!axtarisQutusuQalsin)
            {
                txtAxtaris.Clear();
            }

            txtSay.Clear();
            txtQeyd.Clear();

            lblMehsulId.Text = string.Empty;
            lblMehsulAdi.Text = "Məhsul Adı";
            lblStokKodu.Text = "Stok Kodu: -";
            lblMovcudStok.Text = "Mövcud Stok: 0";
            lblMovcudStok.ForeColor = Color.FromArgb(33, 150, 243);
            lblOlcuVahidi.Text = AnbarSabitleri.VarsayilanDeyerler.VarsayilanOlcuVahidi;

            MehsulPaneliniGoster(false);
            EmeliyyatDuymeleriniAktivet(false);

            dgvTarixce.DataSource = null;

            if (axtarisQutusuQalsin)
            {
                txtAxtaris.Focus();
                txtAxtaris.SelectAll();
            }
            else
            {
                AxtarisFocus();
            }
        }
        finally
        {
            _suppressEvents = false;
        }
    }

    public void MehsulPaneliniGoster(bool goster)
    {
        pnlMehsulMelumat.Visible = goster;
    }

    public void EmeliyyatDuymeleriniAktivet(bool aktiv)
    {
        grpEmeliyyat.Enabled = aktiv;
    }

    public void AxtarDuymesiniAktivet(bool aktiv)
    {
        btnAxtar.Enabled = aktiv;
    }

    public void AxtarisFocus()
    {
        if (txtAxtaris.CanFocus)
        {
            txtAxtaris.Focus();
            txtAxtaris.SelectAll();
        }
    }

    public void SayFocus()
    {
        if (txtSay.CanFocus)
        {
            txtSay.Focus();
            txtSay.SelectAll();
        }
    }

    #endregion

    #region IAnbarView Methods - Validation

    public void XetaGoster(Control control, string mesaj)
    {
        if (control == null) return;

        errorProvider1.SetError(control, mesaj);
        errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        errorProvider1.SetIconPadding(control, 2);
    }

    public void XetaniTemizle(Control control)
    {
        if (control == null) return;

        errorProvider1.SetError(control, string.Empty);
    }

    public void ButunXetalariTemizle()
    {
        // Clear errors from all controls recursively
        ClearErrorsRecursive(this);
    }

    private void ClearErrorsRecursive(Control parent)
    {
        if (parent == null) return;

        errorProvider1.SetError(parent, string.Empty);

        foreach (Control child in parent.Controls)
        {
            ClearErrorsRecursive(child);
        }
    }

    public void ValidasiyaXetalariGoster(string xetalar)
    {
        if (string.IsNullOrWhiteSpace(xetalar)) return;

        XetaMesajiGoster(xetalar);
    }

    #endregion

    #region IAnbarView Methods - Messages

    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons duymeler, MessageBoxIcon ikon)
    {
        return MessageBox.Show(this, mesaj, basliq, duymeler, ikon);
    }

    public void UgurMesajiGoster(string mesaj)
    {
        MessageBox.Show(this, mesaj, "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void XetaMesajiGoster(string mesaj)
    {
        MessageBox.Show(this, mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void XeberdarlikMesajiGoster(string mesaj)
    {
        MessageBox.Show(this, mesaj, "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public void MelumatMesajiGoster(string mesaj)
    {
        MessageBox.Show(this, mesaj, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public bool TesdiqSorusu(string mesaj)
    {
        var netice = MessageBox.Show(this, mesaj, "Təsdiq",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        return netice == DialogResult.Yes;
    }

    #endregion

    #region IAnbarView Methods - Loading State

    public void YuklemeGoster(string mesaj = "Yüklənir...")
    {
        _isLoading = true;
        _suppressEvents = true;

        // BazaForm yükləmə göstəricisi
        base.YuklemeGoster();

        // Form elementlərini deaktiv et
        grpAxtaris.Enabled = false;
        grpEmeliyyat.Enabled = false;
        btnTarixceYenile.Enabled = false;
    }

    public void YuklemeGizle()
    {
        _isLoading = false;
        _suppressEvents = false;

        // BazaForm yükləmə göstəricisi
        base.YuklemeGizle();

        // Form elementlərini aktivləşdir
        grpAxtaris.Enabled = true;

        // Əməliyyat düymələri yalnız məhsul seçilibsə aktiv olur
        grpEmeliyyat.Enabled = MehsulSecilmisdir;

        btnTarixceYenile.Enabled = MehsulSecilmisdir;
    }

    #endregion

    #region IAnbarView Methods - Data Refresh

    public void TarixceGridiniYenile()
    {
        if (MehsulSecilmisdir)
        {
            TarixceGosterIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion

    #region Protected Overrides

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Əgər yüklənmə gedərsə, bağlanmasını blokla
        if (_isLoading)
        {
            e.Cancel = true;
            XeberdarlikMesajiGoster("Əməliyyat davam edir. Lütfən gözləyin.");
        }

        base.OnFormClosing(e);
    }

    #endregion
}
