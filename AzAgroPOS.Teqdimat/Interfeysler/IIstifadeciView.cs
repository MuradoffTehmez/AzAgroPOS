// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IIstifadeciView.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat.Interfeysler;

public interface IIstifadeciView
{
    string IstifadeciId { get; set; }
    string IstifadeciAdi { get; set; }
    string TamAd { get; set; }
    string Parol { get; set; }
    int SecilmisRolId { get; }

    void IstifadecileriGoster(List<IstifadeciDto> istifadeciler);
    void RollariGoster(List<Rol> rollar);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    event EventHandler FormYuklendi;
    event EventHandler IstifadeciYarat_Istek;
    event EventHandler IstifadeciYenile_Istek;
    event EventHandler IstifadeciSil_Istek;
    event EventHandler FormuTemizle_Istek;
}