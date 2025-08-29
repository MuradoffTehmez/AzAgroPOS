// Fayl: AzAgroPOS.Teqdimat/SatisFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;

public partial class SatisFormu : BazaForm, ISatisView
{
    private readonly SatisPresenter _presenter;
    public SatisFormu()
    {
        InitializeComponent();
        _presenter = new SatisPresenter(this);
        // Başlanğıcda ödəniş panelini və müştəri seçimini gizlədirik
        OdenisDuymeleriniAktivEt(false);
    }

    // Interfeys Implementasiyası
    public string BarkodAxtaris => txtBarkodAxtaris.Text;
    public int? SecilmisMusteriId => (int?)cmbMusteriler.SelectedValue > 0 ? (int?)cmbMusteriler.SelectedValue : null;

    public event EventHandler BarkodDaxilEdildi_Istek;
    public event EventHandler<OdenisMetodu> SatisiTesdiqle_Istek;

    public void SebeteMehsulGoster(IEnumerable<SatisSebetiElementiDto> sebet)
    {
        dgvSebet.DataSource = sebet.ToList();
        if (dgvSebet.Columns.Count > 0)
        {
            dgvSebet.Columns["MehsulId"].Visible = false;
            dgvSebet.Columns["MehsulAdi"].HeaderText = "Məhsulun Adı";
            dgvSebet.Columns["Miqdar"].HeaderText = "Miqdar";
            dgvSebet.Columns["VahidinQiymeti"].HeaderText = "Qiymət";
            dgvSebet.Columns["UmumiMebleg"].HeaderText = "Məbləğ";
        }
        // Səbət boş deyilsə, ödəniş düymələrini aktiv et
        OdenisDuymeleriniAktivEt(sebet.Any());
    }

    public void UmumiMebligiGoster(decimal mebleg)
    {
        lblUmumiMebleg.Text = $"ÜMUMİ MƏBLƏĞ: {mebleg:N2} AZN";
    }

    public void MusteriSiyahisiniGoster(List<MusteriDto> musteriler)
    {
        // Invoke tələb oluna bilər, çünki Presenter başqa bir thread-də işləyə bilər
        if (InvokeRequired)
        {
            Invoke(() => MusteriSiyahisiniGoster(musteriler));
            return;
        }

        // Siyahının başına "Müştərisiz" seçimini əlavə edirik
        var listDataSource = new List<object> { new { Id = 0, TamAd = "Şəxsi Satış (müştərisiz)" } };
        listDataSource.AddRange(musteriler);

        cmbMusteriler.DataSource = listDataSource;
        cmbMusteriler.DisplayMember = "TamAd";
        cmbMusteriler.ValueMember = "Id";
    }

    public void OdenisDuymeleriniAktivEt(bool aktiv)
    {
        if (InvokeRequired)
        {
            Invoke(() => OdenisDuymeleriniAktivEt(aktiv));
            return;
        }
        materialCardOdenis.Visible = aktiv;
    }

    public void FormuSifirla()
    {
        txtBarkodAxtaris.Clear();
        txtBarkodAxtaris.Focus();
        if (cmbMusteriler.Items.Count > 0)
            cmbMusteriler.SelectedIndex = 0;
    }

    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
    }

    // Hadisələrin Presenter-ə ötürülməsi
    private void txtBarkodAxtaris_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BarkodDaxilEdildi_Istek?.Invoke(this, EventArgs.Empty);
            txtBarkodAxtaris.SelectAll();
            e.SuppressKeyPress = true; // "ding" səsini bloklayır
        }
    }

    private void btnNagd_Click(object sender, EventArgs e)
    {
        SatisiTesdiqle_Istek?.Invoke(this, OdenisMetodu.Nağd);
    }

    private void btnKart_Click(object sender, EventArgs e)
    {
        SatisiTesdiqle_Istek?.Invoke(this, OdenisMetodu.Kart);
    }

    private void btnNisye_Click(object sender, EventArgs e)
    {
        SatisiTesdiqle_Istek?.Invoke(this, OdenisMetodu.Nisyə);
    }
}