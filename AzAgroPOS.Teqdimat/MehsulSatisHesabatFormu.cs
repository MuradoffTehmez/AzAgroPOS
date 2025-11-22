// Fayl: AzAgroPOS.Teqdimat/MehsulSatisHesabatFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Mehsul uzre satis hesabati formu - tarix araliginda mehsullarin satis statistikasini gosterir.
/// </summary>
public partial class MehsulSatisHesabatFormu : BazaForm, IMehsulSatisHesabatView
{
    private readonly MehsulSatisHesabatPresenter _presenter;
    private List<MehsulUzreSatisDetayDto>? _cariHesabat;

    public MehsulSatisHesabatFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        _presenter = new MehsulSatisHesabatPresenter(this, hesabatManager);
        StilVerDataGridView(dgvHesabat);
    }

    #region IMehsulSatisHesabatView Implementasiyasi

    public DateTime BaslangicTarix => dtpBaslangic.Value.Date;
    public DateTime BitisTarix => dtpBitis.Value.Date.AddDays(1).AddSeconds(-1); // Gunun sonuna qeder

    public event EventHandler? HesabatiGosterIstek;

    public void HesabatiGoster(List<MehsulUzreSatisDetayDto> hesabat)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => HesabatiGoster(hesabat));
            return;
        }

        try
        {
            _cariHesabat = hesabat;

            if (hesabat == null || hesabat.Count == 0)
            {
                BosNeticeMesajiGoster();
                return;
            }

            // DataGridView-e melumatlari yukle
            dgvHesabat.DataSource = null; // Evvelceki datasource-u temizle
            dgvHesabat.DataSource = hesabat;

            // Sutun basliqlari
            SutunlarıDuzelt();

            // Xulase statistikalarini hesabla ve goster
            XulaseniYenile(hesabat);

            // UI veziyyetini yenile
            pnlXulase.Visible = true;
            dgvHesabat.Visible = true;
            lblMesaj.Visible = false;
            btnExcelIxrac.Enabled = true;
        }
        finally
        {
            // Yukleme gostericisini gizle
            YuklemeGizle();
        }
    }

    private void SutunlarıDuzelt()
    {
        if (dgvHesabat.Columns.Contains("MehsulAdi"))
            dgvHesabat.Columns["MehsulAdi"].HeaderText = "Mehsul Adi";
        if (dgvHesabat.Columns.Contains("CemiSatilanMiqdar"))
            dgvHesabat.Columns["CemiSatilanMiqdar"].HeaderText = "Satilan Miqdar";
        if (dgvHesabat.Columns.Contains("CemiMebleg"))
            dgvHesabat.Columns["CemiMebleg"].HeaderText = "Cemi Mebleg";
        if (dgvHesabat.Columns.Contains("OrtalamaQiymet"))
            dgvHesabat.Columns["OrtalamaQiymet"].HeaderText = "Ortalama Qiymet";
    }

    public void MesajGoster(string mesaj)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => MesajGoster(mesaj));
            return;
        }

        try
        {
            lblMesaj.Text = mesaj;
            lblMesaj.ForeColor = Color.FromArgb(244, 67, 54); // Qirmizi - xeta mesaji ucun
            lblMesaj.Visible = true;
            dgvHesabat.Visible = false;
            pnlXulase.Visible = false;
            btnExcelIxrac.Enabled = false;
        }
        finally
        {
            YuklemeGizle();
        }
    }

    #endregion

    #region Form Hadise Isleyicileri

    private void MehsulSatisHesabatFormu_Load(object sender, EventArgs e)
    {
        // Varsayilan tarix araligini teyin et - cari ayin baslangicindan bu gune
        dtpBaslangic.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpBitis.Value = DateTime.Now;

        // Ilkin veziyyet
        pnlXulase.Visible = false;
        dgvHesabat.Visible = false;
        btnExcelIxrac.Enabled = false;

        // Mesaji goster
        lblMesaj.Text = "Hesabati gormek ucun tarix araligini secin ve 'Hesabati Goster' duymesine basin.";
        lblMesaj.ForeColor = Color.Gray;
        lblMesaj.Visible = true;
    }

    private void btnGoster_Click(object sender, EventArgs e)
    {
        // Tarix validasiyasi
        if (!TarixleriValidasiyaEt())
        {
            return;
        }

        // Yukleme gostericisini goster
        YuklemeGoster("Hesabat yuklenilir...");

        // Hesabati goster isteyini tetikle
        HesabatiGosterIstek?.Invoke(this, EventArgs.Empty);
    }

    private void btnExcelIxrac_Click(object sender, EventArgs e)
    {
        if (_cariHesabat == null || _cariHesabat.Count == 0)
        {
            MessageBox.Show("Ixrac edilecek melumat yoxdur.", "Xeberdarliq",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ExportHelper.ShowExportDialog(dgvHesabat, $"MehsulSatisHesabati_{dtpBaslangic.Value:yyyyMMdd}_{dtpBitis.Value:yyyyMMdd}");
    }

    #endregion

    #region Yardimci Metodlar

    /// <summary>
    /// Baslangic ve bitis tarixlerini validasiya edir.
    /// </summary>
    private bool TarixleriValidasiyaEt()
    {
        if (dtpBitis.Value.Date < dtpBaslangic.Value.Date)
        {
            MessageBox.Show(
                "Bitis tarixi baslangic tarixinden evvel ola bilmez!",
                "Tarix Xetasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            dtpBitis.Focus();
            return false;
        }

        // Maximum 1 illik aralig
        var gunFerqi = (dtpBitis.Value.Date - dtpBaslangic.Value.Date).TotalDays;
        if (gunFerqi > 365)
        {
            MessageBox.Show(
                "Tarix araligi 1 ilden cox ola bilmez!",
                "Tarix Xetasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        return true;
    }

    /// <summary>
    /// Xulase panelindeki statistikalari yeniler.
    /// </summary>
    private void XulaseniYenile(List<MehsulUzreSatisDetayDto> hesabat)
    {
        // Umumi satis meblegi
        var umumiSatis = hesabat.Sum(h => h.CemiMebleg);
        lblUmumiSatisDeger.Text = $"{umumiSatis:N2} AZN";

        // Mehsul sayi
        lblMehsulSayiDeger.Text = hesabat.Count.ToString();

        // En cox satilan mehsul
        var enCoxSatilan = hesabat.OrderByDescending(h => h.CemiSatilanMiqdar).FirstOrDefault();
        if (enCoxSatilan != null)
        {
            // Uzun adlari qisalt
            var mehsulAdi = enCoxSatilan.MehsulAdi;
            if (mehsulAdi.Length > 30)
            {
                mehsulAdi = mehsulAdi.Substring(0, 27) + "...";
            }
            lblEnCoxSatilanDeger.Text = $"{mehsulAdi} ({enCoxSatilan.CemiSatilanMiqdar:N0} ed.)";
        }
        else
        {
            lblEnCoxSatilanDeger.Text = "-";
        }
    }

    /// <summary>
    /// Bos netice mesajini gosterir.
    /// </summary>
    private void BosNeticeMesajiGoster()
    {
        lblMesaj.Text = $"Secilen tarix araliginda ({dtpBaslangic.Value:dd.MM.yyyy} - {dtpBitis.Value:dd.MM.yyyy}) satis tapilmadi.";
        lblMesaj.ForeColor = Color.FromArgb(255, 152, 0); // Narinci - xeberdarliq
        lblMesaj.Visible = true;
        dgvHesabat.Visible = false;
        pnlXulase.Visible = false;
        btnExcelIxrac.Enabled = false;
    }

    #endregion
}
