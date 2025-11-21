// Fayl: AzAgroPOS.Teqdimat/AnbarQaliqHesabatFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;

public partial class AnbarQaliqHesabatFormu : BazaForm, IAnbarQaliqHesabatView
{
    private readonly AnbarQaliqHesabatPresenter _presenter;
    private List<AnbarQaliqDetayDto>? _cariHesabat;

    public AnbarQaliqHesabatFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        StilVerDataGridView(dgvHesabat);

        _presenter = new AnbarQaliqHesabatPresenter(this, hesabatManager);

        // Event handler-ları qoş
        btnGoster.Click += BtnGoster_Click;
        btnExcelIxrac.Click += BtnExcelIxrac_Click;
    }

    #region IAnbarQaliqHesabatView Properties

    public string LimitSay => txtLimit.Text;

    public string KateqoriyaFilter =>
        cmbKateqoriya.SelectedItem?.ToString() == "Hamısı" ? string.Empty : cmbKateqoriya.SelectedItem?.ToString() ?? string.Empty;

    public bool YalnizTukenenleri => chkYalnizTukenenleri.Checked;

    #endregion

    #region IAnbarQaliqHesabatView Events

    public event EventHandler? HesabatiGosterIstek;

    #endregion

    #region IAnbarQaliqHesabatView Methods

    public void HesabatiGoster(List<AnbarQaliqDetayDto> hesabat)
    {
        if (InvokeRequired)
        {
            Invoke(() => HesabatiGoster(hesabat));
            return;
        }

        _cariHesabat = hesabat;

        if (hesabat == null || hesabat.Count == 0)
        {
            lblMesaj.Text = "Seçilmiş filtrlərə uyğun məhsul tapılmadı.";
            lblMesaj.ForeColor = Color.FromArgb(255, 152, 0);
            lblMesaj.Visible = true;
            dgvHesabat.Visible = false;
            pnlXulase.Visible = false;
            btnExcelIxrac.Enabled = false;
            YuklemeGizle();
            return;
        }

        dgvHesabat.DataSource = hesabat;

        // Sütun başlıqlarını tərcümə et
        if (dgvHesabat.Columns.Contains("StokKodu"))
            dgvHesabat.Columns["StokKodu"].HeaderText = "Stok Kodu";
        if (dgvHesabat.Columns.Contains("MehsulAdi"))
            dgvHesabat.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
        if (dgvHesabat.Columns.Contains("MovcudMiqdar"))
            dgvHesabat.Columns["MovcudMiqdar"].HeaderText = "Mövcud Miqdar";
        if (dgvHesabat.Columns.Contains("MinimumSay"))
            dgvHesabat.Columns["MinimumSay"].HeaderText = "Min. Say";
        if (dgvHesabat.Columns.Contains("AlisQiymeti"))
            dgvHesabat.Columns["AlisQiymeti"].HeaderText = "Alış Qiyməti";
        if (dgvHesabat.Columns.Contains("SatisQiymeti"))
            dgvHesabat.Columns["SatisQiymeti"].HeaderText = "Satış Qiyməti";

        lblMesaj.Visible = false;
        dgvHesabat.Visible = true;
        pnlXulase.Visible = true;
        btnExcelIxrac.Enabled = true;

        YuklemeGizle();
    }

    public void MesajGoster(string mesaj)
    {
        if (InvokeRequired)
        {
            Invoke(() => MesajGoster(mesaj));
            return;
        }

        lblMesaj.Text = mesaj;
        lblMesaj.ForeColor = Color.FromArgb(244, 67, 54);
        lblMesaj.Visible = true;
        dgvHesabat.DataSource = null;
        dgvHesabat.Visible = false;
        pnlXulase.Visible = false;
        btnExcelIxrac.Enabled = false;

        YuklemeGizle();
    }

    public void XulaseGoster(int mehsulSayi, decimal umumiDeger, int kritikSay, int tukenmisSay)
    {
        if (InvokeRequired)
        {
            Invoke(() => XulaseGoster(mehsulSayi, umumiDeger, kritikSay, tukenmisSay));
            return;
        }

        lblMehsulSayiDeyer.Text = mehsulSayi.ToString();
        lblUmumiDegerDeyer.Text = $"{umumiDeger:N2} ₼";
        lblKritikSayDeyer.Text = kritikSay.ToString();
        lblTukenmisSayDeyer.Text = tukenmisSay.ToString();
    }

    public void KateqoriyalariYukle(List<string> kateqoriyalar)
    {
        if (InvokeRequired)
        {
            Invoke(() => KateqoriyalariYukle(kateqoriyalar));
            return;
        }

        cmbKateqoriya.Items.Clear();
        cmbKateqoriya.Items.Add("Hamısı");
        foreach (var kateqoriya in kateqoriyalar)
        {
            cmbKateqoriya.Items.Add(kateqoriya);
        }
        cmbKateqoriya.SelectedIndex = 0;
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

    private void BtnGoster_Click(object? sender, EventArgs e)
    {
        // Limit validasiyası
        if (!int.TryParse(txtLimit.Text, out var limit) || limit < 0)
        {
            MessageBox.Show("Zəhmət olmasa düzgün limit sayı daxil edin.", "Xəbərdarlıq",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtLimit.Focus();
            return;
        }

        YuklemeGoster();
        HesabatiGosterIstek?.Invoke(this, EventArgs.Empty);
    }

    private void BtnExcelIxrac_Click(object? sender, EventArgs e)
    {
        if (_cariHesabat == null || _cariHesabat.Count == 0)
        {
            MessageBox.Show("İxrac ediləcək məlumat yoxdur.", "Xəbərdarlıq",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ExportHelper.ShowExportDialog(dgvHesabat, $"AnbarQaliqHesabati_{DateTime.Now:yyyyMMdd}");
    }

    #endregion
}
