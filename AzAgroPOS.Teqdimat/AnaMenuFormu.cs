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

        // Növbənin vəziyyətinə görə Satış düyməsini aktiv/deaktiv edirik
        btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;

        // Admin roluna görə icazələr (Admin hər şeyi görə bilər)
        if (istifadeci.RolAdi == "Admin")
        {
            return;
        }

        // Kassir roluna görə icazələr
        if (istifadeci.RolAdi == "Kassir")
        {
            btnMehsulIdareetme.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
            btnIstifadeciIdareetme.Enabled = false;
        }
        else // Digər bütün rollar üçün hər şeyi bağlayırıq
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
        // Növbə pəncərəsi bağlananda menyudakı düymələrin vəziyyətini yeniləyirik
        IcazeleriYoxla();
    }

    private void btnIstifadeciIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = new IstifadeciIdareetmeFormu()) { form.ShowDialog(); }
    }

    private void btnHesabatlar_Click(object sender, EventArgs e)
    {
        using (var form = new HesabatFormu()) { form.ShowDialog(); }
    }

    private void btnMehsulSatisHesabati_Click(object sender, EventArgs e)
    {
        using (var form = new MehsulSatisHesabatFormu()) { form.ShowDialog(); }
    }

    private void btnZHesabatArxivi_Click(object sender, EventArgs e)
    {
        using (var form = new ZHesabatArxivFormu()) { form.ShowDialog(); }
    }
}