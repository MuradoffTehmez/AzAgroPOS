// Fayl: AzAgroPOS.Verilenler/Interfeysler/IXercRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Xərc əməliyyatlarını idarə edən repozitorinin interfeysi
/// diqqət: Bu interfeys xərc qeydiyyatları ilə bağlı əməliyyatlar üçün nəzərdə tutulub.
/// qeyd: Əsas CRUD əməliyyatlarını və xərcə aid xüsusi axtarışlar üçün metodlar təqdim edir.
/// </summary>
public interface IXercRepozitori : IRepozitori<Xerc>
{
    // Xərcə aid xüsusi metodlar burada təyin olunur
    // Hazırda standart CRUD əməliyyatları kifayətdir
}