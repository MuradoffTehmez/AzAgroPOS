// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ITemirView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Mentiq.DTOs;

public interface ITemirView
{
    // View-a data göndərmək
    void SifarisleriGoster(List<TemirDto> sifarisler);

    // View-dan data oxumaq
    string MusteriAdi { get; }
    string MusteriTelefonu { get; }
    string CihazAdi { get; }
    string ProblemTesviri { get; }
    decimal YekunMebleg { get; }

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler YeniSifarisYarat_Istek;

    void FormuTemizle();
    void MesajGoster(string mesaj, string basliq);
}