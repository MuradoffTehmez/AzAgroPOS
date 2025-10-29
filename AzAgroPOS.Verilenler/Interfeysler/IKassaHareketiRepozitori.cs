// Fayl: AzAgroPOS.Verilenler/Interfeysler/IKassaHareketiRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Kassa hərəkətlərini idarə edən repozitorinin interfeysi
/// diqqət: Bu interfeys kassa hərəkətləri ilə bağlı əməliyyatlar üçün nəzərdə tutulub.
/// qeyd: Əsas CRUD əməliyyatlarını və kassa hərəkətlərinə aid xüsusi axtarışlar üçün metodlar təqdim edir.
/// </summary>
public interface IKassaHareketiRepozitori : IRepozitori<KassaHareketi>
{
    // Kassa hərəkətlərinə aid xüsusi metodlar burada təyin olunur
    // Hazırda standart CRUD əməliyyatları kifayətdir
}