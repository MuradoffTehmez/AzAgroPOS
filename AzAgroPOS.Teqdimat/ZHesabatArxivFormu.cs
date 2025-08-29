// Fayl: AzAgroPOS.Teqdimat/ZHesabatArxivFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class ZHesabatArxivFormu : BazaForm, IZHesabatArxivView
{
    private readonly ZHesabatArxivPresenter _presenter;
    public ZHesabatArxivFormu()
    {
        InitializeComponent();
        _presenter = new ZHesabatArxivPresenter(this);
    }

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

    public event EventHandler FormYuklendi;
    public event EventHandler HesabatGosterIstek;

    public void NovbeleriGoster(List<BaglanmisNovbeDto> novbeler)
    {
        if (InvokeRequired)
        {
            Invoke(() => NovbeleriGoster(novbeler));
            return;
        }
        dgvNovbeler.DataSource = novbeler;
    }

    public void HesabatiGoster(string hesabatMetni)
    {
        MessageBox.Show(hesabatMetni, "Z-Hesabatı (Arxiv)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void ZHesabatArxivFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    private void btnGoster_Click(object sender, EventArgs e)
    {
        HesabatGosterIstek?.Invoke(this, EventArgs.Empty);
    }
}