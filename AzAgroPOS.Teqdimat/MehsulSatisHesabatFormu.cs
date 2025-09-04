// Fayl: AzAgroPOS.Teqdimat/MehsulSatisHesabatFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class MehsulSatisHesabatFormu : BazaForm, IMehsulSatisHesabatView
{
    private readonly MehsulSatisHesabatPresenter _presenter;

    public MehsulSatisHesabatFormu()
    {
        InitializeComponent();
        _presenter = new MehsulSatisHesabatPresenter(this);
        StilVerDataGridView(dgvHesabat);
    }

    public DateTime BaslangicTarix => dtpBaslangic.Value;
    public DateTime BitisTarix => dtpBitis.Value;

    public event EventHandler HesabatiGosterIstek;

    public void HesabatiGoster(List<MehsulUzreSatisDetayDto> hesabat)
    {
        if (InvokeRequired)
        {
            Invoke(() => HesabatiGoster(hesabat));
            return;
        }
        dgvHesabat.DataSource = hesabat;
        lblMesaj.Visible = false;
        dgvHesabat.Visible = true;
    }

    public void MesajGoster(string mesaj)
    {
        if (InvokeRequired)
        {
            Invoke(() => MesajGoster(mesaj));
            return;
        }
        lblMesaj.Text = mesaj;
        lblMesaj.Visible = true;
        dgvHesabat.Visible = false;
    }

    private void btnGoster_Click(object sender, EventArgs e)
    {
        HesabatiGosterIstek?.Invoke(this, EventArgs.Empty);
    }
}