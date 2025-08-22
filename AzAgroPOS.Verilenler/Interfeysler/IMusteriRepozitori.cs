// Fayl: AzAgroPOS.Verilenler/Interfeysler/IMusteriRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;
/// <summary>
/// Bütün müştəri verilənlər bazası əməliyyatları üçün interfeys.
/// Diqqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// Qeyd: Bu interfeys, müştəri verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və müştəri ilə əlaqəli əməliyyatları asanlaşdırır.
/// Uzunluğu IRepozitori<Musteri> interfeysindən miras alır və müştəri ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// </summary>
public interface IMusteriRepozitori : IRepozitori<Musteri> 
{
    // Burada müştəri ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Ünvanına görə müştəriləri tapmaq, telefon nömrəsinə görə müştəriləri filtrləmək və s.
}