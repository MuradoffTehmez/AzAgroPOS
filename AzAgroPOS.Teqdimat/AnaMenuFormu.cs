// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
namespace AzAgroPOS.Teqdimat;
using System;
using System.Windows.Forms;
using AzAgroPOS.Teqdimat.Yardimcilar;
public partial class AnaMenuFormu : BazaForm
{
    public AnaMenuFormu()
    {
        InitializeComponent();
        this.Load += AnaMenuFormu_Load;
    }
    private void AnaMenuFormu_Load(object sender, EventArgs e) => IcazeleriYoxla();
    private void IcazeleriYoxla()
    {
        var istifadeci = AktivSessiya.AktivIstifadeci;
        if (istifadeci == null) { Application.Exit(); return; }
        this.Text = $"AzAgroPOS - Ana Menyu (İstifadəçi: {istifadeci.TamAd})";
        btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;
        if (istifadeci.RolAdi == "Admin") return;
        if (istifadeci.RolAdi == "Kassir")
        {
            btnMehsulIdareetme.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
        }
        else
        {
            btnMehsulIdareetme.Enabled = false;
            btnYeniSatis.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
            btnNovbeIdareetme.Enabled = false;
        }
    }
    private void btnMehsulIdareetme_Click(object sender, EventArgs e) { using (var f = new MehsulIdareetmeFormu()) { f.ShowDialog(); } }
    private void btnYeniSatis_Click(object sender, EventArgs e) { using (var f = new SatisFormu()) { f.ShowDialog(); } }
    private void btnNisyeIdareetme_Click(object sender, EventArgs e) { using (var f = new NisyeIdareetmeFormu()) { f.ShowDialog(); } }
    private void btnTemirIdareetme_Click(object sender, EventArgs e) { using (var f = new TemirIdareetmeFormu()) { f.ShowDialog(); } }
    private void btnNovbeIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new NovbeIdareetmesiFormu()) { form.ShowDialog(); }
        IcazeleriYoxla();
    }
}