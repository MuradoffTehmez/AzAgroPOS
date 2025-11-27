// Fayl: AzAgroPOS.Teqdimat/Interfeysler/INisyeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// İnterfeys, Nisye (borc) əməliyyatlarını idarə etmək üçün istifadə olunur.
/// İnterfeys, müştəri məlumatlarını göstərmək, müştəri hərəkətlərini göstərmək və ödəniş əməliyyatlarını idarə etmək üçün metodlar və hadisələr təyin edir.
/// </summary>
public interface INisyeView
{

    // View-a data göndərmək
    /// <summary>
    /// bu list , müştəri məlumatlarını göstərmək üçün istifadə olunur.
    /// Daha dəqiq, müştəri siyahısını DataGridView və ya ComboBox kimi bir nəzarətə göstərmək üçün istifadə olunur.
    /// </summary>
    /// <param name="musteriler"></param>
    void MusterileriGoster(List<MusteriDto> musteriler);
    /// <summary>
    /// list, müştəri hərəkətlərini göstərmək üçün istifadə olunur.
    /// daha dəqiq, müştərinin borc və ödəniş hərəkətlərini DataGridView və ya digər bir nəzarətə göstərmək üçün istifadə olunur.
    /// </summary>
    /// <param name="hereketler"></param>
    void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler);

    // View-dan data oxumaq
    int? SecilmisMusteriId { get; }
    decimal OdenisMeblegi { get; }

    /// <summary>
    /// Ödəniş düyməsinin aktiv/deaktiv olma vəziyyəti
    /// </summary>
    bool OdenisButtonAktivdir { get; set; }

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler MusteriSecildi;
    event EventHandler OdenisEdildi;

    /// <summary>
    /// mesajgoster metodu, istifadəçiyə mesaj göstərmək üçün istifadə olunur.
    /// </summary>
    /// <param name="mesaj"></param>
    /// <param name="basliq"></param>
    void MesajGoster(string mesaj, string basliq);

    /// <summary>
    /// MessageBox göstərir və istifadəçi cavabını qaytarır
    /// </summary>
    System.Windows.Forms.DialogResult MesajGoster(string mesaj, string basliq,
        System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon);

    /// <summary>
    ///  formuTemizle metodu, formu sıfırlamaq üçün istifadə olunur.
    ///  daha dəqiq, formdakı bütün məlumatları təmizləmək və istifadəçiyə yeni bir əməliyyat üçün boş bir forma təqdim etmək üçün istifadə olunur.
    /// </summary>
    void FormuTemizle();
}