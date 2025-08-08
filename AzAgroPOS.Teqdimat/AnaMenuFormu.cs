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

    private void AnaMenuFormu_Load(object sender, EventArgs e)
    {
        IcazeleriYoxla();
    }

    private void IcazeleriYoxla()
    {
        var istifadeci = AktivSessiya.AktivIstifadeci;
        if (istifadeci == null)
        {
            MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı. Tətbiq bağlanır.", "Kritik Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Application.Exit();
            return;
        }

        this.Text = $"AzAgroPOS - Ana Menyu (İstifadəçi: {istifadeci.TamAd})";
        btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;

        if (istifadeci.RolAdi == "Admin")
        {
            // Admin üçün bütün düymələr aktivdir
            return;
        }

        if (istifadeci.RolAdi == "Kassir")
        {
            btnMehsulIdareetme.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
            btnIstifadeciIdareetme.Enabled = false;
        }
        else
        {
            btnMehsulIdareetme.Enabled = false;
            btnYeniSatis.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
            btnNovbeIdareetme.Enabled = false;
            btnIstifadeciIdareetme.Enabled = false;
        }
    }

    private void btnMehsulIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new MehsulIdareetmeFormu()) { form.ShowDialog(); }
    }

    private void btnYeniSatis_Click(object sender, EventArgs e)
    {
        using (var form = new SatisFormu()) { form.ShowDialog(); }
    }

    private void btnNisyeIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new NisyeIdareetmeFormu()) { form.ShowDialog(); }
    }

    private void btnTemirIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new TemirIdareetmeFormu()) { form.ShowDialog(); }
    }

    private void btnNovbeIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new NovbeIdareetmesiFormu()) { form.ShowDialog(); }
        IcazeleriYoxla(); 
    }

    private void btnIstifadeciIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new IstifadeciIdareetmeFormu()) { form.ShowDialog(); }
    }
}