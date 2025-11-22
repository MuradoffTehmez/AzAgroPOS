// Fayl: AzAgroPOS.Teqdimat/HesabatFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;

public partial class HesabatFormu : BazaForm, IHesabatView
{
    private readonly HesabatPresenter _presenter;
    private GunlukSatisHesabatDto? _cariHesabat;
    private List<GunlukSatisDetayDto>? _filtreliSatislar;

    public HesabatFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        _presenter = new HesabatPresenter(this, hesabatManager);
        StilVerDataGridView(dgvSatislar);
        PanelləriSıfırla();

        // Axtarış event handler
        txtAxtaris.TextChanged += TxtAxtaris_TextChanged;
        cmbOdenisTipiFiltr.SelectedIndexChanged += CmbOdenisTipiFiltr_SelectedIndexChanged;
    }

    private void TxtAxtaris_TextChanged(object? sender, EventArgs e)
    {
        FiltriTetbiqEt();
    }

    private void CmbOdenisTipiFiltr_SelectedIndexChanged(object? sender, EventArgs e)
    {
        FiltriTetbiqEt();
    }

    private void FiltriTetbiqEt()
    {
        if (_cariHesabat?.SatislarinSiyahisi == null) return;

        var axtarisMeni = txtAxtaris.Text?.ToLower() ?? string.Empty;
        var odenisTipi = cmbOdenisTipiFiltr.SelectedItem?.ToString();

        _filtreliSatislar = _cariHesabat.SatislarinSiyahisi
            .Where(s =>
                (string.IsNullOrEmpty(axtarisMeni) ||
                 s.SatisId.ToString().Contains(axtarisMeni) ||
                 (s.MusteriAdi?.ToLower().Contains(axtarisMeni) ?? false)) &&
                (string.IsNullOrEmpty(odenisTipi) || odenisTipi == "Hamisi" ||
                 s.OdenisMetodu == odenisTipi))
            .ToList();

        dgvSatislar.DataSource = null;
        dgvSatislar.DataSource = _filtreliSatislar;

        // Sutun basliqlari yenile
        SutunBasliqlariniDuzelt();

        // Filtrelenmis statistikalar
        lblFiltreliSay.Text = $"Gosterilen: {_filtreliSatislar.Count} / {_cariHesabat.SatislarinSiyahisi.Count}";
    }

    #region IHesabatView Properties

    public DateTime SecilmisTarix => dtpTarix.Value.Date;

    #endregion

    #region IHesabatView Events

    public event EventHandler? HesabatiGosterIstek;

    #endregion

    #region IHesabatView Methods

    public void HesabatiGoster(GunlukSatisHesabatDto hesabat)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => HesabatiGoster(hesabat));
            return;
        }

        try
        {
            _cariHesabat = hesabat;
            _filtreliSatislar = hesabat.SatislarinSiyahisi;

            // Xulase kartlarini yenile
            XulaseGoster(
                hesabat.UmumiDovriyye,
                hesabat.CemiSatisSayi,
                hesabat.NagdSatisCemi,
                hesabat.KartSatisCemi,
                hesabat.NisyeSatisCemi
            );

            // Filtrleri sifirla
            txtAxtaris.Text = string.Empty;
            cmbOdenisTipiFiltr.SelectedIndex = 0;

            // DataGridView-a melumatlari yukle
            dgvSatislar.DataSource = null;
            dgvSatislar.DataSource = hesabat.SatislarinSiyahisi;

            // Sutun basliqlari
            SutunBasliqlariniDuzelt();

            // Filtrelenmis statistikalar
            lblFiltreliSay.Text = $"Gosterilen: {hesabat.SatislarinSiyahisi?.Count ?? 0} / {hesabat.SatislarinSiyahisi?.Count ?? 0}";

            pnlXulase.Visible = true;
            pnlFiltrPanel.Visible = true;
            dgvSatislar.Visible = true;
            lblMesaj.Visible = false;
            btnExcelIxrac.Enabled = true;
        }
        finally
        {
            YuklemeGizle();
        }
    }

    private void SutunBasliqlariniDuzelt()
    {
        if (dgvSatislar.Columns.Contains("SatisId"))
            dgvSatislar.Columns["SatisId"].HeaderText = "Satis No";
        if (dgvSatislar.Columns.Contains("SatisVaxti"))
            dgvSatislar.Columns["SatisVaxti"].HeaderText = "Satis Vaxti";
        if (dgvSatislar.Columns.Contains("CemiMebleg"))
            dgvSatislar.Columns["CemiMebleg"].HeaderText = "Cemi Mebleg";
        if (dgvSatislar.Columns.Contains("OdenisTipi"))
            dgvSatislar.Columns["OdenisTipi"].HeaderText = "Odenis Tipi";
        if (dgvSatislar.Columns.Contains("KassirAdi"))
            dgvSatislar.Columns["KassirAdi"].HeaderText = "Kassir";
    }

    public void XetaMesajiGoster(string mesaj)
    {
        if (InvokeRequired)
        {
            Invoke(() => XetaMesajiGoster(mesaj));
            return;
        }

        PanelləriSıfırla();
        lblMesaj.Text = mesaj;
        lblMesaj.ForeColor = Color.FromArgb(244, 67, 54);
        lblMesaj.Visible = true;

        YuklemeGizle();
    }

    public void PanelləriSıfırla()
    {
        pnlXulase.Visible = false;
        dgvSatislar.Visible = false;
        lblMesaj.Visible = false;
        dgvSatislar.DataSource = null;
        btnExcelIxrac.Enabled = false;
        _cariHesabat = null;
    }

    public void XulaseGoster(decimal umumiDovriyye, int satisSayi, decimal nagdSatis, decimal kartSatis, decimal nisyeSatis)
    {
        if (InvokeRequired)
        {
            Invoke(() => XulaseGoster(umumiDovriyye, satisSayi, nagdSatis, kartSatis, nisyeSatis));
            return;
        }

        lblUmumiDovriyyeDeyer.Text = $"{umumiDovriyye:N2} ₼";
        lblSatisSayiDeyer.Text = satisSayi.ToString();
        lblNagdSatisDeyer.Text = $"{nagdSatis:N2} ₼";
        lblKartSatisDeyer.Text = $"{kartSatis:N2} ₼";
        lblNisyeSatisDeyer.Text = $"{nisyeSatis:N2} ₼";
    }

    public new void YuklemeGoster()
    {
        if (InvokeRequired)
        {
            Invoke(() => YuklemeGoster());
            return;
        }
        base.YuklemeGoster();
        btnGoster.Enabled = false;
        btnExcelIxrac.Enabled = false;
    }

    public new void YuklemeGizle()
    {
        if (InvokeRequired)
        {
            Invoke(() => YuklemeGizle());
            return;
        }
        base.YuklemeGizle();
        btnGoster.Enabled = true;
    }

    #endregion

    #region Event Handlers

    private void btnGoster_Click(object? sender, EventArgs e)
    {
        YuklemeGoster();
        HesabatiGosterIstek?.Invoke(this, EventArgs.Empty);
    }

    private void btnExcelIxrac_Click(object? sender, EventArgs e)
    {
        if (_cariHesabat == null || _cariHesabat.SatislarinSiyahisi == null || _cariHesabat.SatislarinSiyahisi.Count == 0)
        {
            MessageBox.Show("Ixrac edilecek melumat yoxdur.", "Xeberdariliq",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ExportHelper.ShowExportDialog(dgvSatislar, $"GunlukSatisHesabati_{SecilmisTarix:yyyyMMdd}");
    }

    #endregion
}
