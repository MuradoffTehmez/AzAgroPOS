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
        // Form yüklənəndə icazələri yoxlamaq üçün Load hadisəsinə abunə oluruq
        this.Load += AnaMenuFormu_Load;
    }

    private void AnaMenuFormu_Load(object sender, EventArgs e)
    {
        IcazeleriYoxla();
    }

    /// <summary>
    /// Aktiv istifadəçinin roluna görə düymələrin aktivliyini tənzimləyir.
    /// </summary>
    private void IcazeleriYoxla()
    {
        var istifadeci = AktivSessiya.AktivIstifadeci;
        if (istifadeci == null)
        {
            // Bu hal baş verməməlidir, çünki giriş pəncərəsi bunu yoxlayır.
            // Hər ehtimala qarşı bütün proqramı bağlayaq.
            MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı. Tətbiq bağlanır.", "Kritik Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Application.Exit();
            return;
        }

        // Aktiv istifadəçinin adını pəncərənin başlığında göstərək
        this.Text = $"AzAgroPOS - Ana Menyu (İstifadəçi: {istifadeci.TamAd})";

        // Admin rolundakı istifadəçi hər şeyi görə bilər, ona görə heç bir düyməni bağlamırıq
        if (istifadeci.RolAdi == "Admin")
        {
            return;
        }

        // Kassir rolunun icazələri
        if (istifadeci.RolAdi == "Kassir")
        {
            btnMehsulIdareetme.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
        }
        else // Naməlum və ya icazəsi olmayan digər rollar üçün hər şeyi bağlayaq
        {
            btnMehsulIdareetme.Enabled = false;
            btnYeniSatis.Enabled = false;
            btnNisyeIdareetme.Enabled = false;
            btnTemirIdareetme.Enabled = false;
        }
    }

    private void btnMehsulIdareetme_Click(object sender, EventArgs e)
    {
        // Məhsul idarəetmə pəncərəsini açırıq
        using (var mehsulFormu = new MehsulIdareetmeFormu())
        {
            mehsulFormu.ShowDialog();
        }
    }

    private void btnYeniSatis_Click(object sender, EventArgs e)
    {
        // Satış pəncərəsini açırıq
        using (var satisFormu = new SatisFormu())
        {
            satisFormu.ShowDialog();
        }
    }

    private void btnNisyeIdareetme_Click(object sender, EventArgs e)
    {
        // Nisyə idarəetmə pəncərəsini açırıq
        using (var nisyeFormu = new NisyeIdareetmeFormu())
        {
            nisyeFormu.ShowDialog();
        }
    }

    private void btnTemirIdareetme_Click(object sender, EventArgs e)
    {
        // Təmir idarəetmə pəncərəsini açırıq
        using (var temirFormu = new TemirIdareetmeFormu())
        {
            temirFormu.ShowDialog();
        }
    }
}