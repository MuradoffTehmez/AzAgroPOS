// Fayl: AzAgroPOS.Verilenler/Interfeysler/IIstifadeciRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler;
/// <summary>
/// Bütün istifadəçi verilənlər bazası əməliyyatları üçün interfeys.
/// Uzunluğu IRepozitori<Istifadeci> interfeysindən miras alır və istifadəçi ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// </summary>
public interface IIstifadeciRepozitori : IRepozitori<Istifadeci> 
{
    /// <summary>
    /// İstifadəçi adı və şifrə ilə istifadəçini tapır.
    /// </summary>
    /// <param name="istifadeciAdi">İstifadəçi adı.</param>
    /// <param name="sifre">Şifrə.</param>
    /// <returns>Əgər istifadəçi tapılarsa, Istifadeci obyekti; əks halda, null.</returns>
    //Istifadeci? TapIstifadeci(string istifadeciAdi, string sifre);
}