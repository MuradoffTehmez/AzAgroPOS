// Fayl: AzAgroPOS.Teqdimat/TemirIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

/// <summary>
/// Bu class, təmir idarəetmə formunu təmsil edir.
/// Diqqət - bu form, BazaForm sinifindən törədilmişdir.
/// Qeyd - bu form, ITemirView interfeysini həyata keçirir və təmir əməliyyatlarını idarə etmək üçün TemirPresenter ilə əlaqələndirilir.
/// </summary>
public partial class TemirIdareetmeFormu : BazaForm, ITemirView
{
    /// <summary>
    /// Təmir əməliyyatlarını idarə etmək üçün istifadə olunan presenter.
    /// Diqqət - bu presenter, ITemirView interfeysini alır və TemirManager ilə əlaqələndirir.
    /// Qeyd - bu presenter, yeni sifariş yaratmaq və sifarişləri göstərmək üçün metodlar və hadisələr təyin edir.
    /// </summary>
    private readonly TemirPresenter _presenter;
    /// <summary>
    /// temir idarəetmə formu konstruktoru, formu ilkin vəziyyətə gətirir və presenter-i yaradır.
    /// Diqqət - InitializeComponent metodu, formun komponentlərini ilkin vəziyyətə gətirir.
    /// Qeyd - TemirPresenter, ITemirView interfeysini alır və təmir əməliyyatlarını idarə etmək üçün TemirManager ilə əlaqələndirir.
    /// </summary>
    public TemirIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new TemirPresenter(this);
    }

    /// <summary>
    /// Müştərinin adı text qutusundakı mətni qaytarır.
    /// diqqət - bu mətn, istifadəçi tərəfindən daxil edilir.
    /// qeyd - əgər mətn qutusu boşdursa, boş sətir qaytarılır.
    /// </summary>
    public string MusteriAdi => txtMusteriAdi.Text;
    /// <summary>
    /// Müştərinin telefonu text qutusundakı mətni qaytarır.
    /// diqət - bu mətn, istifadəçi tərəfindən daxil edilir.
    /// qeyd - əgər mətn qutusu boşdursa, boş sətir qaytarılır.
    /// </summary>
    public string MusteriTelefonu => txtMusteriTelefonu.Text;
    /// <summary>
    /// Cihazın adı text qutusundakı mətni qaytarır.
    /// diqət - bu mətn, istifadəçi tərəfindən daxil edilir.
    /// qeyd - əgər mətn qutusu boşdursa, boş sətir qaytarılır.
    /// </summary>
    public string CihazAdi => txtCihazAdi.Text;
    /// <summary>
    /// Problemin təsviri text qutusundakı mətni qaytarır.
    /// diqət - bu mətn, istifadəçi tərəfindən daxil edilir.
    /// qeyd - əgər mətn qutusu boşdursa, boş sətir qaytarılır.
    /// </summary>
    public string ProblemTesviri => txtProblemTesviri.Text;
    /// <summary>
    /// Yekun məbləğ text qutusundakı mətni decimal olaraq qaytarır.
    /// diqət - bu məbləğ, istifadəçi tərəfindən daxil edilir.
    /// qeyd - əgər daxil edilən məbləğ düzgün formatda deyilsə, 0 qaytarılır.
    /// </summary>
    public decimal YekunMebleg => decimal.TryParse(txtYekunMebleg.Text, out var mebleg) ? mebleg : 0;
    /// <summary>
    /// Form yükləndikdə çağırılan hadisə.
    /// diqət - bu hadisə, istifadəçi formu yüklədikdə tetiklenir.
    /// qeyd - bu hadisə, TemirPresenter tərəfindən dinlənilir və bütün təmir sifarişlərini yükləmək və göstərmək üçün istifadə olunur.
    /// </summary>
    public event EventHandler FormYuklendi;
    /// <summary>
    /// Yeni təmir sifarişi yaratmaq üçün istifadəçi tərəfindən çağırılan hadisə.
    /// diqət - bu hadisə, istifadəçi btnYeniSifaris adlı düyməni kliklədikdə tetiklenir.
    /// qeyd - bu hadisə, TemirPresenter tərəfindən dinlənilir və yeni təmir sifarişi yaratmaq üçün istifadə olunur.
    /// </summary>
    public event EventHandler YeniSifarisYarat_Istek;
    /// <summary>
    /// Sifarişləri göstərmək üçün istifadə olunur.
    /// diqət - bu metod, TemirDto obyektlərinin siyahısını qəbul edir və dgvTemirSifarisleri DataGridView-də göstərir.
    /// qeyd - əgər siyahı boşdursa, DataGridView də boş olacaq.
    /// </summary>
    /// <param name="sifarisler"></param>
    public void SifarisleriGoster(List<TemirDto> sifarisler)
    {
        dgvTemirSifarisleri.DataSource = sifarisler;
        // Sütunları konfiqurasiya et
    }
    /// <summary>
    /// Formu təmizləyir.
    /// qeyd - bu metod, bütün mətn qutularını təmizləyir və yeni sifariş yaratdıqdan sonra istifadə olunur.
    /// </summary>
    public void FormuTemizle()
    {
        txtMusteriAdi.Clear();
        txtMusteriTelefonu.Clear();
        txtCihazAdi.Clear();
        txtProblemTesviri.Clear();
        txtYekunMebleg.Clear();
    }
    /// <summary>
    /// Mesaj göstərir.
    /// qeyd - bu metod, istifadəçiyə məlumat vermək üçün istifadə olunur.
    /// Diqqət - bu metod, MessageBox.Show metodu ilə mesajı göstərir.
    /// </summary>
    /// <param name="mesaj"></param>
    /// <param name="basliq"></param>
    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
    }
    /// <summary>
    /// temir idarəetmə formu yükləndikdə çağırılan hadisə.
    /// Diqət - bu metod, form yükləndikdə tetiklenir və FormYuklendi hadisəsini tetikler.
    /// Qeyd - bu metod, TemirPresenter tərəfindən dinlənilir və bütün təmir sifarişlərini yükləmək və göstərmək üçün istifadə olunur.      
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TemirIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }
    /// <summary>
    /// yeni sifariş yarat düyməsi klikləndikdə çağırılan hadisə.
    /// Diqət - bu metod, istifadəçi btnYeniSifaris adlı düyməni kliklədikdə tetiklenir və YeniSifarisYarat_Istek hadisəsini tetikler.
    /// Qeyd - bu metod, TemirPresenter tərəfindən dinlənilir və yeni təmir sifarişi yaratmaq üçün istifadə olunur.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnYeniSifaris_Click(object sender, EventArgs e)
    {
        YeniSifarisYarat_Istek?.Invoke(this, EventArgs.Empty);
    }
}