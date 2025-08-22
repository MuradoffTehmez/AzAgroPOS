// Fayl: AzAgroPOS.Teqdimat/SatisFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
/// <summary>
/// bu class, satış əməliyyatlarını idarə etmək üçün istifadə olunan formu təmsil edir.
/// diqqət - bu form, BazaForm sinifindən törədilmişdir.
/// qeyd - bu form, ISatisView interfeysini həyata keçirir və satış əməliyyatlarını idarə etmək üçün SatisPresenter ilə əlaqələndirilir.
/// </summary>
public partial class SatisFormu : BazaForm, ISatisView
{
    /// <summary>
    /// satış əməliyyatlarını idarə etmək üçün istifadə olunan presenter.
    /// diqqət - bu presenter, ISatisView interfeysini alır və SatisManager ilə əlaqələndirir.
    /// qeyd - bu presenter, barkodla məhsul tapmaq, satış təsdiqləmək və sebeti göstərmək üçün metodlar və hadisələr təyin edir.
    /// </summary>
    private readonly SatisPresenter _presenter;
    /// <summary>
    /// SatisFormu konstruktoru, formu ilkin vəziyyətə gətirir və presenter-i yaradır.
    /// diqqət - InitializeComponent metodu, formun komponentlərini ilkin vəziyyətə gətirir.
    /// qeyd - SatisPresenter, ISatisView interfeysini alır və satış əməliyyatlarını idarə etmək üçün SatisManager ilə əlaqələndirir.
    /// </summary>
    public SatisFormu()
    {
        InitializeComponent();
        _presenter = new SatisPresenter(this);
    }

    // Interfeys Implementasiyası
    /// <summary>
    /// barkod axtarış mətn qutusundakı mətni qaytarır.
    /// diqqət - bu mətn, istifadəçi tərəfindən daxil edilir və Enter düyməsinə basıldıqda oxunur.
    /// qeyd - əgər mətn qutusu boşdursa, boş sətir qaytarılır.
    /// </summary>
    public string BarkodAxtaris => txtBarkodAxtaris.Text;
    /// <summary>
    /// barkod daxil edildikdə tetiklenen hadisə.
    /// diqqət - bu hadisə, istifadəçi txtBarkodAxtaris mətn qutusunda Enter düyməsinə basdıqda tetiklenir.
    /// qeyd - bu hadisə, SatisPresenter tərəfindən dinlənilir və barkodla məhsul tapmaq üçün istifadə olunur.
    /// </summary>
    public event EventHandler BarkodDaxilEdildi_Istek;
    /// <summary>
    /// satışı təsdiqlədikdə tetiklenen hadisə.
    /// diqqət - bu hadisə, istifadəçi btnSatisiTesdiqle düyməsini kliklədikdə tetiklenir.
    /// qeyd - bu hadisə, SatisPresenter tərəfindən dinlənilir və satış əməliyyatını tamamlamak üçün istifadə olunur.
    /// </summary>
    public event EventHandler SatisiTesdiqle_Istek;
    /// <summary>
    /// Satış sebetini göstərir.
    /// Diqqət - bu metod, SatisSebetiElementiDto obyektlərinin siyahısını qəbul edir və dgvSebet DataGridView-də göstərir.
    /// Qeyd - əgər siyahı boşdursa, DataGridView də boş olacaq.
    /// LİSTİN İÇERİSİNDE OLAN SAHƏLƏR: MehsulId, MehsulAdi, Miqdar, VahidinQiymeti, UmumiMebleg  hesablanmış sahədir.
    /// </summary>
    /// <param name="sebet"></param>
    public void SebeteMehsulGoster(IEnumerable<SatisSebetiElementiDto> sebet)
    {
        dgvSebet.DataSource = sebet.ToList();
        if (dgvSebet.Columns.Count > 0)
        {
            dgvSebet.Columns["MehsulId"].Visible = false;
            dgvSebet.Columns["MehsulAdi"].HeaderText = "Məhsulun Adı";
            dgvSebet.Columns["Miqdar"].HeaderText = "Miqdar";
            dgvSebet.Columns["VahidinQiymeti"].HeaderText = "Qiymət";
            dgvSebet.Columns["UmumiMebleg"].HeaderText = "Məbləğ";
        }
    }
    /// <summary>
    /// Umumi məbləği göstərir.
    /// Diqqət - bu metod, decimal tipində ümumi məbləği qəbul edir və lblUmumiMebleg adlı Label-da göstərir.
    /// Qeyd - məbləğ ədədi formatda (N2) göstərilir və AZN valyutası ilə birlikdə göstərilir.
    /// </summary>
    /// <param name="mebleg"></param>
    public void UmumiMebligiGoster(decimal mebleg)
    {
        lblUmumiMebleg.Text = $"ÜMUMİ MƏBLƏĞ: {mebleg:N2} AZN";
    }
    /// <summary>
    /// Formu sıfırlayır.
    /// Qeyd - bu metod, txtBarkodAxtaris mətn qutusunu təmizləyir və fokusunu ora qoyur ki, yeni barkod daxil etmək rahat olsun.
    /// Diqqət - bu metod başqa bir iplikdən çağırılırsa, Invoke metodu ilə əsas iplikdə çağırılır.
    /// </summary>
    public void FormuSifirla()
    {
        txtBarkodAxtaris.Clear();
        txtBarkodAxtaris.Focus();
    }
    /// <summary>
    /// MESAJ GÖSTƏRİR. Bu metod, MessageBox.Show metodunu istifadə edərək mesaj qutusunu göstərir.
    /// Diqqət - bu metod, mesaj, başlıq, düymələr və ikon parametrlərini qəbul edir və uyğun mesaj qutusunu göstərir.
    /// Qeyd - bu metod başqa bir iplikdən çağırılırsa, Invoke metodu ilə əsas iplikdə çağırılır.
    /// </summary>
    /// <param name="mesaj"></param>
    /// <param name="basliq"></param>
    /// <param name="düymələr"></param>
    /// <param name="ikon"></param>
    /// <returns></returns>
    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
    }

    // Hadisələrin Presenter-ə ötürülməsi
    /// <summary>
    /// TextBox-da Enter düyməsinə basıldıqda tetiklenen hadisə.
    /// Diqqət - bu metod, txtBarkodAxtaris mətn qutusunda Enter düyməsinə basıldıqda çağırılır.
    /// Qeyd - bu metod, BarkodDaxilEdildi_Istek hadisəsini tetikler və mətn qutusunu təmizləyir ki, yeni barkod daxil etmək rahat olsun.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtBarkodAxtaris_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BarkodDaxilEdildi_Istek?.Invoke(this, EventArgs.Empty);
            // Enter-ə basdıqdan sonra mətn qutusunu təmizləyək ki, yeni barkod daxil etmək rahat olsun
            txtBarkodAxtaris.SelectAll();
        }
    }
    /// <summary>
    /// BtnSatisiTesdiqle düyməsinə basıldıqda tetiklenen hadisə.
    /// Diqqət - bu metod, btnSatisiTesdiqle düyməsi kliklənəndə çağırılır.
    /// Qeyd - bu metod, SatisiTesdiqle_Istek hadisəsini tetikler və satış əməliyyatını tamamlayır.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSatisiTesdiqle_Click(object sender, EventArgs e)
    {
        SatisiTesdiqle_Istek?.Invoke(this, EventArgs.Empty);
    }
}