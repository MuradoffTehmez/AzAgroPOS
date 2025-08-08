// Fayl: AzAgroPOS.Teqdimat/TemirIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class TemirIdareetmeFormu : BazaForm, ITemirView
{
    private readonly TemirPresenter _presenter;

    public TemirIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new TemirPresenter(this);
    }

    public string MusteriAdi => txtMusteriAdi.Text;
    public string MusteriTelefonu => txtMusteriTelefonu.Text;
    public string CihazAdi => txtCihazAdi.Text;
    public string ProblemTesviri => txtProblemTesviri.Text;
    public decimal YekunMebleg => decimal.TryParse(txtYekunMebleg.Text, out var mebleg) ? mebleg : 0;

    public event EventHandler FormYuklendi;
    public event EventHandler YeniSifarisYarat_Istek;

    public void SifarisleriGoster(List<TemirDto> sifarisler)
    {
        dgvTemirSifarisleri.DataSource = sifarisler;
        // Sütunları konfiqurasiya et
    }

    public void FormuTemizle()
    {
        txtMusteriAdi.Clear();
        txtMusteriTelefonu.Clear();
        txtCihazAdi.Clear();
        txtProblemTesviri.Clear();
        txtYekunMebleg.Clear();
    }

    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
    }

    private void TemirIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    private void btnYeniSifaris_Click(object sender, EventArgs e)
    {
        YeniSifarisYarat_Istek?.Invoke(this, EventArgs.Empty);
    }
}