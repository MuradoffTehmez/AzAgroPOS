// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
namespace AzAgroPOS.Teqdimat;

public partial class AnaMenuFormu : BazaForm
{
    public AnaMenuFormu()
    {
        InitializeComponent();
    }

    private void btnMehsulIdareetme_Click(object sender, EventArgs e)
    {
        // Məhsul idarəetmə pəncərəsini açırıq
        var mehsulFormu = new MehsulIdareetmeFormu();
        mehsulFormu.ShowDialog();
    }

    private void btnYeniSatis_Click(object sender, EventArgs e)
    {
        // Satış pəncərəsini açırıq (hələ yaratmamışıq, amma əlavə edəcəyik)
        var satisFormu = new SatisFormu();
        satisFormu.ShowDialog();
    }
}