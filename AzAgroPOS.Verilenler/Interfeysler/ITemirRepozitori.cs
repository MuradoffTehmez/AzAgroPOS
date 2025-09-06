// Fayl: AzAgroPOS.Verilenler/Interfeysler/ITemirRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;

/// <summary>
/// bütün təmir verilənlər bazası əməliyyatları üçün interfeys.
/// diqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// qeyd: Bu interfeys, təmir verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və təmir ilə əlaqəli əməliyyatları asanlaşdırır.
/// </summary>
public interface ITemirRepozitori : IRepozitori<Temir>
{
    // Burada təmir ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Müəyyən bir tarixdəki təmir işlərini tapmaq, istifadəçiyə görə təmir işlərini filtrləmək və s.
    // təmir işlərinin ümumi xərclərini hesablamaq üçün xüsusi metodlar əlavə edilə bilər.
    // təmir işlərinin müddətini hesablamaq üçün xüsusi metodlar əlavə edilə bilər.

}