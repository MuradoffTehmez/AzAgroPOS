// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ITemirView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Mentiq.DTOs;

/// <summary>
///  Temir view interfeysi. 
///  AzAgroPOS.Teqdimat.Interfeysler.ITemirView
/// </summary>
public interface ITemirView
{
    /// <summary>
    /// Sifarişləri göstərmək üçün istifadə olunur.
    /// Dəyişikliklər varsa, bu metod təmir sifarişlərini göstərmək üçün istifadə olunur.
    /// </summary>
    /// <param name="sifarisler"></param>
    void SifarisleriGoster(List<TemirDto> sifarisler);

    // View-dan data oxumaq
    string MusteriAdi { get; }
    string MusteriTelefonu { get; }
    string CihazAdi { get; }
    string ProblemTesviri { get; }
    decimal YekunMebleg { get; }

    /// <summary>
    ///  Form yükləndikdə çağırılan hadisə.
    ///  Dəyişikliklər varsa, form yükləndikdə bütün təmir sifarişlərini yükləyir və göstərir.
    /// </summary>
    event EventHandler FormYuklendi;
    /// <summary>
    /// Yeni təmir sifarişi yaratmaq üçün istifadəçi tərəfindən çağırılan hadisə.
    /// Dəyişikliklər varsa, yeni təmir sifarişi yaratmaq üçün istifadəçi tərəfindən çağırılan hadisə.
    /// </summary>
    event EventHandler YeniSifarisYarat_Istek;

    void FormuTemizle();
    void MesajGoster(string mesaj, string basliq);
}