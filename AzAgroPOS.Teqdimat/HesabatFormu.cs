// Fayl: AzAgroPOS.Teqdimat/HesabatFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;

namespace AzAgroPOS.Teqdimat;

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
        if (_cariHesabat?.SatislarinSiyahisi == null)
        {
            return;
        }

        string axtarisMeni = txtAxtaris.Text?.ToLower() ?? string.Empty;
        string? odenisTipi = cmbOdenisTipiFiltr.SelectedItem?.ToString();

        _filtreliSatislar = _cariHesabat.SatislarinSiyahisi
            .Where(s =>
                (string.IsNullOrEmpty(axtarisMeni) ||
                 s.SatisId.ToString().Contains(axtarisMeni) ||
                 (s.MusteriAdi?.ToLower().Contains(axtarisMeni) ?? false)) &&
                (string.IsNullOrEmpty(odenisTipi) || odenisTipi == "Hamisi" ||
                 s.OdenisMetodu == odenisTipi))
            .ToList();

        dgvSatislar.DataSource = new System.ComponentModel.BindingList<GunlukSatisDetayDto>(_filtreliSatislar);

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

            // Sutun basliqlari
            SutunBasliqlariniDuzelt();

            // DataGridView-a melumatlari yukle
            dgvSatislar.DataSource = new System.ComponentModel.BindingList<GunlukSatisDetayDto>(hesabat.SatislarinSiyahisi);

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
        if (dgvSatislar.Columns.Count > 0) return;

        dgvSatislar.AutoGenerateColumns = false;
        
        dgvSatislar.Columns.Add(new DataGridViewTextBoxColumn { Name = "SatisId", DataPropertyName = "SatisId", HeaderText = "Satis No" });
        
        var dateCol = new DataGridViewTextBoxColumn { Name = "SatisVaxti", DataPropertyName = "SatisVaxti", HeaderText = "Satis Vaxti" };
        dateCol.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvSatislar.Columns.Add(dateCol);
        
        var sumCol = new DataGridViewTextBoxColumn { Name = "CemiMebleg", DataPropertyName = "CemiMebleg", HeaderText = "Cemi Mebleg" };
        sumCol.DefaultCellStyle.Format = "N2";
        dgvSatislar.Columns.Add(sumCol);
        
        dgvSatislar.Columns.Add(new DataGridViewTextBoxColumn { Name = "OdenisTipi", DataPropertyName = "OdenisMetodu", HeaderText = "Odenis Tipi" });
        dgvSatislar.Columns.Add(new DataGridViewTextBoxColumn { Name = "MusteriAdi", DataPropertyName = "MusteriAdi", HeaderText = "Musteri Adi" });
        dgvSatislar.Columns.Add(new DataGridViewTextBoxColumn { Name = "IstifadeciAdi", DataPropertyName = "IstifadeciAdi", HeaderText = "Istifadeci Adi" });
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
        
        if (dgvSatislar.DataSource is System.ComponentModel.BindingList<GunlukSatisDetayDto> currentList)
        {
            currentList.Clear();
        }
        
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
