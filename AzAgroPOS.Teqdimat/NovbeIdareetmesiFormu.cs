// Fayl: AzAgroPOS.Teqdimat/NovbeIdareetmesiFormu.cs
namespace AzAgroPOS.Teqdimat;
// using-lər...
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System;
using System.Windows.Forms;
public partial class NovbeIdareetmesiFormu : BazaForm, INovbeView
{
    private readonly NovbePresenter _presenter;
    public NovbeIdareetmesiFormu()
    {
        InitializeComponent();
        _presenter = new NovbePresenter(this);
    }

    public decimal BaslangicMebleg => decimal.TryParse(txtBaslangicMebleg.Text, out var m) ? m : 0;
    public decimal FaktikiMebleg => decimal.TryParse(txtFaktikiMebleg.Text, out var m) ? m : 0;

    public event EventHandler NovbeAc_Istek;
    public event EventHandler NovbeBagla_Istek;

    public void NovbeAciqdirGoster(string isci, DateTime acilisTarixi)
    {
        if (this.InvokeRequired) { this.Invoke(() => NovbeAciqdirGoster(isci, acilisTarixi)); return; }
        cardNovbeAc.Visible = false;
        cardNovbeBagla.Visible = true;
        lblNovbeMelumat.Text = $"{isci} tərəfindən {acilisTarixi:dd.MM.yyyy HH:mm}-də açılmış növbə aktivdir.";
    }

    public void NovbeBaxlidirGoster()
    {
        if (this.InvokeRequired) { this.Invoke(() => NovbeBaxlidirGoster()); return; }
        cardNovbeAc.Visible = true;
        cardNovbeBagla.Visible = false;
        txtFaktikiMebleg.Text = "0";
        txtBaslangicMebleg.Text = "0";
    }

    public void HesabatGoster(string hesabatMetni)
    {
        if (this.InvokeRequired) { this.Invoke(() => HesabatGoster(hesabatMetni)); return; }
        MessageBox.Show(hesabatMetni, "Z-Hesabatı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnNovbeAc_Click(object sender, EventArgs e) => NovbeAc_Istek?.Invoke(this, EventArgs.Empty);
    private void btnNovbeBagla_Click(object sender, EventArgs e) => NovbeBagla_Istek?.Invoke(this, EventArgs.Empty);
}