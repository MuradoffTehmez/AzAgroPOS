// Fayl: AzAgroPOS.Teqdimat/AnbarQaliqHesabatFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;

namespace AzAgroPOS.Teqdimat;

public partial class AnbarQaliqHesabatFormu : BazaForm, IAnbarQaliqHesabatView
{
    private readonly AnbarQaliqHesabatPresenter _presenter;
    private List<AnbarQaliqDetayDto>? _cariHesabat;
    private readonly Label _lblUmumiMiqdar = new();
    private readonly Label _lblSatisDeyeri = new();
    private readonly Label _lblPotensialFerq = new();
    private readonly Label _lblMenfiQaliq = new();

    public AnbarQaliqHesabatFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        StilVerDataGridView(dgvHesabat);

        _presenter = new AnbarQaliqHesabatPresenter(this, hesabatManager);
        Shown += async (_, _) =>
        {
            await _presenter.KateqoriyalariYukleAsync();
            txtLimit.Text = int.MaxValue.ToString();
            BtnGoster_Click(this, EventArgs.Empty);
        };

        // Event handler-ları qoş
        btnGoster.Click += BtnGoster_Click;
        btnExcelIxrac.Click += BtnExcelIxrac_Click;
        Button butunAnbar = new()
        {
            Text = "BÜTÜN ANBAR",
            Location = new Point(920, 17),
            Size = new Size(155, 38),
            BackColor = Color.FromArgb(46, 125, 50),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        butunAnbar.Click += (_, _) =>
        {
            txtLimit.Text = int.MaxValue.ToString();
            chkYalnizTukenenleri.Checked = false;
            cmbKateqoriya.SelectedIndex = 0;
            BtnGoster_Click(butunAnbar, EventArgs.Empty);
        };
        pnlFiltr.Controls.Add(butunAnbar);
        pnlXulase.Height = 172;
        SummaryCard(_lblUmumiMiqdar, "MÖVCUD ÜMUMİ MİQDAR", 18);
        SummaryCard(_lblSatisDeyeri, "POTENSİAL SATIŞ DƏYƏRİ", 308);
        SummaryCard(_lblPotensialFerq, "POTENSİAL BRÜT FƏRQ", 598);
        SummaryCard(_lblMenfiQaliq, "MƏNFİ STOK AÇIĞI", 888);
    }

    private void SummaryCard(Label value, string title, int left)
    {
        Panel card = new() { Location = new Point(left, 89), Size = new Size(270, 70), BackColor = Color.White };
        Label heading = new() { Text = title, Location = new Point(12, 8), Size = new Size(245, 23), ForeColor = Color.FromArgb(70, 85, 79), Font = new Font("Segoe UI", 9, FontStyle.Bold) };
        value.Location = new Point(12, 31);
        value.Size = new Size(245, 32);
        value.Font = new Font("Segoe UI", 15, FontStyle.Bold);
        value.ForeColor = Color.FromArgb(31, 86, 43);
        card.Controls.AddRange([heading, value]);
        pnlXulase.Controls.Add(card);
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
            XulaseGoster(0, 0, 0, 0);
            _lblUmumiMiqdar.Text = "0";
            _lblSatisDeyeri.Text = "0,00 ₼";
            _lblPotensialFerq.Text = "0,00 ₼";
            _lblMenfiQaliq.Text = "0";
            pnlXulase.Visible = true;
            btnExcelIxrac.Enabled = false;
            YuklemeGizle();
            return;
        }

        if (dgvHesabat.Columns.Count == 0)
        {
            dgvHesabat.AutoGenerateColumns = false;
            
            dgvHesabat.Columns.Add(new DataGridViewTextBoxColumn { Name = "StokKodu", DataPropertyName = "StokKodu", HeaderText = "Stok Kodu" });
            dgvHesabat.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulAdi", DataPropertyName = "MehsulAdi", HeaderText = "Məhsul Adı" });
            dgvHesabat.Columns.Add(new DataGridViewTextBoxColumn { Name = "KateqoriyaAdi", DataPropertyName = "KateqoriyaAdi", HeaderText = "Kateqoriya" });
            
            var qtyCol = new DataGridViewTextBoxColumn { Name = "MovcudSay", DataPropertyName = "MovcudSay", HeaderText = "Mövcud Miqdar" };
            qtyCol.DefaultCellStyle.Format = "N2";
            dgvHesabat.Columns.Add(qtyCol);
            
            var minCol = new DataGridViewTextBoxColumn { Name = "MinimumSay", DataPropertyName = "MinimumSay", HeaderText = "Min. Say" };
            minCol.DefaultCellStyle.Format = "N2";
            dgvHesabat.Columns.Add(minCol);
            
            var buyCol = new DataGridViewTextBoxColumn { Name = "AlisQiymeti", DataPropertyName = "AlisQiymeti", HeaderText = "Alış Qiyməti" };
            buyCol.DefaultCellStyle.Format = "N2";
            dgvHesabat.Columns.Add(buyCol);
            
            var sellCol = new DataGridViewTextBoxColumn { Name = "SatisQiymeti", DataPropertyName = "SatisQiymeti", HeaderText = "Satış Qiyməti" };
            sellCol.DefaultCellStyle.Format = "N2";
            dgvHesabat.Columns.Add(sellCol);
        }

        dgvHesabat.DataSource = new System.ComponentModel.BindingList<AnbarQaliqDetayDto>(hesabat);
        XulaseGoster(hesabat.Count,
            hesabat.Sum(m => Math.Max(0, m.MovcudSay) * m.AlisQiymeti),
            hesabat.Count(m => m.MovcudSay > 0 && m.MovcudSay <= m.MinimumSay),
            hesabat.Count(m => m.MovcudSay <= 0));
        decimal alisDeyeri = hesabat.Sum(m => Math.Max(0, m.MovcudSay) * m.AlisQiymeti);
        decimal satisDeyeri = hesabat.Sum(m => Math.Max(0, m.MovcudSay) * m.SatisQiymeti);
        _lblUmumiMiqdar.Text = hesabat.Sum(m => Math.Max(0, m.MovcudSay)).ToString("N0");
        _lblSatisDeyeri.Text = $"{satisDeyeri:N2} ₼";
        _lblPotensialFerq.Text = $"{satisDeyeri - alisDeyeri:N2} ₼";
        _lblMenfiQaliq.Text = hesabat.Where(m => m.MovcudSay < 0).Sum(m => -m.MovcudSay).ToString("N0");
        lblMehsulSayiBasliq.Text = "GÖSTƏRİLƏN MƏHSUL NÖVÜ";
        lblUmumiDegerBasliq.Text = "GÖSTƏRİLƏN ALIŞ DƏYƏRİ";

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
        foreach (string kateqoriya in kateqoriyalar)
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
        if (!int.TryParse(txtLimit.Text, out int limit) || limit < 0)
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
