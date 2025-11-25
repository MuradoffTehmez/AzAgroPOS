// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ILoginView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
/// <summary>
///  interfeys, istifadəçi giriş əməliyyatlarını idarə etmək üçün istifadə olunur.
///  Daha dəqiq, istifadəçi adı və parol daxil edildikdə, giriş yoxlanılması və nəticənin göstərilməsi üçün metodlar və hadisələr təyin edir.   
/// </summary>
public interface ILoginView
{
    /// <summary>
    /// İstifadeciAdi xüsusiyyəti, istifadəçinin giriş üçün daxil etdiyi istifadəçi adını saxlayır.
    /// </summary>
    string IstifadeciAdi { get; }
    /// <summary>
    /// Parol xüsusiyyəti, istifadəçinin parolunu daxil etməsi üçün istifadə olunur.
    /// </summary>
    string Parol { get; }
    /// <summary>
    /// UgurluDaxilOlundu xüsusiyyəti, istifadəçi uğurla daxil olduqda true, əks halda false dəyərini alır.
    /// </summary>
    bool UgurluDaxilOlundu { get; set; }
    /// <summary>
    ///  DaxilOl_Istek hadisəsi, istifadəçi giriş əməliyyatını başlatmaq üçün tetiklenir.
    /// </summary>
    event EventHandler DaxilOl_Istek;
    /// <summary>
    /// MesajGoster metodu, istifadəçiyə mesaj göstərmək üçün istifadə olunur.
    /// Daha dəqiq, istifadəçi giriş əməliyyatında baş verən xətaları və ya uğurlu giriş mesajlarını göstərmək üçün istifadə olunur.
    /// </summary>
    /// <param name="mesaj"></param>
    void MesajGoster(string mesaj);
    /// <summary>
    /// FormuBagla metodu, giriş əməliyyatı uğurla tamamlandıqda formu bağlamaq üçün istifadə olunur.
    /// </summary>
    void FormuBagla();
}