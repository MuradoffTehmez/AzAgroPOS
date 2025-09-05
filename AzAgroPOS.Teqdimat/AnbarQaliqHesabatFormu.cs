// Fayl: AzAgroPOS.Teqdimat/AnbarQaliqHesabatFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Mentiq.Idareciler;

public partial class AnbarQaliqHesabatFormu : BazaForm, IAnbarQaliqHesabatView
{
    private readonly AnbarQaliqHesabatPresenter _presenter;

    public AnbarQaliqHesabatFormu(HesabatManager hesabatManager)
    {
        InitializeComponent();
        StilVerDataGridView(dgvHesabat);

        _presenter = new AnbarQaliqHesabatPresenter(this, hesabatManager);
    }

    public string LimitSay => txtLimit.Text;

    public event EventHandler HesabatiGosterIstek;

    public void HesabatiGoster(List<AnbarQaliqDetayDto> hesabat)
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
        dgvHesabat.DataSource = null;
        dgvHesabat.Visible = false;
    }

    private void btnGoster_Click(object sender, EventArgs e)
    {
        HesabatiGosterIstek?.Invoke(this, EventArgs.Empty);
    }
}