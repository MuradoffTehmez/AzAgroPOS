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

        if (dgvHesabat.Columns.Count == 0)
        {
            dgvHesabat.AutoGenerateColumns = false;
            
            dgvHesabat.Columns.Add(new DataGridViewTextBoxColumn { Name = "StokKodu", DataPropertyName = "StokKodu", HeaderText = "Stok Kodu" });
            dgvHesabat.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulAdi", DataPropertyName = "MehsulAdi", HeaderText = "Məhsul Adı" });
            
            var qtyCol = new DataGridViewTextBoxColumn { Name = "MovcudMiqdar", DataPropertyName = "MovcudMiqdar", HeaderText = "Mövcud Miqdar" };
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
