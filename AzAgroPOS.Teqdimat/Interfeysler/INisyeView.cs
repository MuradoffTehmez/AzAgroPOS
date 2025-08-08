// Fayl: AzAgroPOS.Teqdimat/Interfeysler/INisyeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Mentiq.DTOs;

public interface INisyeView
{
    // View-a data göndərmək
    void MusterileriGoster(List<MusteriDto> musteriler);
    void MusteriHereketleriniGoster(List<NisyeHereketiDto> hereketler);

    // View-dan data oxumaq
    int? SecilmisMusteriId { get; }
    decimal OdenisMeblegi { get; }

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler MusteriSecildi;
    event EventHandler OdenisEdildi;

    void MesajGoster(string mesaj, string basliq);
    void FormuTemizle();
}