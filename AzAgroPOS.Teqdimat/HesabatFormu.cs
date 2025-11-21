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

    public HesabatFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        _presenter = new HesabatPresenter(this, hesabatManager);
        StilVerDataGridView(dgvSatislar);
        PanelləriSıfırla();
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
            Invoke(() => HesabatiGoster(hesabat));
            return;
        }

        _cariHesabat = hesabat;

        // Xulase kartlarini yenile
        XulaseGoster(
            hesabat.UmumiDovriyye,
            hesabat.CemiSatisSayi,
            hesabat.NagdSatisCemi,
            hesabat.KartSatisCemi,
            hesabat.NisyeSatisCemi
        );

        // DataGridView-a melumatlari yukle
        dgvSatislar.DataSource = hesabat.SatislarinSiyahisi;

        // Sutun basliqlari
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

        pnlXulase.Visible = true;
        dgvSatislar.Visible = true;
        lblMesaj.Visible = false;
        btnExcelIxrac.Enabled = true;

        YuklemeGizle();
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
