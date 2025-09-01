// Fayl: AzAgroPOS.Varliglar/Musteri.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Nisyə və ya digər əməliyyatlar üçün qeydiyyata alınan müştəriləri təmsil edir.
/// diqqət: Bu sinif, müştəri məlumatlarını saxlamaq və idarə etmək üçün istifadə olunur.
/// qeyd: Müştəri məlumatları, nisyə əməliyyatları və digər müştəri ilə əlaqəli funksiyalar üçün vacibdir.
/// </summary>
public class Musteri : BazaVarligi
{
    /// <summary>
    /// Müştərinin tam adı (Ad, Soyad, Ata adı).
    /// diqqət: Tam ad sahəsi boş ola bilməz və müştərinin tam adını ehtiva etməlidir.
    /// qeyd: Müştərinin tam adı, müştəri ilə əlaqə və identifikasiya üçün vacibdir.
    /// </summary>
    public string TamAd { get; set; } = string.Empty;

    /// <summary>
    /// Müştərinin telefon nömrəsi.
    /// diqqət: Telefon nömrəsi sahəsi boş ola bilməz və müştərinin əlaqə nömrəsini ehtiva etməlidir.
    /// qeyd: Müştərinin telefon nömrəsi, müştəri ilə əlaqə saxlamaq üçün vacibdir.
    /// </summary>
    public string TelefonNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Müştərinin ünvanı.
    /// diqqət: Ünvan sahəsi boş ola bilər, lakin müştərinin ünvanını ehtiva edə bilər.
    /// qeyd: Müştərinin ünvanı, müştəri ilə əlaqə və çatdırılma üçün faydalı ola bilər.
    /// </summary>
    public string? Unvan { get; set; }

    /// <summary>
    /// Müştərinin ümumi nisyə borcu.
    /// diqqət: Bu sahə mənfi ola bilməz və müştərinin ümumi borc məbləğini ehtiva edir.
    /// qeyd: Ümumi borc sahəsi, müştərinin nisyə əməliyyatları və maliyyə vəziyyətini izləmək üçün vacibdir.
    /// </summary>
    public decimal UmumiBorc { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public decimal KreditLimiti { get; set; } = 0;
}