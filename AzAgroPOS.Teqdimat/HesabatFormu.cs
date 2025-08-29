// Fayl: AzAgroPOS.Teqdimat/HesabatFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class HesabatFormu : BazaForm, IHesabatView
{
    private readonly HesabatPresenter _presenter;
    public HesabatFormu()
    {
        InitializeComponent();
        _presenter = new HesabatPresenter(this);
        PanelləriSıfırla();
    }

    public DateTime SecilmisTarix => dtpTarix.Value;

    public event EventHandler HesabatiGosterIstek;

    public void HesabatiGoster(GunlukSatisHesabatDto hesabat)
    {
        // Invoke tələb oluna bilər
        if (InvokeRequired)
        {
            Invoke(() => HesabatiGoster(hesabat));
            return;
        }

        lblUmumiDovriyye.Text = $"{hesabat.UmumiDovriyye:N2} AZN";
        lblSatisSayi.Text = hesabat.CemiSatisSayi.ToString();
        lblNagd.Text = $"{hesabat.NagdSatisCemi:N2} AZN";
        lblKart.Text = $"{hesabat.KartSatisCemi:N2} AZN";
        lblNisye.Text = $"{hesabat.NisyeSatisCemi:N2} AZN";
        dgvSatislar.DataSource = hesabat.SatislarinSiyahisi;

        pnlNetice.Visible = true;
        lblMesaj.Visible = false;
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
        lblMesaj.Visible = true;
    }

    public void PanelləriSıfırla()
    {
        pnlNetice.Visible = false;
        lblMesaj.Visible = false;
        dgvSatislar.DataSource = null;
    }

    private void btnGoster_Click(object sender, EventArgs e)
    {
        HesabatiGosterIstek?.Invoke(this, EventArgs.Empty);
    }
}