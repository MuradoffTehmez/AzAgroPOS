// Fayl: AzAgroPOS.Teqdimat/NisyeIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class NisyeIdareetmeFormu : BazaForm, INisyeView
{
    private readonly NisyePresenter _presenter;

    public NisyeIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new NisyePresenter(this);
        StilVerDataGridView(dgvMusteriler);
        StilVerDataGridView(dgvNisyeHereketleri);
    }

    public int? SecilmisMusteriId
    {
        get
        {
            if (dgvMusteriler.CurrentRow != null && dgvMusteriler.CurrentRow.DataBoundItem is MusteriDto musteri)
            {
                return musteri.Id;
            }
            return null;
        }
    }

    public decimal OdenisMeblegi => decimal.TryParse(txtOdenisMeblegi.Text, out var mebleg) ? mebleg : 0;

    public event EventHandler FormYuklendi;
    public event EventHandler MusteriSecildi;
    public event EventHandler OdenisEdildi;

    public void MusterileriGoster(List<MusteriDto> musteriler)
    {
        dgvMusteriler.DataSource = musteriler;
        // Sütunları konfiqurasiya et
    }

    public void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler)
    {
        dgvNisyeHereketleri.DataSource = hereketler;
        // Sütunları konfiqurasiya et
    }

    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
    }

    public void FormuTemizle()
    {
        txtOdenisMeblegi.Clear();
    }

    private void NisyeIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
    {
        MusteriSecildi?.Invoke(this, EventArgs.Empty);
    }

    private void btnOdenisEt_Click(object sender, EventArgs e)
    {
        OdenisEdildi?.Invoke(this, EventArgs.Empty);
    }
}