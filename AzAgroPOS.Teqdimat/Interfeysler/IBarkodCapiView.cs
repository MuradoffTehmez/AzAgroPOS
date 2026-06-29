// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IBarkodCapiView.cs

using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Interfeysler;

public interface IBarkodCapiView
{
    // View-dan məlumat oxumaq
    string AxtarisMetni { get; }
    List<BarkodEtiketDto> CapSiyahisi { get; }

    // Hadisələr
    event EventHandler AxtarisIstek;
    event EventHandler SiyahiniCapaGonderIstek;

    // View-a məlumat göndərmək
    void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar);
    void CapSiyahisiniYenile(List<BarkodEtiketDto> siyahı);
    void AxtarisXetasiGoster(string mesaj);
    void MesajGoster(string mesaj, string basliq);
}