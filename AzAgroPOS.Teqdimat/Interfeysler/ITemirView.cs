// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ITemirView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Mentiq.DTOs;

/// <summary>
///  Temir view interfeysi. 
///  AzAgroPOS.Teqdimat.Interfeysler.ITemirView
/// </summary>
public interface ITemirView
{
    // View-dan məlumat oxumaq
    string MusteriAdi { get; set; }
    string MusteriTelefonu { get; set; }
    string CihazAdi { get; set; }
    string SeriyaNomresi { get; set; }
    string ProblemTesviri { get; set; }
    int? UstaId { get; set; }
    decimal TemirXerci { get; set; }
    decimal ServisHaqqi { get; set; }
    decimal YekunMebleg { get; set; }
    int SecilmisSifarisId { get; }

    // Hadisələr (Events)
    event EventHandler FormYuklendi;
    event EventHandler YeniSifarisYarat_Istek;
    event EventHandler SifarisYenile_Istek;
    event EventHandler SifarisSil_Istek;
    event EventHandler FormuTemizle_Istek;
    event EventHandler EhtiyatHissəsiElaveEt_Istek;
    event EventHandler ÖdənişiTamamla_Istek;

    // View-a məlumat göndərmək
    void SifarisleriGoster(List<TemirDto> sifarisler);
    void UstaSiyahisiniGoster(List<IstifadeciDto> ustalar);
    void MesajGoster(string mesaj, string basliq);
    void FormuTemizle();
}