// Fayl: AzAgroPOS.Teqdimat/ZHesabatArxivFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System.Text;

public partial class ZHesabatArxivFormu : BazaForm, IZHesabatArxivView
{
    private readonly ZHesabatArxivPresenter _presenter;
    private ZHesabatDto? _secilmisHesabat;

    public ZHesabatArxivFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        _presenter = new ZHesabatArxivPresenter(this, hesabatManager);
        StilVerDataGridView(dgvNovbeler);

        // Event handler-ları qoş
        btnFiltrle.Click += BtnFiltrle_Click;
        btnGoster.Click += BtnGoster_Click;
        btnCap.Click += BtnCap_Click;
        dgvNovbeler.SelectionChanged += DgvNovbeler_SelectionChanged;

        // Default tarix aralığı - son 30 gün
        dtpBitis.Value = DateTime.Today;
        dtpBaslangic.Value = DateTime.Today.AddDays(-30);
    }

    #region IZHesabatArxivView Properties

    public int? SecilmisNovbeId
    {
        get
        {
            if (dgvNovbeler.CurrentRow != null && dgvNovbeler.CurrentRow.DataBoundItem is BaglanmisNovbeDto novbe)
            {
                return novbe.NovbeId;
            }
            return null;
        }
    }

    public DateTime BaslangicTarixi => dtpBaslangic.Value.Date;
    public DateTime BitisTarixi => dtpBitis.Value.Date.AddDays(1).AddSeconds(-1);

    #endregion

    #region IZHesabatArxivView Events

    public event EventHandler? FormYuklendi;
    public event EventHandler? HesabatGosterIstek;
    public event EventHandler? HesabatCapIstek;
    public event EventHandler? TarixFiltrDeyisdi;

    #endregion

    #region IZHesabatArxivView Methods

    public void NovbeleriGoster(List<BaglanmisNovbeDto> novbeler)
    {
        if (InvokeRequired)
        {
            Invoke(() => NovbeleriGoster(novbeler));
            return;
        }
        dgvNovbeler.DataSource = novbeler;

        // Sütun başlıqlarını Azərbaycan dilinə tərcümə et
        if (dgvNovbeler.Columns.Count > 0)
        {
            if (dgvNovbeler.Columns.Contains("NovbeId"))
                dgvNovbeler.Columns["NovbeId"].HeaderText = "Növbə №";
            if (dgvNovbeler.Columns.Contains("AcilmaTarixi"))
                dgvNovbeler.Columns["AcilmaTarixi"].HeaderText = "Açılma Tarixi";
            if (dgvNovbeler.Columns.Contains("BaglanmaTarixi"))
                dgvNovbeler.Columns["BaglanmaTarixi"].HeaderText = "Bağlanma Tarixi";
            if (dgvNovbeler.Columns.Contains("KassirAdi"))
                dgvNovbeler.Columns["KassirAdi"].HeaderText = "Kassir";
            if (dgvNovbeler.Columns.Contains("CemiSatis"))
                dgvNovbeler.Columns["CemiSatis"].HeaderText = "Cəmi Satış";
        }
    }

    public void HesabatiGoster(string hesabatMetni)
    {
        MessageBox.Show(hesabatMetni, "Z-Hesabatı (Arxiv)", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void HesabatDetallariGoster(ZHesabatDto hesabat)
    {
        if (InvokeRequired)
        {
            Invoke(() => HesabatDetallariGoster(hesabat));
            return;
        }

        _secilmisHesabat = hesabat;

        lblAcilisTarixiDeyer.Text = hesabat.AcilmaTarixi.ToString("dd.MM.yyyy HH:mm");
        lblBaglanmaTarixiDeyer.Text = hesabat.BaglanmaTarixi.ToString("dd.MM.yyyy HH:mm");
        lblKassirDeyer.Text = hesabat.KassirAdi;
        lblBaslangicMeblegDeyer.Text = $"{hesabat.BaslangicMebleg:N2} ₼";
        lblSatisSayiDeyer.Text = hesabat.SatisSayi.ToString();
        lblGozlenilenMeblegDeyer.Text = $"{hesabat.GozlenilenMebleg:N2} ₼";
        lblFaktikiMeblegDeyer.Text = $"{hesabat.FaktikiMebleg:N2} ₼";

        // Fərq rəngini müəyyənləşdir
        lblFerqDeyer.Text = $"{hesabat.Ferq:N2} ₼";
        if (hesabat.Ferq < 0)
            lblFerqDeyer.ForeColor = Color.FromArgb(244, 67, 54); // Qırmızı - çatışmazlıq
        else if (hesabat.Ferq > 0)
            lblFerqDeyer.ForeColor = Color.FromArgb(76, 175, 80); // Yaşıl - artıq
        else
            lblFerqDeyer.ForeColor = Color.FromArgb(33, 33, 33); // Normal
    }

    public void MesajGoster(string mesaj)
    {
        if (InvokeRequired)
        {
            Invoke(() => MesajGoster(mesaj));
            return;
        }
        MessageBox.Show(mesaj, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void XulaseGoster(int novbeSayi, decimal cemiSatis, decimal nagdSatis, decimal kartSatis)
    {
        if (InvokeRequired)
        {
            Invoke(() => XulaseGoster(novbeSayi, cemiSatis, nagdSatis, kartSatis));
            return;
        }

        lblNovbeSayiDeyer.Text = novbeSayi.ToString();
        lblCemiSatisDeyer.Text = $"{cemiSatis:N2} ₼";
        lblNagdSatisDeyer.Text = $"{nagdSatis:N2} ₼";
        lblKartSatisDeyer.Text = $"{kartSatis:N2} ₼";
    }

    public new void YuklemeGoster()
    {
        if (InvokeRequired)
        {
            Invoke(() => YuklemeGoster());
            return;
        }
        base.YuklemeGoster();
        btnFiltrle.Enabled = false;
        btnGoster.Enabled = false;
        btnCap.Enabled = false;
    }

    public new void YuklemeGizle()
    {
        if (InvokeRequired)
        {
            Invoke(() => YuklemeGizle());
            return;
        }
        base.YuklemeGizle();
        btnFiltrle.Enabled = true;
        btnGoster.Enabled = true;
        btnCap.Enabled = true;
    }

    #endregion

    #region Event Handlers

    private void ZHesabatArxivFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    private void BtnFiltrle_Click(object? sender, EventArgs e)
    {
        TarixFiltrDeyisdi?.Invoke(this, EventArgs.Empty);
    }

    private void BtnGoster_Click(object? sender, EventArgs e)
    {
        HesabatGosterIstek?.Invoke(this, EventArgs.Empty);
    }

    private void BtnCap_Click(object? sender, EventArgs e)
    {
        if (_secilmisHesabat == null)
        {
            MessageBox.Show("Zəhmət olmasa əvvəlcə bir hesabat seçin.", "Xəbərdarlıq",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        HesabatCapIstek?.Invoke(this, EventArgs.Empty);
    }

    private void DgvNovbeler_SelectionChanged(object? sender, EventArgs e)
    {
        // Seçilmiş sətir dəyişəndə avtomatik hesabat detallarını yüklə
        if (dgvNovbeler.CurrentRow != null)
        {
            HesabatGosterIstek?.Invoke(this, EventArgs.Empty);
        }
    }

    #endregion

    #region Thermal Print

    public void TermalCapEt(ZHesabatDto hesabat, string printerAdi)
    {
        if (string.IsNullOrEmpty(printerAdi))
        {
            MessageBox.Show("Printer seçilməyib. Konfiqurasiyada qəbz printerini təyin edin.",
                "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            var builder = new StringBuilder();

            // Header
            builder.AppendLine("================================");
            builder.AppendLine("         Z-HESABATI             ");
            builder.AppendLine("================================");
            builder.AppendLine();

            // Tarix məlumatları
            builder.AppendLine($"Açılış:    {hesabat.AcilmaTarixi:dd.MM.yyyy HH:mm}");
            builder.AppendLine($"Bağlanma:  {hesabat.BaglanmaTarixi:dd.MM.yyyy HH:mm}");
            builder.AppendLine($"Kassir:    {hesabat.KassirAdi}");
            builder.AppendLine();

            // Satış məlumatları
            builder.AppendLine("--------------------------------");
            builder.AppendLine("SATIŞ MƏLUMATlARI");
            builder.AppendLine("--------------------------------");
            builder.AppendLine($"Satış sayı:        {hesabat.SatisSayi}");
            builder.AppendLine($"Nağd satış:        {hesabat.NagdSatislar:N2} AZN");
            builder.AppendLine($"Kartla satış:      {hesabat.KartSatislar:N2} AZN");
            builder.AppendLine($"Cəmi satış:        {hesabat.CemiSatislar:N2} AZN");
            builder.AppendLine();

            // Kassa məlumatları
            builder.AppendLine("--------------------------------");
            builder.AppendLine("KASSA MƏLUMATlARI");
            builder.AppendLine("--------------------------------");
            builder.AppendLine($"Başlanğıc:         {hesabat.BaslangicMebleg:N2} AZN");
            builder.AppendLine($"Gözlənilən:        {hesabat.GozlenilenMebleg:N2} AZN");
            builder.AppendLine($"Faktiki:           {hesabat.FaktikiMebleg:N2} AZN");
            builder.AppendLine($"Fərq:              {hesabat.Ferq:N2} AZN");
            builder.AppendLine();

            builder.AppendLine("================================");
            builder.AppendLine($"Çap tarixi: {DateTime.Now:dd.MM.yyyy HH:mm}");
            builder.AppendLine("================================");

            // Thermal printerdə çap et
            PrinterHelper.TermalCapEt(printerAdi, builder.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Çap zamanı xəta: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #endregion
}
